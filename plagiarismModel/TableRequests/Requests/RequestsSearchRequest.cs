namespace plagiarismModel.TableRequests.Requests
{
    public class RequestsSearchRequest
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int? UserId { get; set; }
    }
}
