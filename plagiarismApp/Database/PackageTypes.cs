using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace plagiarismApp.Database
{
    public partial class PackageTypes
    {
        public PackageTypes()
        {
            Documents = new HashSet<Documents>();
            UsersPackageTypes = new HashSet<UsersPackageTypes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        public byte[] ImageThumb { get; set; }

        public virtual ICollection<Documents> Documents { get; set; }
        public virtual ICollection<UsersPackageTypes> UsersPackageTypes { get; set; }
    }
}
