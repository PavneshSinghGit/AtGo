// <copyright file="IDocumentGeneratorService.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;

namespace AtGo2.DocumentService.Services
{
    /// <summary>
    /// Interface for document generator service.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    public interface IDocumentGeneratorService<T>
        where T : class
    {
        /// <summary>
        /// Generates the document.
        /// </summary>
        /// <param name="reportData">The reportData.</param>
        /// <returns><see cref="IActionResult"/>.</returns>
        Stream GenerateDocument(T reportData);
    }
}
