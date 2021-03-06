﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* IrbisPoolGuard.cs --
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;

using AM.Logging;

using CodeJam;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

#endregion

namespace ManagedIrbis.Pooling
{
    /// <summary>
    /// Следит за своевременным возвращением соединения в пул.
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public sealed class IrbisPoolGuard
        : IDisposable
    {
        #region Properties

        /// <summary>
        /// Отслеживаемое подключение.
        /// </summary>
        [NotNull]
        public IrbisConnection Connection { get; private set; }

        /// <summary>
        /// Отслеживаемый пул подключений.
        /// </summary>
        [NotNull]
        public IrbisConnectionPool Pool { get; private set; }

        #endregion

        #region Construction

        /// <summary>
        /// Конструктор.
        /// </summary>
        public IrbisPoolGuard
            (
                [NotNull] IrbisConnectionPool pool
            )
        {
            Code.NotNull(pool, "pool");

            Log.Trace("IrbisPoolGuard::Constructor");

            Pool = pool;
            Connection = Pool.AcquireConnection();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Неявное преобразование.
        /// </summary>
        public static implicit operator IrbisConnection
            (
                [NotNull] IrbisPoolGuard guard
            )
        {
            return guard.Connection;
        }

        #endregion

        #region IDisposable members

        /// <inheritdoc cref="IDisposable.Dispose" />
        public void Dispose()
        {
            Log.Trace
                (
                    "IrbisPoolGuard::Dispose"
                );

            Pool.ReleaseConnection(Connection);
        }

        #endregion
    }
}
