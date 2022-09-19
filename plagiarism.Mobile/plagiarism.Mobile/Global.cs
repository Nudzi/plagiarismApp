using plagiarismModel;
using System.Collections.Generic;

namespace plagiarism.Mobile
{
    public class Global
    {
        public static Users LoggedUser { get; set; }
        public static UsersPackageTypes UsersPackageType { get; set; }
        public static bool JustRegisterNoPackage { get; set; }
        public static string AccessToken { get; set; }
        public static List<Documents> MatchedDocs { get; set; }
    }
}
