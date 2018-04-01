using System.Collections.Generic;

namespace GL.Servers.CoC.Files.CSV_Logic
{
    using GL.Servers.CoC.Files.CSV_Helpers;
    using GL.Servers.Files.CSV_Reader;

    internal class Village_Objects : Data
    {
        public Village_Objects(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Data.LoadData(this, this.GetType(), Row);
        }

        public string Name { get; set; }
        public bool Disabled { get; set; }
        public string TID { get; set; }
        public string InfoTID { get; set; }
        public string SWF { get; set; }
        public string ExportName { get; set; }
        public int TileX100 { get; set; }
        public int TileY100 { get; set; }
        public int RequiredTH { get; set; }
        public bool AutomaticUpgrades { get; set; }
        public List<int> BuildTimeD { get; set; }
        public List<int> BuildTimeH { get; set; }
        public List<int> BuildTimeM { get; set; }
        public List<int> BuildTimeS { get; set; }
        public bool RequiresBuilder { get; set; }
        public string BuildResource { get; set; }
        public List<int> BuildCost { get; set; }
        public List<int> TownHallLevel { get; set; }
        public string PickUpEffect { get; set; }
        public string Animations { get; set; }
        public int AnimX { get; set; }
        public int AnimY { get; set; }
        public int AnimID { get; set; }
        public int AnimDir { get; set; }
        public int AnimVisibilityOdds { get; set; }
        public bool HasInfoScreen { get; set; }
        public int VillageType { get; set; }
        public int UnitHousing { get; set; }
        public bool HousesUnits { get; set; }
        public bool AllianceBuilding { get; set; }

        public override int GetUpgradeLevelCount() => 2;
        public override int GetConstructionTime(int level)
        {
            int Total_Time = 0;
            if (BuildTimeD.Length > level + 1)
                Total_Time += BuildTimeD[level] * 86400;
            if (BuildTimeH.Length > level + 1)
                Total_Time += BuildTimeH[level] * 3600;
            if (BuildTimeM.Length > level + 1)
                Total_Time += BuildTimeM[level] * 60;
            if (BuildTimeS.Length > level + 1)
                Total_Time += BuildTimeS[level];


            return Total_Time;
            //return BuildTimeS[level] + BuildTimeM[level] * 60 + BuildTimeH[level] * 60 * 60 + BuildTimeD[level] * 60 * 60 * 24;
        }

        public override int GetRequiredTownHallLevel(int level) => TownHallLevel[level] - 1;
        public override Resource GetBuildResource(int level) => CSV.Tables.Get(Gamefile.Resources).GetData(BuildResource) as Resource;
        public override int GetBuildCost(int level) => BuildCost;

    }
}
