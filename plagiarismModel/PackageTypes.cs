using System.Collections.Generic;

namespace plagiarismModel
{
    public class PackageTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        public byte[] ImageThumb { get; set; }

        public List<UsersPackageTypes> UsersPackageTypes { get; set; }
    }
}
