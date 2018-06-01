using GL.Servers.CoC.Files;
using GL.Servers.CoC.Files.CSV_Logic;
using GL.Servers.CoC.Logic.Enums;
using GL.Servers.CoC.Logic.Slots.Items;

namespace GL.Servers.CoC.Logic.Slots
{
    using System.Collections.Generic;

    internal class Resources : Dictionary<int, Slot>
    {
        internal Player Player;

        /// <summary>
        /// Initializes a new instance of the <see cref="Resources"/>.
        /// </summary>
        internal Resources()
        {
            // Resources
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Resources"/>.
        /// </summary>
        /// <param name="Player">The player.</param>
        /// <param name="Init"></param>
        internal Resources(Player Player, bool Init = false)
        {
            this.Player = Player;

            if (Init)
            {
                this.Initialize();
            }
        }

        /// <summary>
        /// Minuses the specified resource value.
        /// </summary>
        /// <param name="ID">The resource.</param>
        /// <param name="Count">The count.</param>
        /// <returns>true if sucess.</returns>
        internal bool Minus(int ID, int Count)
        {
            if (ID >= 3000000 && ID <= 3000003 || ID >= 3000007 && ID <= 3000008)
            {
                if (this.ContainsKey(ID))
                {
                    if (this[ID].Count >= Count)
                    {
                        this[ID].Count -= Count;
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Pluses the specified resource value.
        /// </summary>
        /// <param name="ID">The resource.</param>
        /// <param name="Count">The count.</param>
        /// <returns>The added quantity.</returns>
        internal int Plus(int ID, int Count, bool IgnoreCap = false)
        {
            if (ID > 3000000 && ID <= 3000003 || ID >= 3000007 && ID <= 3000008)
            {
                if (this.ContainsKey(ID))
                {
                    if (this.Player.ResourceCaps.ContainsKey(ID))
                    {
                        if (this[ID].Count + Count > this.Player.ResourceCaps[ID].Count && !IgnoreCap)
                        {
                            Count = this.Player.ResourceCaps[ID].Count - this[ID].Count;

                            if (Count >= 0)
                            {
                                this[ID].Count += Count;
                            }
                            else Count = 0;
                        }
                        else this[ID].Count += Count;
                    }
                    else if (IgnoreCap) this[ID].Count += Count;
                    else Count = 0;
                }
                else
                {
                    if (this.Player.ResourceCaps.ContainsKey(ID))
                    {
                        if (Count > this.Player.ResourceCaps[ID].Count)
                        {
                            base.Add(ID, new Slot(ID, this.Player.ResourceCaps[ID].Count));
                            Count = this.Player.ResourceCaps[ID].Count;
                        }
                        else base.Add(ID, new Slot(ID, Count));
                    }
                    else if (IgnoreCap) base.Add(ID, new Slot(ID, Count));
                    else Count = 0;
                }
            }
            else if (ID == 3000000)
            {
                this[ID].Count += Count;
            }
            else Count = 0;

            return Count;
        }

        internal int Get(int ID)
        {
            if (this.ContainsKey(ID))
            {
                return this[ID].Count;
            }

            return 0;
        }

        /// <summary>
        /// Initializes start resources.
        /// </summary>
        internal void Initialize()
        {
            base.Add(3000000, new Slot(3000000, (CSV.Tables.Get(Gamefile.Globals).GetData("STARTING_DIAMONDS") as Globals).NumberValue));
            base.Add(3000001, new Slot(3000001, (CSV.Tables.Get(Gamefile.Globals).GetData("STARTING_GOLD") as Globals).NumberValue));
            base.Add(3000002, new Slot(3000002, (CSV.Tables.Get(Gamefile.Globals).GetData("STARTING_ELIXIR") as Globals).NumberValue));
            base.Add(3000003, new Slot(3000003, (CSV.Tables.Get(Gamefile.Globals).GetData("STARTING_GOLD2") as Globals).NumberValue));
            base.Add(3000004, new Slot(3000004, (CSV.Tables.Get(Gamefile.Globals).GetData("STARTING_ELIXIR2") as Globals).NumberValue));
        }
    }
}
