namespace GL.Servers.CoC.Files.CSV_Logic
{
    using GL.Servers.CoC.Files.CSV_Helpers;
    using GL.Servers.Files.CSV_Reader;

    internal class Regions : Data
    {
        public Regions(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Data.LoadData(this, this.GetType(), Row);
        }

        public string Name { get; set; }
        public string TID { get; set; }
        public string DisplayName { get; set; }
        public bool IsCountry { get; set; }
        public bool HS { get; set; }
    }
}
