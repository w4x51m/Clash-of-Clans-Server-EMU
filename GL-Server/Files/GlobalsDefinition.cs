namespace GL.Servers.CoC.Files
{
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class Globals_definition
    {
        internal static string Json = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Home"/> class.
        /// </summary>
        internal Globals_definition()
        {
            if (Directory.Exists("Gamefiles/"))
            {
                if (File.Exists("Gamefiles/globals_definition.json"))
                {
                    Globals_definition.Json = File.ReadAllText("Gamefiles/globals_definition.json", Encoding.UTF8);
                    Globals_definition.Json = Regex.Replace(Globals_definition.Json, "(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+", "$1");
                }
            }
        }
    }
}