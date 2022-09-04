namespace plagiarismModel.TableRequests.Documents
{
    public class DocumentsSearchRequest
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Type { get; set; }
        public string Extension { get; set; }
        public string Text { get; set; }
        public int? TimeUsed { get; set; }
        public int? PackageTypeId { get; set; }
    }
}
