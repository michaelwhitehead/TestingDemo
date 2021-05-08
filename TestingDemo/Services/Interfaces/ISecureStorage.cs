using System.Threading.Tasks;

namespace TestingDemo.Services.Interfaces
{
    public interface ISecureStorage
    {
        Task SetSecretSettingsFlag(bool value);

        Task<bool> GetSecretSettingsFlag();

        Task SetToken(string value);

        Task<string> GetToken();

        Task SetRefreshToken(string value);

        Task<string> GetRefreshToken();

        Task<string> GetDataAsync(string appVersion);
    }
}
