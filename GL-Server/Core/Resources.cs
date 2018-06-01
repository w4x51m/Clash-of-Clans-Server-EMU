namespace GL.Servers.CoC.Core
{
    using System;

    using GL.Servers.CoC.Core.Consoles;
    using GL.Servers.CoC.Core.Database;
    using GL.Servers.CoC.Core.Events;
    using GL.Servers.CoC.Core.Network;

    using GL.Servers.CoC.Extensions.Game;
    using GL.Servers.CoC.Files;
    using GL.Servers.CoC.Logic.Slots;
    using GL.Servers.CoC.Packets;

    using GL.Servers.Core;
    using GL.Servers.Core.Network;
    using GL.Servers.Files;

    using NLog;

    internal class Resources
    {
        internal static XorShift Random;

        internal static Redis Redis;
        internal static Parser Parser;
        internal static Fingerprint Fingerprint;
        internal static CSV CSV;
        internal static Home Home;
        internal static NPC Npc;
        internal static Helpers Helpers;
        internal static Timers Checker;
        internal static Test Test;
        internal static Sentry Sentry;

        internal static Cluster Cluster;
        internal static Players Players;
        internal static Clans Clans;
        internal static Battles Battles;
        internal static WorldChats Chats;
        internal static Logger Logger;

        internal static TCPServer Gateway;
        internal static UDPServer UGateway;

        internal static EventsHandler Events;

        internal static bool Started;

        internal static int ServerTime
        {
            get
            {
                return (int) DateTime.UtcNow.Subtract(new DateTime(1970, 1,1)).TotalSeconds;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Resources"/> class.
        /// </summary>
        internal static void Initialize()
        {
            Resources.Logger        = LogManager.GetCurrentClassLogger(typeof(Resources));

            Resources.Sentry        = new Sentry(Constants.SentryAPI, Constants.SentryID, Constants.UseSentry);

#if DEBUG
            Console.WriteLine("Loaded " + Factory.Messages.Count + " messages, " + Factory.Commands.Count + " commands, and " + Factory.Debugs.Count + " debug commands.");
#endif

            Resources.Redis         = new Redis();
            Resources.Parser        = new Parser();
            Resources.Fingerprint   = new Fingerprint();
            Resources.CSV           = new CSV();
            Resources.Home          = new Home();
            Resources.Npc           = new NPC();
            Resources.Helpers       = new Helpers();
            Resources.Checker       = new Timers();

            Resources.Players       = new Players();
            Resources.Clans         = new Clans();
            Resources.Battles       = new Battles();
            Resources.Chats         = new WorldChats();
            Resources.Random        = new XorShift();
            Resources.Cluster       = new Cluster();

            Resources.Test          = new Test();

            Resources.Gateway       = new TCPServer();
            Resources.UGateway      = new UDPServer();

            Resources.Events        = new EventsHandler();

            Resources.Started       = true;
        }
    }
}