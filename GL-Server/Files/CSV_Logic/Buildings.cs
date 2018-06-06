using System.Collections.Generic;

namespace GL.Servers.CoC.Files.CSV_Logic
{
    using GL.Servers.CoC.Files.CSV_Helpers;
    using GL.Servers.Files.CSV_Reader;
    using GL.Servers.Files.CSV_Enums;

    internal class Buildings : Data
    {
        public Buildings(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Data.LoadData(this, this.GetType(), Row);
        }

        public string Name { get; set; }
        public string TID { get; set; }
        public string InfoTID { get; set; }
        public string BuildingClass { get; set; }
        public string SecondaryTargetingClass { get; set; }
        public string ShopBuildingClass { get; set; }
        public string SWF { get; set; }
        public List<string> ExportName { get; set; }
        public string ExportNameNpc { get; set; }
        public string ExportNameConstruction { get; set; }
        public string ExportNameLocked { get; set; }
        public List<int> BuildTimeD { get; set; }
        public List<int> BuildTimeH { get; set; }
        public List<int> BuildTimeM { get; set; }
        public List<int> BuildTimeS { get; set; }
        public string BuildResource { get; set; }
        public List<int> BuildCost { get; set; }
        public List<int> TownHallLevel { get; set; }
        public List<int> TownHallLevel2 { get; set; }
        public List<int> Width { get; set; }
        public List<int> Height { get; set; }
        public string Icon { get; set; }
        public List<string> ExportNameBuildAnim { get; set; }
        public List<string> ExportNameUpgradeAnim { get; set; }
        public List<int> MaxStoredGold { get; set; }
        public List<int> MaxStoredElixir { get; set; }
        public List<int> MaxStoredDarkElixir { get; set; }
        public List<int> MaxStoredWarGold { get; set; }
        public List<int> MaxStoredWarElixir { get; set; }
        public List<int> MaxStoredWarDarkElixir { get; set; }
        public List<int> MaxStoredGold2 { get; set; }
        public List<int> MaxStoredElixir2 { get; set; }
        public int PercentageStoredGold { get; set; }
        public int PercentageStoredElixir { get; set; }
        public List<int> PercentageStoredDarkElixir { get; set; }
        public bool LootOnDestruction { get; set; }
        public bool Bunker { get; set; }
        public int Village2Housing { get; set; }
        public List<int> HousingSpace { get; set; }
        public List<int> HousingSpaceAlt { get; set; }
        public string ProducesResource { get; set; }
        public List<int> ResourcePer100Hours { get; set; }
        public List<int> ResourceMax { get; set; }
        public List<int> ResourceIconLimit { get; set; }
        public List<int> UnitProduction { get; set; }
        public bool UpgradesUnits { get; set; }
        public List<int> ProducesUnitsOfType { get; set; }
        public List<int> BoostCost { get; set; }
        public bool FreeBoost { get; set; }
        public List<int> Hitpoints { get; set; }
        public List<int> RegenTime { get; set; }
        public int AttackRange { get; set; }
        public bool AltAttackMode { get; set; }
        public int AltAttackRange { get; set; }
        public int PrepareSpeed { get; set; }
        public int AttackSpeed { get; set; }
        public int AltAttackSpeed { get; set; }
        public int CoolDownOverride { get; set; }
        public List<int> DPS { get; set; }
        public List<int> AltDPS { get; set; }
        public List<int> Damage { get; set; }
        public string PreferredTarget { get; set; }
        public int PreferredTargetDamageMod { get; set; }
        public bool RandomHitPosition { get; set; }
        public List<string> DestroyEffect { get; set; }
        public List<string> DestroyDamageEffect { get; set; }
        public List<string> AttackEffect { get; set; }
        public List<string> AttackEffect2 { get; set; }
        public int ChainAttackDistance { get; set; }
        public string AttackEffectAlt { get; set; }
        public List<string> HitEffect { get; set; }
        public List<string> Projectile { get; set; }
        public List<string> AltProjectile { get; set; }
        public List<string> ExportNameDamaged { get; set; }
        public int BuildingW { get; set; }
        public int BuildingH { get; set; }
        public int BaseGfx { get; set; }
        public List<string> ExportNameBase { get; set; }
        public bool AirTargets { get; set; }
        public bool GroundTargets { get; set; }
        public bool AltAirTargets { get; set; }
        public bool AltGroundTargets { get; set; }
        public bool AltMultiTargets { get; set; }
        public int AmmoCount { get; set; }
        public string AmmoResource { get; set; }
        public List<int> AmmoCost { get; set; }
        public int MinAttackRange { get; set; }
        public int DamageRadius { get; set; }
        public int PushBack { get; set; }
        public List<bool> WallCornerPieces { get; set; }
        public string LoadAmmoEffect { get; set; }
        public string NoAmmoEffect { get; set; }
        public string ToggleAttackModeEffect { get; set; }
        public string PickUpEffect { get; set; }
        public string PlacingEffect { get; set; }
        public bool CanNotSellLast { get; set; }
        public List<string> DefenderCharacter { get; set; }
        public List<int> DefenderCount { get; set; }
        public List<int> DefenderZ { get; set; }
        public List<int> AltDefenderZ { get; set; }
        public List<int> DestructionXP { get; set; }
        public bool Locked { get; set; }
        public int StartingHomeCount { get; set; }
        public bool Hidden { get; set; }
        public string AOESpell { get; set; }
        public string AOESpellAlternate { get; set; }
        public int TriggerRadius { get; set; }
        public List<string> ExportNameTriggered { get; set; }
        public string AppearEffect { get; set; }
        public bool ForgesSpells { get; set; }
        public bool ForgesMiniSpells { get; set; }
        public bool IsHeroBarrack { get; set; }
        public string HeroType { get; set; }
        public bool IncreasingDamage { get; set; }
        public List<int> DPSLv2 { get; set; }
        public List<int> DPSLv3 { get; set; }
        public List<int> DPSMulti { get; set; }
        public List<int> Lv2SwitchTime { get; set; }
        public List<int> Lv3SwitchTime { get; set; }
        public List<string> AttackEffectLv2 { get; set; }
        public List<string> AttackEffectLv3 { get; set; }
        public string TransitionEffectLv2 { get; set; }
        public string TransitionEffectLv3 { get; set; }
        public List<int> AltNumMultiTargets { get; set; }
        public bool PreventsHealing { get; set; }
        public List<int> StrengthWeight { get; set; }
        public int AlternatePickNewTargetDelay { get; set; }
        public List<string> AltBuildResource { get; set; }
        public int SpeedMod { get; set; }
        public int StatusEffectTime { get; set; }
        public List<int> ShockwavePushStrength { get; set; }
        public int ShockwaveArcLength { get; set; }
        public int ShockwaveExpandRadius { get; set; }
        public int TargetingConeAngle { get; set; }
        public int AimRotateStep { get; set; }
        public bool PenetratingProjectile { get; set; }
        public int PenetratingRadius { get; set; }
        public int PenetratingExtraRange { get; set; }
        public int TurnSpeed { get; set; }
        public bool NeedsAim { get; set; }
        public bool TargetGroups { get; set; }
        public int TargetGroupsRadius { get; set; }
        public string HitSpell { get; set; }
        public int HitSpellLevel { get; set; }
        public string ExportNameBeamStart { get; set; }
        public string ExportNameBeamEnd { get; set; }
        public int Damage2 { get; set; }
        public int Damage2Radius { get; set; }
        public int Damage2Delay { get; set; }
        public int Damage2Min { get; set; }
        public int Damage2FalloffStart { get; set; }
        public int Damage2FalloffEnd { get; set; }
        public string HitEffect2 { get; set; }
        public int WakeUpSpeed { get; set; }
        public int WakeUpSpace { get; set; }
        public string PreAttackEffect { get; set; }
        public bool ShareHeroCombatData { get; set; }
        public int BurstCount { get; set; }
        public int BurstDelay { get; set; }
        public int AltBurstCount { get; set; }
        public int AltBurstDelay { get; set; }
        public int DummyProjectileCount { get; set; }
        public List<int> DieDamage { get; set; }
        public int DieDamageRadius { get; set; }
        public string DieDamageEffect { get; set; }
        public int DieDamageDelay { get; set; }
        public bool IsRed { get; set; }
        public int VillageType { get; set; }
        public string WallBlockX { get; set; }
        public string WallBlockY { get; set; }
        public int RedMul { get; set; }
        public int GreenMul { get; set; }
        public int BlueMul { get; set; }
        public int RedAdd { get; set; }
        public int GreenAdd { get; set; }
        public int BlueAdd { get; set; }
        public List<int> DefenceTroopCount { get; set; }
        public string DefenceTroopCharacter { get; set; }
        public string DefenceTroopCharacter2 { get; set; }
        public List<int> DefenceTroopLevel { get; set; }
        public List<int> AmountCanBeUpgraded { get; set; }
        public bool SelfAsAoeCenter { get; set; }
        public int NewTargetAttackDelay { get; set; }
        public string GearUpBuilding { get; set; }
        public int GearUpLevelRequirement { get; set; }
        public string GearUpResource { get; set; }
        public List<int> GearUpCost { get; set; }
        public List<int> GearUpTime { get; set; }
        public string GearUpTID { get; set; }
        public int StartUpgradeBoosterCost { get; set; }

