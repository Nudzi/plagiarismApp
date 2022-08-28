using System.Collections.Generic;

namespace plagiarismModel
{
    public class UserAddresses
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }

        public List<Users> Users { get; set; }
    }
}
