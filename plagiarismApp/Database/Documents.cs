using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace plagiarismApp.Database
{
    public partial class Documents
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Type { get; set; }
        public string Extension { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public int? TimeUsed { get; set; }
        public int PackageTypeId { get; set; }
        public byte[] Image { get; set; }
        public byte[] ImageThumb { get; set; }

        public virtual PackageTypes PackageType { get; set; }
    }
}
