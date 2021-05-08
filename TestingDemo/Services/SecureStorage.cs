using System.Threading.Tasks;
using TestingDemo.Services.Interfaces;

namespace TestingDemo.Services
{
    public class SecureStorage : ISecureStorage
    {
        public Task SetSecretSettingsFlag(bool value)
        {
            return Xamarin.Essentials.SecureStorage.SetAsync("SecretSettings", value.ToString());
        }

        public async Task<bool> GetSecretSettingsFlag()
        {
            var value = await Xamarin.Essentials.SecureStorage.GetAsync("SecretSettings");
            return bool.TryParse(value, out bool result) ? result : false;
        }

        public Task SetToken(string value)
        {
            return Xamarin.Essentials.SecureStorage.SetAsync("Token", value);
        }

        public Task<string> GetToken()
        {
            return Xamarin.Essentials.SecureStorage.GetAsync("Token");
        }

        public Task SetRefreshToken(string value)
        {
            return Xamarin.Essentials.SecureStorage.SetAsync("RefreshToken", value);
        }

        public Task<string> GetRefreshToken()
        {
            return Xamarin.Essentials.SecureStorage.GetAsync("RefreshToken");
        }

        public Task<string> GetDataAsync(string appVersion)
        {
            return Xamarin.Essentials.SecureStorage.GetAsync(appVersion);
        }
    }
}
