using Newtonsoft.Json.Linq;
using plagiarism.Mobile.Services;
using plagiarismModel;
using plagiarismModel.Enums;
using plagiarismModel.TableRequests.UsersPackageTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace plagiarism.Mobile
{
    public class Helper
    {
        private static APIService _usersPackageTypesService = new APIService("usersPackageTypes");

        private static Random random = new Random();
        public static string Alphabet =
"abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789/=-(*)&^%$#@!";
        public static string GenerateString(int size)
        {
            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = Alphabet[random.Next(Alphabet.Length)];
            }
            return new string(chars);
        }

        public static async void GetAccessToken()
        {
            var requestUrl = "https://id.copyleaks.com/v3/account/login/api";

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), requestUrl))
                {
                    var data = "{\"email\":\"nudzejma.kezo@gmail.com\",\"key\":\"93914651-29c4-4bf5-9278-fc1f9c05e4a2\"}";
                    request.Content = new StringContent(data, Encoding.UTF8, "application/json");

                    var response = await httpClient.SendAsync(request);
                    var jsonString = await response.Content.ReadAsStringAsync();
                    Global.AccessToken = JObject.Parse(jsonString)["access_token"].ToString();
                }
            }
        }

        public static decimal buildPackageDisc(string package)
        {
            if (PackageTypesTypes.Basic.ToString().Equals(package))
            {
                return (decimal)PackageTypesDisc.Basic;
            }
            if (PackageTypesTypes.Silver.ToString().Equals(package))
            {
                return (decimal)PackageTypesDisc.Silver;
            }
            else
            {
                return (decimal)PackageTypesDisc.Premium;
            }
        }

        public static DateTime buildPackageExpDate(string package)
        {
            if (PackageTypesExpDate.Basic.ToString().Equals(package))
                return DateTime.Now.AddMonths((int)(PackageTypesExpDate.Basic));
            if (PackageTypesExpDate.Silver.ToString().Equals(package))
                return DateTime.Now.AddMonths((int)(PackageTypesExpDate.Silver));
            else return DateTime.Now.AddMonths((int)(PackageTypesExpDate.Premium));
        }

        public static async Task<UsersPackageTypes> FindUsersPackageAsync()
        {
            var usersPackageTypesSearchRequest = new UsersPackageTypesSearchRequest
            {
                UserId = Global.LoggedUser.Id
            };
            var usersPackageTypes =
                await _usersPackageTypesService.Get<List<UsersPackageTypes>>(usersPackageTypesSearchRequest);

            return usersPackageTypes.Where(x => x.IsActive).FirstOrDefault();
        }

        public static void BuildCustomId()
        {
            Global.CustomId = "scan-for-user-" + Global.LoggedUser.Id;
            Global.ExportId = "export-for-user-" + Global.LoggedUser.Id;
        }
    }
}
