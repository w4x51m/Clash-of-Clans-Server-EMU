namespace GL.Servers.CoC.Logic.Slots
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Threading.Tasks;

    using GL.Servers.CoC.Core;
    using GL.Servers.CoC.Core.Database;
    using GL.Servers.CoC.Core.Database.Models;
    using GL.Servers.Logic.Enums;

    using Newtonsoft.Json;

    internal class Clans : Dictionary<int, Clan>
    {
        internal JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            TypeNameHandling            = TypeNameHandling.Auto,            MissingMemberHandling   = MissingMemberHandling.Ignore,
            DefaultValueHandling        = DefaultValueHandling.Include,     NullValueHandling       = NullValueHandling.Ignore,
            PreserveReferencesHandling  = PreserveReferencesHandling.All,   ReferenceLoopHandling   = ReferenceLoopHandling.Ignore,
            Formatting                  = Formatting.None
        };

        internal int Seed;
        internal object Gate            = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="Clans"/> class.
        /// </summary>
        internal Clans()
        {
            this.Seed = MySQL_Backup.GetClanSeed() + 1;

            this.GetRange();
        }

        /// <summary>
        /// Adds the specified clan.
        /// </summary>
        /// <param name="Clan">The clan.</param>
        internal void Add(Clan Clan)
        {
            lock (this.Gate)
            {
                if (this.ContainsKey(Clan.LowID))
                {
                    this[Clan.LowID] = Clan;
                }
                else
                {
                    this.Add(Clan.LowID, Clan);
                }
            }
        }

        /// <summary>
        /// Removes the specified clan.
        /// </summary>
        /// <param name="Clan">The clan.</param>
        internal void Remove(Clan Clan)
        {
            lock (this.Gate)
            {
                if (this.ContainsKey(Clan.LowID))
                {
                    this.Remove(Clan.LowID);
                }
            }

            this.Save(Clan);
        }

        /// <summary>
        /// Gets the clan using the specified identifier in the specified database.
        /// </summary>
        /// <param name="HighID">The high identifier.</param>
        /// <param name="LowID">The low identifier.</param>
        /// <param name="DBMS">The DBMS.</param>
        /// <param name="Store">if set to <c>true</c> [store].</param>
        internal Clan Get(int HighID, int LowID, DBMS DBMS = Constants.Database, bool Store = true)
        {
            if (!this.ContainsKey(LowID))
            {
                Clan Clan = null;

                switch (DBMS)
                {
                    case DBMS.MySQL:
                    {
                        using (GCS_MySQL Database = new GCS_MySQL())
                        {
                            Core.Database.Models.Clans Data = Database.Clans.Find(HighID, LowID);

                            if (Data != null)
                            {
                                if (!string.IsNullOrEmpty(Data.Data))
                                {
                                    Clan = new Clan(HighID, LowID);

                                    JsonConvert.PopulateObject(Data.Data, Clan, this.Settings);

                                    if (Store)
                                    {
                                        this.Add(Clan);
                                    }
                                }
                            }
                        }

                        break;
                    }

                    case DBMS.Redis:
                    {
                        string Data = Redis.Clans.StringGet(HighID + "-" + LowID).ToString();

                        if (!string.IsNullOrEmpty(Data))
                        {
                            Clan = new Clan(HighID, LowID);

                            JsonConvert.PopulateObject(Data, Clan, this.Settings);

                            if (Store)
                            {
                                this.Add(Clan);
                            }
                        }

                        break;
                    }

                    case DBMS.Both:
                    {
                        Clan = this.Get(HighID, LowID, DBMS.Redis, Store);

                        if (Clan == null)
                        {
                            Clan = this.Get(HighID, LowID, DBMS.MySQL, Store);

                            if (Clan != null)
                            {
                                this.Save(Clan, DBMS.Redis);
                            }
                        }

                        break;
                    }
                }

                return Clan;
            }

            return this[LowID];
        }

        /// <summary>
        /// Gets the range.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Limit">The limit.</param>
        internal List<Clan> GetRange(int Offset = 0, int Limit = 50, bool Store = true)
        {
            List<Clan> Clans = new List<Clan>(Limit - Offset);
            DbSqlQuery<Core.Database.Models.Clans> SqlClans;

            using (GCS_MySQL MySQL = new GCS_MySQL())
            {
                SqlClans = MySQL.Clans.SqlQuery("SELECT * FROM Clans LIMIT " + Offset + ", " + Limit + ";");

                if (SqlClans != null)
                {
                    if (SqlClans.Any())
                    {
                        foreach (Core.Database.Models.Clans Data in SqlClans)
                        {
                            if (!string.IsNullOrEmpty(Data.Data))
                            {
                                Clan Clan = new Clan(Data.HighID, Data.LowID);

                                JsonConvert.PopulateObject(Data.Data, Clan, this.Settings);

                                if (Store) // && Clan.Members.Count > 0)
                                {
                                    this.Add(Clan);
                                }

                                Clans.Add(Clan);
                            }
                        }
                    }
                }
            }

            return Clans;
        }

        /// <summary>
        /// Creates a clan with the specified identifier in the specified database.
        /// </summary>
        /// <param name="HighID">The high identifier.</param>
        /// <param name="LowID">The low identifier.</param>
        /// <param name="DBMS">The DBMS.</param>
        /// <param name="Store">if set to <c>true</c> [store].</param>
        internal Clan New(int HighID = Constants.ServerID, int LowID = 0, DBMS DBMS = Constants.Database, bool Store = true)
        {
            Clan Clan;

            if (LowID == 0)
            {
                lock (this.Gate)
                {
                    Clan = new Clan(HighID, this.Seed++);
                }
            }
            else
            {
                Clan = new Clan(HighID, LowID);
            }

            switch (DBMS)
            {
                case DBMS.MySQL:
                {
                    using (GCS_MySQL Database = new GCS_MySQL())
                    {
                        // lock (Clan.Members.Gate)
                        {
                            Database.Clans.Add(new Core.Database.Models.Clans
                            {
                                HighID  = Clan.HighID,
                                LowID   = Clan.LowID,
                                Data    = JsonConvert.SerializeObject(Clan, this.Settings)
                            });
                        }

                        Database.SaveChangesAsync();
                    }

                    if (Store)
                    {
                        this.Add(Clan);
                    }

                    break;
                }

                case DBMS.Redis:
                {
                    // lock (Clan.Members.Gate)
                    {
                        Redis.Clans.StringSetAsync(Clan.ToString(), JsonConvert.SerializeObject(Clan, this.Settings), TimeSpan.FromMinutes(30));
                    }

                    if (Store)
                    {
                        this.Add(Clan);
                    }

                    break;
                }

                case DBMS.Both:
                {
                    this.New(Clan.HighID, Clan.LowID, DBMS.MySQL, Store);
                    this.New(Clan.HighID, Clan.LowID, DBMS.Redis, Store);
                    break;
                }
            }

            return Clan;
        }

        /// <summary>
        /// Creates a clan with the specified identifier in the specified database.
        /// </summary>
        /// <param name="Clan">The clan.</param>
        /// <param name="DBMS">The DBMS.</param>
        /// <param name="Store">if set to <c>true</c> [store].</param>
        internal Clan New(Clan Clan, DBMS DBMS = Constants.Database, bool Store = true)
        {
            if (Clan.LowID == 0)
            {
                lock (this.Gate)
                {
                    Clan.LowID = this.Seed++;
                }
            }

            switch (DBMS)
            {
                case DBMS.MySQL:
                {
                    using (GCS_MySQL Database = new GCS_MySQL())
                    {
                        // lock (Clan.Members.Gate)
                        {
                            Database.Clans.Add(new Core.Database.Models.Clans
                            {
                                HighID  = Clan.HighID,
                                LowID   = Clan.LowID,
                                Data    = JsonConvert.SerializeObject(Clan, this.Settings)
                            });
                        }

                        Database.SaveChangesAsync();
                    }

                    if (Store)
                    {
                        this.Add(Clan);
                    }

                    break;
                }

                case DBMS.Redis:
                {
                    // lock (Clan.Members.Gate)
                    {
                        Redis.Clans.StringSetAsync(Clan.ToString(), JsonConvert.SerializeObject(Clan, this.Settings), TimeSpan.FromMinutes(30));
                    }

                    if (Store)
                    {
                        this.Add(Clan);
                    }

                    break;
                }

                case DBMS.Both:
                {
                    this.New(Clan, DBMS.Redis, Store);
                    this.New(Clan, DBMS.MySQL, Store);
                    break;
                }
            }

            return Clan;
        }

        /// <summary>
        /// Saves the specified clan in the specified database.
        /// </summary>
        /// <param name="Clan">The clan.</param>
        /// <param name="DBMS">The DBMS.</param>
        internal void Save(Clan Clan, DBMS DBMS = Constants.Database)
        {
            switch (DBMS)
            {
                case DBMS.MySQL:
                {
                    using (GCS_MySQL Database = new GCS_MySQL())
                    {
                        Core.Database.Models.Clans Data = Database.Clans.Find(Clan.HighID, Clan.LowID);

                        if (Data != null)
                        {
                            // lock (Clan.Members.Gate)
                            {
                                Data.Data = JsonConvert.SerializeObject(Clan, this.Settings);
                            }
                        }

                        Database.SaveChangesAsync();
                    }

                    break;
                }

                case DBMS.Redis:
                {
                    // lock (Clan.Members.Gate)
                    {
                        Redis.Clans.StringSetAsync(Clan.ToString(), JsonConvert.SerializeObject(Clan, this.Settings), TimeSpan.FromMinutes(30));
                    }

                    break;
                }

                case DBMS.Both:
                {
                    this.Save(Clan, DBMS.MySQL);
                    this.Save(Clan, DBMS.Redis);
                    break;
                }
            }
        }

        /// <summary>
        /// Saves the specified DBMS.
        /// </summary>
        /// <param name="DBMS">The DBMS.</param>
        internal void Save(DBMS DBMS = Constants.Database)
        {
            Clan[] Clans = this.Values.ToArray();

            Parallel.ForEach(Clans, Clan =>
            {
                try
                {
                    this.Save(Clan, DBMS);
                }
                catch (Exception Exception)
                {
                    Core.Resources.Logger.Error(Exception, "Did not successed to save the clan " + Clan + " at shutdown.");
                }
            });

            Core.Resources.Logger.Info("Saved " + Clans.Length + " clans.");
            Console.WriteLine("Saved " + Clans.Length + " clans.");
        }
    }
}