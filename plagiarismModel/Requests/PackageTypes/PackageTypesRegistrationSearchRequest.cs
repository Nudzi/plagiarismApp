namespace plagiarismModel.Requests.PackageTypes
{
    public class PackageTypesRegistrationSearchRequest
    {
        public PackageTypesRegistrationSearchRequest(string name, string price, int packageTypeId)
        {
            NameAndPrice = name + " - " + price + "$";
            Name = name;
            PackageTypeId = packageTypeId;
        }
        public string NameAndPrice { get; set; }
        public string Name { get; set; }
        public int PackageTypeId { get; set; }
    }
}
