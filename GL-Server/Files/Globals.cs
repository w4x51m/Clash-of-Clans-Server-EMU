namespace GL.Servers.CoC.Files
{
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class Globals
    {
        internal static string Json = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Home"/> class.
        /// </summary>
        internal Globals()
        {
            if (Directory.Exists("Gamefiles/"))
            {
                if (File.Exists("Gamefiles/globals.json"))
                {
                    Globals.Json = File.ReadAllText("Gamefiles/globals.json", Encoding.UTF8);
                    Globals.Json = Regex.Replace(Globals.Json, "(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+", "$1");
                }
            }
        }
    }
}