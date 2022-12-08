using Microsoft.Reporting.NETCore;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace ReportProject
{
    public class ReportService : IReportService
    {


        public byte[] GenerateReportAsync(string reportName)
        {
            LocalReport report = new LocalReport();
            var fs = new FileStream("JobReturnTicketReportPrint.rdl", FileMode.Open);
            report.LoadReportDefinition(fs);
            var items = getCustomerData();
            ReportDataSource reportDataSource = new ReportDataSource("TempJobReturnTicketPrintDetails", items);
            //ReportDataSource reportDataSource = new ReportDataSource("Items", items);
            report.DataSources.Add(reportDataSource);
            // report.SetParameters(parameters);
            var result = report.Render("PDF");
            return result;
        }

        private DataTable getCustomerData()
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Employee;") ;
            // slightly altered using just a datatable
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM [dbo].[TempJobReturnTicketPrintDetails]";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            dt.TableName = "TempJobReturnTicketPrintDetails";
            return dt;
        }


        //public byte[] GenerateReportAsync(string reportName)
        //{
        //    LocalReport report = new LocalReport();
        //    var fs = new FileStream("JobReturnTicketReportPrint.rdl", FileMode.Open);
        //    report.LoadReportDefinition(fs);
        //  //  var items = new[] { new ReportItem { Description = "Widget 6000", Price = 104.99m, Qty = 1 }, new ReportItem { Description = "Gizmo MAX", Price = 1.41m, Qty = 25 } };
        //    var parameters = new[] { new ReportParameter("Title", "Invoice 4/2020") };
        //    var items= new[] { new TempJobReturnTicketPrintDetails { Address = "",AFE="",ASPXPage="",Attributes="",BillTo="" } };



        //    ReportDataSource reportDataSource = new ReportDataSource("DataSet1", items);
        //    //ReportDataSource reportDataSource = new ReportDataSource("Items", items);
        //    report.DataSources.Add(reportDataSource);
        //   // report.SetParameters(parameters);
        //    var result = report.Render("PDF");
        //    return result;
        //}

        //public byte[] GenerateReportAsync(string reportName)
        //{
        //    string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("ReportProject.dll", string.Empty);
        //    string rdlcFilePath = "D:\\ReportProject\\ReportToPdf\\ReportToPdf.rdl";// string.Format("{0}ReportToPdf\\{1}.rdl", fileDirPath, reportName);
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        //    Encoding.GetEncoding("windows-1252");
        //    LocalReport report = new LocalReport(rdlcFilePath);
        //    List<UserDto> userList = new List<UserDto>();
        //    userList.Add(new UserDto
        //    {
        //        FirstName = "Alex",
        //        LastName = "Smith",
        //        Email = "alex.smith@gmail.com",
        //        Phone = "2345334432"
        //    });

        //    userList.Add(new UserDto
        //    {
        //        FirstName = "John",
        //        LastName = "Legend",
        //        Email = "john.legend@gmail.com",
        //        Phone = "5633435334"
        //    });

        //    userList.Add(new UserDto
        //    {
        //        FirstName = "Stuart",
        //        LastName = "Jones",
        //        Email = "stuart.jones@gmail.com",
        //        Phone = "3575328535"
        //    });
        //    report.AddDataSource("dsUsers", userList);
        //    var result = report.Execute(GetRenderType("pdf"), 1, parameters);
        //    return result.MainStream;
        //}

        //private RenderType GetRenderType(string reportType)
        //{
        //    var renderType = RenderType.Pdf;
        //    switch (reportType.ToLower())
        //    {
        //        default:
        //        case "pdf":
        //            renderType = RenderType.Pdf;
        //            break;
        //        case "word":
        //            renderType = RenderType.Word;
        //            break;
        //        case "excel":
        //            renderType = RenderType.Excel;
        //            break;
        //    }

        //    return renderType;
        //}
    }
}
