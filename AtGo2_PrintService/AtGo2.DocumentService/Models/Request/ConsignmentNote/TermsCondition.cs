// <copyright file="TermsCondition.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

namespace AtGo2.DocumentService.Models.Request.ConsignmentNote
{
    /// <summary>
    /// Container for terms condition.
    /// </summary>
    public class TermsCondition
    {
        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        public IEnumerable<string> Details { get; set; }
    }
}
