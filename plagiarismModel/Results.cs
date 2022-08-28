using System;

namespace plagiarismModel
{
    public class Results
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime RunDate { get; set; }
        public decimal Percentage { get; set; }

        public Users User { get; set; }
    }
}
