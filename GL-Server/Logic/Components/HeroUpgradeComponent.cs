namespace GL.Servers.CoC.Logic.Components
{
    using Newtonsoft.Json;

    internal class HeroUpgradeComponent
    {
        internal Objects Objects;

        [JsonProperty("level")] internal int Level;
        [JsonProperty("t")]     internal float? Time;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeroUpgradeComponent"/>
        /// </summary>
        internal HeroUpgradeComponent()
        {
            // HeroUpgradeComponent.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeroUpgradeComponent"/>
        /// </summary>
        /// <param name="Objects">The objects class.</param>
        internal HeroUpgradeComponent(Objects Objects)
        {
            this.Objects = Objects;
        }

        /// <summary>
        /// Executed when a construction task has been completed.
        /// </summary>
        internal void ConstructionEnded()
        {
            
        }

        /// <summary>
        /// Refreshes the specified time.
        /// </summary>
        /// <param name="Time">The time.</param>
        internal void Refresh(float Time)
        {
            if (this.Time.HasValue)
            {
                this.Time -= Time;

                if (this.Time <= 0f)
                {
                    this.ConstructionEnded();

                    this.Time = null;
                }
            }
        }
    }
}
