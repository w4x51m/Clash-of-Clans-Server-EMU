using System.Linq;
using GL.Servers.CoC.Files.CSV_Logic;
using GL.Servers.CoC.Logic.Enums;
using GL.Servers.CoC.Logic.Slots.Items;

namespace GL.Servers.CoC.Logic.Slots
{
    using GL.Servers.CoC.Files;
    using System.Collections.Generic;

    internal class Missions : List<int>
    {
        internal Player Player;

        /// <summary>
        /// Initializes a new instance of the <see cref="Missions"/>.
        /// </summary>
        internal Missions()
        {
            // Missions.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Missions"/>.
        /// </summary>
        /// <param name="Player">The player class.</param>
        internal Missions(Player Player)
        {
            this.Player = Player;
        }

        /// <summary>
        /// Add the specific mission.
        /// </summary>
        /// <param name="ID">Mission id.</param>
        /// <param name="Mission">Mission data.</param>
        internal void Add(int ID, Files.CSV_Logic.Missions Mission)
        {
            if (!this.Contains(ID))
            {
                if (Mission.RewardResource != null)
                {
                    this.Player.Resources.Plus(CSV.Tables.Get(Gamefile.Resources).GetData(Mission.RewardResource).GlobalID, Mission.RewardResourceCount, true);
                }

                if (Mission.RewardXP > 0)
                {
                    this.Player.AddExperience(Mission.RewardXP);
                }

                if (Mission.RewardTroop != null)
                {
                    this.Player.Units.Add(CSV.Tables.Get(Gamefile.Characters).GetData(Mission.RewardTroop).GlobalID, Mission.RewardTroopCount);
                }

                this.Add(ID);
            }
        }

        /// <summary>
        /// Synchronize the missions.
        /// </summary>
        internal void Synchronize()
        {
            foreach (Files.CSV_Logic.Missions Mission in CSV.Tables.Get(Gamefile.Missions).Datas)
            {
                if (!this.Contains(Mission.GlobalID))
                {
                    if (!string.IsNullOrEmpty(Mission.Dependencies))
                    {
                        if (!this.Contains(CSV.Tables.Get(Gamefile.Missions).GetData(Mission.Dependencies).GlobalID))
                        {
                            return;
                        }
                    }

                    if (Mission.BuildBuilding != null)
                    {
                        List<Building> Buildings = this.Player.Objects.Buildings.Values.Where(B => B.Data == CSV.Tables.Get(Gamefile.Buildings).GetData(Mission.BuildBuilding).GlobalID).ToList();

                        if (Buildings.Count > 0)
                        {
                            if (Buildings.Count >= Mission.BuildBuildingCount)
                            {
                                if (Buildings.Exists(T => T.Level + 1 >= Mission.BuildBuildingLevel))
                                {
                                    this.Add(Mission.GlobalID, Mission);
                                }
                            }
                        }
                    }
                    else if (Mission.ChangeName)
                    {
                        if (this.Player.NameSetted)
                        {
                            this.Add(Mission.GlobalID, Mission);
                        }
                    }
                    else if (Mission.AttackNPC != null)
                    {

                        if (this.Player.NpcProgress.ContainsKey(CSV.Tables.Get(Gamefile.Npcs).GetData(Mission.AttackNPC).GlobalID))
                        {
                            this.Add(Mission.GlobalID, Mission);
                        }
                    }

                    else if (Mission.TrainTroops > 0)
                    {
                        if (this.Player.Units.Sum(T => T.Value.Count > 0 ? (CSV.Tables.Get(Gamefile.Characters).GetDataWithID(T.Key) as Characters).HousingSpace * T.Value.Count : 0) >= Mission.TrainTroops)
                        {
                            this.Add(Mission.GlobalID, Mission);
                        }
                    }
                }
            }
        }
    }
}
