using Newtonsoft.Json.Linq;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Plugin.Permissions;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace plagiarism.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanDocPage : ContentPage
    {
        private static FileData fileData = null;
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
                    fileData = await CrossFilePicker.Current.PickFile();
                    if (fileData == null)
                        return;

                    //writing the filename to our view
                    //SupportingDocument is the x:name of our label in xaml
                    SupportingDocument.Text = fileData.FileName;
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

        private void CheckText()
        {
            // Example #1
            // Read the file as one string.
            string text = System.IO.File.ReadAllText(fileData.FilePath, Encoding.UTF8);

            System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

            // Example #2
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(fileData.FilePath, Encoding.UTF8);
            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Contents of WriteLines2.txt = ");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
            }

            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            CheckText();
        }
    }
}