namespace GL.Servers.CoC.Logic.Slots
{
    using System.Collections.Generic;

    using GL.Servers.CoC.Files;
    using GL.Servers.CoC.Logic.Enums;
    using GL.Servers.CoC.Logic.Slots.Items;

    using Newtonsoft.Json;

    internal class Decos : Dictionary<int, Deco>
    {
        internal Objects Objects;

        internal int Seed;

        internal bool isMap2;

        /// <summary>
        /// Initializes a new instance of the <see cref="Decos"/>
        /// </summary>
        internal Decos()
        {
            // Decos
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Decos"/> class.
        /// </summary>
        /// <param name="Objects">The Objects class.</param>
        internal Decos(Objects Objects, bool isMap2 = false)
        {
            this.Objects = Objects;
            this.isMap2  = isMap2;
        }

        /// <summary>
        /// Synchronizes this instance.
        /// </summary>
        internal void Synchronize()
        {
            this.Seed = 506000000;

            foreach (KeyValuePair<int, Deco> Deco in this)
            {
                Deco.Value.ID  = Deco.Key;
                Deco.Value.Csv = CSV.Tables.Get(Gamefile.Decos).GetDataWithID(Deco.Value.Data) as Files.CSV_Logic.Decos;

                this.Seed++;
            }
        }

        /// <summary>
        /// Refreshes the decos.
        /// </summary>
        /// <param name="Tick"></param>
        internal void Refresh(float Tick)
        {
            // Refresh.
        }
    }
}
