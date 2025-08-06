// <copyright file="TB5ReportRequest.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

namespace AtGo2.DocumentService.Models.Request
{
    /// <summary>
    /// Request for TB5 Report.
    /// </summary>
    public class TB5ReportRequest : ReportRequest
    {
        /// <summary>
        /// Gets or sets the ReportType.
        /// </summary>
        public string ReportType { get; set; }

        /// <summary>
        /// Gets or sets the records.
        /// </summary>
        public IEnumerable<TB5ReportRecord> Records { get; set; }
    }

    /// <summary>
    /// Container for TB5 rpeort records.
    /// </summary>
#pragma warning disable SA1402 // File may only contain a single type
    public class TB5ReportRecord
#pragma warning restore SA1402 // File may only contain a single type
    {
        /// <summary>
        /// Gets or sets the Taxability.
        /// </summary>
        public string Taxability { get; set; }

        /// <summary>
        /// Gets or sets the GSTR1Field.
        /// </summary>
        public string GSTR1Field { get; set; }

        /// <summary>
        /// Gets or sets the ITCEligibility.
        /// </summary>
        public string ITCEligibility { get; set; }

        /// <summary>
        /// Gets or sets the TypeOfCustomer.
        /// </summary>
        public string TypeOfCustomer { get; set; }

        /// <summary>
        /// Gets or sets the NatureOfSupply.
        /// </summary>
        public string NatureOfSupply { get; set; }

        /// <summary>
        /// Gets or sets the SubGroup.
        /// </summary>
        public string SubGroup { get; set; }

        /// <summary>
        /// Gets or sets the VoucherType.
        /// </summary>
        public string VoucherType { get; set; }

        /// <summary>
        /// Gets or sets the TaxRate.
        /// </summary>
        public string TaxRate { get; set; }

        /// <summary>
        /// Gets or sets the TransactionValueWithTaxByStateCodeWithName.
        /// </summary>
        public Dictionary<string, StatewiseTransactionValueWithTax> TransactionValueWithTaxByStateCodeWithName { get; set; }
    }
}
