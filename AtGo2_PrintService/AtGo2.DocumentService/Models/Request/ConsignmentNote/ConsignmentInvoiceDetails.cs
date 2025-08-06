// <copyright file="ConsignmentInvoiceDetails.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

namespace AtGo2.DocumentService.Models.Request.ConsignmentNote
{
    /// <summary>
    /// Container for invoice details.
    /// </summary>
    public class ConsignmentInvoiceDetails
    {
        /// <summary>Gets or sets the invoice number.</summary>
        public string InvoiceNo { get; set; }

        /// <summary>Gets or sets the invoice date.</summary>
        public DateTime? InvoiceDate { get; set; }

        /// <summary>Gets or sets the invoice value.</summary>
        public decimal? InvoiceValue { get; set; }
    }
}
