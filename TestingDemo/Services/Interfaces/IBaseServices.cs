namespace TestingDemo.Services.Interfaces
{
    public interface IBaseServices
    {
        ILogger Logger { get; }

        ISecureStorage SecureStorage { get; }
    }
}
