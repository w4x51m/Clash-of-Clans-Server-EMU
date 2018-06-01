namespace GL.Servers.CoC.Logic.Slots
{
    using System.Collections.Generic;

    using GL.Servers.CoC.Files;
    using GL.Servers.CoC.Logic.Enums;
    using GL.Servers.CoC.Logic.Slots.Items;


    internal class Traps : Dictionary<int, Trap>
    {
        internal Objects Objects;

        internal int Seed;

        internal bool isMap2;

        /// <summary>
        /// Initializes a new instance of the <see cref="Traps"/>
        /// </summary>
        internal Traps()
        {
            // Buildings
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Traps"/>
        /// </summary>
        /// <param name="Objects">The objects class.</param>
        internal Traps(Objects Objects, bool isMap2 = false)
        {
            this.Objects = Objects;
            this.isMap2  = isMap2;
        }

        /// <summary>
        /// Start construction of the new building.
        /// </summary>
        /// <param name="Data">The data.</param>
        /// <param name="X">The x position</param>
        /// <param name="Y">The y position</param>
        /// <returns></returns>
        internal bool Construct(int Data, int X, int Y)
        {
            Building Building   = new Building(this.Seed++, Data);
            Building.Csv        = CSV.Tables.Get(Gamefile.Buildings).GetDataWithID(Building.Data) as Files.CSV_Logic.Buildings;

            return Building.Move(X, Y);
        }

        /// <summary>
        /// Synchronizes this instance.
        /// </summary>
        internal void Synchronize()
        {
            this.Seed = 504000000;

            foreach (KeyValuePair<int, Trap> Trap in this)
            {
                Trap.Value.ID  = Trap.Key;
                Trap.Value.Csv = CSV.Tables.Get(Gamefile.Traps).GetDataWithID(Trap.Value.Data) as Files.CSV_Logic.Traps;

                if (Trap.Value.ConstructionTime.HasValue)
                {
                    Trap.Value.ConstructionTime = (int) Trap.Value.ConstructionTime;
                }

                if (this.isMap2)
                {
                    this.Objects.Collider2.Set(Trap.Value.X, Trap.Value.Y, Trap.Value.Csv.Width, Trap.Value.Csv.Height, Trap.Value.ID);
                }
                else
                {
                    this.Objects.Collider.Set(Trap.Value.X, Trap.Value.Y, Trap.Value.Csv.Width, Trap.Value.Csv.Height, Trap.Value.ID);
                }
            }
        }

        /// <summary>
        /// Refreshes the <see cref="Trap"/>.
        /// </summary>
        /// <param name="Tick"></param>
        internal void Refresh(float Tick)
        {
            foreach (KeyValuePair<int, Trap> Trap in this)
            {
                Trap.Value.Refresh(Tick);
            }
        }
    }
}
