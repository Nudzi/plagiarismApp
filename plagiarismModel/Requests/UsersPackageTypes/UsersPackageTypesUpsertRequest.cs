using System;

namespace plagiarismModel.Requests.UsersPackageTypes
{
    public class UsersPackageTypesUpsertRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PackageTypeId { get; set; }
        public DateTime ExpiredDate { get; set; }
        public decimal Discount { get; set; }
        public bool IsActive { get; set; }
    }
}
