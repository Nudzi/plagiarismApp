namespace plagiarism.Mobile.Models
{
    public enum MenuItemType
    {
        Menu,
        Profile,
        AboutUs,
        Documents,
        Card,
        Logout
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}