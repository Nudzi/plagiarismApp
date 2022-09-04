using System;

namespace plagiarismModel.TableRequests.UsersPackageTypes
{
    public class UsersPackageTypesReportRequest
    {
        public string PackageName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public decimal Discount { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
