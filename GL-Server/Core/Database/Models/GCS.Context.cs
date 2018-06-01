namespace GL.Servers.CoC.Core.Database.Models
{
    using System.Data.Entity;

    using MySql.Data.Entity;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    internal class GCS_MySQL : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GCS_MySQL"/> class.
        /// </summary>
        internal GCS_MySQL() : base("name=GCS_MySQL")
        {
            // GCS_MySQL
        }

        /// <summary>
        /// Gets or sets the clans.
        /// </summary>
        public virtual DbSet<Clans> Clans
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the players.
        /// </summary>
        public virtual DbSet<Players> Players
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the streams.
        /// </summary>
        public virtual DbSet<Streams> Streams
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the leagues.
        /// </summary>
        public virtual DbSet<Leagues> Leagues
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the wars.
        /// </summary>
        public virtual DbSet<Wars> Wars
        {
            get;
            set;
        }
    }
}
