using System;

namespace plagiarismModel.TableRequests.UsersUserTypes
{
    public class UsersUserTypesUpsertRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
