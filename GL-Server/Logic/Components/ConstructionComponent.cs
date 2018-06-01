namespace GL.Servers.CoC.Logic.Components
{
    using System;

    using GL.Servers.CoC.Extensions.Game;
    using GL.Servers.CoC.Files;
    using GL.Servers.CoC.Logic.Enums;
    using GL.Servers.CoC.Logic.Slots.Items;

    internal static class ConstructionComponent
    {

        /// <summary>
        /// Start construction of the <see cref="Building"/>.
        /// </summary>
        /// <param name="UseAltResource"></param>
        /// <returns>True if success.</returns>
        internal static bool Construct(this Building Building, bool UseAltResource)
        {
            if (!Building.ConstructionTime.HasValue)
            {
                if (Building.Csv.BuildCost.Count > Building.Level + 1)
                {
                    if (Building.Objects.Buildings.Townhall.Level + 1 >= Building.Csv.TownHallLevel[Building.Level + 1])
                    {
                        if (!UseAltResource || !string.IsNullOrEmpty(Building.Csv.AltBuildResource[Building.Level + 1]))
                        {
                            int Resource = CSV.Tables.Get(Gamefile.Resources).GetData(Building.Csv.BuildResource).GlobalID;

                            if (Building.Objects.Player.Resources.Minus(Resource, Building.Csv.BuildCost[Building.Level + 1]))
                            {
                                if (Building.ResourceTime.HasValue)
                                {
                                    Building.Collect();
                                }

                                Building.ConstructionTime = (int) new TimeSpan(Building.Csv.BuildTimeD[Building.Level + 1], Building.Csv.BuildTimeH[Building.Level + 1], Building.Csv.BuildTimeM[Building.Level + 1], Building.Csv.BuildTimeS[Building.Level + 1]).TotalSeconds;

                                if (Building.ConstructionTime <= 0f)
                                {
                                    Building.ConstructionEnded();
                                    Building.ConstructionTime = null;
                                }

                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Start construction of the <see cref="VillageObject"/>.
        /// </summary>
        /// <returns>True if success.</returns>
        internal static bool Construct(this VillageObject Building)
        {
            if (!Building.ConstructionTime.HasValue)
            {
                if (Building.Csv.BuildCost.Count > Building.Level + 1)
                {
                    if (Building.Objects.Buildings.Townhall.Level + 1 >= Building.Csv.TownHallLevel[Building.Level + 1])
                    {
                        int Resource = CSV.Tables.Get(Gamefile.Resources).GetData(Building.Csv.BuildResource).GlobalID;

                        if (Building.Objects.Player.Resources.Minus(Resource, Building.Csv.BuildCost[Building.Level + 1]))
                        {
                            Building.ConstructionTime = (int) new TimeSpan(Building.Csv.BuildTimeD[Building.Level + 1], Building.Csv.BuildTimeH[Building.Level + 1], Building.Csv.BuildTimeD[Building.Level + 1], Building.Csv.BuildTimeS[Building.Level + 1]).TotalSeconds;

                            if (Building.ConstructionTime <= 0f)
                            {
                                Building.ConstructionEnded();
                                Building.ConstructionTime = null;
                            }

                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Invoked when the construction is ended.
        /// </summary>
        internal static void ConstructionEnded(this Building Building)
        {
            if (Building.ConstructionTime.HasValue && Building.ConstructionTime <= 0f)
            {
                Building.Level++;

                int TotalTime = (int)new TimeSpan(Building.Csv.BuildTimeD[Building.Level], Building.Csv.BuildTimeH[Building.Level], Building.Csv.BuildTimeM[Building.Level], Building.Csv.BuildTimeS[Building.Level]).TotalSeconds;

                Building.Objects.Player.AddExperience((int)Math.Sqrt(TotalTime));

                if (Building.Csv.ResourcePer100Hours[Building.Level] > 0)
                {
                    Building.ResourceTime = Building.Csv.ResourceMax[Building.Level] * 1f / Building.Csv.ResourcePer100Hours[Building.Level] * 360000 + 1f + Building.ConstructionTime;
                }

                if (Building.Csv.UpgradesUnits && Building.UnitUpgrade == null)
                {
                    Building.UnitUpgrade = new UnitUpgradeComponent(Building.Objects);
                }

                if (Building.Csv.HeroType != null && Building.HeroUpgrade == null)
                {
                    Building.HeroUpgrade = new HeroUpgradeComponent(Building.Objects);
                }

                if (!Building.Csv.Bunker)
                {
                    if (Building.Level > 0)
                    {
                        Building.Objects.Player.ResourceCaps.Plus(3000001, Building.Csv.MaxStoredGold[Building.Level], Building.Csv.MaxStoredGold[Building.Level - 1]);
                        Building.Objects.Player.ResourceCaps.Plus(3000002, Building.Csv.MaxStoredElixir[Building.Level], Building.Csv.MaxStoredElixir[Building.Level - 1]);
                        Building.Objects.Player.ResourceCaps.Plus(3000003, Building.Csv.MaxStoredDarkElixir[Building.Level], Building.Csv.MaxStoredDarkElixir[Building.Level - 1]);
                        Building.Objects.Player.ResourceCaps.Plus(3000007, Building.Csv.MaxStoredGold2[Building.Level], Building.Csv.MaxStoredGold2[Building.Level - 1]);
                        Building.Objects.Player.ResourceCaps.Plus(3000008, Building.Csv.MaxStoredElixir2[Building.Level], Building.Csv.MaxStoredElixir2[Building.Level - 1]);
                    }
                    else
                    {
                        Building.Objects.Player.ResourceCaps.Plus(3000001, Building.Csv.MaxStoredGold[Building.Level]);
                        Building.Objects.Player.ResourceCaps.Plus(3000002, Building.Csv.MaxStoredElixir[Building.Level]);
                        Building.Objects.Player.ResourceCaps.Plus(3000003, Building.Csv.MaxStoredDarkElixir[Building.Level]);
                        Building.Objects.Player.ResourceCaps.Plus(3000007, Building.Csv.MaxStoredGold2[Building.Level]);
                        Building.Objects.Player.ResourceCaps.Plus(3000008, Building.Csv.MaxStoredElixir2[Building.Level]);
                    }
                }
            }
        }

        /// <summary>
        /// Invoked when the construction is ended.
        /// </summary>
        internal static void ConstructionEnded(this VillageObject Building)
        {
            if (Building.ConstructionTime.HasValue && Building.ConstructionTime <= 0f)
            {
                Building.Level++;

                int TotalTime = (int)new TimeSpan(Building.Csv.BuildTimeD[Building.Level], Building.Csv.BuildTimeH[Building.Level], Building.Csv.BuildTimeM[Building.Level], Building.Csv.BuildTimeS[Building.Level]).TotalSeconds;

                Building.Objects.Player.AddExperience((int)Math.Sqrt(TotalTime));
            }
        }

        /// <summary>
        /// Speed up the construction.
        /// </summary>
        /// <returns>True if success.</returns>
        internal static bool SpeedUp(this Building Building)
        {
            if (Building.ConstructionTime.HasValue && Building.ConstructionTime > 0f)
            {
                if (Building.Objects.Player.Resources.Minus(3000000, Helpers.SpeedUpCost((int) Building.ConstructionTime)))
                {
                    Building.ConstructionTime = 0;
                    Building.ConstructionEnded();
                    Building.ConstructionTime = null;

                    return true;
                }

                return false;
            }

            Console.WriteLine("SpeedUp() not available!");

            return true;
        }
    }
}
