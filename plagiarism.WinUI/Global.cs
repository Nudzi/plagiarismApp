using plagiarismModel;

namespace plagiarism.WinUI
{
    public class Global
    {
        public static plagiarismModel.Users LoggedUser { get; set; }
        public static bool Admin { get; set; }
        public static bool Institution { get; set; }
        public static bool User { get; set; }
        public static bool Employee { get; set; }
        public static bool shouldEditRoles { get; set; }
        public static bool shouldEditProduct { get; set; }

    }
}
