using System;
using System.Threading.Tasks;
using TestingDemo.Services.Interfaces;

namespace TestingDemo.Demo_3
{
    public class ComplexDataService
    {
        private readonly ILogger _logger;
        private readonly ISecureStorage _secureStorage;
        private readonly INativeSettingsService _nativeSettingsService;
        private readonly IPreferences _preferences;

        public ComplexDataService(
            ILogger logger,
            ISecureStorage secureStorage,
            INativeSettingsService nativeSettingsService,
            IPreferences preferences)
        {
            _logger = logger;
            _secureStorage = secureStorage;
            _nativeSettingsService = nativeSettingsService;
            _preferences = preferences;
        }

        public Task<string> GetDataAsync()
        {
            try
            {
                var appVersion = _nativeSettingsService.GetVersion();

                return _secureStorage.GetDataAsync(appVersion);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }

            return Task.FromResult(string.Empty);
        }
    }
}
