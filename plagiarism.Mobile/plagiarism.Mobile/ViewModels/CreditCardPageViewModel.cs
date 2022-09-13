using plagiarism.Mobile.Services;
using plagiarism.Mobile.Views;
using plagiarismModel;
using plagiarismModel.Enums;
using plagiarismModel.TableRequests.PackageTypes;
using plagiarismModel.TableRequests.UsersPackageTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            expiredDays();
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

        public void expiredDays()
        {
            if (Global.UsersPackageType != null)
            {
                ExpiredDays = (int)(Global.UsersPackageType.ExpiredDate - DateTime.Now).TotalDays;

                if (ExpiredDays < 0)
                {
                    ExpiredDays = 0;
                }
            }
        }

        internal async Task ExtendPackage()
        {
            UsersPackageTypesUpsertRequest usersPackageTypesUpsertRequest = new UsersPackageTypesUpsertRequest
            {
                UserId = Global.LoggedUser.Id,
                IsActive = true,
                PackageTypeId = SelectedPackageTypes.PackageTypeId,
                Discount = Helper.buildPackageDisc(SelectedPackageTypes.Name),
                ExpiredDate = Helper.buildPackageExpDate(SelectedPackageTypes.Name),
                CreatedDate = DateTime.Now
            };

            var usersPackageTypesSearchRequest = new UsersPackageTypesSearchRequest
            {
                UserId = Global.LoggedUser.Id
            };

            // make all of the rest packages unactive
            var usersPackageTypes =
                await _usersPackageTypesService.Get<List<UsersPackageTypes>>(usersPackageTypesSearchRequest);

            // break if Basic is bought again
            var basicPackage = usersPackageTypes.Where(x => x.PackageTypeId == SelectedPackageTypes.PackageTypeId
            && x.PackageTypeId.Equals((int)PackageTypesTypes.Basic)).FirstOrDefault();

            if (basicPackage != null && Global.JustRegisterNoPackage)
            {
                UsersPackageTypesUpsertRequest usersPackageTypesUpdateRequest = new UsersPackageTypesUpsertRequest
                {
                    Id = basicPackage.Id,
                    UserId = Global.LoggedUser.Id,
                    IsActive = true,
                    PackageTypeId = basicPackage.PackageTypeId,
                    Discount = basicPackage.Discount,
                    ExpiredDate = basicPackage.ExpiredDate,
                    CreatedDate = basicPackage.CreatedDate
                };

                await _usersPackageTypesService.Update<UsersPackageTypes>(basicPackage.Id, usersPackageTypesUpdateRequest);
                Global.UsersPackageType = await Helper.FindUsersPackageAsync();
                Global.JustRegisterNoPackage = false;
                Application.Current.MainPage = new MainPage(Global.LoggedUser);
                return;
            }

            if (basicPackage != null)
            {
                await Application.Current.MainPage.DisplayAlert("Error",
                   "You already had Basic package, try purchasing another one.", "OK");
                Application.Current.MainPage = new MainPage(Global.LoggedUser);
            }

            var activePckges = usersPackageTypes.Where(x => x.IsActive);

            foreach (var item in activePckges)
            {
                UsersPackageTypesUpsertRequest usersPackageTypesUpdateRequest = new UsersPackageTypesUpsertRequest
                {
                    Id = item.Id,
                    UserId = Global.LoggedUser.Id,
                    IsActive = false,
                    PackageTypeId = item.PackageTypeId,
                    Discount = item.Discount,
                    ExpiredDate = item.ExpiredDate,
                    CreatedDate = item.CreatedDate
                };

                await _usersPackageTypesService.Update<UsersPackageTypes>(item.Id, usersPackageTypesUpdateRequest);
            }

            Global.UsersPackageType = await _usersPackageTypesService.Insert<UsersPackageTypes>(usersPackageTypesUpsertRequest);
        }
    }
}
