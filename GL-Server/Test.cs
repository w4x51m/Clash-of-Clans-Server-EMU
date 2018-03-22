namespace GL.Servers.CoC
{
    using System;
    using System.Text;

    using GL.Servers.CoC.Extensions.List;
    using GL.Servers.Library.ZLib;

    internal class Test
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Test"/> class.
        /// </summary>
        internal Test()
        {

        }

        internal void Uncompress(string Hexa)
        {
            byte[] Buffer = ZlibStream.UncompressBuffer(Hexa.HexaToBytes());
            Console.WriteLine("Uncompressed : " + Encoding.UTF8.GetString(Buffer));
        }
    }
}