using Foundation;
using TestingDemo.Services.Interfaces;

namespace TestingDemo.iOS.Services
{
    public class NativeSettingsService : INativeSettingsService
    {
        public string GetBuildNumber()
        {
            return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString();
        }

        public string GetVersion()
        {
            return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleVersion").ToString();
        }
    }
}
