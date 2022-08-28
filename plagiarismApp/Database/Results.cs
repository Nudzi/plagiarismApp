using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace plagiarismApp.Database
{
    public partial class Results
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime RunDate { get; set; }
        public decimal Percentage { get; set; }

        public virtual Users User { get; set; }
    }
}
