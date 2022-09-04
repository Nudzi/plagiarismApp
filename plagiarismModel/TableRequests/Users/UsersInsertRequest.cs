using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace plagiarismModel.TableRequests.Users
{
    public class UsersInsertRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OfficialName { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }
        [Required]
        [MinLength(2)]
        public string UserName { get; set; }
        public bool Status { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string PasswordConfirmation { get; set; }
        public List<int> UserTypes { get; set; } = new List<int>();
        public int? UserAddressId { get; set; }
    }
}
