namespace plagiarismModel.Requests.Documents
{
    public class DocumentsReportRequest
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Type { get; set; }
        public string Extension { get; set; }
        public string PackageName { get; set; }
        public int TimeUsed { get; set; }
    }
}
