using TestingDemo.Services.Interfaces;

namespace TestingDemo.Services
{
    public class BaseServices : IBaseServices
    {
        public BaseServices(ILogger logger, ISecureStorage secureStorage)
        {
            Logger = logger;
            SecureStorage = secureStorage;
        }

        public ILogger Logger { get; }

        public ISecureStorage SecureStorage { get; }
    }
}
