using System;

namespace plagiarismModel
{
    public class Results
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? InstitutionId { get; set; }
        public DateTime RunDate { get; set; }
        public decimal Percentage { get; set; }

        public Institutions Institution { get; set; }
        public Users User { get; set; }
    }
}
