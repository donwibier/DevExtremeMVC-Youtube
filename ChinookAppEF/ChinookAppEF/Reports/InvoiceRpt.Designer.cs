//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChinookAppEF.Reports {
    
    public partial class InvoiceRpt : DevExpress.XtraReports.UI.XtraReport {
        private void InitializeComponent() {
            DevExpress.XtraReports.ReportInitializer reportInitializer = new DevExpress.XtraReports.ReportInitializer(this, "ChinookAppEF.Reports.InvoiceRpt.repx");

            // Controls
            this.Detail = reportInitializer.GetControl<DevExpress.XtraReports.UI.DetailBand>("Detail");
            this.TopMargin = reportInitializer.GetControl<DevExpress.XtraReports.UI.TopMarginBand>("TopMargin");
            this.BottomMargin = reportInitializer.GetControl<DevExpress.XtraReports.UI.BottomMarginBand>("BottomMargin");
            this.DetailReport = reportInitializer.GetControl<DevExpress.XtraReports.UI.DetailReportBand>("DetailReport");
            this.customerTable = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTable>("customerTable");
            this.vendorLogo = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPictureBox>("vendorLogo");
            this.invoiceInfoTable = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTable>("invoiceInfoTable");
            this.xrTableRow9 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableRow>("xrTableRow9");
            this.customerNameRow = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableRow>("customerNameRow");
            this.customerAddressRow = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableRow>("customerAddressRow");
            this.tableRow1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableRow>("tableRow1");
            this.tableRow2 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableRow>("tableRow2");
            this.billToLabel = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("billToLabel");
            this.customerName = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("customerName");
            this.customerAddress = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("customerAddress");
            this.tableCell1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("tableCell1");
            this.tableCell2 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("tableCell2");
            this.invoiceInfoTableRow1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableRow>("invoiceInfoTableRow1");
            this.invoiceInfoTableRow2 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableRow>("invoiceInfoTableRow2");
            this.invoiceInfoTableRow3 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableRow>("invoiceInfoTableRow3");
            this.xrTableCell2 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("xrTableCell2");
            this.totalCaption2 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("totalCaption2");
            this.invoiceDateCaption = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("invoiceDateCaption");
            this.invoiceNumberCaption = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("invoiceNumberCaption");
            this.total2 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("total2");
            this.invoiceDate = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("invoiceDate");
            this.invoiceNumber = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("invoiceNumber");
            this.thankYouLabel = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("thankYouLabel");
            this.vendorTable = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTable>("vendorTable");
            this.vendorLogo2 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPictureBox>("vendorLogo2");
            this.vendorTableRow1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableRow>("vendorTableRow1");
            this.vendorTableRow2 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableRow>("vendorTableRow2");
            this.vendorName = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("vendorName");
            this.vendorPhone = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("vendorPhone");
            this.vendorEmail = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("vendorEmail");
            this.vendorAddress = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("vendorAddress");
            this.vendorEmptyCell = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("vendorEmptyCell");
            this.vendorWebsite = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("vendorWebsite");
            this.InvoiceItems = reportInitializer.GetControl<DevExpress.XtraReports.UI.DetailBand>("InvoiceItems");
            this.InvoiceItemsHeader = reportInitializer.GetControl<DevExpress.XtraReports.UI.ReportHeaderBand>("InvoiceItemsHeader");
            this.InvoiceItemsFooter = reportInitializer.GetControl<DevExpress.XtraReports.UI.ReportFooterBand>("InvoiceItemsFooter");
            this.detailTable = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTable>("detailTable");
            this.detailTableRow1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableRow>("detailTableRow1");
            this.detailTableRow2 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableRow>("detailTableRow2");
            this.productName = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("productName");
            this.quantity = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("quantity");
            this.unitPrice = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("unitPrice");
            this.lineTotal = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("lineTotal");
            this.productDescription = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("productDescription");
            this.detailTableCell1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("detailTableCell1");
            this.detailTableCell2 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("detailTableCell2");
            this.detailTableCell5 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("detailTableCell5");
            this.headerTable = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTable>("headerTable");
            this.headerTableRow = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableRow>("headerTableRow");
            this.productDesctiptionCaption = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("productDesctiptionCaption");
            this.quantityCaption = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("quantityCaption");
            this.unitPriceCaption = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("unitPriceCaption");
            this.lineTotalCaption = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("lineTotalCaption");
            this.totalTable = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTable>("totalTable");
            this.totalRow = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableRow>("totalRow");
            this.totalCaption = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("totalCaption");
            this.total = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("total");
            this.tableRow3 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableRow>("tableRow3");
            this.tableCell3 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("tableCell3");

            // Parameters
            this.invoiceIds = reportInitializer.GetParameter("invoiceIds");

            // Data Sources
            this.objectDataSource2 = reportInitializer.GetDataSource<DevExpress.DataAccess.ObjectBinding.ObjectDataSource>("objectDataSource2");

            // Styles
            this.simpleTextStyle = reportInitializer.GetStyle("simpleTextStyle");
            this.captionsStyle = reportInitializer.GetStyle("captionsStyle");
            this.baseControlStyle = reportInitializer.GetStyle("baseControlStyle");
            this.evenDetailStyle = reportInitializer.GetStyle("evenDetailStyle");
            this.oddDetailStyle = reportInitializer.GetStyle("oddDetailStyle");
        }
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailReportBand DetailReport;
        private DevExpress.XtraReports.UI.XRTable customerTable;
        private DevExpress.XtraReports.UI.XRPictureBox vendorLogo;
        private DevExpress.XtraReports.UI.XRTable invoiceInfoTable;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow9;
        private DevExpress.XtraReports.UI.XRTableRow customerNameRow;
        private DevExpress.XtraReports.UI.XRTableRow customerAddressRow;
        private DevExpress.XtraReports.UI.XRTableRow tableRow1;
        private DevExpress.XtraReports.UI.XRTableRow tableRow2;
        private DevExpress.XtraReports.UI.XRTableCell billToLabel;
        private DevExpress.XtraReports.UI.XRTableCell customerName;
        private DevExpress.XtraReports.UI.XRTableCell customerAddress;
        private DevExpress.XtraReports.UI.XRTableCell tableCell1;
        private DevExpress.XtraReports.UI.XRTableCell tableCell2;
        private DevExpress.XtraReports.UI.XRTableRow invoiceInfoTableRow1;
        private DevExpress.XtraReports.UI.XRTableRow invoiceInfoTableRow2;
        private DevExpress.XtraReports.UI.XRTableRow invoiceInfoTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell totalCaption2;
        private DevExpress.XtraReports.UI.XRTableCell invoiceDateCaption;
        private DevExpress.XtraReports.UI.XRTableCell invoiceNumberCaption;
        private DevExpress.XtraReports.UI.XRTableCell total2;
        private DevExpress.XtraReports.UI.XRTableCell invoiceDate;
        private DevExpress.XtraReports.UI.XRTableCell invoiceNumber;
        private DevExpress.XtraReports.UI.XRLabel thankYouLabel;
        private DevExpress.XtraReports.UI.XRTable vendorTable;
        private DevExpress.XtraReports.UI.XRPictureBox vendorLogo2;
        private DevExpress.XtraReports.UI.XRTableRow vendorTableRow1;
        private DevExpress.XtraReports.UI.XRTableRow vendorTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell vendorName;
        private DevExpress.XtraReports.UI.XRTableCell vendorPhone;
        private DevExpress.XtraReports.UI.XRTableCell vendorEmail;
        private DevExpress.XtraReports.UI.XRTableCell vendorAddress;
        private DevExpress.XtraReports.UI.XRTableCell vendorEmptyCell;
        private DevExpress.XtraReports.UI.XRTableCell vendorWebsite;
        private DevExpress.XtraReports.UI.DetailBand InvoiceItems;
        private DevExpress.XtraReports.UI.ReportHeaderBand InvoiceItemsHeader;
        private DevExpress.XtraReports.UI.ReportFooterBand InvoiceItemsFooter;
        private DevExpress.XtraReports.UI.XRTable detailTable;
        private DevExpress.XtraReports.UI.XRTableRow detailTableRow1;
        private DevExpress.XtraReports.UI.XRTableRow detailTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell productName;
        private DevExpress.XtraReports.UI.XRTableCell quantity;
        private DevExpress.XtraReports.UI.XRTableCell unitPrice;
        private DevExpress.XtraReports.UI.XRTableCell lineTotal;
        private DevExpress.XtraReports.UI.XRTableCell productDescription;
        private DevExpress.XtraReports.UI.XRTableCell detailTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell detailTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell detailTableCell5;
        private DevExpress.XtraReports.UI.XRTable headerTable;
        private DevExpress.XtraReports.UI.XRTableRow headerTableRow;
        private DevExpress.XtraReports.UI.XRTableCell productDesctiptionCaption;
        private DevExpress.XtraReports.UI.XRTableCell quantityCaption;
        private DevExpress.XtraReports.UI.XRTableCell unitPriceCaption;
        private DevExpress.XtraReports.UI.XRTableCell lineTotalCaption;
        private DevExpress.XtraReports.UI.XRTable totalTable;
        private DevExpress.XtraReports.UI.XRTableRow totalRow;
        private DevExpress.XtraReports.UI.XRTableCell totalCaption;
        private DevExpress.XtraReports.UI.XRTableCell total;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource2;
        private DevExpress.XtraReports.UI.XRControlStyle simpleTextStyle;
        private DevExpress.XtraReports.UI.XRControlStyle captionsStyle;
        private DevExpress.XtraReports.UI.XRControlStyle baseControlStyle;
        private DevExpress.XtraReports.UI.XRControlStyle evenDetailStyle;
        private DevExpress.XtraReports.UI.XRControlStyle oddDetailStyle;
        private DevExpress.XtraReports.Parameters.Parameter invoiceIds;
        private DevExpress.XtraReports.UI.XRTableRow tableRow3;
        private DevExpress.XtraReports.UI.XRTableCell tableCell3;
    }
}
