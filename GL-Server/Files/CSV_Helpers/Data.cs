namespace GL.Servers.CoC.Files.CSV_Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using GL.Servers.Files.CSV_Reader;

    using Newtonsoft.Json;

    internal class Data
    {
        internal DataTable DataTable;
        internal Row Row;

        [JsonProperty("id")] internal readonly int ID;

        /// <summary>
        /// Initializes a new instance of the <see cref="Data"/> class.
        /// </summary>
        /// <param name="Row">The row.</param>
        /// <param name="DataTable">The data table.</param>
        internal Data(Row Row, DataTable DataTable)
        {
            this.Row = Row;
            this.DataTable = DataTable;
            this.ID = DataTable.Datas.Count + 1000000 * DataTable.Index;
        }

        internal int Type
        {
            get
            {
                return this.DataTable.Index;
            }
        }

        internal int GlobalID
        {
            get
            {
                return this.ID;
            }
        }

        internal static void LoadData(Data Data, Type Type, Row Row)
        {
            foreach (PropertyInfo Property in Type.GetProperties())
            {
                if (Property.PropertyType.IsGenericType)
                {
                    Type ListType = typeof(List<>);
                    Type[] Generic = Property.PropertyType.GetGenericArguments();
                    Type ConcreteType = ListType.MakeGenericType(Generic);
                    object NewList = Activator.CreateInstance(ConcreteType);
                    MethodInfo Add = ConcreteType.GetMethod("Add");
                    string IndexerName = ((DefaultMemberAttribute) NewList.GetType().GetCustomAttributes(typeof(DefaultMemberAttribute), true)[0]).MemberName;
                    PropertyInfo IndexProperty = NewList.GetType().GetProperty(IndexerName);

                    for (int i = Row.Offset; i < Row.Offset + Row.GetArraySize(Property.Name); i++)
                    {
                        string Value = Row.GetValue(Property.Name, i - Row.Offset);

                        if (Value == string.Empty && i != Row.Offset)
                        {
                            Value = IndexProperty.GetValue(NewList, new object[]
                            {
                                i - Row.Offset - 1
                            }).ToString();
                        }

                        if (string.IsNullOrEmpty(Value))
                        {
                            object Object = Generic[0].IsValueType ? Activator.CreateInstance(Generic[0]) : string.Empty;

                            Add.Invoke(NewList, new[]
                            {
                                Object
                            });
                        }
                        else
                        {
                            Add.Invoke(NewList, new[]
                            {
                                Convert.ChangeType(Value, Generic[0])
                            });
                        }
                    }

                    Property.SetValue(Data, NewList);
                }
                else
                {
                    Property.SetValue(Data, Row.GetValue(Property.Name, 0) == string.Empty ? null : Convert.ChangeType(Row.GetValue(Property.Name, 0), Property.PropertyType), null);
                }
            }
        }

        internal int GetID()
        {
            return CSV_Helpers.GlobalID.GetID(this.ID);
        }
    }
}
