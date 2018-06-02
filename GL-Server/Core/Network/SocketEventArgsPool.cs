namespace GL.Servers.CoC.Core.Network
{
    using System.Collections.Generic;
    using System.Net.Sockets;

    internal class SocketAsyncEventArgsPool
    {
        internal readonly List<SocketAsyncEventArgs> Pool;

        internal readonly object Gate = new object();

        /// <summary>
        ///     Initializes a new instance of the <see cref="SocketAsyncEventArgsPool"/> class.
        /// </summary>
        internal SocketAsyncEventArgsPool(int Capacity)
        {
            this.Pool = new List<SocketAsyncEventArgs>(Capacity);
        }

        /// <summary>
        ///     Dequeues this instance.
        /// </summary>
        /// <returns>
        ///     <see cref="SocketAsyncEventArgs"/>
        /// </returns>
        internal SocketAsyncEventArgs Dequeue()
        {
            SocketAsyncEventArgs Saea = null;

            lock (this.Gate)
            {
                if (this.Pool.Count > 0)
                {
                    Saea = this.Pool[0];
                    this.Pool.RemoveAt(0);
                }

                return Saea;
            }
        }

        /// <summary>
        ///     Enqueues the specified item.
        /// </summary>
        /// <param name="AsyncEvent">
        ///     The <see cref="SocketAsyncEventArgs"/> instance containing the event data.
        /// </param>
        internal void Enqueue(SocketAsyncEventArgs AsyncEvent)
        {
            AsyncEvent.AcceptSocket     = null;
            AsyncEvent.RemoteEndPoint   = null;

            lock (this.Gate)
            {
                if (this.Pool.Count < this.Pool.Capacity)
                {
                    this.Pool.Add(AsyncEvent);
                }
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        internal void Dispose()
        {
            lock (this.Gate)
            {
                this.Pool.Clear();
            }
        }
    }
}