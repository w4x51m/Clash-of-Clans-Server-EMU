namespace GL.Servers.CoC.Files.CSV_Logic
{
    using GL.Servers.CoC.Files.CSV_Helpers;
    using GL.Servers.Files.CSV_Reader;

    internal class Townhall_Levels : Data
    {
        public Townhall_Levels(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Data.LoadData(this, this.GetType(), Row);
        }

        public string Name { get; set; }
        public int AttackCost { get; set; }
        public int ResourceStorageLootPercentage { get; set; }
        public int DarkElixirStorageLootPercentage { get; set; }
        public int ResourceStorageLootCap { get; set; }
        public int DarkElixirStorageLootCap { get; set; }
        public int WarPrizeResourceCap { get; set; }
        public int WarPrizeDarkElixirCap { get; set; }
        public int WarPrizeAllianceExpCap { get; set; }
        public int CartLootCapResource { get; set; }
        public int CartLootReengagementResource { get; set; }
        public int CartLootCapDarkElixir { get; set; }
        public int CartLootReengagementDarkElixir { get; set; }
        public int Troop Housing { get; set; }
        public int Elixir Storage { get; set; }
        public int Gold Storage { get; set; }
        public int Elixir Pump { get; set; }
        public int Gold Mine { get; set; }
        public int Barrack { get; set; }
        public int Cannon { get; set; }
        public int Cannon_gearup { get; set; }
        public int Wall { get; set; }
        public int Archer Tower { get; set; }
        public int Archer Tower_gearup { get; set; }
        public int Wizard Tower { get; set; }
        public int Air Defense { get; set; }
        public int Mortar { get; set; }
        public int Mortar_gearup { get; set; }
        public int Alliance Castle { get; set; }
        public int Ejector { get; set; }
        public int Superbomb { get; set; }
        public int Mine { get; set; }
        public int Worker Building { get; set; }
        public int Laboratory { get; set; }
        public int Communications mast { get; set; }
        public int Tesla Tower { get; set; }
        public int Spell Forge { get; set; }
        public int Mini Spell Factory { get; set; }
        public int Bow { get; set; }
        public int Halloweenbomb { get; set; }
        public int Slowbomb { get; set; }
        public int Hero Altar Barbarian King { get; set; }
        public int Dark Elixir Pump { get; set; }
        public int Dark Elixir Storage { get; set; }
        public int Hero Altar Archer Queen { get; set; }
        public int AirTrap { get; set; }
        public int MegaAirTrap { get; set; }
        public int Dark Elixir Barrack { get; set; }
        public int Dark Tower { get; set; }
        public int SantaTrap { get; set; }
        public int StrengthMaxTroopTypes { get; set; }
        public int StrengthMaxSpellTypes { get; set; }
        public int Totem { get; set; }
        public int Halloweenskels { get; set; }
        public int Air Blaster { get; set; }
        public int Hero Altar Grand Warden { get; set; }
        public int Mega Cannon { get; set; }
        public int Ancient Artillery { get; set; }
        public int Bomb Tower { get; set; }
        public int TreasuryGold { get; set; }
        public int TreasuryElixir { get; set; }
        public int TreasuryDarkElixir { get; set; }
        public int TreasuryWarGold { get; set; }
        public int TreasuryWarElixir { get; set; }
        public int TreasuryWarDarkElixir { get; set; }
        public int FriendlyCost { get; set; }
        public int PackElixir { get; set; }
        public int PackGold { get; set; }
        public int PackDarkElixir { get; set; }
        public int PackGold2 { get; set; }
        public int PackElixir2 { get; set; }
        public int FreezeBomb { get; set; }
        public int DuelPrizeResourceCap { get; set; }
        public int Elixir Pump2 { get; set; }
        public int Elixir Storage2 { get; set; }
        public int Gold Mine2 { get; set; }
        public int Gold Storage2 { get; set; }
        public int WallStraight { get; set; }
        public int Cannon2 { get; set; }
        public int Archer Tower2 { get; set; }
        public int Troop Housing2 { get; set; }
        public int Tesla Tower2 { get; set; }
        public int Double Cannon { get; set; }
        public int Clock Tower { get; set; }
        public int Laboratory2 { get; set; }
        public int Multi Mortar { get; set; }
        public int Barrack2 { get; set; }
        public int Mega Tesla { get; set; }
        public int Guard Post { get; set; }
        public int Pusher { get; set; }
        public int Hero Altar Warmachine { get; set; }
        public int Air Defense Mini { get; set; }
        public int Crusher { get; set; }
        public int AirGroundTrap { get; set; }
        public int Air Defense2 { get; set; }
        public int MegaAirGroundTrap { get; set; }
        public int AttackCostVillage2 { get; set; }
        public int ChangeTroopCost { get; set; }
        public int Flamer { get; set; }
        public int Gem Mine { get; set; }
        public int Ejector2 { get; set; }
        public int Giant Cannon { get; set; }
        public int ShrinkTrap { get; set; }
    }
}