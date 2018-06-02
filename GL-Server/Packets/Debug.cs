namespace GL.Servers.CoC.Packets
{
    using GL.Servers.CoC.Logic;
    using GL.Servers.Logic.Enums;

    internal class Debug
    {
        /// <summary>
        /// Gets or sets the device.
        /// </summary>
        internal Device Device
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        internal string[] Parameters
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the required rank.
        /// </summary>
        internal Rank RequiredRank
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Debug"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Parameters">The parameters.</param>
        internal Debug(Device Device, params string[] Parameters)
        {
            this.Device         = Device;
            this.Parameters     = Parameters;
        }

        /// <summary>
        /// Decodes this instance.
        /// </summary>
        internal virtual void Decode()
        {
            // Decode.
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        /// <returns>True if success</returns>
        internal virtual bool Process()
        {
            return true;
        }
    }
}
