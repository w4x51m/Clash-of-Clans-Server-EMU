using GL.Servers.CoC.Files;
using GL.Servers.CoC.Logic.Enums;
using GL.Servers.Files;
using Newtonsoft.Json;

namespace GL.Servers.CoC.Packets.Messages.Client
{
    using GL.Servers.CoC.Core;
    using GL.Servers.CoC.Logic;
    using GL.Servers.CoC.Packets.Messages.Server;
    using GL.Servers.CoC.Core.Network;

    using GL.Servers.Extensions.Binary;
    using GL.Servers.Logic.Enums;
    using GL.Servers.Core;

    using System;

    internal class Authentification : Message
    {
        internal int HighID;
        internal int LowID;

        internal string Token;
        internal string MasterHash;
        internal string Region;

        internal int Major;
        internal int Minor;
        internal int Revision;

        /// <summary>
        /// Initializes a new instance of the <see cref="Authentification"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Reader">The reader.</param>
        public Authentification(Device Device, Reader Reader) : base(Device, Reader)
        {
            this.Device.State = State.LOGIN;
        }

        /// <summary>
        /// Decodes this message.
        /// </summary>
        internal override void Decode()
        {
            try
            {
                this.HighID             = this.Reader.ReadInt32();
                this.LowID              = this.Reader.ReadInt32();
                
                this.Token              = this.Reader.ReadString();

                this.Major              = this.Reader.ReadInt32();
                this.Revision           = this.Reader.ReadInt32();
                this.Minor              = this.Reader.ReadInt32();

                this.MasterHash         = this.Reader.ReadString();

                this.Reader.Seek(4);

                this.Device.AndroidID   = this.Reader.ReadString();
                this.Device.MACAddress  = this.Reader.ReadString();
                this.Device.Model       = this.Reader.ReadString();

                this.Reader.Seek(4);

                this.Region             = this.Reader.ReadString();
                this.Device.OpenUDID    = this.Reader.ReadString();
                this.Device.OSVersion   = this.Reader.ReadString();

                this.Device.Android     = this.Reader.ReadBoolean();

                this.Reader.Seek(4);

                this.Device.AndroidID   = this.Reader.ReadString();

                this.Reader.ReadByte();
                this.Reader.ReadInt32();

                this.Reader.ReadString();

                this.Device.CryptoSeed  = this.Reader.ReadInt32();

                this.Reader.Seek(9);

                this.Reader.ReadString();
            }
            catch (Exception Exception)
            {
                Resources.Logger.Error(Exception, this.GetType().Name + " : " + "Client " + this.Device.Socket.RemoteEndPoint + " sent a misconstructed Authentification packet.");
            }
        }

        /// <summary>
        /// Processes this message.
        /// </summary>
        internal override void Process()
        {
            Console.WriteLine(this.Major);
            Console.WriteLine(this.Minor);
            Console.WriteLine(this.Revision);

            if (this.Trusted())
            {
                if (this.LowID == 0)
                {
#if CHRONO
                    this.Chrono         = new Performance();
#endif

                    this.Device.Player = Resources.Players.New();

#if CHRONO
                    this.TimeTaken      = this.Chrono.Stop();

                    if (this.TimeTaken.TotalSeconds > 1.0)
                    {
                        Debug.WriteLine("[*] " + this.GetType().Name + " : " + "Took " + this.TimeTaken.TotalSeconds + " seconds to create a new player.");
                    }
#endif

                    if (this.Device.Player != null)
                    {
                        this.Login();
                    }
                    else
                    {
                        new Authentification_Failed(this.Device, Reason.Pause).Send();
                    }
                }
                else if (this.LowID > 0)
                {
                    if (this.HighID == Constants.ServerID)
                    {
                        this.Device.Player = Resources.Players.Get(this.HighID, this.LowID);

                        if (this.Device.Player != null)
                        {
                            //if (string.Equals(this.Token, this.Device.Player.Token))
                            {
                                //if (this.Device.Player.Objects.NextBreak <= 0f)
                                //{
                                //    if (DateTime.UtcNow.Subtract(this.Device.Player.Objects.EndSession).TotalMinutes >= 15)
                                //    {
                                //        this.Device.Player.Objects.NextBreak = 14400;
                                //    }
                                //    else
                                //    {
                                //        new Authentification_Failed(this.Device, Reason.Pause).Send();

                                //        return;
                                //    }
                                //}

                                this.Login();
                            }
                            /*else
                            {
                                new Authentification_Failed(this.Device, Reason.Reset).Send();
                            }*/
                        }
                        else
                        {
                            new Authentification_Failed(this.Device, Reason.Reset).Send();
                        }
                    }
                    else new Authentification_Failed(this.Device, Reason.Redirection).Send();
                }
                else
                {
                    Resources.Logger.Error(this.GetType().Name + " : " + "Client tried to login with a low id inferior to 0. | LowID = " + this.LowID);
                }
            }
        }

        internal bool Trusted()
        {
            if (this.Major == (int) CVersion.Major && this.Minor == (int) CVersion.Minor)
            {
                if (!Constants.Maintenance)
                {
                    if (!string.Equals(this.MasterHash, Fingerprint.Sha))
                    {
                        //new Authentification_Failed(this.Device, Reason.Patch).Send();

                        return true;
                    }

                    return true;
                }
                else
                {
                    new Authentification_Failed(this.Device, Reason.Maintenance).Send();
                }
            }
            else
            {
                new Authentification_Failed(this.Device, Reason.Update).Send();
            }

            return false;
        }

        /// <summary>
        /// Logins this instance.
        /// </summary>
        internal void Login()
        {
            this.Device.Random        = new XorShift();
            this.Device.Player.Device = this.Device;

            if (this.Device.Player.Chat == null)
            {
                Resources.Chats.Join(this.Device.Player);
            }

            if (!string.IsNullOrEmpty(this.Region))
            {
                this.Device.Player.Region = this.Region.ToUpper();
            }

            System.Diagnostics.Debug.WriteLine("[*] Request " + this.HighID + "-" + this.LowID + ".");
            System.Diagnostics.Debug.WriteLine("[*] Player " + this.Device.Player + " is signing in.");
            System.Diagnostics.Debug.WriteLine("[*] Token : " + this.Device.Player.Token + ".");

            new Session_Key(this.Device).Send();
            new Authentification_OK(this.Device).Send();
            new Own_Home_Data(this.Device).Send();

            if (this.Device.Player.ClanLowID > 0)
            {
#if CHRONO
                this.Chrono     = new Performance();
#endif

                Clan Alliance = Resources.Clans.Get(this.Device.Player.ClanHighID, this.Device.Player.ClanLowID);

#if CHRONO
                this.TimeTaken  = this.Chrono.Stop();

                if (this.TimeTaken.TotalSeconds > 1.0)
                {
                    Debug.WriteLine("[*] " + this.GetType().Name + " : " + "Took " + this.TimeTaken.TotalSeconds + " seconds to get a clan.");
                }
#endif

                if (Alliance != null)
                {
                    new ClanStream(this.Device, Alliance).Send();
                }
                else
                {
                    Resources.Logger.Error(this.GetType().Name + " : " + "Failed to get the clan " + this.Device.Player.ClanHighID + "-" + this.Device.Player.ClanLowID + " stream data, clan was not found in databases.");
                }
            }
        }
    }
}