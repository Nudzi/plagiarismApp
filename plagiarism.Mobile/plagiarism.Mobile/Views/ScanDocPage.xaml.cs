using Plugin.FilePicker;
using Plugin.Permissions;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace plagiarism.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanDocPage : ContentPage
    {
        public ScanDocPage()
        {
            InitializeComponent();
        }

        [Obsolete]
        async Task<bool> RequestStoragePermission()
        {
            //We always have permission on anything lower than marshmallow.
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Storage);
            if (status != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
            {
                Console.WriteLine("Does not have storage permission granted, requesting.");
                var results = await CrossPermissions.Current.RequestPermissionsAsync(Plugin.Permissions.Abstractions.Permission.Storage);
                if (results.ContainsKey(Plugin.Permissions.Abstractions.Permission.Storage) &&
                    results[Plugin.Permissions.Abstractions.Permission.Storage] != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                {
                    Console.WriteLine("Storage permission Denied.");
                    return false;
                }
            }
            return true;
        }

        [Obsolete]
        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var requestAccessGrant = await RequestStoragePermission();

                if (requestAccessGrant)
                {
                    var filedata = await CrossFilePicker.Current.PickFile();
                    if (filedata == null)
                        return;

                    //writing the filename to our view
                    //SupportingDocument is the x:name of our label in xaml
                    SupportingDocument.Text = filedata.FileName;
                }
                else
                {
                    await DisplayAlert("Error Occured", "Failed to attach document. please grant access.", "Ok");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured ", ex);
            }
        }
    }
}