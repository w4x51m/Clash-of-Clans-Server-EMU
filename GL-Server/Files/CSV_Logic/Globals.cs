namespace GL.Servers.CoC.Files.CSV_Logic
{
    using System.Collections.Generic;

    using GL.Servers.CoC.Files.CSV_Helpers;
    using GL.Servers.Files.CSV_Reader;

    internal class Globals : Data
    {
        public Globals(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Data.LoadData(this, this.GetType(), Row);
        }

        public string Name { get; set; }
        public int NumberValue { get; set; }
        public bool BooleanValue { get; set; }
        public string TextValue { get; set; }
        public List<int> NumberArray { get; set; }
        public List<int> AltNumberArray { get; set; }
        public List<string> StringArray { get; set; }
        public List<string> AltStringArray { get; set; }
    }
}
