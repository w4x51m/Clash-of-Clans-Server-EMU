using System;
using System.Linq;
using GL.Servers.CoC.Logic.Components;

namespace GL.Servers.CoC.Logic.Slots
{
    using System.Collections.Generic;

    using GL.Servers.CoC.Files;
    using GL.Servers.CoC.Logic.Enums;
    using GL.Servers.CoC.Logic.Slots.Items;

    internal class Buildings : Dictionary<int, Building>
    {
        internal Objects Objects;

        internal Building Townhall;
        internal Building Castle;

        internal int Seed;

        internal bool isMap2;

        /// <summary>
        /// Initializes a new instance of the <see cref="Buildings"/>
        /// </summary>
        internal Buildings()
        {
            // Buildings
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Buildings"/>
        /// </summary>
        /// <param name="Objects">The objects class.</param>
        internal Buildings(Objects Objects, bool isMap2 = false)
        {
            this.Objects = Objects;
            this.isMap2  = isMap2;
        }

        /// <summary>
        /// Start construction of the <see cref="Building"/>.
        /// </summary>
        /// <param name="Data">The data.</param>
        /// <param name="X">The x position</param>
        /// <param name="Y">The y position</param>

        /// <returns></returns>
        internal bool Construct(int Data, int X, int Y, bool UseAltResource = false)
        {
            Building Building = new Building(-1, Data);

            Building.Csv        = CSV.Tables.Get(Gamefile.Buildings).GetDataWithID(Building.Data) as Files.CSV_Logic.Buildings;
            int Resource        = CSV.Tables.Get(Gamefile.Resources).GetData(Building.Csv.BuildResource).GlobalID;

            Building.Objects = this.Objects;

            if (Building.Move(X, Y))
            {
                if (Building.Construct(UseAltResource))
                {
                    this.Add(Building.ID = this.Seed++, Building);

                    return true;
                }

                if (this.isMap2) this.Objects.Collider2.Set(X, Y, Building.Csv.Width, Building.Csv.Height, 0);
                else             this.Objects.Collider.Set(X, Y, Building.Csv.Width, Building.Csv.Height, 0);
            }

            return false;
        }

        /// <summary>
        /// Synchronizes this instance.
        /// </summary>
        internal void Synchronize()
        {
            this.Seed = 500000000;

            if (this.isMap2)
            {
                this.Objects.Player.ResourceCaps.Set(3000007, 0);
                this.Objects.Player.ResourceCaps.Set(3000008, 0);
            }
            else
            {
                this.Objects.Player.ResourceCaps.Set(3000001, 0);
                this.Objects.Player.ResourceCaps.Set(3000002, 0);
                this.Objects.Player.ResourceCaps.Set(3000003, 0);
            }
            
            foreach (KeyValuePair<int, Building> Building in this)
            {
                Building.Value.ID      = Building.Key;
                Building.Value.Csv     = CSV.Tables.Get(Gamefile.Buildings).GetDataWithID(Building.Value.Data) as Files.CSV_Logic.Buildings;
                Building.Value.Objects = this.Objects;

                if (Building.Value.ConstructionTime.HasValue)   Building.Value.ConstructionTime = (int) Building.Value.ConstructionTime;
                if (Building.Value.ResourceTime.HasValue)       Building.Value.ResourceTime     = (int) Building.Value.ResourceTime;
                if (Building.Value.BoostTime.HasValue)          Building.Value.BoostTime        = (int) Building.Value.BoostTime;
                if (Building.Value.ClanMailTime.HasValue)       Building.Value.ClanMailTime     = (int) Building.Value.ClanMailTime;
                if (Building.Value.UnitRequestTime.HasValue)    Building.Value.UnitRequestTime  = (int) Building.Value.UnitRequestTime;
                if (Building.Value.ShareReplayTime.HasValue)    Building.Value.ShareReplayTime  = (int) Building.Value.ShareReplayTime;
                if (Building.Value.ChallengeTime.HasValue)      Building.Value.ChallengeTime    = (int) Building.Value.ChallengeTime;
                if (Building.Value.ElderKickTime.HasValue)      Building.Value.ElderKickTime    = (int) Building.Value.ElderKickTime;
                if (Building.Value.Hitpoints.HasValue)          Building.Value.Hitpoints        = (int) Building.Value.Hitpoints;

                if (Building.Value.UnitUpgrade != null)
                {
                    Building.Value.UnitUpgrade.Objects = this.Objects;

                    if (Building.Value.UnitUpgrade.ID.HasValue)
                    {
                        Building.Value.UnitUpgrade.Time = (int) Building.Value.UnitUpgrade.Time;
                    }
                }

                if (Building.Value.HeroUpgrade != null)
                {
                    Building.Value.HeroUpgrade.Objects = this.Objects;

                    if (Building.Value.HeroUpgrade.Time.HasValue)
                    {
                        Building.Value.HeroUpgrade.Time = (int) Building.Value.UnitUpgrade.Time;
                    }
                }

                if (!Building.Value.Csv.Bunker && Building.Value.Level >= 0)
                {
                    this.Objects.Player.ResourceCaps.Plus(3000001, Building.Value.Csv.MaxStoredGold[Building.Value.Level]);
                    this.Objects.Player.ResourceCaps.Plus(3000002, Building.Value.Csv.MaxStoredElixir[Building.Value.Level]);
                    this.Objects.Player.ResourceCaps.Plus(3000003, Building.Value.Csv.MaxStoredDarkElixir[Building.Value.Level]);
                    this.Objects.Player.ResourceCaps.Plus(3000007, Building.Value.Csv.MaxStoredGold2[Building.Value.Level]);
                    this.Objects.Player.ResourceCaps.Plus(3000008, Building.Value.Csv.MaxStoredElixir2[Building.Value.Level]);
                }

                if (Building.Value.Data == 1000001)
                {
                    this.Townhall = Building.Value;
                }
                else if (Building.Value.Data == 1000014)
                {
                    this.Castle   = Building.Value;
                }

                if (this.isMap2)
                {
                    this.Objects.Collider2.Set(Building.Value.X, Building.Value.Y, Building.Value.Csv.Width, Building.Value.Csv.Height, Building.Value.ID);
                }
                else
                {
                    this.Objects.Collider.Set(Building.Value.X, Building.Value.Y, Building.Value.Csv.Width, Building.Value.Csv.Height, Building.Value.ID);
                }

                this.Seed++;
            }
        }

        /// <summary>
        /// Refreshes the building.
        /// </summary>
        /// <param name="Tick">The time</param>
        internal void Refresh(float Tick)
        {
            foreach (KeyValuePair<int, Building> Building in this)
            {
                Building.Value.Refresh(Tick);
            }
        }
    }
}