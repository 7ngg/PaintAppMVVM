using System;
using System.IO;
using System.Windows.Ink;

namespace BoardApp.Converters
{
    public class BoardConverter
    {
        public static string ConvertObject(StrokeCollection board)
        {
            using MemoryStream stream = new();
            board.Save(stream);
            return Convert.ToBase64String(stream.ToArray());
        }

        public static StrokeCollection RevertObject(string str)
        {
            if (str == null)
            {
                return new StrokeCollection();
            }

            byte[] strokesBytes = Convert.FromBase64String(str);
            using MemoryStream stream = new(strokesBytes);
            var collection = new StrokeCollection(stream);
            return collection;
        }
    }
}
