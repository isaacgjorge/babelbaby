using System.Configuration;

namespace EasyCare.Util
{
    public class Constants
    {
        public static string SqlFilePath = ConfigurationManager.AppSettings["sqlFilePath"];
        public static string jwtSecretKey = ConfigurationManager.AppSettings["jwtSecretKey"];
    }
}
