using System;

namespace plagiarismModel
{
    public class UsersPackageTypes
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PackageTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public decimal Discount { get; set; }
        public bool IsActive { get; set; }

        public PackageTypes PackageType { get; set; }
        public Users User { get; set; }
    }
}
