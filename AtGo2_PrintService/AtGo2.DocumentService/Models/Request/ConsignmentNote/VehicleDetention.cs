// <copyright file="VehicleDetention.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

namespace AtGo2.DocumentService.Models.Request.ConsignmentNote
{
    /// <summary>Represents vehicle detention details.</summary>
    public class VehicleDetention
    {
        /// <summary>Gets or sets the report type.</summary>
        public string Report { get; set; }

        /// <summary>Gets or sets the date.</summary>
        public DateTime? Date { get; set; }

        /// <summary>Gets or sets the time.</summary>
        public TimeSpan? Time { get; set; }
    }
}
