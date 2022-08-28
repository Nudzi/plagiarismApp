using plagiarism.Mobile.Services;
using plagiarismModel;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace plagiarism.Mobile.ViewModels
{
    public class FeedbackViewModel : BaseViewModel
    {
        private readonly APIService _feedbacksService = new APIService("feedbacks");
        public byte[] byteImage { get; set; }
        public FeedbackViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
        }
        public async Task SendFeedback(string feedbacks, string reason, string userNumber)
        {
            int telephone;
            bool success = int.TryParse(userNumber, out telephone);
            try
            {
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
