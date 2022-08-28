using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace plagiarismApp.Database
{
    public partial class Users
    {
        public Users()
        {
            Results = new HashSet<Results>();
            UserImages = new HashSet<UserImages>();
            UsersPackageTypes = new HashSet<UsersPackageTypes>();
            UsersUserTypes = new HashSet<UsersUserTypes>();
        }

        public int Id { get; set; }
        public int UserAddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OfficialName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool Status { get; set; }

        public virtual UserAddresses UserAddress { get; set; }
        public virtual ICollection<Results> Results { get; set; }
        public virtual ICollection<UserImages> UserImages { get; set; }
        public virtual ICollection<UsersPackageTypes> UsersPackageTypes { get; set; }
        public virtual ICollection<UsersUserTypes> UsersUserTypes { get; set; }
    }
}
