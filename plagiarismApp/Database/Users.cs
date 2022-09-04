using System.Collections.Generic;

namespace plagiarismApp.Database
{
    public partial class Users
    {
        public Users()
        {
            Requests = new HashSet<Requests>();
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
        public virtual ICollection<Requests> Requests { get; set; }
        public virtual ICollection<Results> Results { get; set; }
        public virtual ICollection<UserImages> UserImages { get; set; }
        public virtual ICollection<UsersPackageTypes> UsersPackageTypes { get; set; }
        public virtual ICollection<UsersUserTypes> UsersUserTypes { get; set; }
    }
}
