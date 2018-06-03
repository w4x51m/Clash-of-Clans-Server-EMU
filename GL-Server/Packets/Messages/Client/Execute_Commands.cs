using GL.Servers.CoC.Core.Network;
using GL.Servers.CoC.Packets.Messages.Server;

namespace GL.Servers.CoC.Packets.Messages.Client
{
    using GL.Servers.CoC.Core;
    using GL.Servers.CoC.Logic;
    using GL.Servers.Extensions.Binary;

    using System;
    using System.Collections.Generic;

    internal class Execute_Commands : Message
    {
        internal uint Tick;
        internal uint Checksum;
        internal uint Count;

        internal byte[] Commands;

        internal List<Command> Historic;

        /// <summary>
        /// Initializes a new instance of the <see cref="Execute_Commands"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Reader">The reader.</param>
        public Execute_Commands(Device Device, Reader Reader) : base(Device, Reader)
        {
            // Execute_Commands.
        }

        /// <summary>
        /// Decodes the <see cref="Message" />, using the <see cref="Reader" /> instance.
        /// </summary>
        internal override void Decode()
        {
            this.Tick       = this.Reader.ReadUInt32();
            this.Checksum   = this.Reader.ReadUInt32();
            this.Count      = this.Reader.ReadUInt32();

            if (this.Count > 0)
            {
                if (this.Count <= 512)
                {
                    this.Commands = this.Reader.ReadBytes((int)(this.Reader.BaseStream.Length - this.Reader.BaseStream.Position));
                    this.Historic = new List<Command>((int)this.Count);
                }
                else
                {
                    Resources.Logger.Error(this.GetType().Name + " : Player " + this.Device.Player + " sent more commands than authorized : " + this.Count + ".");
                }
            }
        }

        /// <summary>
        /// Processes this message.
        /// </summary>
        internal override void Process()
        {
            if (this.Count > 0 && this.Count <= 512)
            {
                using (Reader Reader = new Reader(this.Commands))
                {
                    for (int i = 0; i < this.Count; i++)
                    {
                        ushort CommandID = (ushort) Reader.ReadInt32();

                        if (Factory.Commands.ContainsKey(CommandID))
                        {
                            Command Command = Activator.CreateInstance(Factory.Commands[CommandID], Reader, this.Device, CommandID) as Command;

                            Command.Decode();

                            if (Command.Identifier >= 700 && Command.Identifier < 800)
                            {
                                if (this.Device.Player.Battle != null)
                                {
                                    this.Device.Player.Battle.Process(Command);
                                }
                                else
                                {
                                    new Server_Error(this.Device, $"Execute command failed! Command is only allowed in attack state.").Send();

                                    return;
                                }
                            }
                            else if (this.Device.Refresh(Command.Tick))
                            {
                                Command.Process();
                            }
                            else
                            {
                                new Server_Error(this.Device, $"Execute command failed! Command should have been executed already. (type={Command.Identifier} server_tick={(int)(this.Device.Tick * 62.5f + 0.5f)} command_tick={Command.Tick})").Send();

                                return;
                            }

                            this.Historic.Add(Command);
                        }
                        else
                        {
                            Console.WriteLine("Command " + CommandID + " is not handled. [" + (i + 1) + "/" + this.Count + "] " + (this.Historic.Count > 0 ? "Last command was " + this.Historic[i - 1].GetType().Name : string.Empty));
                            break;
                        }
                    }
                }

                this.Historic = null;
            }

            if (!this.Device.Refresh((int)this.Tick))
            {
                new Server_Error(this.Device, $"Execute command failed! Execute sub tick was not found!").Send();
            }
        }
    }
}