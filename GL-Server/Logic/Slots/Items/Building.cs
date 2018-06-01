using System;
using GL.Servers.CoC.Extensions;
using GL.Servers.CoC.Files;
using GL.Servers.CoC.Logic.Components;
using GL.Servers.CoC.Logic.Enums;
using GL.Servers.CoC.Logic.Interfaces;
using Newtonsoft.Json;

namespace GL.Servers.CoC.Logic.Slots.Items
{
    internal class Building : IGameObject
    {
        internal Objects Objects;
        [JsonIgnore]                        internal Files.CSV_Logic.Buildings Csv;

        [JsonProperty("id")]                public int ID { get; set; }
        [JsonProperty("data")]              public int Data { get; set; }

        [JsonProperty("x")]                 public int X { get; set; }
        [JsonProperty("y")]                 public int Y { get; set; }

        [JsonProperty("l1x")]               public int? L1X { get; set; }
        [JsonProperty("l1y")]               public int? L1Y { get; set; }
        [JsonProperty("l2x")]               public int? L2X { get; set; }
        [JsonProperty("l2y")]               public int? L2Y { get; set; }
        [JsonProperty("l3x")]               public int? L3X { get; set; }
        [JsonProperty("l3y")]               public int? L3Y { get; set; }
        [JsonProperty("l4x")]               public int? L4X { get; set; }
        [JsonProperty("l4y")]               public int? L4Y { get; set; }
        [JsonProperty("l5x")]               public int? L5X { get; set; }
        [JsonProperty("l5y")]               public int? L5Y { get; set; }
        [JsonProperty("l6x")]               public int? L6X { get; set; }
        [JsonProperty("l6y")]               public int? L6Y { get; set; }
        [JsonProperty("l7x")]               public int? L7X { get; set; }
        [JsonProperty("l7y")]               public int? L7Y { get; set; }

        [JsonProperty("lvl")]               internal int Level = -1;

        [JsonProperty("aim_angle")]         internal int? AimAngle;

        [JsonProperty("const_t")]           internal float? ConstructionTime;
        [JsonProperty("res_time")]          internal float? ResourceTime;
        [JsonProperty("boost_t")]           internal float? BoostTime;
        [JsonProperty("clan_mail_time")]    internal float? ClanMailTime;
        [JsonProperty("unit_req_time")]     internal float? UnitRequestTime;
        [JsonProperty("share_replay_time")] internal float? ShareReplayTime;
        [JsonProperty("challenge_time")]    internal float? ChallengeTime;
        [JsonProperty("elder_kick_time")]   internal float? ElderKickTime;
        [JsonProperty("hp")]                internal float? Hitpoints;

        [JsonProperty("locked")]            internal bool? Locked;
        [JsonProperty("boost_pause")]       internal bool? BoostPause;
        [JsonProperty("attack_mode")]       internal bool? AttackMode;

        [JsonProperty("hero_upg")]          internal HeroUpgradeComponent HeroUpgrade;
        [JsonProperty("unit_upg")]          internal UnitUpgradeComponent UnitUpgrade;


