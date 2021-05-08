using System;
using System.IO;

namespace TestingDemo.Helpers
{
    public static class WriteOutput
    {
        public static void WriteToFile(string file, string data)
        {
            var result = $"{Environment.NewLine}{data}";

            File.AppendAllText(file, result);
        }

        public static void Reset(string file)
        {
            File.Delete(file);
        }
    }
}
