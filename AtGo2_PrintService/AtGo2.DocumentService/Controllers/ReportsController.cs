// <copyright file="ReportsController.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

using System.Text;
using AtGo2.DocumentService.Models.Request;
using AtGo2.DocumentService.Models.Request.ConsignmentNote;
using AtGo2.DocumentService.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QRCoder;

namespace AtGo2.DocumentService.Controllers
{
    /// <summary>
    /// Controller for report generation.
    /// </summary>
    [Route("api/[controller]")]
    public class ReportsController : Controller
    {
        private readonly IConfiguration _config;
        private readonly string _url;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportsController"/> class.
        /// </summary>
        /// <param name="config">The config.</param>
        public ReportsController(IConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _url = _config.GetValue<string>("ApiUrl") ?? throw new ArgumentNullException("ApiUrl");
        }

        /// <summary>
        /// Generates the report.
        /// </summary>
        /// <param name="reportType">The report invoiceRequest.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [Route("run")]
        [HttpPost]
        public async Task<IActionResult> GetReport(string reportType)
        {
            Request.EnableBuffering();
            using var reader = new StreamReader(Request.Body, Encoding.UTF8, leaveOpen: true);
            var body = await reader.ReadToEndAsync();
            Request.Body.Position = 0;
            ViewBag.ApiUrl = _url;
            switch (reportType.ToLower())
            {
                case "invoice":
                    var invoiceRequest = JsonConvert.DeserializeObject<InvoiceReportRequest>(body);
                    return await Task.Run(() =>
                    {
                        return View("InvoiceReport", invoiceRequest);
                    });
                case "consignmentnote":
                    var consignmentNoteRequest = JsonConvert.DeserializeObject<ConsignmentNoteRequest>(body);
                    return await Task.Run(() =>
                    {
                        ViewBag.QRCodeImage = GenerateQRCodeBase64(consignmentNoteRequest.ConsignmentNumber);
                        return View("ConsignmentNote", consignmentNoteRequest);
                    });
                case "tb5report":
                    return await Task.Run(() =>
                    {
                        var request = JsonConvert.DeserializeObject<TB5ReportRequest>(body);
                        var stream = new TB5ReportGeneratorService().GenerateDocument(request);
                        stream.Seek(0, SeekOrigin.Begin);
                        return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "TB5Report.xlsx");
                    });
                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>An <see cref="IActionResult"/>.</returns>
        [HttpGet("{name}")]
        public IActionResult GetImage([FromRoute]string name)
        {
            // Assuming your images are stored in a directory called "Images" within the wwwroot folder.
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "Images", $"{name}");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var image = System.IO.File.OpenRead(filePath);
            return File(image, "image/png");
        }

        private string GenerateQRCodeBase64(string qrData)
        {
            using var qrGenerator = new QRCodeGenerator();
            using var qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q);

            var qrCode = new QRCoder.BitmapByteQRCode(qrCodeData); // No 'using' here
            var bitmap = qrCode.GetGraphic(20);
            var base64 = Convert.ToBase64String(bitmap);
            return $"data:image/png;base64,{base64}";
        }
    }
}