        /// <summary>
        /// Initializes a new instance of the <see cref="Building"/>
        /// </summary>
        internal Building()
        {
            // Building
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Building"/>.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <param name="Data">The data identifier.</param>
        internal Building(int ID, int Data)
        {
            this.ID   = ID;
            this.Data = Data;
        }

        /// <summary>
        /// Unlockes the building.
        /// </summary>
        /// <returns>True if success.</returns>
        internal bool Unlock()
        {
            if (this.Locked ?? false)
            {
                int Resource    = CSV.Tables.Get(Gamefile.Resources).GetData(this.Csv.BuildResource).GlobalID;

                if (this.Objects.Player.Resources.Minus(Resource, this.Csv.BuildCost[0]))
                {
                    this.Locked = null;

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Toggles attack mode.
        /// </summary>
        /// <returns>True if success.</returns>
        internal bool ToggleAttackMode()
        {
            if (this.Csv.AltAttackMode)
            {
                this.AttackMode = !this.AttackMode ?? true;

                return true;
            }

            return false;
        }


        /// <summary>
        /// Changes aim angle.
        /// </summary>
        /// <returns>True if success.</returns>
        internal bool ChangeAimAngle()
        {
            if (this.Csv.AimRotateStep > 0)
            {
                if (this.AimAngle.HasValue)
                {
                    this.AimAngle += this.Csv.AimRotateStep;

                    if (this.AimAngle >= 360)
                    {
                        this.AimAngle -= 360;
                    }
                }
                else
                {
                    this.AimAngle = this.Csv.AimRotateStep;
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Refreshes the <see cref="Building"/>.
        /// </summary>
        /// <param name="Tick">The tick</param>
        public void Refresh(float Tick)
        {
            if (this.ConstructionTime.HasValue)
            {
                this.ConstructionTime -= Tick;

                if (this.ConstructionTime <= 0f)
                {
                    this.ConstructionEnded();
                    this.ConstructionTime = null;
                }
            }

            if (this.ResourceTime.HasValue)
            {
                this.ResourceTime -= Tick;

                if (this.ResourceTime <= 0f)
                {
                    this.ResourceTime = 0;
                }
            }

            if (this.BoostTime.HasValue && (!this.BoostPause ?? true))
            {
                this.BoostTime -= Tick;

                if (this.BoostTime <= 0f)
                {
                    this.BoostTime = null;
                }
            }

            if (this.ClanMailTime.HasValue)
            {
                this.ClanMailTime -= Tick;

                if (this.ClanMailTime <= 0f)
                {
                    this.ClanMailTime = null;
                }
            }

            if (this.UnitRequestTime.HasValue)
            {
                this.UnitRequestTime -= Tick;

                if (this.UnitRequestTime <= 0f)
                {
                    this.UnitRequestTime = null;
                }
            }

            if (this.ShareReplayTime.HasValue)
            {
                this.ShareReplayTime -= Tick;

                if (this.ShareReplayTime <= 0f)
                {
                    this.ShareReplayTime = null;
                }
            }

            if (this.ChallengeTime.HasValue)
            {
                this.ChallengeTime -= Tick;

                if (this.ChallengeTime <= 0f)
                {
                    this.ChallengeTime = null;
                }
            }

            if (this.ElderKickTime.HasValue)
            {
                this.ElderKickTime -= Tick;

                if (this.ElderKickTime <= 0f)
                {
                    this.ElderKickTime = null;
                }
            }

            if (this.Hitpoints.HasValue)
            {
                this.Hitpoints += this.Csv.Hitpoints[this.Level] * 1f / this.Csv.RegenTime[this.Level] * Tick;

                if (this.Hitpoints <= 0f)
                {
                    this.Hitpoints = null;
                }
            }

            if (this.Csv.UpgradesUnits)
            {
                if (this.UnitUpgrade != null)
                {
                    this.UnitUpgrade.Refresh(Tick);
                }
                else
                {
                    this.UnitUpgrade = new UnitUpgradeComponent(this.Objects);
                }
            }

            if (this.Csv.HeroType != null)
            {
                if (this.HeroUpgrade != null)
                {
                    this.HeroUpgrade.Refresh(Tick);
                }
                else
                {
                    this.HeroUpgrade = new HeroUpgradeComponent(this.Objects);
                }
            }
        }

        /// <summary>
        /// Move the <see cref="Building"/>.
        /// </summary>
        /// <param name="X">X position</param>
        /// <param name="Y">Y position</param>
        /// <returns>True if sucess</returns>
        internal bool Move(int X, int Y)
        {
            if (this.Objects.Collider.Move(this.X, this.Y, X, Y, this.Csv.Width, this.Csv.Height, this.ID))
            {
                this.X = X;
                this.Y = Y;

                return true;
            }

            return false;
        }
    }
}
