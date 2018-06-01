using GL.Servers.CoC.Logic.Components;
using GL.Servers.CoC.Logic.Enums;

namespace GL.Servers.CoC.Logic.Slots
{
    using System.Collections.Generic;
    using GL.Servers.CoC.Logic.Slots.Items;
    using GL.Servers.CoC.Files;

    internal class VillageObjects : Dictionary<int, VillageObject>
    {
        internal Objects Objects;

        internal VillageObject Boat;

        internal int Seed;

        /// <summary>
        /// Initializes a new instance of the <see cref="VillageObjects"/>.
        /// </summary>
        internal VillageObjects()
        {
            // VillageObjects.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VillageObjects"/>.
        /// </summary>
        /// <param name="Player">The player.</param>
        internal VillageObjects(Objects Objects)
        {
            this.Objects = Objects;
        }

        internal void Synchronize()
        {
            this.Seed = 508000000;

            foreach (KeyValuePair<int, VillageObject> Building in this)
            {
                Building.Value.ID = Building.Key;
                Building.Value.Csv = CSV.Tables.Get(Gamefile.Village_Objects).GetDataWithID(Building.Value.Data) as Files.CSV_Logic.Village_Objects;
                Building.Value.Objects = this.Objects;

                if (Building.Value.Data == 39000000)
                {
                    this.Boat = Building.Value;
                }

                this.Seed++;
            }

            if (this.Boat == null)
            {
                VillageObject Boat = new VillageObject(508000000, 39000000);

                Boat.Level = 1;
                Boat.X = 14;
                Boat.Y = 53;

                this.Add(508000000, Boat);
            }
        }

        /// <summary>
        /// Refreshes the building.
        /// </summary>
        /// <param name="Tick">The time</param>
        internal void Refresh(float Tick)
        {
            foreach (KeyValuePair<int, VillageObject> Building in this)
            {
                Building.Value.Refresh(Tick);
            }
        }
    }
}