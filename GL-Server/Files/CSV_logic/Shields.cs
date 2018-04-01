namespace GL.Servers.CoC.Files.CSV_Logic
{
    using GL.Servers.CoC.Files.CSV_Helpers;
    using GL.Servers.Files.CSV_Reader;

    internal class Shields : Data
    {
        public Shields(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Data.LoadData(this, this.GetType(), Row);
        }

        public string Name { get; set; }
        public string TID { get; set; }
        public string InfoTID { get; set; }
        public int TimeH { get; set; }
        public int GuardTimeH { get; set; }
        public int Diamonds { get; set; }
        public string IconSWF { get; set; }
        public string IconExportName { get; set; }
        public int CooldownS { get; set; }
        public int LockedAboveScore { get; set; }
    }
}
