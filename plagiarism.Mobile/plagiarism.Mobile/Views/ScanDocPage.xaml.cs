using plagiarism.Mobile.ViewModels;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Plugin.Permissions;
using Spire.Doc;
using Spire.Pdf;
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
        ScanViewModel model = null;
        public ScanDocPage()
        {
            InitializeComponent();
            BindingContext = model = new ScanViewModel { };
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

        private async void CheckText()
        {
            CheckExtension();
            //ScanFile();
            await model.CheckPlagiarism();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            CheckText();
        }

        private void CheckExtension()
        {
            var file = new FileInfo(fileData.FilePath);

            if (file.Extension.Equals(".doc") || file.Extension.Equals(".docx"))
            {
                CheckDoc();
            }
            if (file.Extension.Equals(".txt"))
            {
                CheckTxt();
            }
            if (file.Extension.Equals(".pdf"))
            {
                CheckPdf();
            }
        }

        private void CheckTxt()
        {
            model.Text = File.ReadAllText(fileData.FilePath);
        }

        private void CheckDoc()
        {
            Document doc = new Document();
            doc.LoadFromFile(fileData.FilePath);
            doc.SaveToTxt("result.text", Encoding.UTF8);
            string[] lines = File.ReadAllLines("result.text", System.Text.Encoding.Default);
            foreach (string line in lines)
            {
                model.Text += "\t" + line;
            }
        }

        private void CheckPdf()
        {
            //Create a Document object
            PdfDocument pdf = new PdfDocument();
            //Load a Word file
            pdf.LoadFromFile(fileData.FilePath);
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "result.doc");

            //Convert the text in Word line by line into a txt file
            pdf.SaveToFile(path);
            //Create a Document object
            Document doc = new Document();
            //Load a Word file
            doc.LoadFromFile(path);
            //Convert the text in Word line by line into a txt file
            doc.SaveToTxt("result.text", Encoding.UTF8);
            //Read all lines of txt file
            string[] lines = File.ReadAllLines("result.text", System.Text.Encoding.Default);
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                model.Text += "\t" + line;
            }
        }

        private async void ScanFile()
        {
            var customId = "scan-for-user-" + Global.LoggedUser.Id;
            var requestUrl = "https://api.copyleaks.com/v3/scans/submit/file/" + customId;
            Helper.GetAccessToken();
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("PUT"), requestUrl))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Global.AccessToken);

                    var data = "{\"base64\":\"SGVsbG8gd29ybGQh\",\"filename\":\"" + fileData.FileName +
                        "\",\"properties\"" +
                        ":{\"webhooks\":{\"status\":\"https://enkbumpblgdi.x.pipedream.net/{STATUS}/" + customId + "\"}}}";
                    request.Content = new StringContent(data, Encoding.UTF8, "application/json");

                    var response = await httpClient.SendAsync(request);
                }
            }
        }
    }
}
