using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace plagiarismApp.Database
{
    public partial class UsersUserTypes
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Users User { get; set; }
        public virtual UserTypes UserType { get; set; }
    }
}
