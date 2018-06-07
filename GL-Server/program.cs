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
 
                                                                                                                         
                                                                                                                         
KKKKKKKKK    KKKKKKK     OOOOOOOOO     ZZZZZZZZZZZZZZZZZZZ     OOOOOOOOO     LLLLLLLLLLL            UUUUUUUU     UUUUUUUU
K:::::::K    K:::::K   OO:::::::::OO   Z:::::::::::::::::Z   OO:::::::::OO   L:::::::::L            U::::::U     U::::::U
K:::::::K    K:::::K OO:::::::::::::OO Z:::::::::::::::::Z OO:::::::::::::OO L:::::::::L            U::::::U     U::::::U
K:::::::K   K::::::KO:::::::OOO:::::::OZ:::ZZZZZZZZ:::::Z O:::::::OOO:::::::OLL:::::::LL            UU:::::U     U:::::UU
KK::::::K  K:::::KKKO::::::O   O::::::OZZZZZ     Z:::::Z  O::::::O   O::::::O  L:::::L               U:::::U     U:::::U 
  K:::::K K:::::K   O:::::O     O:::::O        Z:::::Z    O:::::O     O:::::O  L:::::L               U:::::D     D:::::U 
  K::::::K:::::K    O:::::O     O:::::O       Z:::::Z     O:::::O     O:::::O  L:::::L               U:::::D     D:::::U 
  K:::::::::::K     O:::::O     O:::::O      Z:::::Z      O:::::O     O:::::O  L:::::L               U:::::D     D:::::U 
  K:::::::::::K     O:::::O     O:::::O     Z:::::Z       O:::::O     O:::::O  L:::::L               U:::::D     D:::::U 
  K::::::K:::::K    O:::::O     O:::::O    Z:::::Z        O:::::O     O:::::O  L:::::L               U:::::D     D:::::U 
  K:::::K K:::::K   O:::::O     O:::::O   Z:::::Z         O:::::O     O:::::O  L:::::L               U:::::D     D:::::U 
KK::::::K  K:::::KKKO::::::O   O::::::OZZZ:::::Z     ZZZZZO::::::O   O::::::O  L:::::L         LLLLLLU::::::U   U::::::U 
K:::::::K   K::::::KO:::::::OOO:::::::OZ::::::ZZZZZZZZ:::ZO:::::::OOO:::::::OLL:::::::LLLLLLLLL:::::LU:::::::UUU:::::::U 
K:::::::K    K:::::K OO:::::::::::::OO Z:::::::::::::::::Z OO:::::::::::::OO L::::::::::::::::::::::L UU:::::::::::::UU  
K:::::::K    K:::::K   OO:::::::::OO   Z:::::::::::::::::Z   OO:::::::::OO   L::::::::::::::::::::::L   UU:::::::::UU    
KKKKKKKKK    KKKKKKK     OOOOOOOOO     ZZZZZZZZZZZZZZZZZZZ     OOOOOOOOO     LLLLLLLLLLLLLLLLLLLLLLLL     UUUUUUUUU      
                                                                                                                         
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
                         V10.134.6.Cyber Daekness
            ", Color.Green, Color.Fuchsia, 14);

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("GemsLand program is under the 'Proprietary' license.");
            Console.WriteLine("GemsLand is NOT affiliated to 'Supercell Oy'.");
            Console.WriteLine("ClashLand does NOT own 'Clash of Clans'");
            Console.WriteLine("Mod1 Super Exp gain");
            Console.WriteLine("Mod2 Auto Upgrade: troops, spells, heroes".);
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
