using System;

namespace GL.Servers.CoC.Logic
{
    using System.Collections.Generic;
    using GL.Servers.CoC.Files;
    using GL.Servers.CoC.Logic.Enums;
    using GL.Servers.CoC.Logic.Interfaces;
    using GL.Servers.CoC.Logic.Slots;
    using GL.Servers.CoC.Logic.Slots.Items;
    using GL.Servers.Extensions.List;
    using Newtonsoft.Json;
    using Resources = GL.Servers.CoC.Logic.Slots.Resources;
    using Writer = GL.Servers.CoC.Extensions.List.Writer;

    public class Player
    {
        internal Device Device;
        internal WorldChat Chat;

        internal IBattle Battle;

        [JsonProperty("high_id")]           internal int HighID             = -1;
        [JsonProperty("low_id")]            internal int LowID              = -1;

        [JsonProperty("clan_high_id")]      internal int ClanHighID;
        [JsonProperty("clan_low_id")]       internal int ClanLowID;

        [JsonProperty("league_high_id")]    internal int LeagueHighID;
        [JsonProperty("league_low_id")]     internal int LeagueLowID;

        [JsonProperty("token")]             internal string Token;
        [JsonProperty("password")]          internal string Password;

        [JsonProperty("facebook")]          internal Facebook Facebook;
        [JsonProperty("google")]            internal Google Google;
        [JsonProperty("gamecenter")]        internal Gamecenter Gamecenter;

        // Avatar

        [JsonProperty("name")]              internal string Name            = "Darkness";
        [JsonProperty("region")]            internal string Region;

        [JsonProperty("lvl")]               internal int Level              = 21;
        [JsonProperty("xp")]                internal int Experience;              = 500;

        [JsonProperty("league_type")]       internal int League;
        [JsonProperty("score")]             internal int Score;
        [JsonProperty("duel_score")]        internal int DuelScore;
        [JsonProperty("legendary_score")]   internal int LegendaryScore;

        [JsonProperty("l_season_month")]    internal int LastSeasonMonth;
        [JsonProperty("l_season_year")]     internal int LastSeasonYear;
        [JsonProperty("l_season_rank")]     internal int LastSeasonRank;
        [JsonProperty("l_season_score")]    internal int LastSeasonScore;

        [JsonProperty("o_season_month")]    internal int OldSeasonMonth;
        [JsonProperty("o_season_year")]     internal int OldSeasonYear;
        [JsonProperty("o_season_rank")]     internal int OldSeasonRank;
        [JsonProperty("o_season_score")]    internal int OldSeasonScore;

        [JsonProperty("wins")]              internal int Wins;              = 100;
        [JsonProperty("loses")]             internal int Loses;
        [JsonProperty("t_wins")]            internal int TotalWins;              = 20;
        [JsonProperty("defense_wins")]      internal int DefenseWins;
        [JsonProperty("t_defense_wins")]    internal int TotalDefenseWins;              = 1;
        [JsonProperty("defense_loses")]     internal int DefenseLoses;
        [JsonProperty("troop_received")]    internal int TroopReceived;
        [JsonProperty("troop_sended")]      internal int TroopSended;
        [JsonProperty("t_unit_sended")]     internal int TotalUnitSended;
        [JsonProperty("t_spell_sended")]    internal int TotalSpellSended;
        [JsonProperty("town_hall_lvl")]     internal int TownHallLevel;
        [JsonProperty("castle_lvl")]        internal int CastleLevel;
        [JsonProperty("castle_total")]      internal int CastleTotal;
        [JsonProperty("castle_used")]       internal int CastleUsed;
        [JsonProperty("castle_total_sp")]   internal int CastleTotalSp;
        [JsonProperty("castle_used_sp")]    internal int CastleUsedSp;

        [JsonProperty("war_state")]         internal int WarState;

        [JsonProperty("treasury_gold")]     internal int TreasuryGold;
        [JsonProperty("treasury_elixir")]   internal int TreasuryElixir;
        [JsonProperty("treasury_d_elixir")] internal int TreasuryDarkElixir;

        [JsonProperty("name_setted")]       internal bool NameSetted;
        [JsonProperty("name_changed")]      internal bool NameChanged;

        [JsonProperty("resource_caps")]     internal Caps ResourceCaps;
        [JsonProperty("resources")]         internal Resources Resources;

        [JsonProperty("units")]             internal GameSlots Units;
        [JsonProperty("units2")]            internal GameSlots Units2;

        [JsonProperty("spells")]            internal GameSlots Spells;
        [JsonProperty("variables")]         internal Variables Variables;
        [JsonProperty("alliance_units")]    internal GameSlots AllianceUnits;

        [JsonProperty("hero_states")]       internal GameSlots HeroStates;
        [JsonProperty("hero_health")]       internal GameSlots HeroHealth;
        [JsonProperty("hero_upgrade")]      internal GameSlots HeroUpgrade;

