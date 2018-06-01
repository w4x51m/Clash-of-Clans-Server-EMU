namespace GL.Servers.CoC.Logic.Slots
{
    using System.Collections.Generic;

    using GL.Servers.CoC.Logic.Slots.Items;

    internal class Caps : Dictionary<int, Slot>
    {
        internal Player Player;

        /// <summary>
        /// Initializes a new instance of the <see cref="Caps"/>.
        /// </summary>
        internal Caps()
        {
            // Resources
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Caps"/>.
        /// </summary>
        /// <param name="Player">The player.</param>
        internal Caps(Player Player)
        {
            this.Player = Player;
        }

        internal void Plus(int ID, int Count, int OldValue = 0)
        {
            if (this.ContainsKey(ID))
            {
                this[ID].Count += Count - OldValue;
            }
            else base.Add(ID, new Slot(ID, Count));
        }

        internal void Set(int ID, int Count)
        {
            if (this.ContainsKey(ID))
            {
                this[ID].Count = Count;
            }
            else base.Add(ID, new Slot(ID, Count));
        }
    }
}
