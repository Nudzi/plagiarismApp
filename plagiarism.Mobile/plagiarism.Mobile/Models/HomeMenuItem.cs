namespace plagiarism.Mobile.Models
{
    public enum MenuItemType
    {
        Menu,
        Profile,
        AboutUs,
        Logout
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}