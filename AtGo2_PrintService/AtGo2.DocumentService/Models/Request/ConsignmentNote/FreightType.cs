// <copyright file="FreightType.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

namespace AtGo2.DocumentService.Models.Request.ConsignmentNote
{
    /// <summary>Freight types available.</summary>
    public enum FreightType
    {
        /// <summary>
        /// Paid.
        /// </summary>
        Paid,

        /// <summary>
        /// ToPay.
        /// </summary>
        ToPay,

        /// <summary>
        /// To Be Billed
        /// </summary>
        TBB,
    }
}
