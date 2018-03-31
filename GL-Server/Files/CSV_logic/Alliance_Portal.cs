namespace GL.Servers.CoC.Files.CSV_Logic
{
    using GL.Servers.CoC.Files.CSV_Helpers;
    using GL.Servers.Files.CSV_Reader;

    internal class Alliance_Portal : Data
    {
        public Alliance_Portal(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Data.LoadData(this, this.GetType(), Row);
        }

        public string Name { get; set; }
        public string TID { get; set; }
        public string SWF { get; set; }
        public string ExportName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int VillageType { get; set; }
    }
}
