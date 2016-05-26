/* SocketUtility.cs -- 
 * Ars Magna project, http://arsmagna.ru
 */

#region Using directives

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

using CodeJam;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

#endregion

namespace AM.Net
{
    /// <summary>
    /// 
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public static class SocketUtility
    {
        #region Private members

        #endregion

        #region Public methods

        /// <summary>
        /// Gets IP address from hostname.
        /// </summary>
        /// <returns>Resolved IP address of the host.</returns>
        [NotNull]
        public static IPAddress IPAddressFromHostname
            (
                [NotNull]string hostname
            )
        {
            Code.NotNull(hostname, "hostname");

            if (hostname.OneOf("localhost","local", "(local)"))
            {
                return IPAddress.Loopback;
            }

            IPHostEntry hostEntry = Dns.GetHostEntry(hostname);
            if (hostEntry.AddressList.Length == 0)
            {
                throw new SocketException();
            }

            return hostEntry.AddressList
                    [
                        new Random().Next(hostEntry.AddressList.Length)
                    ];
        }

        [NotNull]
        public static Task<int> ReceiveAsync
            (
                [NotNull] this Socket socket,
                byte[] buffer,
                int offset,
                int size,
                SocketFlags socketFlags
            )
        {
            var tcs = new TaskCompletionSource<int>(socket);

            socket.BeginReceive
                (
                    buffer,
                    offset,
                    size,
                    socketFlags,
                    iar =>
                        {
                            var t = (TaskCompletionSource<int>)iar.AsyncState;
                            var s = (Socket)t.Task.AsyncState;
                            try
                            {
                                t.TrySetResult(s.EndReceive(iar));
                            }
                            catch (Exception exc)
                            {
                                t.TrySetException(exc);
                            }
                        },
                    tcs
                );

            return tcs.Task;
        }

        [NotNull]
        public static Task<int> SendAsync
            (
                [NotNull] this Socket socket,
                byte[] buffer,
                int offset,
                int size,
                SocketFlags socketFlags
            )
        {
            var tcs = new TaskCompletionSource<int>(socket);

            socket.BeginSend
                (
                    buffer,
                    offset,
                    size,
                    socketFlags,
                    iar =>
                    {
                        var t = (TaskCompletionSource<int>)iar.AsyncState;
                        var s = (Socket)t.Task.AsyncState;
                        try
                        {
                            t.TrySetResult(s.EndReceive(iar));
                        }
                        catch (Exception exc)
                        {
                            t.TrySetException(exc);
                        }
                    },
                    tcs
                );

            return tcs.Task;
        }

        #endregion
    }
}