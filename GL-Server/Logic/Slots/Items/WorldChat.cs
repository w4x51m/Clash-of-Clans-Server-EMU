using System.Collections.Generic;
using System.Linq;
using System.Threading;
using GL.Servers.CoC.Core.Network;
using GL.Servers.CoC.Packets.Messages.Server;

namespace GL.Servers.CoC.Logic.Slots.Items
{
    internal class WorldChat
    {
        internal Dictionary<long, Player> Players;

        internal object Gate = new object();

        internal WorldChat()
        {
            this.Players = new Dictionary<long, Player>();
        }

        internal bool Join(Player Player)
        {
            lock (this.Gate)
            {
                if (!this.Players.ContainsKey(Player.PlayerID))
                {
                    if (this.Players.Count < 25)
                    {
                        this.Players.Add(Player.PlayerID, Player);
                    }
                    else return false;
                }

                Player.Chat = this;

                return true;
            }
        }

        internal void Quit(Player Player)
        {
            lock (this.Gate)
            {
                if (this.Players.ContainsKey(Player.PlayerID))
                {
                    this.Players.Remove(Player.PlayerID);

                    if (this.Players.Count < 25)
                    {
                        Core.Resources.Chats.Add(this);
                    }
                }
            }
        }

        internal void Entry(Player Player, string Message)
        {
            if (Message.Length > 0 && Message.Length < 200)
            {
                ThreadPool.QueueUserWorkItem(GCS =>
                {
                    foreach (Player Chatter in this.Players.Values.ToArray())
                    {
                        if (Chatter.Device.Connected)
                        {
                            new GlobalChatLine(Chatter.Device, Message, Player).Send();
                        }
                    }
                });
            }
        }
    }
}