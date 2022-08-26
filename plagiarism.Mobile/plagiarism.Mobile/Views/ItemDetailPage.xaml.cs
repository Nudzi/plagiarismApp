using plagiarism.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace plagiarism.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}