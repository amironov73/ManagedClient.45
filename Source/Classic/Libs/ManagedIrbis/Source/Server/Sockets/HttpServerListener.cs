﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* HttpServerListener.cs --
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

using CodeJam;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

#endregion

namespace ManagedIrbis.Server.Sockets
{
    /// <summary>
    /// Слушает протокол HTTP.
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public class HttpServerListener
        : IrbisServerListener
    {
        #region Construction

        /// <summary>
        /// Constructor.
        /// </summary>
        public HttpServerListener
            (
                [NotNull] IPEndPoint endPoint,
                CancellationToken token
            )
        {
            Code.NotNull(endPoint, "endPoint");

            _listener = new TcpListener(endPoint);
            _token = token;
        }

        #endregion

        #region Private members

        private CancellationToken _token;

        private readonly TcpListener _listener;

        #endregion

        #region Public methods

        /// <summary>
        /// Create listener for the given port.
        /// </summary>
        [NotNull]
        public static HttpServerListener ForPort
            (
                int portNumber,
                CancellationToken token
            )
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, portNumber);
            HttpServerListener result = new HttpServerListener(endPoint, token);

            return result;
        }

        #endregion

        #region IrbisServerListener methods

        /// <inheritdoc cref="IrbisServerListener.AcceptClientAsync"/>
        public override Task<IrbisServerSocket> AcceptClientAsync()
        {
#if WINMOBILE || POCKETPC

            return new Task<IrbisServerSocket>(AM.ActionUtility.NoActionFunction<IrbisServerSocket>);

#else

            TaskCompletionSource<IrbisServerSocket> result
                = new TaskCompletionSource<IrbisServerSocket>();

#if FW35 || FW40

            Task<TcpClient> task = Task<TcpClient>.Factory.FromAsync
                (
                    _listener.BeginAcceptTcpClient,
                    _listener.EndAcceptTcpClient,
                    _listener
                );

#else

            Task<TcpClient> task = _listener.AcceptTcpClientAsync();

#endif

            task.ContinueWith
                (
                    s1 =>
                    {
                        TcpClient client = s1.Result;
                        IrbisServerSocket socket = new HttpServerSocket(client, _token);
                        result.SetResult(socket);
                    },
                    _token
                );

            return result.Task;

#endif
        }

        /// <inheritdoc cref="IrbisServerListener.GetLocalAddress" />
        public override string GetLocalAddress()
        {
            return _listener.LocalEndpoint.ToString();
        }

        /// <inheritdoc cref="IrbisServerListener.Start" />
        public override void Start()
        {
            _listener.Start();
        }

        /// <inheritdoc cref="IrbisServerListener.Stop" />
        public override void Stop()
        {
            _listener.Stop();
        }

        #endregion

        #region IDisposable members

        /// <inheritdoc cref="IrbisServerListener.Dispose" />
        public override void Dispose()
        {
            _listener.Stop();
        }

        #endregion
    }
}
