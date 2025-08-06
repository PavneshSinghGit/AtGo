// <copyright file="DocumentsController.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

using AtGo2.DocumentService.Models;
using AtGo2.DocumentService.Models.Request.Documents;
using AtGo2.DocumentService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace AtGo2.DocumentService.Controllers
{
    /// <summary>
    /// Documents controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IFileHandlerFactory _fileHandlerFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentsController"/> class.
        /// </summary>
        /// <param name="fileHandlerFactory">The fileHandlerFactory.</param>
        public DocumentsController(IFileHandlerFactory fileHandlerFactory)
        {
            _fileHandlerFactory = fileHandlerFactory;
        }

        /// <summary>
        /// Endpoint to upload the file.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [Route("Upload")]
        [HttpPost]
        public async Task<IActionResult> UploadFiles([FromForm] DocumentUploadRequest request)
        {
            var tenantId = Request.Headers["X-TENANT-ID"][0];
            if (string.IsNullOrWhiteSpace(tenantId))
            {
                return Forbid("Invalid Tenant Id");
            }

            var storageMode = Request.Headers["X-STORAGE-MODE"][0];
            if (string.IsNullOrWhiteSpace(tenantId) || !Enum.TryParse<FileStorageMode>(storageMode, true, out var fileStorageMode))
            {
                return BadRequest("Invalid Storage Mode");
            }

            if (request.Files == null || request.Files.Count == 0)
            {
                return BadRequest("No files uploaded.");
            }

            var fileHandler = _fileHandlerFactory.GetFileHandler(fileStorageMode, tenantId);
            var uploadedFiles = await fileHandler.SaveFileAsync(request);

            return Ok(new { FilePaths = uploadedFiles });
        }

        /// <summary>
        /// Endpoint to upload the file.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [Route("download")]
        [HttpPost]
        public async Task<IActionResult> DownloadFile([FromBody] DocumentDowloadRequest request)
        {
            var tenantId = Request.Headers["X-TENANT-ID"][0];
            if (string.IsNullOrWhiteSpace(tenantId))
            {
                return Forbid("Invalid Tenant Id");
            }

            var storageMode = Request.Headers["X-STORAGE-MODE"][0];
            if (string.IsNullOrWhiteSpace(tenantId) || !Enum.TryParse<FileStorageMode>(storageMode, true, out var fileStorageMode))
            {
                return BadRequest("Invalid Storage Mode");
            }

            var fileHandler = _fileHandlerFactory.GetFileHandler(fileStorageMode, tenantId);
            var uploadedFiles = new List<string>();

            var file = await fileHandler.GetFile(request);
            if (file == null || file.Length == 0)
            {
                return NotFound();
            }

            string contentType = "application/octet-stream"; // default
            var provider = new FileExtensionContentTypeProvider();
            if (provider.TryGetContentType(request.FileLocation, out string detectedType))
            {
                contentType = detectedType;
            }

            return File(file, contentType, Path.GetFileName(request.FileLocation));
        }
    }
}
