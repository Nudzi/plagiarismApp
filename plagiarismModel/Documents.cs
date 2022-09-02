namespace plagiarismModel
{
    public class Documents
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Type { get; set; }
        public string Extension { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public int? TimeUsed { get; set; }
        public int PackageTypeId { get; set; }
        public byte[] Image { get; set; }
        public byte[] ImageThumb { get; set; }

        public PackageTypes PackageType { get; set; }
    }
}
