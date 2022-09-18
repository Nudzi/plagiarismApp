using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using plagiarism.Mobile.ViewModels;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Plugin.Permissions;
using Spire.Doc;
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
            if (SearchOnline.IsChecked)
            {
                ScanFile();
            }
            else
            {
                CheckExtension();
                await model.CheckPlagiarism();
            }
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
            PdfReader reader = new PdfReader(fileData.FilePath);
            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                model.Text += PdfTextExtractor.GetTextFromPage(reader, page);
            }
            reader.Close();
        }

        private async void ScanFile()
        {
            await Application.Current.MainPage.DisplayAlert("Success", "Online", "OK");

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
