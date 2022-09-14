using plagiarismModel;

namespace plagiarism.Mobile
{
    public class Global
    {
        public static Users LoggedUser { get; set; }
        public static UsersPackageTypes UsersPackageType { get; set; }
        public static bool JustRegisterNoPackage { get; set; }
        public static string OneDriveApiRoot { get; set; } = "https://api.onedrive.com/v1.0/";
    }
}
