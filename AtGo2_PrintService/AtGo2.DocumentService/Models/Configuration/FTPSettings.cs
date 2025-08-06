// <copyright file="FTPSettings.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

namespace AtGo2.DocumentService.Models.Configuration
{
    /// <summary>
    /// Configuration model for FTP.
    /// </summary>
    public class FTPSettings : BaseDocumentHandlerConfiguration
    {
        /// <summary>
        /// Gets or sets the Host.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the Port.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets the Username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        public string Password { get; set; }
    }
}
