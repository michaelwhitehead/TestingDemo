using FreshMvvm;
using TestingDemo.Demo_4.Api;
using TestingDemo.Demo_4.ViewModels;
using TestingDemo.Services;
using TestingDemo.Services.Interfaces;

namespace TestingDemo
{
    public static partial class Registration
    {
        public static IFreshIOC Container { get; } = FreshIOC.Container;

        public static void RegisterDependencies()
        {
            PageMapper();
            Services();
        }

        private static void PageMapper()
        {
            FreshPageModelResolver.PageModelMapper = new CustomPageMapper();
        }

        private static void Services()
        {
            Container.Register<ILogger, Logger>();
            Container.Register<ISecureStorage, SecureStorage>();
            Container.Register<IPreferences, Preferences>();
            Container.Register<IBaseServices, BaseServices>();
            Container.Register<IGithubApiService, GithubApiService>();
        }
    }
}
