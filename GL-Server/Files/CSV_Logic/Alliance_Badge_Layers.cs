namespace GL.Servers.CoC.Files.CSV_Logic
{
    using GL.Servers.CoC.Files.CSV_Helpers;
    using GL.Servers.Files.CSV_Reader;

    internal class Alliance_Badge_Layers : Data
    {
        public Alliance_Badge_Layers(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Data.LoadData(this, this.GetType(), Row);
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string SWF { get; set; }
        public string ExportName { get; set; }
        public int RequiredClanLevel { get; set; }
    }
}
