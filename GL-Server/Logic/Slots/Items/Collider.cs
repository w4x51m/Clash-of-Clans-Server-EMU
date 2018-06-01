using System;

namespace GL.Servers.CoC.Logic.Slots.Items
{
    internal class Collider
    {
        internal Objects Objects;
        internal int[][] Map;

        /// <summary>
        /// Initializes a new instance of the <see cref="Collider"/>.
        /// </summary>
        /// <param name="Objects"></param>
        internal Collider(Objects Objects)
        {
            this.Objects = Objects;
            this.Map     = new int[50][];

            for (int i = 0; i < 50; i++)
            {
                this.Map[i] = new int[50];
            }
        }

        /// <summary>
        /// Move object.
        /// </summary>
        /// <param name="oldX">Old object x position.</param>
        /// <param name="oldY">Old object y position.</param>
        /// <param name="x">New object x position.</param>
        /// <param name="y">New object y position.</param>
        /// <param name="width">Object width size.</param>
        /// <param name="height">Object height size.</param>
        /// <param name="ID">Object unique identifier.</param>
        /// <returns></returns>
        internal bool Move(int oldX, int oldY, int x, int y, int width, int height, int ID)
        {
            for (int x_pos = 0; x_pos < width; x_pos++)
            {
                for (int y_pos = 0; y_pos < height; y_pos++)
                {
                    if (this.Map[x + x_pos][y + y_pos] == 0 || this.Map[x + x_pos][y + y_pos] == ID)
                    {
                        this.Map[oldX + x_pos][oldY + y_pos]    = 0;
                        this.Map[x + x_pos][y + y_pos]          = ID;
                    }
                    else
                    {
                        Console.WriteLine("Collision with : " + this.Map[x + x_pos][y + y_pos]);
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Set object position without check collision.
        /// </summary>
        /// <param name="x">New object x position.</param>
        /// <param name="y">New object y position.</param>
        /// <param name="width">Object width size.</param>
        /// <param name="height">Object height size.</param>
        /// <param name="ID">Object unique identifier.</param>
        internal void Set(int x, int y, int width, int height, int ID)
        {
            for (int x_pos = 0; x_pos < width; x_pos++)
            {
                for (int y_pos = 0; y_pos < height; y_pos++)
                {
                    this.Map[x + x_pos][y + y_pos] = ID;
                }
            }
        }

        /// <summary>
        /// Return if x and y position is free.
        /// </summary>
        /// <param name="x">New object x position.</param>
        /// <param name="y">New object y position.</param>
        /// <returns>is free.</returns>
        internal bool isFree(int x, int y)
        {
            return this.Map[x][y] == 0;
        }
    }
}
