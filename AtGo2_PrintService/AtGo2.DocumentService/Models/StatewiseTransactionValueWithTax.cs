// <copyright file="StatewiseTransactionValueWithTax.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

namespace AtGo2.DocumentService.Models
{
    /// <summary>
    /// Container for statewise transaction value.
    /// </summary>
    public class StatewiseTransactionValueWithTax
    {
        /// <summary>
        /// Gets or sets the taxable value.
        /// </summary>
        public double? TaxableValue { get; set; }

        /// <summary>
        /// Gets or sets the IGST.
        /// </summary>
        public double? IGST { get; set; }

        /// <summary>
        /// Gets or sets the CGST.
        /// </summary>
        public double? CGST { get; set; }

        /// <summary>
        /// Gets or sets the SGST.
        /// </summary>
        public double? SGST { get; set; }
    }
}
