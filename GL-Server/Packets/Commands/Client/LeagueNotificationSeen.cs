﻿namespace GL.Servers.CoC.Packets.Commands.Client
{
    using GL.Servers.CoC.Logic;
    using GL.Servers.Extensions.Binary;

    internal class LeagueNotificationSeen : Command
    {
        public LeagueNotificationSeen(Reader Reader, Device Device, int Identifier) : base(Reader, Device, Identifier)
        {
            
        }

        internal override void Decode()
        {
            this.Debug();
        }

        internal override void Process()
        {
            base.Process();
        }
    }
}