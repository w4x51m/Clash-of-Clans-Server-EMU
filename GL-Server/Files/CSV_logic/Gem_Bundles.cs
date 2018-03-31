namespace GL.Servers.CoC.Files.CSV_Logic
{
    using GL.Servers.CoC.Files.CSV_Helpers;
    using GL.Servers.Files.CSV_Reader;

    internal class Gem_Bundles : Data
    {
        public Gem_Bundles(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Data.LoadData(this, this.GetType(), Row);
        }

        public string Name { get; set; }
        public int LinkedPackageID { get; set; }  
        public string BillingPackage { get; set; }  
        public string TID { get; set; }  
        public string InfoTID { get; set; }
        public bool Disabled { get; set; }
        public bool ExistsApple { get; set; }  
        public bool ExistsAndroid { get; set; }
        public bool ExistsKunlun { get; set; }  
        public bool ExistsBazaar { get; set; }
        public bool ExistsTencent { get; set; }
        public string IconSWF { get; set; }
        public string IconExportName { get; set; }
        public string ShopItemExportName { get; set; }
        public string ShopItemInfoExportName { get; set; }
        public string ShopItemBG { get; set; }
        public int TownhallLimitMin { get; set; }
        public int TownhallLimitMax { get; set; }
        public int VillageType { get; set; }
        public string Buildings { get; set; }
        public int GemCost { get; set; }
        public string BuildingType { get; set; }
        public int BuildingNumber { get; set; }
        public int BuildingLevel { get; set; }
        public string UnlocksTroop { get; set; }
        public string TroopType { get; set; }
        public int GiftGems { get; set; }
        public int GiftUsers { get; set; }
        public string Resources { get; set; }
        public int ResourceAmounts { get; set; }
        public bool ResourceAmountFromThCSV { get; set; }
        public int THResourceMultiplier { get; set; }
        public bool RED { get; set; }
        public int Priority { get; set; }
        public bool FrontPageItem { get; set; }
        public bool TreasureItem { get; set; }
        public string ReplacesBillingPackage { get; set; }
        public string ValueTID { get; set; }
        public int ValueForUI { get; set; }
        public int AvailableTimeMinutes { get; set; }
        public int CooldownAfterPurchaseMinutes { get; set; }
        public int TimesCanBePurchased { get; set; }
        public int ShopFrontPageCooldownAfterPurchaseMin { get; set; }
        public bool HideTimer { get; set; }
    }
}
