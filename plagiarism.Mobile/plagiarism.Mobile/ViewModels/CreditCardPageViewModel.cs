using plagiarism.Mobile.Services;
using plagiarismModel;
using plagiarismModel.TableRequests.PackageTypes;
using plagiarismModel.TableRequests.UsersPackageTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace plagiarism.Mobile.ViewModels
{
    public class CreditCardPageViewModel : BaseViewModel
    {
        public ObservableCollection<PackageTypesRegistrationSearchRequest> PackageTypesList { get; set; }
            = new ObservableCollection<PackageTypesRegistrationSearchRequest>();
        private readonly APIService _packageTypesService = new APIService("packageTypes");
        private readonly APIService _usersPackageTypesService = new APIService("usersPackageTypes");

        public CreditCardPageViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        PackageTypesRegistrationSearchRequest _selectedPackageTypes = null;

        public PackageTypesRegistrationSearchRequest SelectedPackageTypes
        {
            get { return _selectedPackageTypes; }
            set { SetProperty(ref _selectedPackageTypes, value); }
        }

        string _cardNumber = string.Empty;
        public ICommand InitCommand { get; set; }
        public string CardNumber
        {
            get { return _cardNumber; }
            set
            {
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

        string _price = string.Empty;
        public string Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        int _expiredDays = 0;
        public int ExpiredDays
        {
            get { return _expiredDays; }
            set { SetProperty(ref _expiredDays, value); }
        }

        public async Task Init()
        {
            await addPackageTypes();
            await expiredDays();
            var value = CardNumber;
            if (value == null) CardName = "NotRecognized";

            var number = value.ToString();
            var numberNormalized = number.Replace("-", string.Empty);

            if (visaRegex.IsMatch(numberNormalized)) CardName = "Visa";

            if (amexRegex.IsMatch(numberNormalized)) CardName = "Amex";

            if (masterRegex.IsMatch(numberNormalized)) CardName = " MasterCard";

            if (dinnersRegex.IsMatch(numberNormalized)) CardName = " Dinners";

            if (discoverRegex.IsMatch(numberNormalized)) CardName = " Discover";

            if (jcbRegex.IsMatch(numberNormalized)) CardName = " JCB";
        }

        public async Task addPackageTypes()
        {
            if (PackageTypesList.Count == 0)
            {
                var packageTypesListDB = await _packageTypesService.Get<List<PackageTypes>>(null);
                foreach (var item in packageTypesListDB)
                {
                    PackageTypesList.Add(new PackageTypesRegistrationSearchRequest(item.Name, item.Price.ToString(),
                        item.Id));
                }
                SelectedPackageTypes = PackageTypesList[0];
            }
        }

        public async Task expiredDays()
        {
            var usersPackageTypesSearchRequest = new UsersPackageTypesSearchRequest
            {
                UserId = Global.LoggedUser.Id
            };
            var usersPackageTypes = await _usersPackageTypesService.Get<List<UsersPackageTypes>>(usersPackageTypesSearchRequest);

            ExpiredDays = (int)(usersPackageTypes[0].ExpiredDate - DateTime.Now).TotalDays;
        }
    }
}
