using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace plagiarismApp.Database
{
    public partial class UserTypes
    {
        public UserTypes()
        {
            UsersUserTypes = new HashSet<UsersUserTypes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UsersUserTypes> UsersUserTypes { get; set; }
    }
}
