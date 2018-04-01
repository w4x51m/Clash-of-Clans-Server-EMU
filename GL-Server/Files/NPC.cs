using GL.Servers.CoC.Files.CSV_Logic;
using GL.Servers.CoC.Logic.Enums;

namespace GL.Servers.CoC.Files
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class NPC
    {
        /// <summary>
        ///     A Dictionary of levels which can be loaded and used.
        /// </summary>
        internal static readonly Dictionary<int, string> Levels = new Dictionary<int, string>();

        /// <summary>
        ///     Initialize a new instance of the <see cref="NPC" /> class.
        /// </summary>
        internal NPC()
        {
            foreach (Npcs Npc in CSV.Tables.Get(Gamefile.Npcs).Datas)
            {
                NPC.Levels.Add(Npc.GlobalID, File.ReadAllText(@"Gamefiles/" + Npc.LevelFile));
            }

            Console.WriteLine(NPC.Levels.Count + " NPC Files, loaded and stored in memory.\n");
        }
    }
}