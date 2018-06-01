using System;
using System.Collections.Generic;

namespace GL.Servers.CoC.Logic.Slots.Items
{

    internal class GameSlots : Dictionary<int, Slot>, ICloneable
    {
        internal GameSlots Clone()
        {
            return this.MemberwiseClone() as GameSlots;
        }

        internal void Add(int ID, int Count)
        {
            if (this.ContainsKey(ID))
            {
                this[ID].Count += Count;
            }
            else base.Add(ID, new Slot(ID, Count));
        }

        internal bool Remove(int ID, int Count)
        {
            if (this.ContainsKey(ID))
            {
                if (this[ID].Count >= Count)
                {
                    this[ID].Count -= Count;

                    return true;
                }
            }

            return false;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
