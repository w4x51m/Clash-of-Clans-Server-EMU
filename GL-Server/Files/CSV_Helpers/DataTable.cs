namespace GL.Servers.CoC.Files.CSV_Helpers
{
    using System.Collections.Generic;

    using GL.Servers.CoC.Files.CSV_Logic;
    using GL.Servers.Files.CSV_Reader;

    internal class DataTable
    {
        internal List<Data> Datas;
        internal int Index;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataTable"/> class.
        /// </summary>
        internal DataTable()
        {
            this.Datas = new List<Data>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataTable"/> class.
        /// </summary>
        /// <param name="Table">The table.</param>
        /// <param name="Index">The index.</param>
        internal DataTable(Table Table, int Index)
        {
            this.Index = Index;
            this.Datas = new List<Data>();

            for (int i = 0; i < Table.GetRowCount(); i++)
            {
                Row Row = Table.GetRowAt(i);
                Data Data = this.Create(Row);

                this.Datas.Add(Data);
            }
        }

        internal Data Create(Row _Row)
        {
            Data _Data;

            switch (this.Index)
            {
    }
                case 1:
                    _Data = new Achievements(_Row, this);
                    break;
                case 2:
                    _Data = new Alliance_Badges(_Row, this);
                    break;
                case 3:
                    _Data = new Alliance_Badge_Layers(_Row, this);
                    break;
                case 4:
                    _Data = new Alliance_Levels(_Row, this);
                    break;
                case 5:
                    _Data = new Alliance_Portal(_Row, this);
                    break;
                case 6:
                    _Data = new Boosters(_Row, this);
                    break;
                case 7:
                    _Data = new Buildings(_Row, this);
                    break;
                case 8:
                    _Data = new Building_Classes(_Row, this);
                    break;
                case 9:
                    _Data = new Calendar_Event_Functions(_Row, this);
                    break;
                case 10:
                    _Data = new Characters(_Row, this);
                    break;
                case 11:
                    _Data = new Decos(_Row, this);
                    break;
                case 12:
                    _Data = new Effects(_Row, this);
                    break;
                case 13:
                    _Data = new Experience_Levels(_Row, this);
                    break;
                case 14:
                    _Data = new Gem_Bundles(_Row, this);
                    break;
                case 15:
                    _Data = new Globals(_Row, this);
                    break;
                case 16:
                    _Data = new Heroes(_Row, this);
                    break;
                case 17:
                    _Data = new Leagues(_Row, this);
                    break;
                case 18:
                    _Data = new Leagues2(_Row, this);
                    break;
                case 19:
                    _Data = new Locales(_Row, this);
                    break;
                case 20:
                    _Data = new Missions(_Row, this);
                    break;
                case 21:
                    _Data = new Npcs(_Row, this);
                    break;
                case 22:
                    _Data = new Obstacles(_Row, this);
                    break;
                case 23:
                    _Data = new Projectiles(_Row, this);
                    break;
                case 24:
                    _Data = new Regions(_Row, this);
                    break;
                case 25:
                    _Data = new Resources(_Row, this);
                    break;
                case 26:
                    _Data = new Shields(_Row, this);
                    break;
                case 27:
                    _Data = new Spells(_Row, this);
                    break;
                case 28:
                    _Data = new Tasks(_Row, this);
                    break;
                case 29:
                    _Data = new Townhall_Levels(_Row, this);
                    break;
                case 30:
                    _Data = new Trader(_Row, this);
                    break;
                case 31:
                    _Data = new Traps(_Row, this);
                    break;
                case 32:
                    _Data = new Variables(_Row, this);
                    break;
                case 33:
                    _Data = new Village_Objects(_Row, this);
                    break;
                case 34:
                    _Data = new War(_Row, this);
                    break;

                // case 35: Animation
                // case 36: Boombox
                // case 37: Client_Globals
                // case 38: Credits
                // case 39: Deeplinks
                // case 40: Event_entries
                // case 41: Faq
                // case 42: Helpshift
                // case 43: Hints
                // case 44: News 
                // case 45: Particle_emitters
                // case 46: Resource_Packs


               default:
                {
                    _Data = new Data(_Row, this);
                    break;
                }
            }

            return _Data;
        }

        internal Data GetDataWithID(int ID)
        {
            int InstanceID = GlobalID.GetID(ID);
            return this.Datas[InstanceID];
        }

        internal Data GetDataWithInstanceID(int ID)
        {
            return this.Datas[ID];
        }

        internal Data GetData(string _Name)
        {
            return this.Datas.Find(_Data => _Data.Row.Name == _Name);
        }
    }
}