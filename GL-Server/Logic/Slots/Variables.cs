using System.Collections.Generic;

namespace GL.Servers.CoC.Logic.Slots
{
    using GL.Servers.CoC.Logic.Slots.Items;

    internal class Variables : List<Slot>
    {
        internal Player Player;

        internal Variables()
        {
            // Resources
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Variables"/>.
        /// </summary>
        /// <param name="Player">The player.</param>
        /// <param name="Init"></param>
        internal Variables(Player Player, bool Init = false)
        {
            this.Player = Player;

            if (Init)
            {
                this.Initialize();
            }
        }

        internal void Initialize()
        {
            base.Add(new Slot(37000001, 0));
            base.Add(new Slot(37000002, 0));
            base.Add(new Slot(37000003, 0));
            base.Add(new Slot(37000004, 0));
            base.Add(new Slot(37000005, 0));
            base.Add(new Slot(37000006, 0));
            base.Add(new Slot(37000007, 0));
            base.Add(new Slot(37000008, 0));
            base.Add(new Slot(37000009, 0));
            base.Add(new Slot(37000010, 0));
            base.Add(new Slot(37000011, 0));
            base.Add(new Slot(37000012, 0));
            base.Add(new Slot(37000013, 0));
            base.Add(new Slot(37000014, 0));
            base.Add(new Slot(37000015, 0));
            base.Add(new Slot(37000016, 0));
            base.Add(new Slot(37000017, 0));
            base.Add(new Slot(37000018, 0));
            base.Add(new Slot(37000019, 0));
            base.Add(new Slot(37000020, 0));
            base.Add(new Slot(37000021, 0));
            base.Add(new Slot(37000022, 0));
            base.Add(new Slot(37000023, 0));
        }
    }
}
