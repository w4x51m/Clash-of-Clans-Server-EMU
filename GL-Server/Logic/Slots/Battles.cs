using System.Linq;
using System.Threading;
using GL.Servers.CoC.Core.Network;
using GL.Servers.CoC.Logic.Battles;
using GL.Servers.CoC.Logic.Interfaces;
using GL.Servers.CoC.Packets.Messages.Server;
using GL.Servers.Logic.Enums;

namespace GL.Servers.CoC.Logic.Slots
{
    using System.Collections.Generic;

    using GL.Servers.CoC.Files;

    internal class Battles : Dictionary<long, IBattle>
    {
        internal Dictionary<long, Player> WaitingsPlayers;
        internal Thread Processor;

        internal object GateRemove = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="Battles"/>
        /// </summary>
        internal Battles()
        {
            this.WaitingsPlayers = new Dictionary<long, Player>();

            this.Processor = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);

                    lock (this.GateRemove)
                    {
                        Player[] Waitings     = this.WaitingsPlayers.Values.ToArray();
                        List<Player> Offlines = Core.Resources.Players.GetRandom(Waitings.Length);

                        foreach (Player Player in Waitings)
                        {
                            if (Offlines.Count > 0)
                            {
                                if (Player.Device?.Connected ?? false)
                                {
                                    if (!Offlines[0].Device?.Connected ?? true)
                                    {
                                        PvPBattle Battle    = new PvPBattle(Offlines[0].Objects, Player, Offlines[0]);

                                        Player.Battle       = Battle;
                                        Offlines[0].Battle  = Battle;

                                        Player.Device.State = State.IN_BATTLE;

                                        new EnemyHomeData(Player.Device, Offlines[0]).Send();
                                    }
                                }
                                else
                                {
                                    this.WaitingsPlayers.Remove(Player.PlayerID);
                                }
                            }
                            else break;
                        }
                    }
                }
            });


            this.Processor.Start();
        }

        internal void Start_PVP(Player Player)
        {
            if (!this.WaitingsPlayers.ContainsKey(Player.PlayerID))
            {
                if (Player.Device?.Connected ?? false)
                {
                    this.WaitingsPlayers.Add(Player.PlayerID, Player);
                }
            }
        }
    }
}