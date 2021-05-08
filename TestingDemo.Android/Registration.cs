using FreshMvvm;
using TestingDemo.Android.Services;
using TestingDemo.Services.Interfaces;

namespace TestingDemo.Droid
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
