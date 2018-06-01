namespace GL.Servers.CoC.Core
{
    using System;

    using GL.Servers.Logic.Enums;

    internal class Constants
    {
        /// <summary>
        /// The unique server identifier, used to partition the database.
        /// </summary>
        internal const int ServerID             = 0;

        /// <summary>
        /// If set to true, the server will only accept authorized ip's.
        /// </summary>
        internal const bool Local               = true;

        /// <summary>
        /// The length of the buffer used to send packets.
        /// </summary>
        internal const int SendBuffer           = 2048 * 1;

        /// <summary>
        /// The length of the buffer used to receive packets.
        /// </summary>
        internal const int ReceiveBuffer        = 2048 * 1;

        /// <summary>
        /// The maximum of players we can handle at same time.
        /// </summary>
        internal const int MaxPlayers           = 1000 * 30;

        /// <summary>
        /// The maximum of send operation the program can process.
        /// </summary>
        internal const int MaxSends             = 1000 * 5;

        /// <summary>
        /// Whether we should save/find player in <see cref="Redis"/>, <see cref="MySQL"/>, or both.
        /// </summary>
        internal const DBMS Database            = DBMS.MySQL;

        /// <summary>
        /// Whether the server is in maintenance mode or not.
        /// </summary>
        internal const bool Maintenance = false;

        internal static DateTime MaintenanceTime
        {
            get
            {
                return DateTime.UtcNow.AddDays(1);
            }
        }

        internal const bool UseSentry           = false;

        internal const string SentryAPI         = "4e81bcef18ec47258f3b9c65b0a581f6:85b2e8ef43d7483a9606f14a8e0b186a";

        internal const string SentryID          = "172976";

        internal const bool PacketCompression   = true;

        internal const bool Live                = true;
        internal const bool Replay              = true;
        internal const bool CheckTick           = true;
        internal const bool DebugMode           = true;
        internal const bool DebugResearch       = false;

        internal const bool LimitLength         = true;
        internal const bool IgnoreRegion        = false;

        internal const bool FinderBoost         = true;

        internal const double FinderSpeed       = 150;
        internal const double FinderBoostSpeed  = 25;

        /// <summary>
        /// The IP Address authorized to log in the server even if it's in maintenance.
        /// </summary>
        internal static string[] AuthorizedIP =
        {
            "88.189.197.11",
            "212.195.92.120",
        };
    }
}
