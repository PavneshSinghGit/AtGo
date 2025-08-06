// <copyright file="ConsignmentItem.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

namespace AtGo2.DocumentService.Models.Request.ConsignmentNote
{
    /// <summary>Represents a consignment item.</summary>
    public class ConsignmentItem
    {
        /// <summary>Gets or sets the packages.</summary>
        public string Packages { get; set; }

        /// <summary>Gets or sets the description.</summary>
        public string Description { get; set; }

        /// <summary>Gets or sets the weight.</summary>
        public decimal? Weight { get; set; }

        /// <summary>Gets or sets the Volume.</summary>
        public decimal? Volume { get; set; }

        /// <summary>Gets or sets the Size.</summary>
        public string Size { get; set; }
    }
}
