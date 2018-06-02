namespace GL.Servers.CoC.Packets
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    using GL.Servers.CoC.Extensions.List;
    using GL.Servers.CoC.Logic;
    using GL.Servers.Extensions;
    using GL.Servers.Extensions.Binary;

    public class Command
    {
        internal int Identifier;
        internal int Tick;

        internal Reader Reader;
        internal Device Device;

        internal List<byte> Data;

        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        internal Command(Device Device)
        {
            this.Device     = Device;
            this.Data       = new List<byte>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="Reader">The reader.</param>
        /// <param name="Device">The device.</param>
        /// <param name="Identifier">The identifier.</param>
        internal Command(Reader Reader, Device Device, int Identifier)
        {
            this.Identifier = Identifier;
            this.Device     = Device;
            this.Reader     = Reader;

            this.Data       = new List<byte>();
        }

        /// <summary>
        /// Decodes this instance.
        /// </summary>
        internal virtual void Decode()
        {
            // Decode.
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        internal virtual void Encode()
        {
            // Encode.
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        internal virtual void Process()
        {
            // Process.
        }

        /// <summary>
        /// Debugs this instance.
        /// </summary>
        internal void Debug()
        {
            Console.WriteLine(this.GetType().Name + " : " + BitConverter.ToString(this.Reader.ReadBytes((int) (this.Reader.BaseStream.Length - this.Reader.BaseStream.Position))));
        }

        /// <summary>
        /// Shows the values.
        /// </summary>
        internal void ShowValues()
        {
            Console.WriteLine(Environment.NewLine);

            foreach (FieldInfo Field in this.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (Field != null)
                {
                    Console.WriteLine(ConsolePad.Padding(this.GetType().Name) + " - " + ConsolePad.Padding(Field.Name) + " : " + ConsolePad.Padding(!string.IsNullOrEmpty(Field.Name) ? (Field.GetValue(this) != null ? Field.GetValue(this).ToString() : "(null)") : "(null)", 40));
                }
            }
        }

        /// <summary>
        /// Logs this instance.
        /// </summary>
        internal void Log()
        {
            File.AppendAllText(Directory.GetCurrentDirectory() + "\\Logs\\" + this.GetType().Name + ".log", BitConverter.ToString(this.Reader.ReadBytes((int)(this.Reader.BaseStream.Length - this.Reader.BaseStream.Position))) + Environment.NewLine);
        }

        internal byte[] ToBytes
        {
            get
            {
                List<byte> Packet = new List<byte>();

                Packet.AddInt(this.Identifier);
                Packet.AddRange(this.Data);

                return Packet.ToArray();
            }
        }
    }
}
