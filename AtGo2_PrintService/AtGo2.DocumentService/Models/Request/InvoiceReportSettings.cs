// <copyright file="InvoiceReportSettings.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

namespace AtGo2.DocumentService.Models.Request
{
    /// <summary>
    /// Container for invoice report settings.
    /// </summary>
    public class InvoiceReportSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether logo has to be added or not.
        /// </summary>
        public bool AddLogo { get; set; }

        /// <summary>
        /// Gets or sets the PrintType.
        /// </summary>
        public string PrintType { get; set; }
    }
}
