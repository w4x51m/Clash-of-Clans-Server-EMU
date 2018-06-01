namespace GL.Servers.CoC.Files.CSV_Logic
{
    using GL.Servers.CoC.Files.CSV_Helpers;
    using GL.Servers.Files.CSV_Reader;

    internal class Tasks : Data
    {
        public Tasks(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Data.LoadData(this, this.GetType(), Row);
        }

        public string Name { get; set; }
        public string TaskType { get; set; }
        public string ProgressType { get; set; }
        public string Set { get; set; }
        public string TID { get; set; }
        public string InfoTID { get; set; }
        public string IconSWF { get; set; }
        public string IconExportName { get; set; }
        public int Score { get; set; }
        public int DurationMinutes { get; set; }
        public int Quantity { get; set; }
        public int Quantity2 { get; set; }
        public string Data1 { get; set; }
        public string Data2 { get; set; }
        public int SelectionWeight { get; set; }
        public int MinLeague { get; set; }
        public int MaxLeague { get; set; }
        public bool Disabled { get; set; }
    }
}