        [JsonProperty("npc_map_progress")]  internal GameSlots NpcProgress;
        [JsonProperty("npc_looted_gold")]   internal GameSlots NpcLootedGold;
        [JsonProperty("npc_looted_elixir")] internal GameSlots NpcLootedElixir;

        [JsonProperty("unit_preset_1")]     internal GameSlots UnitPreset1;
        [JsonProperty("unit_preset_2")]     internal GameSlots UnitPreset2;
        [JsonProperty("unit_preset_3")]     internal GameSlots UnitPreset3;

        [JsonProperty("previous_army")]     internal GameSlots PreviousArmy;

        [JsonProperty("missions")]          internal Missions Missions;

        [JsonProperty("unit_upgrades")]     internal Upgrades UnitUpgrades;
        [JsonProperty("spell_upgrades")]    internal Upgrades SpellUpgrades;

        [JsonProperty("achievement")]       internal Achievements Achievements;
        [JsonProperty("progress")]          internal Progress Progress;

        [JsonProperty("objects")]           internal Objects Objects;

        /// <summary>
        /// Gets the player identifier.
        /// </summary>
        internal long PlayerID
        {
            get
            {
                return (long)this.HighID << 32 | (long)(uint)this.LowID;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        internal Player()
        {
            this.Objects         = new Objects(this);
            this.Facebook        = new Facebook(this);
            this.Google          = new Google(this);
            this.Gamecenter      = new Gamecenter(this);

            this.Resources       = new Resources(this);
            this.ResourceCaps    = new Caps(this);

            this.Variables       = new Variables(this);

            this.Units           = new GameSlots();
            this.Units2          = new GameSlots();

            this.Spells          = new GameSlots();
            this.AllianceUnits   = new GameSlots();

            this.HeroStates      = new GameSlots();
            this.HeroHealth      = new GameSlots();
            this.HeroUpgrade     = new GameSlots();

            this.NpcProgress     = new GameSlots();
            this.NpcLootedGold   = new GameSlots();
            this.NpcLootedElixir = new GameSlots();

            this.UnitPreset1     = new GameSlots();
            this.UnitPreset2     = new GameSlots();
            this.UnitPreset3     = new GameSlots();

            this.PreviousArmy    = new GameSlots();

            this.Missions        = new Missions(this);

            this.UnitUpgrades    = new Upgrades(this);
            this.SpellUpgrades   = new Upgrades(this);

            this.Achievements    = new Achievements(this);
            this.Progress        = new Progress(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="HighID">The high identifier.</param>
        /// <param name="LowID">The low identifier.</param>
        internal Player(Device Device, int HighID, int LowID) : this()
        {
            this.Device          = Device;
            this.HighID          = HighID;
            this.LowID           = LowID;

            this.Objects         = new Objects(this);
            this.Facebook        = new Facebook(this);
            this.Google          = new Google(this);
            this.Gamecenter      = new Gamecenter(this);

            this.Resources       = new Resources(this, true);
            this.ResourceCaps    = new Caps(this);

            this.Variables       = new Variables(this, true);

            this.Units           = new GameSlots();
            this.Units2          = new GameSlots();
            this.Spells          = new GameSlots();
            this.AllianceUnits   = new GameSlots();

            this.HeroStates      = new GameSlots();
            this.HeroHealth      = new GameSlots();
            this.HeroUpgrade     = new GameSlots();

            this.NpcProgress     = new GameSlots();
            this.NpcLootedGold   = new GameSlots();
            this.NpcLootedElixir = new GameSlots();

            this.UnitPreset1     = new GameSlots();
            this.UnitPreset2     = new GameSlots();
            this.UnitPreset3     = new GameSlots();

            this.PreviousArmy    = new GameSlots();

            this.Missions        = new Missions(this);

            this.UnitUpgrades    = new Upgrades(this);
            this.SpellUpgrades   = new Upgrades(this);
            
            this.Achievements    = new Achievements(this);
            this.Progress        = new Progress(this);

#if DEBUG
            this.Missions.Add(21000017);
            this.Missions.Add(21000018);
            this.Missions.Add(21000019);
            this.Missions.Add(21000020);
            this.Missions.Add(21000021);
            this.Missions.Add(21000022);
            this.Missions.Add(21000023);
            this.Missions.Add(21000024);
            this.Missions.Add(21000025);
#endif
        }

        internal byte[] ToBytes
        {
            get
            {
                List<byte> Packet = new List<byte>();

                Packet.AddInt(this.HighID);
                Packet.AddInt(this.LowID);

                Packet.AddInt(this.HighID);
                Packet.AddInt(this.LowID);

                Packet.Add((byte) (this.ClanLowID > 0 ? 1 : this.LeagueLowID > 0 ? 2 : 0));

                if (this.ClanLowID > 0)
                {
                    Clan Clan = Core.Resources.Clans.Get(this.ClanHighID, this.ClanLowID);

                    if (Clan != null)
                    {
                        Packet.AddInt(this.ClanHighID);
                        Packet.AddInt(this.ClanLowID);

                        Packet.AddString(Clan.Name);

                        Packet.AddInt(Clan.Badge);
                        Packet.AddInt(2); // Role
                        Packet.AddInt(Clan.Level);

                        Packet.AddBool(this.LeagueLowID > 0);
                    }
                    else Packet[Packet.Count] = (byte) (this.LeagueLowID > 0 ? 2 : 0);
                }
                if (this.LeagueLowID > 0)
                {
                    Packet.AddInt(this.LeagueHighID);
                    Packet.AddInt(this.LeagueLowID);
                }

                Packet.AddInt(this.LegendaryScore);

                Packet.AddInt(this.LastSeasonYear > 0 ? 1 : 0);

                Packet.AddInt(this.LastSeasonMonth);
                Packet.AddInt(this.LastSeasonYear);
                Packet.AddInt(this.LastSeasonRank);
                Packet.AddInt(this.LastSeasonScore);

                Packet.AddInt(this.OldSeasonYear > 0 ? 1 : 0);

                Packet.AddInt(this.OldSeasonMonth);
                Packet.AddInt(this.OldSeasonYear);
                Packet.AddInt(this.OldSeasonRank);
                Packet.AddInt(this.OldSeasonScore);

                Packet.AddInt(this.League);

                if (true)
                {
                    Packet.AddInt(-1);
                }
                else
                {
                    Packet.AddInt(this.Objects.Buildings.Castle.Level);
                }

                Packet.AddInt(this.CastleTotal);
                Packet.AddInt(this.CastleUsed);
                Packet.AddInt(this.CastleTotalSp);
                Packet.AddInt(this.CastleUsedSp);

                Packet.AddInt(0);
                Packet.AddInt(0);
                Packet.AddInt(0);
                Packet.AddInt(0);

                Packet.AddInt(0);

                Packet.AddInt(0);
                Packet.AddInt(0);
                Packet.AddInt(0);

                Packet.AddInt(this.League);

                Packet.AddInt(-1);

                Packet.AddInt(0);
                Packet.AddInt(0);
                Packet.AddInt(0);
                Packet.AddInt(0);
                Packet.AddInt(0);

                Packet.AddInt(this.TownHallLevel);

                Packet.AddString(this.Name);

                Packet.AddString(this.Facebook.Identifier);

                Packet.AddInt(this.Level);
                Packet.AddInt(this.Experience);
                
                Packet.AddInt(this.Resources[3000000].Count);
                Packet.AddInt(0); // FreeGems

                Packet.AddInt(1200);
                Packet.AddInt(60);

                Packet.AddInt(this.Score);

                Packet.AddInt(this.Wins);
                Packet.AddInt(this.Loses);
                Packet.AddInt(this.DefenseWins);
                Packet.AddInt(this.DefenseLoses);

                Packet.AddInt(this.TreasuryGold);
                Packet.AddInt(this.TreasuryElixir);
                Packet.AddInt(this.TreasuryDarkElixir);

                Packet.AddInt(0); // ?
                Packet.AddInt(0); // ?

                Packet.AddBool(true);
                Packet.AddInt(220);
                Packet.AddInt(1828055880);
                
                Packet.AddBool(this.NameSetted);
                Packet.AddInt(this.NameChanged ? 1 : -1);
                Packet.AddInt(0);
                Packet.AddInt(0);
                Packet.AddInt(this.WarState);
                Packet.AddInt(0); // Shield cost
                Packet.AddInt(0);

                Packet.Add(0);

                Packet.AddInt(this.ResourceCaps.Count);
                foreach (KeyValuePair<int, Slot> Values in this.ResourceCaps)
                {
                    Packet.AddInt(Values.Key);
                    Packet.AddInt(Values.Value.Count);
                }

                Packet.AddInt(this.Resources.Count);
                foreach (KeyValuePair<int, Slot> Values in this.Resources)
                {
                    Packet.AddInt(Values.Key);
                    Packet.AddInt(Values.Value.Count);
                }

                Packet.AddInt(this.Units.Count);
                foreach (var Units in this.Units)
                {
                    Packet.AddInt(Units.Value.ID);
                    Packet.AddInt(Units.Value.Count);
                }

                Packet.AddInt(this.Spells.Count);
                foreach (var Spells in this.Spells)
                {
                    Packet.AddInt(Spells.Value.ID);
                    Packet.AddInt(Spells.Value.Count);
                }

                Packet.AddInt(this.UnitUpgrades.Count);
                foreach (KeyValuePair<int, Slot> Values in this.UnitUpgrades)
                {
                    Packet.AddInt(Values.Key);
                    Packet.AddInt(Values.Value.Count);
                }

                Packet.AddInt(this.SpellUpgrades.Count);
                foreach (KeyValuePair<int, Slot> Values in this.SpellUpgrades)
                {
                    Packet.AddInt(Values.Key);
                    Packet.AddInt(Values.Value.Count);
                }

                Packet.AddInt(this.HeroUpgrade.Count);
                foreach (var HeroUpgrade in this.HeroUpgrade)
                {
                    Packet.AddInt(HeroUpgrade.Value.ID);
                    Packet.AddInt(HeroUpgrade.Value.Count);
                }

                Packet.AddInt(this.HeroHealth.Count);
                foreach (var HeroHealth in this.HeroHealth)
                {
                    Packet.AddInt(HeroHealth.Value.ID);
                    Packet.AddInt(HeroHealth.Value.Count);
                }

                Packet.AddInt(this.HeroStates.Count);
                foreach (var HeroStates in this.HeroStates)
                {
                    Packet.AddInt(HeroStates.Value.ID);
                    Packet.AddInt(HeroStates.Value.Count);
                }

                Packet.AddInt(this.AllianceUnits.Count);
                foreach (var AllianceUnits in this.AllianceUnits)
                {
                    Packet.AddInt(AllianceUnits.Value.ID);
                    Packet.AddInt(AllianceUnits.Value.Count);
                }

                foreach (var AllianceUnits in this.AllianceUnits)
                {
                    Packet.AddInt(AllianceUnits.Value.ID);
                    Packet.AddInt(AllianceUnits.Value.Count);
                }

                Packet.AddInt(this.Missions.Count);
                foreach (var Missions in this.Missions)
                {
                    Packet.AddInt(Missions);
                }

                Packet.AddInt(0);
                Packet.AddInt(0);
                Packet.AddInt(0);
                Packet.AddInt(0);
                Packet.AddInt(0);
                Packet.AddInt(0);
                Packet.AddInt(0);
                Packet.AddInt(0);
                Packet.AddInt(0);
                Packet.AddInt(0);
                Packet.AddInt(0);
                Packet.AddInt(0);
                Packet.AddInt(0);
                Packet.AddInt(0);

                return Packet.ToArray();
            }
        }

        /// <summary>
        /// Adds the specified amount of experience.
        /// </summary>
        /// <param name="Count">The count.</param>
        internal void AddExperience(int Count)
        {
            this.Experience += Count;

            Files.CSV_Logic.Experience_Levels Level = CSV.Tables.Get(Gamefile.Experience_Levels).GetData(this.Level.ToString()) as Files.CSV_Logic.Experience_Levels;

            if (Level.ExpPoints <= this.Experience)
            {
                this.Level++;
                this.Experience -= Level.ExpPoints;
            }
        }

        internal Player Copy()
        {
            Player Copy = this.MemberwiseClone() as Player;

            //Copy.Units         = new GameSlots(Copy);
            //Copy.Spells        = new GameSlots(Copy);
            //Copy.AllianceUnits = new GameSlots(Copy);

            //Copy.HeroUpgrade   = new GameSlots(Copy);
            //Copy.HeroHealth    = new GameSlots(Copy);
            //Copy.HeroStates    = new GameSlots(Copy);

            //foreach (KeyValuePair<int, Slot> Slot in this.Units)
            //{
            //    Copy.Units.Add(Slot.Key, new Slot(Slot.Value.ID, Slot.Value.Count)); 
            //}      
            //foreach (KeyValuePair<int, Slot> Slot in this.Spells)
            //{
            //    Copy.Spells.Add(Slot.Key, new Slot(Slot.Value.ID, Slot.Value.Count));
            //}            
            //foreach (KeyValuePair<int, Slot> Slot in this.AllianceUnits)
            //{
            //    Copy.AllianceUnits.Add(Slot.Key, new Slot(Slot.Value.ID, Slot.Value.Count));
            //}
            
            //foreach (KeyValuePair<int, Slot> Slot in this.HeroUpgrade)
            //{
            //    Copy.HeroUpgrade.Add(Slot.Key, new Slot(Slot.Value.ID, Slot.Value.Count));
            //}
            //foreach (KeyValuePair<int, Slot> Slot in this.HeroHealth)
            //{
            //    Copy.HeroHealth.Add(Slot.Key, new Slot(Slot.Value.ID, Slot.Value.Count));
            //}
            //foreach (KeyValuePair<int, Slot> Slot in this.HeroStates)
            //{
            //    Copy.HeroStates.Add(Slot.Key, new Slot(Slot.Value.ID, Slot.Value.Count));
            //}

            return Copy;
        }
    }
}
