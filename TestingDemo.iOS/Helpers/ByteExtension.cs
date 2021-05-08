using System;
using System.IO;
using System.Linq;

namespace TestingDemo.iOS.Helpers
{
    public static class ByteExtension
    {
        public static byte[] CleanByteOrderMark(this byte[] bytes)
        {
            var bom = new byte[] { 0xEF, 0xBB, 0xBF };
            if (bytes.Take(3).SequenceEqual(bom))
                return bytes.Skip(3).ToArray();
            return bytes;
        }
    }
}
