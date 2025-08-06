// <copyright file="InvoiceItem.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

namespace AtGo2.DocumentService.Models
{
    /// <summary>
    /// Container for invoice item.
    /// </summary>
    public class InvoiceItem
    {
        /// <summary>
        /// Gets or sets the particulars or charge name.
        /// </summary>
        public string Particulars { get; set; }

        /// <summary>
        /// Gets or sets the SACCode.
        /// </summary>
        public string SACCode { get; set; }

        /// <summary>
        /// Gets or sets the SACCode.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the SACCode.
        /// </summary>
        public string TNT { get; set; }

        /// <summary>
        /// Gets or sets the ChargeType.
        /// </summary>
        public string ChargeType { get; set; }

        /// <summary>
        /// Gets or sets the SACCode.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the Currency.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the CGST.
        /// </summary>
        public decimal? CGST { get; set; }

        /// <summary>
        /// Gets or sets the CGSTPercent.
        /// </summary>
        public string CGSTPercent { get; set; }

        /// <summary>
        /// Gets or sets the SGST.
        /// </summary>
        public decimal? SGST { get; set; }

        /// <summary>
        /// Gets or sets the SGSTPercent.
        /// </summary>
        public string SGSTPercent { get; set; }

        /// <summary>
        /// Gets or sets the IGST.
        /// </summary>
        public decimal? IGST { get; set; }

        /// <summary>
        /// Gets or sets the IGSTPercent.
        /// </summary>
        public string IGSTPercent { get; set; }
    }
}
