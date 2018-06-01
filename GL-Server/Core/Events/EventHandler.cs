namespace GL.Servers.CoC.Core.Events
{
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;

    using GL.Servers.Logic.Enums;

    using GL.Servers.CoC.Logic;
    using GL.Servers.CoC.Core.Network;
    using GL.Servers.CoC.Packets.Messages.Server;

    internal class EventsHandler
    {
        internal static EventHandler EHandler;

        internal delegate void EventHandler(Exits Type = Exits.CTRL_CLOSE_EVENT);

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsHandler"/> class.
        /// </summary>
        internal EventsHandler()
        {
            EventsHandler.EHandler += this.Handler;
            EventsHandler.SetConsoleCtrlHandler(EventsHandler.EHandler, true);
        }

        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(EventHandler Handler, bool Enabled);

        internal void ExitHandler()
        {
            Console.WriteLine("---------- SHUTDOWN ----------");

            Console.ForegroundColor = ConsoleColor.Red;

            Resources.Logger.Info("Server is shutting down, warning player about the maintenance...");

            Console.ForegroundColor = ConsoleColor.White;

            Resources.Checker.Stop();

            foreach (Player Player in Resources.Players.Values.ToArray())
            {
                if (Player.Device != null && Player.Device.State >= State.LOGGED)
                {
                    new Server_Shutdown(Player.Device).Send();
                }
            }

            Resources.Logger.Info(this.GetType().Name + " : " + "Warned every players about the maintenance.");

            bool SavePlayers    = false;
            bool SaveClans      = false;

            if (Resources.Players.Count > 0)
            {
                SavePlayers     = true;
            }

            if (Resources.Clans.Count > 0)
            {
                SaveClans       = true;
            }

            if (SavePlayers || SaveClans)
            {
                Task PTask = new Task(() => Resources.Players.Save());
                Task CTask = new Task(() => Resources.Players.Save());

                if (SavePlayers)
                    PTask.Start();

                if (SaveClans)
                    CTask.Start();

                if (SavePlayers)
                    PTask.Wait();

                if (SaveClans)
                    CTask.Wait();
            }
            else
            {
                Console.WriteLine("Server has nothing to save, shutting down immediatly.");
            }

            Console.WriteLine("------------------------------");

            Thread.Sleep(5000);

            Environment.Exit(0);
        }

        internal void Handler(Exits Type = Exits.CTRL_CLOSE_EVENT)
        {
            this.ExitHandler();
        }
    }
}
