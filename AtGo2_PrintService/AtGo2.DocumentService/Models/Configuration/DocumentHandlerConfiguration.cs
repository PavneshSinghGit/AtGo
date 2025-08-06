// <copyright file="DocumentHandlerConfiguration.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

namespace AtGo2.DocumentService.Models.Configuration
{
    /// <summary>
    /// Configuration class for document handler.
    /// </summary>
    public class DocumentHandlerConfiguration
    {
        /// <summary>
        /// Gets or sets the FileSystem configuration.
        /// </summary>
        public Dictionary<string, FileSystemSettings> FileSystem { get; set; }

        /// <summary>
        /// Gets or sets the Ftp configuration.
        /// </summary>
        public Dictionary<string, FTPSettings> Ftp { get; set; }
    }
}
