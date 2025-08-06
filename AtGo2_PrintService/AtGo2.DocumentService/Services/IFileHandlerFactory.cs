// <copyright file="IFileHandlerFactory.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

using AtGo2.DocumentService.Models;

namespace AtGo2.DocumentService.Services
{
    /// <summary>
    /// Interface for file handler factory.
    /// </summary>
    public interface IFileHandlerFactory
    {
        /// <summary>
        /// Gets the file handler based on storage mode.
        /// </summary>
        /// <param name="mode">The mode.</param>
        /// <param name="tenantId">The tenantId.</param>
        /// <returns>The <see cref="IFileHandler"/>.</returns>
        IFileHandler GetFileHandler(FileStorageMode mode, string tenantId);
    }
}
