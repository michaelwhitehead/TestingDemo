using TestingDemo.Services.Interfaces;

namespace TestingDemo.Services
{
    public class Preferences : IPreferences
    {
        public void Clear()
        {
            Xamarin.Essentials.Preferences.Clear();
        }

        public bool ContainsKey(string key)
        {
            return Xamarin.Essentials.Preferences.ContainsKey(key);
        }

        public string Get(string key, string defaultValue)
        {
            return Xamarin.Essentials.Preferences.Get(key, defaultValue);
        }

        public void Remove(string key)
        {
            Xamarin.Essentials.Preferences.Remove(key);
        }

        public void Set(string key, string value)
        {
            Xamarin.Essentials.Preferences.Set(key, value);
        }
    }
}
