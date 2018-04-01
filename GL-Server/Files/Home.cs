namespace GL.Servers.CoC.Files
{
    using System.IO;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    using GL.Servers.CoC.Logic.Slots.Items;

    using Newtonsoft.Json;

    internal class Home
    {
        internal static string Starting_Home = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Home"/> class.
        /// </summary>
        internal Home()
        {
            if (Directory.Exists("Gamefiles/level/"))
            {
                if (File.Exists("Gamefiles/level/starting_home.json"))
                {
                    Home.Starting_Home = File.ReadAllText("Gamefiles/level/starting_home.json", Encoding.UTF8);
                    Home.Starting_Home = Regex.Replace(Home.Starting_Home, "(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+", "$1");

                    this.Populate();
                }
            }
        }

        /// <summary>
        /// Populates this instance.
        /// </summary>
        internal void Populate()
        {
            Logic.Objects Standart  = new Logic.Objects(null);
            Objects Json            = JsonConvert.DeserializeObject<Objects>(Starting_Home);

            int Seed = 500000000;

            foreach (Building Building in Json.buildings)
            {
                if (Building.ID < 500000000)
                {
                    Building.ID     = Seed++;
                }

                Standart.Buildings.Add(Building.ID, Building);
            }

            Seed = 503000000;
            foreach (Obstacle Obstacle in Json.obstacles)
            {
                if (Obstacle.ID < 503000000)
                {
                    Obstacle.ID     = Seed++;
                }

                Standart.Obstacles.Add(Obstacle.ID, Obstacle);
            }

            Seed = 504000000;
            foreach (Trap Trap in Json.traps)
            {
                if (Trap.ID < 504000000)
                {
                    Trap.ID         = Seed++;
                }

                Standart.Traps.Add(Trap.ID, Trap);
            }

            Seed = 506000000;
            foreach (Deco Deco in Json.decos)
            {
                if (Deco.ID < 506000000)
                {
                    Deco.ID         = Seed++;
                }

                Standart.Decos.Add(Deco.ID, Deco);
            }

            Standart.RespawnVariables = Json.RespawnVars;

            Seed = 500000000;
            foreach (Building Building in Json.buildings2)
            {
                if (Building.ID < 500000000)
                {
                    Building.ID = Seed++;
                }

                Standart.Buildings2.Add(Building.ID, Building);
            }

            Seed = 503000000;
            foreach (Obstacle Obstacle in Json.obstacles2)
            {
                if (Obstacle.ID < 503000000)
                {
                    Obstacle.ID = Seed++;
                }

                Standart.Obstacles2.Add(Obstacle.ID, Obstacle);
            }

            Seed = 504000000;
            foreach (Trap Trap in Json.traps2)
            {
                if (Trap.ID < 504000000)
                {
                    Trap.ID     = Seed++;
                }

                Standart.Traps2.Add(Trap.ID, Trap);
            }

            Seed = 506000000;
            foreach (Deco Deco in Json.decos2)
            {
                if (Deco.ID < 506000000)
                {
                    Deco.ID     = Seed++;
                }

                Standart.Decos2.Add(Deco.ID, Deco);
            }

            Home.Starting_Home  = JsonConvert.SerializeObject(Standart);
        }

        private class Objects
        {
            public List<Building> buildings;
            public List<Obstacle> obstacles;
            public List<Trap> traps;
            public List<Deco> decos;

            public RespawnVariables RespawnVars;

            public List<Building> buildings2;
            public List<Obstacle> obstacles2;
            public List<Trap> traps2;
            public List<Deco> decos2;
        }
    }
}