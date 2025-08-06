// <copyright file="ConsignmentNoteRequest.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

namespace AtGo2.DocumentService.Models.Request.ConsignmentNote
{
    /// <summary>
    /// Represents a consignment note.
    /// </summary>
    public class ConsignmentNoteRequest
    {
        /// <summary>Gets or sets the company details.</summary>
        public CompanyDetails CompanyDetails { get; set; }

        /// <summary>Gets or sets the bill number.</summary>
        public string ConsignmentNumber { get; set; }

        /// <summary>Gets or sets the date.</summary>
        public DateTime? ConsignmentDate { get; set; }

        /// <summary>Gets or sets the consignor GST.</summary>
        public PartyDetails Consignor { get; set; }

        /// <summary>Gets or sets the consignee GST.</summary>
        public PartyDetails Consignee { get; set; }

        /// <summary>Gets or sets the billing GST.</summary>
        public PartyDetails Billing { get; set; }

        /// <summary>Gets or sets the origin.</summary>
        public string Origin { get; set; }

        /// <summary>Gets or sets the destination.</summary>
        public string Destination { get; set; }

        /// <summary>Gets or sets the vehicle number.</summary>
        public string VehicleNo { get; set; }

        /// <summary>Gets or sets the vehicle type.</summary>
        public string VehicleType { get; set; }

        /// <summary>Gets or sets the invoice details.</summary>
        public IEnumerable<ConsignmentInvoiceDetails> InvoiceDetails { get; set; }

        /// <summary>Gets or sets the E-way bill number.</summary>
        public string EWayBillNo { get; set; }

        /// <summary>Gets or sets the list of consignment items.</summary>
        public IEnumerable<ConsignmentItem> Items { get; set; }

        /// <summary>Gets or sets the transporter ID.</summary>
        public string TransporterId { get; set; }

        /// <summary>Gets or sets the freight type.</summary>
        public FreightType Freight { get; set; }

        /// <summary>Gets or sets the damages.</summary>
        public string Damages { get; set; }

        /// <summary>Gets or sets the HVC.</summary>
        public string HVC { get; set; }

        /// <summary>Gets or sets the list of vehicle detentions.</summary>
        public IEnumerable<VehicleDetention> VehicleDetentions { get; set; }

        /// <summary>Gets or sets a value indicating whether the consignment is insured.</summary>
        public bool IsInsured { get; set; }

        /// <summary>Gets or sets the insurance company.</summary>
        public string InsuranceCompany { get; set; }

        /// <summary>Gets or sets the policy number.</summary>
        public string PolicyNumber { get; set; }

        /// <summary>Gets or sets the policy date.</summary>
        public DateTime? PolicyDate { get; set; }

        /// <summary>Gets or sets the insurance amount.</summary>
        public decimal? InsuranceAmount { get; set; }

        /// <summary>Gets or sets the total invoice amount.</summary>
        public decimal? TotalInvoiceValue { get; set; }

        /// <summary>Gets or sets the list of consignment items.</summary>
        public IEnumerable<string> PrintTypes { get; set; }

        /// <summary>Gets or sets the terms and conditions.</summary>
        public IEnumerable<TermsCondition> TermsConditions { get; set; }
    }
}