        public ResourceData GetAltBuildResource(int level) => CSVManager.DataTables.GetResourceByName(AltBuildResource[level]);

        public override int GetBuildCost(int level) => BuildCost[level];

        public string GetBuildingClass() => BuildingClass;

        public override ResourceData GetBuildResource(int level) => CSVManager.DataTables.GetResourceByName(BuildResource[level]);

        public override int GetConstructionTime(int level) => BuildTimeS[level] + BuildTimeM[level] * 60 + BuildTimeH[level] * 60 * 60 + BuildTimeD[level] * 60 * 60 * 24;

        public List<int> GetMaxStoredResourceCounts(int level)
        {
            var maxStoredResourceCounts = new List<int>();
            var resourceDataTable = CSVManager.DataTables.GetTable(2);
            for (var i = 0; i < resourceDataTable.GetItemCount(); i++)
            {
                var value = 0;
                var resourceData = (ResourceData) resourceDataTable.GetItemAt(i);
                var propertyName = "MaxStored" + resourceData.GetName();
                if (GetType().GetProperty(propertyName) != null)
                {
                    var obj = GetType().GetProperty(propertyName).GetValue(this, null);
                    value = ((List<int>) obj)[level];
                }
                maxStoredResourceCounts.Add(value);
            }
            return maxStoredResourceCounts;
        }

        public override int GetRequiredTownHallLevel(int level) => TownHallLevel[level] - 1;

        public override int GetGearUpTime(int level) => this.GearUpTime[level] * 60;

        public int GetUnitProduction(int level) => UnitProduction[level];

        public int GetUnitStorageCapacity(int level) => HousingSpace[level];
        public int GetAltUnitStorageCapacity(int level) => HousingSpaceAlt[level];

        public override int GetUpgradeLevelCount() => BuildCost.Count;

        public bool IsSpellForge() => ForgesSpells || ForgesMiniSpells;

        public bool IsAllianceCastle() => Name == "AllianceCastle";

        public override bool IsTownHall() => BuildingClass == "Town Hall";
        public override bool IsTownHall2() => BuildingClass == "Town Hall2";

        public bool IsWorkerBuilding() => BuildingClass == "Worker";
        pubic bool IsWorker2Bulding()
=>BuildingClass == "Worker2";

    }
}
