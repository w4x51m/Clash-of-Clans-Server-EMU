using System;
using System.Linq;
using GL.Servers.CoC.Files;
using GL.Servers.CoC.Files.CSV_Helpers;
using GL.Servers.CoC.Files.CSV_Logic;
using GL.Servers.CoC.Logic.Enums;

namespace GL.Servers.CoC.Logic.Slots
{
    using System.Collections.Generic;

    using GL.Servers.CoC.Logic.Slots.Items;

    internal class Progress : Dictionary<int, Slot>
    {
        internal Player Player;

        /// <summary>
        /// Initializes a new instance of the <see cref="Progress"/>
        /// </summary>
        internal Progress()
        {
            // Progress
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Progress"/> class.
        /// </summary>
        /// <param name="Player">The player class.</param>
        internal Progress(Player Player)
        {
            this.Player = Player;
        }

        internal void Set(int ID, int Count)
        {
            if (this.ContainsKey(ID))
            {
                this[ID].Count = Count;
            }
            else
            {
                base.Add(ID, new Slot(ID, Count));
            }
        }

        internal int Get(int ID)
        {
            if (this.ContainsKey(ID))
            {
                return this[ID].Count;
            }

            return 0;
        }

        internal void Synchronize()
        {
            Data[] Datas = CSV.Tables.Get(Gamefile.Achievements).Datas.ToArray();

            for (int i = 0; i < Datas.Length; i++)
            {
                Files.CSV_Logic.Achievements Data = Datas[i] as Files.CSV_Logic.Achievements;

                switch (Data.Action)
                {
                    case "upgrade":

                        Files.CSV_Logic.Buildings BuildingData =
                            CSV.Tables.Get(Gamefile.Buildings).GetData(Data.ActionData) as Files.CSV_Logic.Buildings;

                        Building[] Buildings = this.Player.Objects.Buildings.Values.Where(B => B.Data == BuildingData.GlobalID).ToArray();

                        if (Buildings.Length > 0)
                        {
                            this.Set(Data.GlobalID, Buildings.Max(T => T.Level) + 1);
                            this.Set(Data.GlobalID + 1, Buildings.Max(T => T.Level) + 1);
                            this.Set(Data.GlobalID + 2, Buildings.Max(T => T.Level) + 1);
                        }

                        i += 2;

                        break;

                    case "unit_unlock":

                        Characters UnitData = CSV.Tables.Get(Gamefile.Characters).GetData(Data.ActionData) as Characters;
                        Building Building   = this.Player.Objects.Buildings.Values.FirstOrDefault(B => B.Data == 1000006 && B.Level + 1 >= UnitData.BarrackLevel);

                        this.Set(Data.GlobalID, Building != null ? 1 : 0);

                        break;

                    case "victory_points":

                        if (this.Get(Data.GlobalID) < this.Player.Score)
                        {
                            this.Set(Data.GlobalID, this.Player.Score);
                            this.Set(Data.GlobalID + 1, this.Player.Score);
                            this.Set(Data.GlobalID + 2, this.Player.Score);
                        }

                        i += 2;

                        break;

                    case "league":

                        this.Set(Data.GlobalID, this.Player.League);
                        this.Set(Data.GlobalID + 1, this.Player.League);
                        this.Set(Data.GlobalID + 2, this.Player.League);

                        i += 2;

                        break;

                    case "npc_stars":

                        //int Stars = this.Player.NpcProgress.Sum(T => T.Value.Count);

                        //this.Set(Data.GlobalID, Stars);
                        //this.Set(Data.GlobalID + 1, Stars);
                        //this.Set(Data.GlobalID + 2, Stars);

                        //i += 2;

                        break;

                    case "destroy":
                        /*
                        int ActionDataID = CSV.Tables.Get(Gamefile.Buildings).GetData(Data.ActionData).GlobalID;

                        if (this.Player.Destroyed.ContainsKey(Data.GlobalID))
                        {
                            this.Set(Data.GlobalID, this.Player.Destroyed[ActionDataID]);
                            this.Set(Data.GlobalID + 1, this.Player.Destroyed[ActionDataID]);
                            this.Set(Data.GlobalID + 2, this.Player.Destroyed[ActionDataID]);
                        }

                        i += 2;
                        */
                        break;

                    case "loot":

                        // NotImplemented

                        i += 2;

                        break;

                    case "clear_obstacles":


                        break;

                    case "win_pvp_attack":

                        this.Set(Data.GlobalID, this.Player.TotalWins);
                        this.Set(Data.GlobalID + 1, this.Player.TotalWins);
                        this.Set(Data.GlobalID + 2, this.Player.TotalWins);

                        i += 2;

                        break;

                    case "win_pvp_defense":

                        this.Set(Data.GlobalID, this.Player.TotalDefenseWins);
                        this.Set(Data.GlobalID + 1, this.Player.TotalDefenseWins);
                        this.Set(Data.GlobalID + 2, this.Player.TotalDefenseWins);

                        i += 2;

                        break;

                    case "donate_units":

                        this.Set(Data.GlobalID, this.Player.TotalUnitSended);
                        this.Set(Data.GlobalID + 1, this.Player.TotalUnitSended);
                        this.Set(Data.GlobalID + 2, this.Player.TotalUnitSended);

                        i += 2;

                        break;

                    case "donate_spells":

                        this.Set(Data.GlobalID, this.Player.TotalSpellSended);
                        this.Set(Data.GlobalID + 1, this.Player.TotalSpellSended);
                        this.Set(Data.GlobalID + 2, this.Player.TotalSpellSended);

                        i += 2;

                        break;

                    case "war_loot":

                        // NotImplemented

                        i += 2;

                        break;

                    case "war_stars":

                        i += 2;

                        break;

                    default:

                        i += 2;

                        Console.WriteLine("Unknown Type : " + Data.Action);

                        break;
                }
            }
        }


        /// <summary>
        /// Invoked when the player claim achievement.
        /// </summary>
        /// <param name="ID">Achievement ID.</param>
        /// <returns></returns>
        internal bool Claim(int ID)
        {
            Files.CSV_Logic.Achievements Data = CSV.Tables.Get(Gamefile.Achievements).GetDataWithID(ID) as Files.CSV_Logic.Achievements;

            if (this.Get(ID) >= Data.ActionCount)
            {
                if (this.Player.Achievements.Add(Data.GlobalID))
                {
                    this.Player.Resources.Plus(3000000, Data.DiamondReward);
                    this.Player.AddExperience(Data.ExpReward);

                    return true;
                }
            }

            return false;
        }
    }
}