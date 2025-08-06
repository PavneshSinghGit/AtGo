// <copyright file="IFileHandler.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

using AtGo2.DocumentService.Models.Request.Documents;

namespace AtGo2.DocumentService.Services
{
    /// <summary>
    /// Inteface for file handler.
    /// </summary>
    public interface IFileHandler
    {
        /// <summary>
        /// Saves the file.
        /// </summary>
        /// <param name="uploadRequest">The file upload request.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation. Returns the list of uploaded files path.</returns>
        Task<IEnumerable<string>> SaveFileAsync(DocumentUploadRequest uploadRequest);

        /// <summary>
        /// Gets the file.
        /// </summary>
        /// <param name="downloadRequest">The file download request.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation. Returns the byte array of the request file.</returns>
        Task<byte[]> GetFile(DocumentDowloadRequest downloadRequest);
    }
}
