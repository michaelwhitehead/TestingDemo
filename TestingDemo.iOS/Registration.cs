using FreshMvvm;
using TestingDemo.iOS.Services;
using TestingDemo.Services.Interfaces;

namespace TestingDemo.iOS
{
    public static class Registration
    {
        public static IFreshIOC Container { get; } = FreshIOC.Container;

        public static void RegisterDependencies()
        {
            Services();
        }

        private static void Services()
        {
            Container.Register<INativeSettingsService, NativeSettingsService>();
        }
    }
}
