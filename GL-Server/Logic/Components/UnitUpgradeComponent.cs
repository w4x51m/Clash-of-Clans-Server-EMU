namespace GL.Servers.CoC.Logic.Components
{
    using GL.Servers.CoC.Files;
    using GL.Servers.CoC.Files.CSV_Logic;
    using GL.Servers.CoC.Logic.Enums;

    using Newtonsoft.Json;

    internal class UnitUpgradeComponent
    {
        internal Objects Objects;

        [JsonProperty("id")]        internal int? ID;
        [JsonProperty("unit_type")] internal int? UnitType;
        [JsonProperty("t")]         internal float? Time;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitUpgradeComponent"/>
        /// </summary>
        internal UnitUpgradeComponent()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitUpgradeComponent"/>
        /// </summary>
        /// <param name="Objects">The objects class.</param>
        internal UnitUpgradeComponent(Objects Objects)
        {
            this.Objects = Objects;
        }

        /// <summary>
        /// Starts the upgrade task.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <param name="UnitType">Type of the unit.</param>
        internal bool StartUpgrade(int ID, int UnitType)
        {
            if (!this.ID.HasValue)
            {
                if (this.UnitType == 0)
                {
                    Characters Character = CSV.Tables.Get(Gamefile.Characters).GetDataWithID(ID) as Characters;

                    int Level            = this.Objects.Player.UnitUpgrades.GetLevel(ID);
                    int Resource         = CSV.Tables.Get(Gamefile.Resources).GetData(Character.UpgradeResource).GlobalID;

                    if (this.Objects.Player.Resources.Minus(Resource, Character.UpgradeCost[Level]))
                    {
                        this.ID       = ID;
                        this.UnitType = UnitType;
                        this.Time     = Character.UpgradeTimeH[Level] * 3600 + Character.UpgradeTimeM[Level] * 60;

                        return true;
                    }
                }
                else if (this.UnitType == 1)
                {
                    Spells Spells = CSV.Tables.Get(Gamefile.Characters).GetDataWithID(ID) as Spells;

                    int Level            = this.Objects.Player.UnitUpgrades.GetLevel(ID);
                    int Resource         = CSV.Tables.Get(Gamefile.Resources).GetData(Spells.UpgradeResource).GlobalID;

                    if (this.Objects.Player.Resources.Minus(Resource, Spells.UpgradeCost[Level]))
                    {
                        this.ID       = ID;
                        this.UnitType = UnitType;
                        this.Time     = Spells.UpgradeTimeH[Level] * 3600;

                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Executed when an upgrade task has been completed.
        /// </summary>
        internal void UpgradeEnded()
        {
            if (this.Time.HasValue)
            {
                
            }
        }

        /// <summary>
        /// Refreshes the time.
        /// </summary>
        /// <param name="Time">The time.</param>
        internal void Refresh(float Time)
        {
            if (this.Time.HasValue)
            {
                this.Time -= Time;

                if (this.Time <= 0f)
                {
                    this.UpgradeEnded();

                    this.ID       = null;
                    this.UnitType = null;
                    this.Time     = null;
                }
            }
        }
    }
}
