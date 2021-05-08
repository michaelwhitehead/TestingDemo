namespace TestingDemo.Services.Interfaces
{
    public interface IPreferences
    {
        void Clear();

        bool ContainsKey(string key);

        string Get(string key, string defaultValue);

        void Remove(string key);

        void Set(string key, string value);
    }
}
