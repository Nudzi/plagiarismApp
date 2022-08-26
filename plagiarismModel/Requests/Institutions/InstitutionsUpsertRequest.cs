namespace plagiarismModel.Requests.Institutions
{
    public class InstitutionsUpsertRequest
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
    }
}
