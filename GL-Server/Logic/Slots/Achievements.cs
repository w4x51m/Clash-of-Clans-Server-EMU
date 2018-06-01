namespace GL.Servers.CoC.Logic.Slots
{
    using System.Collections.Generic;

    internal class Achievements : List<int>
    {
        internal Player Player;

        /// <summary>
        /// Initializes a new instance of the <see cref="Achievements"/>.
        /// </summary>
        internal Achievements()
        {
            // Achievements.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Achievements"/>.
        /// </summary>
        /// <param name="Player">The player.</param>
        internal Achievements(Player Player)
        {
            this.Player = Player;
        }

        internal bool Add(int ID)
        {
            if (!this.Contains(ID))
            {
                base.Add(ID);

                return true;
            }

            return false;
        }
    }
}
