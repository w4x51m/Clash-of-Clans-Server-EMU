namespace GL.Servers.CoC.Files.CSV_Logic
{
    using GL.Servers.CoC.Files.CSV_Helpers;
    using GL.Servers.Files.CSV_Reader;

    internal class Calendar_Event_Functions : Data
    {
        public Calendar_Event_Functions(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Data.LoadData(this, this.GetType(), Row);
        }

        public string Name { get; set; }
        public string ParameterType { get; set; }
        public string ParameterName { get; set; }
        public string Description { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public bool TargetingSupported { get; set; }
        public string Category { get; set; }
        public bool Deprecated { get; set; }
    }
}
