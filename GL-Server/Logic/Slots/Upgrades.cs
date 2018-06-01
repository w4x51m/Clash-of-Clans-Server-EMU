namespace GL.Servers.CoC.Logic.Slots
{
    using System.Collections.Generic;

    using GL.Servers.CoC.Logic.Slots.Items;


    internal class Upgrades : Dictionary<int, Slot>
    {
        internal Player Player;

        /// <summary>
        /// Initializes a new instance of the <see cref="Upgrades"/>
        /// </summary>
        internal Upgrades()
        {
            // Upgrades
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Upgrades"/>
        /// </summary>
        /// <param name="Player">The player class.</param>
        internal Upgrades(Player Player)
        {
            this.Player = Player;
        }

        /// <summary>
        /// Gets the level of the troop.
        /// </summary>
        /// <param name="ID">The troop id.</param>
        /// <returns></returns>
        internal int GetLevel(int ID)
        {
            if (this.ContainsKey(ID))
            {
                return this[ID].Count;
            }

            return 0;
        }

        /// <summary>
        /// Upgrade the troop.
        /// </summary>
        /// <param name="ID">The troop id.</param>
        internal void Upgrade(int ID)
        {
            if (this.ContainsKey(ID))
            {
                this[ID].Count++;
            }
            else
            {
                base.Add(ID, new Slot(ID, 1));
            }
        }
    }
}
