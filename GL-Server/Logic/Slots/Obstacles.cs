namespace GL.Servers.CoC.Logic.Slots
{
    using System.Collections.Generic;
    
    using GL.Servers.CoC.Files;
    using GL.Servers.CoC.Logic.Enums;
    using GL.Servers.CoC.Logic.Slots.Items;

    internal class Obstacles : Dictionary<int, Obstacle>
    {
        internal Objects Objects;

        internal int Seed;

        internal bool isMap2;

        /// <summary>
        /// Initializes a new instance of the <see cref="Obstacles"/>
        /// </summary>
        internal Obstacles()
        {
            // Buildings
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Obstacles"/>
        /// </summary>
        /// <param name="Objects">The objects class.</param>
        internal Obstacles(Objects Objects, bool isMap2 = false)
        {
            this.Objects = Objects;
            this.isMap2  = isMap2;
        }

        /// <summary>
        /// Synchronizes this instance.
        /// </summary>
        internal void Synchronize()
        {
            this.Seed = 503000000;

            foreach (KeyValuePair<int, Obstacle> Obstacle in this)
            {
                Obstacle.Value.ID  = Obstacle.Key;
                Obstacle.Value.Csv = CSV.Tables.Get(Gamefile.Obstacles).GetDataWithID(Obstacle.Value.Data) as Files.CSV_Logic.Obstacles;

                if (Obstacle.Value.ClearTime.HasValue)
                {
                    Obstacle.Value.ClearTime = (int) Obstacle.Value.ClearTime;
                }

                if (this.isMap2)
                {
                    this.Objects.Collider2.Set(Obstacle.Value.X, Obstacle.Value.Y, Obstacle.Value.Csv.Width, Obstacle.Value.Csv.Height, Obstacle.Value.ID);
                }
                else
                {
                    this.Objects.Collider.Set(Obstacle.Value.X, Obstacle.Value.Y, Obstacle.Value.Csv.Width, Obstacle.Value.Csv.Height, Obstacle.Value.ID);
                }

                this.Seed++;
            }
        }

        /// <summary>
        /// Refreshes the <see cref="Obstacle"/>.
        /// </summary>
        /// <param name="Tick">The time</param>
        internal void Refresh(float Tick)
        {
            foreach (KeyValuePair<int, Obstacle> Obstacle in this)
            {
                Obstacle.Value.Refresh(Tick);
            }
        }
    }
}