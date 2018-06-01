namespace GL.Servers.CoC.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Timers;

    using GL.Servers.CoC.Logic;

    internal class Timers
    {
        internal readonly List<Timer> LTimers = new List<Timer>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Timers"/> class.
        /// </summary>
        internal Timers()
        {
            // this.DeadSockets();
            this.Run();
        }

        /// <summary>
        /// Disconnects dead sockets.
        /// </summary>
        internal void DeadSockets()
        {
            Timer Timer = new Timer();

            Timer.Interval = 30000;
            Timer.AutoReset = true;
            Timer.Elapsed += (UCS, Sucks) =>
            {
                foreach (Player Player in Resources.Players.Values.ToList().Where(Player => Player.Device != null && !Player.Device.Connected))
                {
                    Resources.Gateway.Disconnect(Player.Device.Token.Args);
                }
            };

            this.LTimers.Add(Timer);
        }

        /// <summary>
        /// Runs this instance.
        /// </summary>
        internal void Run()
        {
            foreach (Timer Timer in this.LTimers)
            {
                Timer.Start();
            }
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        internal void Stop()
        {
            foreach (Timer Timer in this.LTimers)
            {
                Timer.Stop();
            }
        }
    }
}