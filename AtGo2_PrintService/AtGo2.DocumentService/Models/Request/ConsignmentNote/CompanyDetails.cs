// <copyright file="CompanyDetails.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

namespace AtGo2.DocumentService.Models.Request.ConsignmentNote
{
    /// <summary>
    /// Container for company details.
    /// </summary>
    public class CompanyDetails
    {
        /// <summary>Gets or sets the company code.</summary>
        public string CompanyCode { get; set; }

        /// <summary>Gets or sets the company name.</summary>
        public string CompanyName { get; set; }

        /// <summary>Gets or sets the CIN.</summary>
        public string CIN { get; set; }

        /// <summary>Gets or sets the GSTIN.</summary>
        public string GSTIN { get; set; }

        /// <summary>Gets or sets the SAC code.</summary>
        public string SACCode { get; set; }

        /// <summary>Gets or sets the PAN number.</summary>
        public string PAN { get; set; }

        /// <summary>Gets or sets the registered office address.</summary>
        public string RegisteredOffice { get; set; }

        /// <summary>Gets or sets the email address.</summary>
        public string Email { get; set; }

        /// <summary>Gets or sets the phone number.</summary>
        public string Phone { get; set; }

        /// <summary>Gets or sets the booking office GST.</summary>
        public string BookingOfficeGST { get; set; }

        /// <summary>Gets or sets the booking office address.</summary>
        public string BookingOfficeAddress { get; set; }

        /// <summary>Gets or sets the billing branch.</summary>
        public string BillingBranch { get; set; }

        /// <summary>Gets or sets the terms and conditions.</summary>
        public string TermsAndConditions { get; set; }
    }
}
