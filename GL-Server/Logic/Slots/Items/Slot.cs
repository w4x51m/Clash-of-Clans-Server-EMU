namespace GL.Servers.CoC.Logic.Slots.Items
{
    using Newtonsoft.Json;

    internal class Slot
    {
        [JsonProperty("id")]  internal int ID;
        [JsonProperty("cnt")] internal int Count;

        /// <summary>
        /// Initializes a new instance of the <see cref="Slot"/>
        /// </summary>
        internal Slot()
        {
            // Slot.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Slot"/> class.
        /// </summary>
        /// <param name="ID">The id.</param>
        /// <param name="Count">The count.</param>
        internal Slot(int ID, int Count)
        {
            this.ID    = ID;
            this.Count = Count;
        }
    }
}