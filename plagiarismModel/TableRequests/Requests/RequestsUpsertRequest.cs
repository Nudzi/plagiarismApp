﻿namespace plagiarismModel.TableRequests.Requests
{
    public class RequestsUpsertRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public int UserId { get; set; }
    }
}
