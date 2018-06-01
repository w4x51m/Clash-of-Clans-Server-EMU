using System;
using GL.Servers.CoC.Core;

namespace GL.Servers.CoC.Logic.Slots
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GL.Servers.CoC.Logic.Slots.Items;

    internal class WorldChats : List<WorldChat>
    {
        internal object Gate = new object();

        internal WorldChats()
        {
            for (int i = 0; i < Constants.MaxPlayers / 25 + 1; i++)
            {
                this.Add(new WorldChat());
            }

            Console.WriteLine(this.Count + " Gamerooms create!\n");
        }

        internal void Join(Player Player)
        {
            lock (this.Gate)
            {
                while (this.Count > 0)
                {
                    if (!this[0].Join(Player))
                    {
                        this.RemoveAt(0);
                    }

                    break;
                }
            }
        }
    }
}
