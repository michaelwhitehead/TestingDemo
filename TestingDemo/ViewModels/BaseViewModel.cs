using System.Threading.Tasks;
using FreshMvvm;
using TestingDemo.Services.Interfaces;

namespace TestingDemo.ViewModels
{
    public class BaseViewModel : FreshBasePageModel
    {
        public BaseViewModel(IBaseServices baseServices)
        {
            Logger = baseServices.Logger;
            SecureStorage = baseServices.SecureStorage;
        }

        public ILogger Logger { get; }

        public ISecureStorage SecureStorage { get; }

        public string Title { get; set; }

        public override void Init(object initData)
        {
            base.Init(initData);
            InitAsync(initData);
        }

        public override void ReverseInit(object returnedData)
        {
            base.ReverseInit(returnedData);
            ReverseInitAsync(returnedData);
        }

        public virtual Task InitAsync(object initData)
        {
            return Task.FromResult(true);
        }

        public virtual Task ReverseInitAsync(object initData)
        {
            return Task.FromResult(true);
        }
    }
}
