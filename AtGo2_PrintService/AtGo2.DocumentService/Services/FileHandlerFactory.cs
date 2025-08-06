// <copyright file="FileHandlerFactory.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

using AtGo2.DocumentService.Models;
using AtGo2.DocumentService.Models.Configuration;
using Microsoft.Extensions.Options;

namespace AtGo2.DocumentService.Services
{
    /// <summary>
    /// Implementation for file handler factory.
    /// </summary>
    public class FileHandlerFactory : IFileHandlerFactory
    {
        private readonly DocumentHandlerConfiguration _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileHandlerFactory"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public FileHandlerFactory(IOptions<DocumentHandlerConfiguration> options)
        {
            _config = options.Value ?? throw new ArgumentNullException(nameof(options));
        }

        /// <inheritdoc/>
        public IFileHandler GetFileHandler(FileStorageMode mode, string tenantId)
        {
            var settings = GetConfigurationsByStorageModeAndTenantId(mode, tenantId);
            return mode switch
            {
                FileStorageMode.FileSystem => new FileSystemHandler(settings as FileSystemSettings),
                FileStorageMode.FTP => new FTPHandler(settings as FTPSettings),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private BaseDocumentHandlerConfiguration GetConfigurationsByStorageModeAndTenantId(FileStorageMode mode, string tenantId)
        {
            switch (mode)
            {
                case FileStorageMode.FileSystem:
                    if (!_config.FileSystem.TryGetValue(tenantId, out var fileSystem))
                    {
                        throw new InvalidOperationException($"Configuration not available for tenantId {tenantId} for mode {mode}");
                    }

                    return fileSystem;
                case FileStorageMode.FTP:
                    if (!_config.Ftp.TryGetValue(tenantId, out var ftp))
                    {
                        throw new InvalidOperationException($"Configuration not available for tenantId {tenantId} for mode {mode}");
                    }

                    return ftp;
                default: throw new NotSupportedException($"Storage mode {mode} not supported");
            }
        }
    }
}
