using System.Collections.Generic;

namespace plagiarismModel
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OfficialName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string UserName { get; set; }
        public bool? Status { get; set; }
        public int? UserAddressId { get; set; }

        public UserAddresses UserAddress { get; set; }
        
        public List<UsersUserTypes> UserTypes { get; set; }
        public List<Results> Results { get; set; }
        public List<UserImages> UserImages { get; set; }
        public List<UsersPackageTypes> UsersPackageTypes { get; set; }
        public List<UsersUserTypes> UsersUserTypes { get; set; }
    }
}
