// <copyright file="InvoicePrintData.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

namespace AtGo2.DocumentService.Models.Request
{
    /// <summary>
    /// Request model for invoice report.
    /// </summary>
    public class InvoicePrintData : ReportRequest
    {
        /// <summary>
        /// Gets or sets the CompCode.
        /// </summary>
        public string CompCode { get; set; }

        /// <summary>
        /// Gets or sets the invoice type.
        /// </summary>
        public string InvoiceType { get; set; }

        /// <summary>
        /// Gets or sets the invoice number.
        /// </summary>
        public string InvoiceNo { get; set; }

        /// <summary>
        /// Gets or sets the invoice date.
        /// </summary>
        public string InvoiceDate { get; set; }

        /// <summary>
        /// Gets or sets the job no.
        /// </summary>
        public string JobNo { get; set; }

        /// <summary>
        /// Gets or sets the house no.
        /// </summary>
        public string HouseNo { get; set; }

        /// <summary>
        /// Gets or sets the master no.
        /// </summary>
        public string MasterNo { get; set; }

        /// <summary>
        /// Gets or sets the packages.
        /// </summary>
        public string Packages { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        public string Weight { get; set; }

        /// <summary>
        /// Gets or sets the Destination.
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Gets or sets the POS.
        /// </summary>
        public string POS { get; set; }

        /// <summary>
        /// Gets or sets the LOS.
        /// </summary>
        public string LOS { get; set; }

        /// <summary>
        /// Gets or sets the NOS.
        /// </summary>
        public string NOS { get; set; }

        /// <summary>
        /// Gets or sets the RefNo.
        /// </summary>
        public string RefNo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the IRN is set.
        /// </summary>
        public string IRN { get; set; }

        /// <summary>
        /// Gets or sets a InvoiceTagging.
        /// </summary>
        public string InvoiceTagging { get; set; }

        /// <summary>
        /// Gets or sets the EInvoiceType.
        /// </summary>
        public string EInvoiceType { get; set; }

        /// <summary>
        /// Gets or sets the QuoteNo.
        /// </summary>
        public string QuoteNo { get; set; }

        /// <summary>
        /// Gets or sets the Remarks.
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// Gets or sets the Module.
        /// </summary>
        public string Module { get; set; }

        /// <summary>
        /// Gets or sets the EmployeeName.
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the Salesman.
        /// </summary>
        public string Salesman { get; set; }

        /// <summary>
        /// Gets or sets the SubTotal.
        /// </summary>
        public decimal SubTotal { get; set; }

        /// <summary>
        /// Gets or sets the SubModule.
        /// </summary>
        public string SubModule { get; set; }

        /// <summary>
        /// Gets or sets the CGST.
        /// </summary>
        public decimal? CGST { get; set; }

        /// <summary>
        /// Gets or sets the SGST.
        /// </summary>
        public decimal? SGST { get; set; }

        /// <summary>
        /// Gets or sets the IGST.
        /// </summary>
        public decimal? IGST { get; set; }

        /// <summary>
        /// Gets or sets the TotalAmount.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the AmountInWords.
        /// </summary>
        public string AmountInWords { get; set; }

        /// <summary>
        /// Gets or sets the Currency.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the Exrate.
        /// </summary>
        public decimal ExRate { get; set; }

        /// <summary>
        /// Gets or sets the IRNQRCode.
        /// </summary>
        public string IRNQRCode { get; set; }

        /// <summary>
        /// Gets or sets the BottomDescription.
        /// </summary>
        public string BottomDescription { get; set; }

        /// <summary>
        /// Gets or sets the BeneficiaryDetails.
        /// </summary>
        public string BeneficiaryDetails { get; set; }

        /// <summary>
        /// Gets or sets the Billing party.
        /// </summary>
        public BusinessEntity BillTo { get; set; }

        /// <summary>
        /// Gets or sets the Ship to party.
        /// </summary>
        public BusinessEntity ShipTo { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        public BusinessEntity Company { get; set; }

        /// <summary>
        /// Gets or sets the InvoiceItems.
        /// </summary>
        public IEnumerable<InvoiceItem> InvoiceItems { get; set; }

        /// <summary>
        /// Gets or sets the IsCrossCountry.
        /// </summary>
        public string IsCrossCountry { get; set; }

        /// <summary>
        /// Gets or sets the vesselname.
        /// </summary>
        public string Vesselname { get; set; }

        /// <summary>
        /// Gets or sets the voyageno.
        /// </summary>
        public string Voyageno { get; set; }

        /// <summary>
        /// Gets or sets the JobDate.
        /// </summary>
        public string JobDate { get; set; }

        /// <summary>
        /// Gets or sets the JobDate.
        /// </summary>
        public string IRNNo { get; set; }

        /// <summary>
        /// Gets or sets the FlightNo.
        /// </summary>
        public string FlightNo { get; set; }

        /// <summary>
        /// Gets or sets the SAWBNo.
        /// </summary>
        public string SAWBNo { get; set; }

        /// <summary>
        /// Gets or sets the Orign.
        /// </summary>
        public string Orign { get; set; }

        /// <summary>
        /// Gets or sets the ChrgWt.
        /// </summary>
        public string ChrgWt { get; set; }

        /// <summary>
        /// Gets or sets the FlightDate.
        /// </summary>
        public string FlightDate { get; set; }

        /// <summary>
        /// Gets or sets the IgmNo.
        /// </summary>
        public string IgmNo { get; set; }

        /// <summary>
        /// Gets or sets the Marks.
        /// </summary>
        public string Marks { get; set; }

        /// <summary>
        /// Gets or sets the ShprName.
        /// </summary>
        public string ShprName { get; set; }

        /// <summary>
        /// Gets or sets the PC.
        /// </summary>
        public string PC { get; set; }

        /// <summary>
        /// Gets or sets the LF.
        /// </summary>
        public string LF { get; set; }

        /// <summary>
        /// Gets or sets the Measurement.
        /// </summary>
        public string Measurement { get; set; }

        /// <summary>
        /// Gets or sets the Containers.
        /// </summary>
        public string Containers { get; set; }

        /// <summary>
        /// Gets or sets the PLoading.
        /// </summary>
        public string PLoading { get; set; }

        /// <summary>
        /// Gets or sets the Discharge.
        /// </summary>
        public string Discharge { get; set; }

        /// <summary>
        /// Gets or sets the PDelivery.
        /// </summary>
        public string PDelivery { get; set; }

        /// <summary>
        /// Gets or sets the SMTP.
        /// </summary>
        public string SMTP { get; set; }

        /// <summary>
        /// Gets or sets the SMTP.
        /// </summary>
        public string ItemNo { get; set; }

        /// <summary>
        /// Gets or sets the SMTP.
        /// </summary>
        public string ContainerNo { get; set; }

        /// <summary>
        /// Gets or sets the Billing party.
        /// </summary>
        public BusinessEntity Notify { get; set; }

        /// <summary>
        /// Gets or sets the LinerName.
        /// </summary>
        public BusinessEntity LinerName { get; set; }

        /// <summary>
        /// Gets or sets the LinerAddr.
        /// </summary>
        public BusinessEntity LinerAddr { get; set; }

        /// <summary>
        /// Gets or sets the NetWt.
        /// </summary>
        public decimal? NetWt { get; set; }

        /// <summary>
        /// Gets or sets the ShipLineCode.
        /// </summary>
        public string ShipLineCode { get; set; }

        /// <summary>
        /// Gets or sets the Registered.
        /// </summary>
        public string Registered { get; set; }

        /// <summary>
        /// Gets or sets the Sez.
        /// </summary>
        public string Sez { get; set; }

        /// <summary>
        /// Gets or sets the Descr.
        /// </summary>
        public string Descr { get; set; }

        /// <summary>
        /// Gets or sets the Measurement.
        /// </summary>
        public string CBM { get; set; }

        /// <summary>
        /// Gets or sets the PReceipt.
        /// </summary>
        public string PReceipt { get; set; }

        /// <summary>
        /// Gets or sets the ConsigneeName.
        /// </summary>
        public string ConsigneeName { get; set; }

        /// <summary>
        /// Gets or sets the ConsigneeName.
        /// </summary>
        public string BillNo { get; set; }

        /// <summary>
        /// Gets or sets the ConsigneeName.
        /// </summary>
        public string PureAgentBillNo { get; set; }

        /// <summary>
        /// Gets or sets the JobDate.
        /// </summary>
        public string InvDate { get; set; }

        /// <summary>
        /// Gets or sets the TotalAmount.
        /// </summary>
        public decimal TotalAmt { get; set; }

        /// <summary>
        /// Gets or sets the PaidAmt.
        /// </summary>
        public decimal PaidAmt { get; set; }

        /// <summary>
        /// Gets or sets the BalAmt.
        /// </summary>
        public decimal BalAmt { get; set; }

        /// <summary>
        /// Gets or sets the Receipt.
        /// </summary>
        public string Receipt { get; set; }

        /// <summary>
        /// Gets or sets the Advance.
        /// </summary>
        public decimal Advance { get; set; }

        /// <summary>
        /// Gets or sets the LessthenDate.
        /// </summary>
        public decimal LessthenDate { get; set; }

        /// <summary>
        /// Gets or sets the LessThenB/WDate.
        /// </summary>
        public decimal LessThenBWDate { get; set; }

        /// <summary>
        /// Gets or sets the GreterB/wDate.
        /// </summary>
        public decimal GreterBwDate { get; set; }

        /// <summary>
        /// Gets or sets the GreterB/wDate.
        /// </summary>
        public decimal GreterDate { get; set; }

        /// <summary>
        /// Gets or sets the GreterB/wDate.
        /// </summary>
        public decimal Net { get; set; }

        /// <summary>
        /// Gets or sets the Receipt.
        /// </summary>
        public string Outstanding { get; set; }

        /// <summary>
        /// Gets or sets the HouseDate.
        /// </summary>
        public string HouseDate { get; set; }

        /// <summary>
        /// Gets or sets the MasterDate.
        /// </summary>
        public string MasterDate { get; set; }

        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the CanNo.
        /// </summary>
        public string CanNo { get; set; }

        /// <summary>
        /// Gets or sets the Origin Name.
        /// </summary>
        public string OriginName { get; set; }

        /// <summary>
        /// Gets or sets the Destination Name.
        /// </summary>
        public string DestinationName { get; set; }

        /// <summary>
        /// Gets or sets the ConsignmentNumbers.
        /// </summary>
        public string ConsignmentNumbers { get; set; }

        /// <summary>
        /// Gets or sets the VehicleNumbers.
        /// </summary>
        public string VehicleNumbers { get; set; }
    }
}
