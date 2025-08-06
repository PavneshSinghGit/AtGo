// <copyright file="TB5ReportGeneratorService.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

using System.Drawing;
using AtGo2.DocumentService.Models;
using AtGo2.DocumentService.Models.Request;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace AtGo2.DocumentService.Services
{
    /// <summary>
    /// Document generator service for TB5 Report.
    /// </summary>
    public class TB5ReportGeneratorService : IDocumentGeneratorService<TB5ReportRequest>
    {
        /// <inheritdoc/>
        public Stream GenerateDocument(TB5ReportRequest reportData)
        {
            // Ensure EPPlus license context is set
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("TB5Report");
                var isDirectIncomeReport = reportData.ReportType == "DirectIncome";
                var gstrItcEligibilityFieldColName = isDirectIncomeReport ? "GSTR-1 field" : "ITC Eligibility";
                var cellRange = isDirectIncomeReport ? "A1:S2" : "A1:R2";
                var groupHeadFieldColName = isDirectIncomeReport ? "Income Group Head" : "Expense Group Head";

                worksheet.Cells[1, 1].Value = "Taxability";
                worksheet.Cells[1, 1, 2, 1].Merge = true;
                worksheet.Cells[1, 1, 2, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 2].Value = gstrItcEligibilityFieldColName;
                worksheet.Cells[1, 2, 2, 2].Merge = true;
                worksheet.Cells[1, 2, 2, 2].Style.Font.Bold = true;
                worksheet.Cells[1, 3].Value = "Type of Customer";
                worksheet.Cells[1, 3, 2, 3].Merge = true;
                worksheet.Cells[1, 3, 2, 3].Style.Font.Bold = true;
                worksheet.Cells[1, 4].Value = "Nature of supply";
                worksheet.Cells[1, 4, 2, 4].Merge = true;
                worksheet.Cells[1, 4, 2, 4].Style.Font.Bold = true;
                worksheet.Cells[1, 5].Value = groupHeadFieldColName;
                worksheet.Cells[1, 5, 2, 5].Merge = true;
                worksheet.Cells[1, 5, 2, 5].Style.Font.Bold = true;
                worksheet.Cells[1, 6].Value = "Voucher Type";
                worksheet.Cells[1, 6, 2, 6].Merge = true;
                worksheet.Cells[1, 6, 2, 6].Style.Font.Bold = true;

                int currentColumn = 7;
                if (isDirectIncomeReport)
                {
                    worksheet.Cells[1, 7].Value = "Tax Rate";
                    worksheet.Cells[1, 7, 2, 7].Merge = true;
                    worksheet.Cells[1, 7, 2, 7].Style.Font.Bold = true;
                    currentColumn++;
                }

                var colIndexByStateCode = new Dictionary<string, (int taxableValue, int igstValue, int cgstValue, int sgstValue)>();
                var stateCodeWithNames = new HashSet<string>();
                foreach (var item in reportData.Records)
                {
                    foreach (var record in item.TransactionValueWithTaxByStateCodeWithName)
                    {
                        stateCodeWithNames.Add(record.Key);
                    }
                }

                foreach (var record in stateCodeWithNames)
                {
                    worksheet.Cells[1, currentColumn, 1, currentColumn + 3].Value = record;
                    worksheet.Cells[1, currentColumn, 1, currentColumn + 3].Merge = true;
                    worksheet.Cells[1, currentColumn, 1, currentColumn + 3].Style.Font.Bold = true;
                    worksheet.Cells[1, currentColumn, 1, currentColumn + 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[1, currentColumn, 1, currentColumn + 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[1, currentColumn, 1, currentColumn + 3].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

                    // Create Child Column Headers
                    worksheet.Cells[2, currentColumn].Value = "Taxable Value";
                    worksheet.Cells[2, currentColumn].AutoFitColumns();
                    worksheet.Cells[2, currentColumn].Style.Font.Bold = true;
                    worksheet.Cells[2, currentColumn].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[2, currentColumn].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                    worksheet.Cells[2, currentColumn + 1].Value = "IGST";
                    worksheet.Cells[2, currentColumn + 1].Style.Font.Bold = true;
                    worksheet.Cells[2, currentColumn + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[2, currentColumn + 1].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                    worksheet.Cells[2, currentColumn + 2].Value = "CGST";
                    worksheet.Cells[2, currentColumn + 2].Style.Font.Bold = true;
                    worksheet.Cells[2, currentColumn + 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[2, currentColumn + 2].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                    worksheet.Cells[2, currentColumn + 3].Value = "SGST";
                    worksheet.Cells[2, currentColumn + 3].Style.Font.Bold = true;
                    worksheet.Cells[2, currentColumn + 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[2, currentColumn + 3].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

                    colIndexByStateCode.Add(record, (currentColumn, currentColumn + 1, currentColumn + 2, currentColumn + 3));

                    currentColumn = currentColumn + 4;
                }

                int rowCounter = 3;
                foreach (var records in reportData.Records)
                {
                    worksheet.Cells[rowCounter, 1].Value = records.Taxability;
                    worksheet.Cells[rowCounter, 2].Value = isDirectIncomeReport ? records.GSTR1Field : records.ITCEligibility;
                    worksheet.Cells[rowCounter, 3].Value = records.TypeOfCustomer;
                    worksheet.Cells[rowCounter, 4].Value = records.NatureOfSupply;
                    worksheet.Cells[rowCounter, 5].Value = records.SubGroup;
                    worksheet.Cells[rowCounter, 6].Value = records.VoucherType;

                    if (isDirectIncomeReport)
                    {
                        worksheet.Cells[rowCounter, 7].Value = records.TaxRate;
                    }

                    foreach ((string stateCodeWithName, StatewiseTransactionValueWithTax transaction) in records.TransactionValueWithTaxByStateCodeWithName)
                    {
                        (int taxableValue, int igstValue, int cgstValue, int sgstValue) = colIndexByStateCode[stateCodeWithName];
                        worksheet.Cells[rowCounter, taxableValue].Value = transaction.TaxableValue;
                        worksheet.Cells[rowCounter, igstValue].Value = transaction.IGST;
                        worksheet.Cells[rowCounter, cgstValue].Value = transaction.CGST;
                        worksheet.Cells[rowCounter, sgstValue].Value = transaction.SGST;
                    }

                    rowCounter++;
                }

                worksheet.Column(1).Width = 12;
                worksheet.Column(2).Width = 14;
                worksheet.Column(3).Width = 16;
                worksheet.Column(4).Width = 16;
                worksheet.Column(5).Width = 42;
                worksheet.Column(6).Width = 12;
                worksheet.Column(7).Width = 10;

                worksheet.Cells[worksheet.Dimension.Address].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // Get the range of all cells used in the worksheet
                var cells = worksheet.Cells[worksheet.Dimension.Address];

                // Apply thin borders to all cells
                cells.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                cells.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                cells.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                cells.Style.Border.Right.Style = ExcelBorderStyle.Thin;

                // Apply a background color to a range of cells
                worksheet.Cells[cellRange].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[cellRange].Style.Fill.BackgroundColor.SetColor(Color.LightBlue); // Set color to LightBlue

                // Save the file
                // Save the package to a MemoryStream
                var stream = new MemoryStream();
                package.SaveAs(stream);
                return stream;
            }
        }
    }
}
