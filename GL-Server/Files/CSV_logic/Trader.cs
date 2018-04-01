namespace GL.Servers.CoC.Files.CSV_Logic
{
    using GL.Servers.CoC.Files.CSV_Helpers;
    using GL.Servers.Files.CSV_Reader;

    internal class Trader : Data
    {
        public Trader(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Data.LoadData(this, this.GetType(), Row);
        }

        public string Name { get; set; }
        public string Items { get; set; }
        public int ItemAmounts { get; set; }
        public int Costs { get; set; }

        public int GetItems() => Items
    }
}
