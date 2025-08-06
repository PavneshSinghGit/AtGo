// <copyright file="PartyDetails.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

namespace AtGo2.DocumentService.Models.Request.ConsignmentNote
{
    /// <summary>Represents party details.</summary>
    public class PartyDetails
    {
        /// <summary>Gets or sets the billing GST.</summary>
        public string GST { get; set; }

        /// <summary>Gets or sets the billing name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the billing address.</summary>
        public string Address { get; set; }
    }
}
