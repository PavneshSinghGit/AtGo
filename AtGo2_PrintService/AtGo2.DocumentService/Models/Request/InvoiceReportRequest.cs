// <copyright file="InvoiceReportRequest.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

namespace AtGo2.DocumentService.Models.Request
{
    /// <summary>
    /// Request model for printing invoice details.
    /// </summary>
    public class InvoiceReportRequest : ReportRequest
    {
        /// <summary>
        /// Gets or sets the Settings for the print.
        /// </summary>
        public InvoiceReportSettings Settings { get; set; }

        /// <summary>
        /// Gets or sets the invoices.
        /// </summary>
        public IEnumerable<InvoicePrintData> Invoices { get; set; }
    }
}
