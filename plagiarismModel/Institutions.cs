using System.Collections.Generic;

namespace plagiarismModel
{
    public class Institutions
    {
        public int Id { get; set; }
        public int UserAddressId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool Status { get; set; }

        public UserAddresses UserAddress { get; set; }
        public List<Results> Results { get; set; }
    }
}
