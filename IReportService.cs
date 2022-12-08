namespace ReportProject
{
    public interface IReportService
    {
        public byte[] GenerateReportAsync(string reportName);
    }
}