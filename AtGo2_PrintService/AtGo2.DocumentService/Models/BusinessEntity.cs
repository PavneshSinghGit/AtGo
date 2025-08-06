// <copyright file="BusinessEntity.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

namespace AtGo2.DocumentService.Models
{
    /// <summary>
    /// Model for business entity.
    /// </summary>
    public class BusinessEntity
    {
        /// <summary>
        /// Gets or sets the business entity party name.
        /// </summary>
        public string BusinessEntityName { get; set; }

        /// <summary>
        /// Gets or sets the business entity party address.
        /// </summary>
        public string BusinessEntityAddress { get; set; }

        /// <summary>
        /// Gets or sets the business entity party GST number.
        /// </summary>
        public string BusinessEntityGSTNumber { get; set; }

        /// <summary>
        /// Gets or sets the business entity party GST state.
        /// </summary>
        public string BusinessEntityGSTState { get; set; }

        /// <summary>
        /// Gets or sets the LUT number.
        /// </summary>
        public string LUTNumber { get; set; }

        /// <summary>
        /// Gets or sets the LUT Date.
        /// </summary>
        public DateTime LUTDate { get; set; }

        /// <summary>
        /// Gets or sets the MSME number.
        /// </summary>
        public string MSMENumber { get; set; }
    }
}
