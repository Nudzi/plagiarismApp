using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace plagiarismApp.Database
{
    public partial class UsersPackageTypes
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PackageTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public decimal Discount { get; set; }
        public bool IsActive { get; set; }

        public virtual PackageTypes PackageType { get; set; }
        public virtual Users User { get; set; }
    }
}
