using System;

namespace plagiarismModel.TableRequests.Results
{
    public class ResultsUpsertRequest
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime RunDate { get; set; }
        public decimal Percentage { get; set; }
    }
}
