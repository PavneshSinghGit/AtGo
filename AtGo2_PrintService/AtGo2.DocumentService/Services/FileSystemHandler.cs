// <copyright file="FileSystemHandler.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

using AtGo2.DocumentService.Models.Configuration;
using AtGo2.DocumentService.Models.Request.Documents;

namespace AtGo2.DocumentService.Services
{
    /// <summary>
    /// Handler for file system.
    /// </summary>
    public class FileSystemHandler : IFileHandler
    {
        private readonly FileSystemSettings _fileSystemSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemHandler"/> class.
        /// </summary>
        /// <param name="fileSystemSettings">The fileSystemSettings.</param>
        public FileSystemHandler(FileSystemSettings fileSystemSettings)
        {
            _fileSystemSettings = fileSystemSettings;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<string>> SaveFileAsync(DocumentUploadRequest uploadRequest)
        {
            var uploadedFilesPath = new List<string>();
            foreach (var file in uploadRequest.Files)
            {
                var filePath = Path.Combine(_fileSystemSettings.RootDirectory, uploadRequest.Path, file.FileName);
                var fileDirectory = Path.Combine(_fileSystemSettings.RootDirectory, uploadRequest.Path);
                if (!Directory.Exists(fileDirectory))
                {
                    Directory.CreateDirectory(fileDirectory);
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                uploadedFilesPath.Add(filePath);
            }

            return uploadedFilesPath;
        }

        /// <inheritdoc/>
        public async Task<byte[]> GetFile(DocumentDowloadRequest request)
        {
            if (!File.Exists(request.FileLocation))
            {
                throw new FileNotFoundException($"File {Path.GetFileName(request.FileLocation)} at the location {request.FileLocation}");
            }

            return await File.ReadAllBytesAsync(request.FileLocation);
        }
    }
}
