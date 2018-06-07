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
            KKKKKKKKK    KKKKKKK     OOOOOOOOO     ZZZZZZZZZZZZZZZZZZZ     OOOOOOOOO             GGGGGGGGGGGGGLLLLLLLLLLL            UUUUUUUU     UUUUUUUU
            K:::::::K    K:::::K   OO:::::::::OO   Z:::::::::::::::::Z   OO:::::::::OO        GGG::::::::::::GL:::::::::L            U::::::U     U::::::U
            K:::::::K    K:::::K OO:::::::::::::OO Z:::::::::::::::::Z OO:::::::::::::OO    GG:::::::::::::::GL:::::::::L            U::::::U     U::::::U
            K:::::::K   K::::::KO:::::::OOO:::::::OZ:::ZZZZZZZZ:::::Z O:::::::OOO:::::::O  G:::::GGGGGGGG::::GLL:::::::LL            UU:::::U     U:::::UU
            KK::::::K  K:::::KKKO::::::O   O::::::OZZZZZ     Z:::::Z  O::::::O   O::::::O G:::::G       GGGGGG  L:::::L               U:::::U     U:::::U 
              K:::::K K:::::K   O:::::O     O:::::O        Z:::::Z    O:::::O     O:::::OG:::::G                L:::::L               U:::::D     D:::::U 
              K::::::K:::::K    O:::::O     O:::::O       Z:::::Z     O:::::O     O:::::OG:::::G                L:::::L               U:::::D     D:::::U 
              K:::::::::::K     O:::::O     O:::::O      Z:::::Z      O:::::O     O:::::OG:::::G    GGGGGGGGGG  L:::::L               U:::::D     D:::::U 
              K:::::::::::K     O:::::O     O:::::O     Z:::::Z       O:::::O     O:::::OG:::::G    G::::::::G  L:::::L               U:::::D     D:::::U 
              K::::::K:::::K    O:::::O     O:::::O    Z:::::Z        O:::::O     O:::::OG:::::G    GGGGG::::G  L:::::L               U:::::D     D:::::U 
              K:::::K K:::::K   O:::::O     O:::::O   Z:::::Z         O:::::O     O:::::OG:::::G        G::::G  L:::::L               U:::::D     D:::::U 
            KK::::::K  K:::::KKKO::::::O   O::::::OZZZ:::::Z     ZZZZZO::::::O   O::::::O G:::::G       G::::G  L:::::L         LLLLLLU::::::U   U::::::U 
            K:::::::K   K::::::KO:::::::OOO:::::::OZ::::::ZZZZZZZZ:::ZO:::::::OOO:::::::O  G:::::GGGGGGGG::::GLL:::::::LLLLLLLLL:::::LU:::::::UUU:::::::U 
            K:::::::K    K:::::K OO:::::::::::::OO Z:::::::::::::::::Z OO:::::::::::::OO    GG:::::::::::::::GL::::::::::::::::::::::L UU:::::::::::::UU  
            K:::::::K    K:::::K   OO:::::::::OO   Z:::::::::::::::::Z   OO:::::::::OO        GGG::::::GGG:::GL::::::::::::::::::::::L   UU:::::::::UU    
            KKKKKKKKK    KKKKKKK     OOOOOOOOO     ZZZZZZZZZZZZZZZZZZZ     OOOOOOOOO             GGGGGG   GGGGLLLLLLLLLLLLLLLLLLLLLLLL     UUUUUUUUU      
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
                         V10.134.6.Cyber Daekness
            ", Color.Green, Color.Blue, 14);

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("GemsLand program is under the 'Proprietary' license.");
            Console.WriteLine("GemsLand is NOT affiliated to 'Supercell Oy'.");
            Console.WriteLine("GemsLand does NOT own 'Clash of Clans'");
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
