namespace plagiarismModel.Requests.UserAddresses
{
    public class UserAddressesSearchRequest
    {
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
    }
}
