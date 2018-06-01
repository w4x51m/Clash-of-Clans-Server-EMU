using GL.Servers.CoC.Core.Network;
using GL.Servers.CoC.Packets.Commands.Server;
using GL.Servers.CoC.Packets.Messages.Server;

namespace GL.Servers.CoC.Core.Consoles
{
    using System;
    using System.Linq;
    using System.Threading;

    using GL.Servers.CoC.Logic;
    using GL.Servers.Extensions;

    internal class Parser
    {
        internal Thread Thread;

        /// <summary>
        /// Initializes a new instance of the <see cref="Parser"/> class.
        /// </summary>
        internal Parser()
        {
            this.Thread             = new Thread(this.Parse);
            this.Thread.Priority    = ThreadPriority.Lowest;
            this.Thread.Name        = this.GetType().Name;
            this.Thread.Start();
        }

        internal void Parse()
        {
            while (true)
            {
                ConsoleKeyInfo Command = Console.ReadKey(false);

                switch (Command.Key)
                {
                    case ConsoleKey.S:
                    {
                        if (Resources.Started)
                        {
                            Console.WriteLine();
                            Console.WriteLine("# " + DateTime.Now.ToString("d") + " ---- STATS ---- " + DateTime.Now.ToString("T") + " #");
                            Console.WriteLine("# ----------------------------------- #");
                            Console.WriteLine("# In-Memory Players # " + ConsolePad.Padding(Resources.Players.Count.ToString(), 15) + " #");
                            Console.WriteLine("# In-Memory Clans   # " + ConsolePad.Padding(Resources.Clans.Count.ToString(), 15) + " #");
                            // Console.WriteLine("# In-Memory Battles # " + ConsolePad.Padding(Resources.Battles.Count + " - " + Resources.Battles.Waiting.Count, 15) + " #");
                            Console.WriteLine("# In-Memory Saea    # " + ConsolePad.Padding(Resources.Gateway.ReadPool.Pool.Count + " - " + Resources.Gateway.WritePool.Pool.Count, 15) + " #");
                            Console.WriteLine("# ----------------------------------- #");
                        }
                        break;
                    }

                    case ConsoleKey.T:
                    {
                        if (Resources.Started)
                        {
                            foreach (Player Player in Resources.Players.Values.ToList())
                            {
                                    new ServerCommand(Player.Device, new ChangeName(Player.Device, "TEST", 1)).Send();
                            }
                        }

                        break;
                    }

                    case ConsoleKey.C:
                    {
                        Console.Clear();
                        break;
                    }

                    case ConsoleKey.F4:
                    case ConsoleKey.Q:
                    case ConsoleKey.Escape:
                    {
                        Resources.Events.ExitHandler();
                        break;
                    }

                    default:
                    {
                        Console.WriteLine();
                        break;
                    }
                }
            }
        }
    }
}
