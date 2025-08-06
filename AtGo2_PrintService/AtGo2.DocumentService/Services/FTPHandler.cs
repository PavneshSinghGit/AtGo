// <copyright file="FTPHandler.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

using System.Net;
using AtGo2.DocumentService.Models.Configuration;
using AtGo2.DocumentService.Models.Request.Documents;

namespace AtGo2.DocumentService.Services
{
    /// <summary>
    /// Implementation for FTP handler.
    /// </summary>
    public class FTPHandler : IFileHandler
    {
        private readonly FTPSettings _ftpSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="FTPHandler"/> class.
        /// </summary>
        /// <param name="ftpSettings">The ftpSettings.</param>
        public FTPHandler(FTPSettings ftpSettings)
        {
            _ftpSettings = ftpSettings;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<string>> SaveFileAsync(DocumentUploadRequest request)
        {
            string ftpPath = $"{_ftpSettings.RootDirectory}/{request.Path ?? string.Empty}";
            string currentPath = ftpPath.TrimEnd('/').Replace("//", "/");
            string remoteDirectory = string.Empty;
            bool directoryExists;
            string[] directories = currentPath.Split('/');
            foreach (string directory in directories)
            {
                remoteDirectory = remoteDirectory + "/" + directory;

                // Create FTP directory if it doesn't exist
                directoryExists = await CheckDirectoryExists(remoteDirectory);
                if (!directoryExists)
                {
                    await CreateDirectory(remoteDirectory);
                }
            }

            var uploadedFilePaths = new List<string>();
            foreach (var file in request.Files)
            {
                var filePath = await UploadFileAsync(ftpPath, file);
                uploadedFilePaths.Add(filePath);
            }

            return uploadedFilePaths;
        }

        /// <inheritdoc/>
        public async Task<byte[]> GetFile(DocumentDowloadRequest request)
        {
            try
            {
                // Create the FTP ftpRequest for downloading the file
                var ftpRequest = (FtpWebRequest)WebRequest.Create(new Uri($"{request.FileLocation}"));
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                ftpRequest.Credentials = new NetworkCredential(_ftpSettings.Username, _ftpSettings.Password);
                ftpRequest.UsePassive = true;

                using (var response = (FtpWebResponse)await ftpRequest.GetResponseAsync())
                using (var responseStream = response.GetResponseStream())
                using (var memoryStream = new MemoryStream())
                {
                    // Copy the file content from FTP to memory stream
                    await responseStream.CopyToAsync(memoryStream);

                    Console.WriteLine($"File downloaded: {Path.GetFileName(request.FileLocation)}");
                    Console.WriteLine($"Status: {response.StatusDescription}");

                    return memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading file: {ex.Message}");
                return null; // or throw the exception if you prefer
            }
        }

        private async Task<string> UploadFileAsync(string remoteDirectory, IFormFile file)
        {
            try
            {
                // Create the FTP ftpRequest for uploading the file
                var request = (FtpWebRequest)WebRequest.Create(new Uri($"{_ftpSettings.Host}/{remoteDirectory}/{file.FileName}"));
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(_ftpSettings.Username, _ftpSettings.Password);
                request.UsePassive = true;
                using (var requestStream = await request.GetRequestStreamAsync())
                using (var memoryStream = new MemoryStream())
                {
                    // Copy the file content into the memory stream
                    await file.CopyToAsync(memoryStream);
                    memoryStream.Position = 0;  // Reset stream position before uploading

                    // Upload the file data
                    await memoryStream.CopyToAsync(requestStream);
                    Console.WriteLine($"File uploaded: {remoteDirectory}/{file.FileName}");
                }

                return request.RequestUri.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading file: {ex.Message}");
                return ex.Message;
            }
        }

        private async Task<bool> CheckDirectoryExists(string remoteDirectory)
        {
            try
            {
                string checkDirUrl = $"{_ftpSettings.Host}/{remoteDirectory}";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(checkDirUrl);
                request.Method = WebRequestMethods.Ftp.ListDirectory;

                request.Credentials = new NetworkCredential(_ftpSettings.Username, _ftpSettings.Password);
                using (var response = (FtpWebResponse)await request.GetResponseAsync())
                {
                    // If we get a valid response, the directory exists
                    return true;
                }
            }
            catch (WebException)
            {
                // Directory does not exist
                return false;
            }
        }

        private async Task CreateDirectory(string remoteDirectory)
        {
            try
            {
                string createDirUrl = $"{_ftpSettings.Host}/{remoteDirectory}";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(createDirUrl);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;

                request.Credentials = new NetworkCredential(_ftpSettings.Username, _ftpSettings.Password);
                using (var response = (FtpWebResponse)await request.GetResponseAsync())
                {
                    // Directory created
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating directory: {ex.Message}");
            }
        }
    }
}
