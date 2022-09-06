namespace plagiarism.Mobile.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new plagiarism.Mobile.App());
        }
    }
}
