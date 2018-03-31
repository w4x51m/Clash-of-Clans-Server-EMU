namespace GL.Servers.CoC.Logic
{
    using System;
    using System.Net.Sockets;

    using GL.Servers.CoC.Core.Network;
    using GL.Servers.CoC.Packets;

    using GL.Servers.Core;
    using GL.Servers.Logic.Enums;
    using GL.Servers.Library;
    using GL.Servers.Extensions;
    using GL.Servers.CoC.Core;
    using GL.Servers.Extensions.Binary;

    internal class Device
    {
        internal Socket Socket;
        internal Player Player;
        internal Token Token;

        internal XorShift Random;
        internal Rjindael Crypto;

        internal bool Android;
        internal bool Advertising;
        internal bool CanProcessed = true;

        internal int Seed;
        internal int CryptoSeed;

        internal float Tick;
        internal double Timestamp;

        internal string Interface;
        internal string AndroidID;
        internal string OpenUDID;
        internal string Model;
        internal string OSVersion;
        internal string MACAddress;
        internal string AdvertiseID;
        internal string VendorID;

        internal State State = State.DISCONNECTED;

        /// <summary>
        /// Initializes a new instance of the <see cref="Device"/> class.
        /// </summary>
        /// <param name="_Socket">The socket.</param>
        internal Device(Socket Socket)
        {
            this.Socket     = Socket;
            this.Crypto     = new Rjindael();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Device"/> class.
        /// </summary>
        /// <param name="Socket">The socket.</param>
        /// <param name="Token">The token.</param>
        internal Device(Socket Socket, Token Token)
        {
            this.Socket     = Socket;
            this.Token      = Token;
            this.Crypto     = new Rjindael();
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Device"/> is connected.
        /// </summary>
        /// <value>
        ///   True if connected, false if disconnected.
        /// </value>
        internal bool Connected
        {
            get
            {
                if (this.Socket.Connected)
                {
                    return true;

                    try
                    {
                        if (!this.Socket.Poll(1000, SelectMode.SelectRead) || this.Socket.Available != 0)
                        {
                            return true;
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Gets the operating system of this instance.
        /// </summary>
        internal string OS
        {
            get
            {
                return this.Android ? "Android" : "iOS";
            }
        }

        /// <summary>
        /// Processes the specified buffer.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        internal void Process(byte[] Buffer)
        {
            if (Buffer.Length >= 7 && Buffer.Length <= Constants.ReceiveBuffer && this.CanProcessed)
            {
                using (Reader Reader = new Reader(Buffer))
                {
                    ushort Identifier   = Reader.ReadUInt16();
                    uint Length         = Reader.ReadUInt24();
                    ushort Version      = Reader.ReadUInt16();

                    Logging.Error(this.GetType(), "Packet " + Identifier + " received from " + this.Socket.RemoteEndPoint + ".");

                    if (Buffer.Length - 7 >= Length)
                    {
                        if (Factory.Messages.ContainsKey(Identifier))
                        {
                            Message Message = Activator.CreateInstance(Factory.Messages[Identifier], this, Reader) as Message;

                            Message.Identifier  = Identifier;
                            Message.Length      = Length;
                            Message.Version     = Version;

                            Message.Reader      = Reader;

                            try
                            {
                                Message.Decrypt();
                                Message.Decode();
                                Message.Process();
                            }
                            catch (Exception Exception)
                            {
                                Resources.Sentry.Catch(Exception, this.Model, this.OS, this.OSVersion);
                                Resources.Logger.Error(Exception, "We got an error (" + Exception.GetType().Name + ") when handling the following message : ID " + Identifier + ", Length " + Length + ", Version " + Version + ".");
                                System.Diagnostics.Debug.WriteLine(ConsolePad.Padding(Exception.GetType().Name, 15) + " : " + Exception.Message + ". [" + (this.Player != null ? this.Player.HighID + ":" + this.Player.LowID : "---") + ']' + Environment.NewLine + Exception.StackTrace);
                            }
                        }
                        else
                        {
                            Resources.Logger.Debug(this.GetType().Name + " : " + "We can't handle the following message : ID " + Identifier + ", Length " + Length + ", Version " + Version + ".");

                            byte[] AltBuffer = Reader.ReadBytes((int)Length);
                            this.Crypto.Decrypt(ref AltBuffer);
                            AltBuffer = null;
                        }

                        if (!this.Token.Aborting)
                        {
                            this.Token.Packet.RemoveRange(0, (int)(Length + 7));

                            if (Buffer.Length - 7 - Length >= 7)
                            {
                                this.Process(Reader.ReadBytes((int)(Buffer.Length - 7 - Length)));
                            }
                        }
                    }
                    else
                    {
                        Resources.Gateway.Disconnect(this.Token.Args);
                    }
                }
            }
            else
            {
                Resources.Gateway.Disconnect(this.Token.Args);
            }
        }

        /// <summary>
        /// Refreshes the objects.
        /// </summary>
        /// <param name="Tick">The tick.</param>
        /// <returns></returns>
        internal bool Refresh(int Tick)
        {
            if (Tick >= (int) (this.Tick * 62.5f + 0.5f))
            {
                this.Timestamp += Tick / 62.5f - this.Tick;

                if (Resources.ServerTime + 1 > (int) this.Timestamp)
                {
                    if (this.State == State.LOGGED)
                    {
                        this.Player.Objects.Refresh(Tick / 62.5f - this.Tick);
                    }
                    
                    this.Tick = Tick / 62.5f;

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="Device"/> class.
        /// </summary>
        ~Device()
        {
            if (!this.Token.Aborting)
            {
                Resources.Gateway.Disconnect(this.Token.Args);
            }

            this.Crypto = null;
            this.Random = null;
            this.Socket = null;

            GC.SuppressFinalize(this);
        }
    }
}