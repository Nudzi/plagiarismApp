using plagiarism.Mobile.Converters;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace plagiarism.Mobile.ViewModels
{
    public class CreditCardPageViewModel : BaseViewModel
    {
        public CreditCardPageViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        string _cardNumber = string.Empty;
        public ICommand InitCommand { get; set; }
        public string CardNumber
        {
            get { return _cardNumber; }
            set {
                SetProperty(ref _cardNumber, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }
            }
        }

        string _cardCvv = string.Empty;
        public string CardCvv
        {
            get { return _cardCvv; }
            set { SetProperty(ref _cardCvv, value); }
        }

        string _cardExpirationDate = string.Empty;
        public string CardExpirationDate
        {
            get { return _cardExpirationDate; }
            set { SetProperty(ref _cardExpirationDate, value); }
        }

        string _cardName = string.Empty;
        public string CardName
        {
            get { return _cardName; }
            set { SetProperty(ref _cardName, value); }
        }

        public async Task Init()
        {
            var value = CardNumber;
            if (value == null) CardName = "NotRecognized";

            var number = value.ToString();
            var numberNormalized = number.Replace("-", string.Empty);

            if (visaRegex.IsMatch(numberNormalized))  CardName = "Visa";

            if (amexRegex.IsMatch(numberNormalized))  CardName = "Amex";

            if (masterRegex.IsMatch(numberNormalized)) CardName = " MasterCard";

            if (dinnersRegex.IsMatch(numberNormalized)) CardName = " Dinners";

            if (discoverRegex.IsMatch(numberNormalized)) CardName = " Discover";

            if (jcbRegex.IsMatch(numberNormalized)) CardName = " JCB";

            CardName = "NotRecognized";
        }
    }
}
