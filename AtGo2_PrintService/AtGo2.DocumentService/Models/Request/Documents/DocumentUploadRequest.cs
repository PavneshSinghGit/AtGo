// <copyright file="DocumentUploadRequest.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

namespace AtGo2.DocumentService.Models.Request.Documents
{
    /// <summary>
    /// Request model for document upload.
    /// </summary>
    public class DocumentUploadRequest
    {
        /// <summary>
        /// Gets or sets the files.
        /// </summary>
        public List<IFormFile> Files { get; set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        public string Path { get; set; }
    }
}
