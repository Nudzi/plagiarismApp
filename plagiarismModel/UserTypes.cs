using System.Collections.Generic;

namespace plagiarismModel
{
    public class UserTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<UsersUserTypes> UsersUserTypes { get; set; }
    }
}
