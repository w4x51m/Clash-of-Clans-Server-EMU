using System.Collections.Generic;

namespace GL.Servers.CoC.Core.Network
{
    using GL.Servers.CoC.Packets;

    internal static class Processor
    {
        /// <summary>
        /// Recepts the specified message.
        /// </summary>
        /// <param name="Message">The message.</param>
        internal static void Recept(this Message Message)
        {
            Message.Decrypt();
            Message.Decode();
            Message.Process();
        }

        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="Message">The message.</param>
        internal static void Send(this Message Message)
        {
            Message.Encode();
            Message.Encrypt();

            Logging.Error(typeof(Processor), "Packet " + Message.Identifier + " sent to " + Message.Device.Socket.RemoteEndPoint + ".");

            Resources.Gateway.Send(Message);

            Message.Process();
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="Command">The command.</param>
        internal static Command Handle(this Command Command)
        {
            Command.Encode();

            return Command;
        }
    }
}
