namespace GL.Servers.CoC
{
    using System;
    using System.Drawing;
    using System.Reflection;

    using GL.Servers.Core.Consoles;
    using GL.Servers.CoC.Core;
    using GL.Servers.CoC.Packets;

    internal class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        internal static void Main()
        {
            Console.Title = $"[GCS] {Assembly.GetExecutingAssembly().GetName().Name} - Developer - {DateTime.Now.Year} ©";

            Console.SetOut(new Prefixed());
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);

            Servers.Core.Consoles.Colorful.Console.WriteWithGradient(@"
  __  ___   ______    ________    ______     _______  __       __    __  
 |  |/  /  /  __  \  |       /   /  __  \   /  _____||  |     |  |  |  | 
 |  '  /  |  |  |  | `---/  /   |  |  |  | |  |  __  |  |     |  |  |  | 
 |    <   |  |  |  |    /  /    |  |  |  | |  | |_ | |  |     |  |  |  | 
 |  .  \  |  `--'  |   /  /----.|  `--'  | |  |__| | |  `----.|  `--'  | 
 |__|\__\  \______/   /________| \______/   \______| |_______| \______/  
                                                                         
                         V10.134.6.Cyber Daekness
            ", Color.Yellow, Color.Fuchsia, 14);

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("GemsLand's programs are protected by our policies, available on our main website.   ");
            Console.WriteLine("GemsLand's programs are under the 'CC Non-Commercial-NoDerivs 3.0 Unported' license.");
            Console.WriteLine("GemsLand is NOT affiliated to 'Supercell Oy', 'Tencent', or 'Riot Games'.           ");
            Console.WriteLine("GemsLand does NOT own 'Clash of Clans', 'Boom Beach', 'Clash Royale', or 'Hay Day'. ");
            Console.WriteLine("MODED-10.134.6 Stabil csv,Logic,json".);
            Console.WriteLine(Assembly.GetExecutingAssembly().GetName().Name + " is now starting..." + Environment.NewLine);

            Factory.Initialize();
            Resources.Initialize();

            Console.WriteLine();
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine();

            HotKeyManager.Initialize();
        }
    }
}
