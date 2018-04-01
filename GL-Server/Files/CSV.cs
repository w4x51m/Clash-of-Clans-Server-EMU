namespace GL.Servers.CoC.Files
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GL.Servers.CoC.Files.CSV_Reader;
    using GL.Servers.Files.CSV_Reader;

    internal class CSV
    {
        internal static readonly Dictionary<int, string> Gamefiles = new Dictionary<int, string>();

        internal static Gamefiles Tables;

        /// <summary>
        /// Initializes a new instance of the <see cref="CSV"/> class.
        /// </summary>
        internal CSV()
        {
            CSV.Tables = new Gamefiles();

            CSV.Gamefiles.Add(1, @"Gamefiles/logic/achievements.csv");
            CSV.Gamefiles.Add(2, @"Gamefiles/logic/alliance_badges.csv");
            CSV.Gamefiles.Add(3, @"Gamefiles/logic/alliance_badge_layers.csv");
            CSV.Gamefiles.Add(4, @"Gamefiles/logic/alliance_levels.csv");
            CSV.Gamefiles.Add(5, @"Gamefiles/logic/alliance_portal.csv");
            CSV.Gamefiles.Add(6, @"Gamefiles/logic/boosters.csv");
            CSV.Gamefiles.Add(7, @"Gamefiles/csv/buildings.csv");
            CSV.Gamefiles.Add(8, @"Gamefiles/logic/building_classes.csv");
            CSV.Gamefiles.Add(9, @"Gamefiles/logic/calendar_event_functions.csv");
            CSV.Gamefiles.Add(10, @"Gamefiles/logic/characters.csv");
            CSV.Gamefiles.Add(11, @"Gamefiles/logic/decos.csv");
            CSV.Gamefiles.Add(12, @"Gamefiles/logic/effects.csv");
            CSV.Gamefiles.Add(13, @"Gamefiles/logic/experience_levels.csv");
            CSV.Gamefiles.Add(14, @"Gamefiles/logic/gem_bundles.csv");
            CSV.Gamefiles.Add(15, @"Gamefiles/logic/globals.csv");
            CSV.Gamefiles.Add(16, @"Gamefiles/logic/heroes.csv");
            CSV.Gamefiles.Add(17, @"Gamefiles/logic/leagues.csv");
            CSV.Gamefiles.Add(18, @"Gamefiles/logic/leagues2.csv");
            CSV.Gamefiles.Add(19, @"Gamefiles/logic/locales.csv");
            CSV.Gamefiles.Add(20, @"Gamefiles/logic/missions.csv");
            CSV.Gamefiles.Add(21, @"Gamefiles/logic/npcs.csv");
            CSV.Gamefiles.Add(22, @"Gamefiles/logic/obstacles.csv");
            CSV.Gamefiles.Add(23, @"Gamefiles/logic/projectiles.csv");
            CSV.Gamefiles.Add(24, @"Gamefiles/logic/regions.csv");
            CSV.Gamefiles.Add(25, @"Gamefiles/logic/resources.csv");
            CSV.Gamefiles.Add(26, @"Gamefiles/logic/shields.csv");
            CSV.Gamefiles.Add(27, @"Gamefiles/logic/spells.csv");
            CSV.Gamefiles.Add(28, @"Gamefiles/logic/tasks.csv");
            CSV.Gamefiles.Add(29, @"Gamefiles/logic/townhall_levels.csv");
            CSV.Gamefiles.Add(30, @"Gamefiles/logic/trader.csv");
            CSV.Gamefiles.Add(31, @"Gamefiles/logic/traps.csv");
            CSV.Gamefiles.Add(32, @"Gamefiles/logic/variables");
            CSV.Gamefiles.Add(33, @"Gamefiles/logic/village_objects.csv");
            CSV.Gamefiles.Add(34, @"Gamefiles/logic/war.csv");
            CSV.Gamefiles.Add(35, @"Gamefiles/csv/animations.csv");
            CSV.Gamefiles.Add(36, @"Gamefiles/csv/billing_packages.csv");
            CSV.Gamefiles.Add(37, @"Gamefiles/csv/boombox.csv");
            CSV.Gamefiles.Add(38, @"Gamefiles/csv/client_globals.csv");
            CSV.Gamefiles.Add(39, @"Gamefiles/csv/credits.csv");
            CSV.Gamefiles.Add(40, @"Gamefiles/csv/deeplinks.csv");
            CSV.Gamefiles.Add(41, @"Gamefiles/csv/event_entries.csv");
            CSV.Gamefiles.Add(42, @"Gamefiles/csv/faq.csv");
            CSV.Gamefiles.Add(43, @"Gamefiles/csv/helpshift.csv");
            CSV.Gamefiles.Add(44, @"Gamefiles/csv/hints.csv");
            CSV.Gamefiles.Add(45, @"Gamefiles/csv/news.csv");
            CSV.Gamefiles.Add(46, @"Gamefiles/csv/particle_emitters.csv");
            CSV.Gamefiles.Add(47, @"Gamefiles/csv/resource_packs.csv");

            Parallel.ForEach(CSV.Gamefiles, File =>
            {
                if (new System.IO.FileInfo(File.Value).Exists)
                {
                    CSV.Tables.Initialize(new Table(File.Value), File.Key);
                }
            });

            Console.WriteLine("Loaded " + CSV.Gamefiles.Count + " gamefiles, and stored them in memory." + Environment.NewLine);
        }
    }
}