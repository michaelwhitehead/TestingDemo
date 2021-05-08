using System;
using System.Collections.Generic;
using TestingDemo.Services.Interfaces;

namespace TestingDemo.Services
{
    public class Logger : ILogger
    {
        public void LogError(Exception exception = null, Dictionary<string, string> properties = null)
        {
            Console.WriteLine(exception.Message, properties);
        }

        public void LogEvent(string name, string detail, Dictionary<string, string> properties = null)
        {
            Console.WriteLine($"{name} : {detail}", properties);
        }

        public void LogEvent(string name, Dictionary<string, string> properties = null)
        {
            Console.WriteLine($"Log: {name}", properties);
        }

        public void LogWarning(string name, Dictionary<string, string> properties = null)
        {
            Console.WriteLine($"Warning! {name}", properties);
        }
    }
}
