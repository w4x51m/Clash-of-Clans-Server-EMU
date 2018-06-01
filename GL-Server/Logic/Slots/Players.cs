namespace GL.Servers.CoC.Logic.Slots
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;

    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using GL.Servers.Extensions;
    using GL.Servers.Logic.Enums;

    using GL.Servers.CoC.Core;
    using GL.Servers.CoC.Core.Database;
    using GL.Servers.CoC.Core.Database.Models;

    using GL.Servers.CoC.Extensions.Json;

    internal class Players : ConcurrentDictionary<long, Player>
    {
        internal JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Include,
            NullValueHandling = NullValueHandling.Ignore,
            PreserveReferencesHandling = PreserveReferencesHandling.All,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.None,
            Converters = new List<JsonConverter> {new FloatConverter()}
        };

        internal int Seed;

        internal object Gate = new object();
        internal object GateAdd = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="Players"/> class.
        /// </summary>
        internal Players()
        {
            this.Seed = MySQL_Backup.GetPlayerSeed() + 1;
        }

        /// <summary>
        /// Adds the specified player.
        /// </summary>
        /// <param name="Player">The player.</param>
        internal void Add(Player Player)
        {
            if (this.ContainsKey(Player.PlayerID))
            {
                if (!this.TryUpdate(Player.PlayerID, Player, Player))
                {
                    // Debug.WriteLine("[*] " + this.GetType().Name + " : " + "Unsuccessfuly updated the specified player to the dictionnary.");
                }
            }
            else
            {
                if (!this.TryAdd(Player.PlayerID, Player))
                {
                    Debug.WriteLine("[*] " + this.GetType().Name + " : " + "Unsuccessfuly added the specified player to the dictionnary.");
                }
            }
        }

        /// <summary>
        /// Removes the specified player.
        /// </summary>
        /// <param name="Player">The player.</param>
        internal void Remove(Player Player)
        {
            Player TmpPlayer;

            if (this.ContainsKey(Player.PlayerID))
            {
                if (!this.TryRemove(Player.PlayerID, out TmpPlayer))
                {
                    Debug.WriteLine("[*] " + this.GetType().Name + " : " + "Unsuccessfuly removed the specified player from the dictionnary.");
                }
            }

            if (Player.Chat != null)
            {
                Player.Chat.Quit(Player);
            }

            this.Save(Player);
        }

        /// <summary>
        /// Gets the player using the specified identifier in the specified database.
        /// </summary>
        /// <param name="HighID">The high identifier.</param>
        /// <param name="LowID">The low identifier.</param>
        /// <param name="DBMS">The DBMS.</param>
        /// <param name="Store">if set to <c>true</c> [store].</param>
        internal Player Get(int HighID, int LowID, DBMS DBMS = Constants.Database, bool Store = true)
        {
            if (!this.ContainsKey((long) HighID<< 32 | (long)(uint) LowID))
            {
                Player Player = null;

                switch (DBMS)
                {
                    case DBMS.MySQL:
                    {
                        using (GCS_MySQL Database = new GCS_MySQL())
                        {
                            Core.Database.Models.Players Data = Database.Players.Find(HighID, LowID);

                            if (Data != null)
                            {
                                if (!string.IsNullOrEmpty(Data.Data))
                                {
                                    Player = JsonConvert.DeserializeObject<Player>(Data.Data, this.Settings);

                                    if (Store)
                                    {
                                        this.Add(Player);
                                    }
                                }
                            }
                        }

                        break;
                    }

                    case DBMS.Redis:
                    {
                        string Data = Redis.Players.StringGet(HighID + "-" + LowID).ToString();
                        Console.WriteLine(Data);
                        if (!string.IsNullOrEmpty(Data))
                        {
                            Player = JsonConvert.DeserializeObject<Player>(Data, this.Settings);

                            if (Store)
                            {
                                this.Add(Player);
                            }
                        }

                        break;
                    }

                    case DBMS.Both:
                    {
                        Player = this.Get(HighID, LowID, DBMS.Redis, Store);

                        if (Player == null)
                        {
                            Player = this.Get(HighID, LowID, DBMS.MySQL, Store);

                            if (Player != null)
                            {
                                this.Save(Player, DBMS.Redis);
                            }
                        }

                        break;
                    }

                    case DBMS.File:
                    {
                        if (File.Exists(Directory.GetCurrentDirectory() + "\\Saves\\Players\\" + HighID + "-" + LowID + ".json"))
                        {
                            string JSON = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Saves\\Players\\" + HighID + "-" + LowID + ".json");

                            if (!string.IsNullOrWhiteSpace(JSON))
                            {
                                Player = JsonConvert.DeserializeObject<Player>(JSON, this.Settings);
                            }
                        }

                        break;
                    }
                }

                return Player;
            }

            return this[LowID];
        }

        /// <summary>
        /// Creates a new player using the specified identifier in the specified database.
        /// </summary>
        /// <param name="HighID">The high identifier.</param>
        /// <param name="LowID">The low identifier.</param>
        /// <param name="DBMS">The DBMS.</param>
        /// <param name="Store">if set to <c>true</c> [store].</param>
        internal Player New(int HighID = Constants.ServerID, int LowID = 0, DBMS DBMS = Constants.Database, bool Store = true)
        {
            Player Player = null;

            if (LowID == 0)
            {
                lock (this.Gate)
                {
                    Player = new Player(null, HighID, this.Seed++);
                }
            }
            else
            {
                Player = new Player(null, HighID, LowID);
            }

            JsonConvert.PopulateObject(Files.Home.Starting_Home, Player.Objects, this.Settings);

            for (int i = 0; i < 20; i++)
            {
                char Letter = (char) Core.Resources.Random.Next('A', 'Z');
                Player.Token = Player.Token + Letter;
            }

            switch (DBMS)
            {
                case DBMS.MySQL:
                {
                    using (GCS_MySQL Database = new GCS_MySQL())
                    {
                        Database.Players.Add(new Core.Database.Models.Players
                        {
                            HighID = Player.HighID,
                            LowID = Player.LowID,
                            Data = JsonConvert.SerializeObject(Player, this.Settings)
                        });

                        Database.SaveChangesAsync();
                    }

                    if (Store)
                    {
                        this.Add(Player);
                    }

                    break;
                }

                case DBMS.Redis:
                {
                    this.Save(Player, DBMS);

                    if (Store)
                    {
                        this.Add(Player);
                    }

                    break;
                }

                case DBMS.Both:
                {
                    this.Save(Player, DBMS);

                    using (GCS_MySQL Database = new GCS_MySQL())
                    {
                        Database.Players.Add(new Core.Database.Models.Players
                        {
                            HighID = Player.HighID,
                            LowID = Player.LowID,
                            Data = JsonConvert.SerializeObject(Player, this.Settings)
                        });

                        Database.SaveChangesAsync();
                    }

                    if (Store)
                    {
                        this.Add(Player);
                    }

                    break;
                }

                case DBMS.File:
                {
                    if (!File.Exists(Directory.GetCurrentDirectory() + "\\Saves\\Players\\" + Player + ".json"))
                    {
                        File.WriteAllText(Directory.GetCurrentDirectory() + "\\Saves\\Players\\" + Player + ".json", JsonConvert.SerializeObject(Player, this.Settings));
                    }

                    break;
                }
            }

            return Player;
        }

        /// <summary>
        /// Saves the specified player in the specified database.
        /// </summary>
        /// <param name="Player">The player.</param>
        /// <param name="DBMS">The DBMS.</param>
        internal void Save(Player Player, DBMS DBMS = Constants.Database)
        {
            switch (DBMS)
            {
                case DBMS.MySQL:
                {
                    using (GCS_MySQL Database = new GCS_MySQL())
                    {
                        Core.Database.Models.Players Data = Database.Players.Find(Player.HighID, Player.LowID);

                        if (Data != null)
                        {
                            Data.HighID = Player.HighID;
                            Data.LowID = Player.LowID;
                            Data.Data = JsonConvert.SerializeObject(Player, this.Settings);
                        }

                        Database.SaveChangesAsync();
                    }

                    break;
                }

                case DBMS.Redis:
                {
                    Redis.Players.StringSetAsync(Player.ToString(), JsonConvert.SerializeObject(Player, this.Settings), TimeSpan.FromMinutes(30));
                    break;
                }

                case DBMS.Both:
                {
                    this.Save(Player, DBMS.MySQL);
                    this.Save(Player, DBMS.Redis);
                    break;
                }

                case DBMS.File:
                {
                    File.WriteAllText(Directory.GetCurrentDirectory() + "\\Saves\\Players\\" + Player + ".json", JsonConvert.SerializeObject(Player, this.Settings));
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
            Player[] Players = this.Values.ToArray();

            Parallel.ForEach(Players, Player =>
            {
                try
                {
                    this.Save(Player, DBMS);
                }
                catch (Exception Exception)
                {
                    Core.Resources.Logger.Error(Exception, "Did not successed to save a player at shutdown.");
                }
            });

            Core.Resources.Logger.Info("Saved " + Players.Length + " players.");
            Console.WriteLine("Saved " + Players.Length + " players.");
        }

        /// <summary>
        /// Gets the random <see cref="Player"/>.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Limit">The limit.</param>
        internal List<Player> GetRandom(int Limit = 50)
        {
            List<Player> Players = new List<Player>(Limit);
            DbSqlQuery<Core.Database.Models.Players> SqlPlayers;

            using (GCS_MySQL MySQL = new GCS_MySQL())
            {
                SqlPlayers = MySQL.Players.SqlQuery("SELECT * FROM Players ORDER BY rand() LIMIT " + Limit);

                if (SqlPlayers != null)
                {
                    if (SqlPlayers.Any())
                    {
                        foreach (Core.Database.Models.Players Data in SqlPlayers)
                        {
                            if (!this.ContainsKey((long) Data.HighID << 32 | (long)(uint) Data.LowID))
                            {
                                if (!string.IsNullOrEmpty(Data.Data))
                                {
                                    Player Player = new Player();

                                    JsonConvert.PopulateObject(Data.Data, Player, this.Settings);

                                    if (Player.NameSetted)
                                    {
                                        Players.Add(Player);
                                        this.Add(Player);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return Players;
        }
    }
}