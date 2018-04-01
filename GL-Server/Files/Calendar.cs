namespace GL.Servers.CoC.Files
{
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class Calendar
    {
        internal static string Json = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Home"/> class.
        /// </summary>
        internal Calendar()
        {
            if (Directory.Exists("Gamefiles/offlinedata/"))
            {
                if (File.Exists("Gamefiles/offlinedata/calendar.json"))
                {
                    Calendar.Json = File.ReadAllText("Gamefiles/offlinedata/calendar.json", Encoding.UTF8);
                    Calendar.Json = Regex.Replace(Calendar.Json, "(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+", "$1");
                }
            }
        }
    }
}