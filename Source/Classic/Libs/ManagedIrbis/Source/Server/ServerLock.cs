﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* ServerLock.cs --
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using AM;

using CodeJam;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

#endregion

namespace ManagedIrbis.Server
{
    /// <summary>
    /// Установка блокировок баз данных.
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public class ServerLock
        : IDisposable
    {
        #region Constants

        /// <summary>
        /// Prefix for mutex name.
        /// </summary>
        public const string MutexPrefix = "IRBIS64_MUTEX";

        #endregion

        #region Properties

        /// <summary>
        /// List of locks.
        /// </summary>
        [NotNull]
        public static readonly List<ServerLock> LockList
            = new List<ServerLock>();

        /// <summary>
        /// Database name.
        /// </summary>
        [NotNull]
        public string Database { get; private set; }

        /// <summary>
        /// Lock for write.
        /// </summary>
        public bool Write { get; private set; }

        #endregion

        #region Construction

        /// <summary>
        /// Constructor.
        /// </summary>
        public ServerLock
            (
                [NotNull] string database,
                bool write,
                int timeout
            )
        {
            Code.NotNullNorEmpty(database, "database");

#if WINMOBILE || POCKETPC

            throw new NotImplementedException();

#else

            Database = database;
            Write = write;
            DateTime startTime = DateTime.Now;

            while (true)
            {
                string mutexName = MutexPrefix + StringUtility.ToUpperInvariant(database);
                bool createNew;
                _mutex = new Mutex(false, mutexName, out createNew);

                if (createNew)
                {
                    break;
                }

#if FW35
                _mutex.Close();
#else
                _mutex.Dispose();
#endif

                if (timeout > 0)
                {
                    int timeSpent = (int) (DateTime.Now - startTime).TotalMilliseconds;
                    if (timeSpent > timeout)
                    {
                        throw new IrbisException();
                    }
                }

#if UAP
                Task.Delay(100).Wait();
#else
                Thread.Sleep(100);
#endif
            }

            lock (Sync)
            {
                LockList.Add(this);
            }

#endif
        }

        #endregion

        #region Private members

        private static readonly object Sync = new object();

        private Mutex _mutex;

        #endregion

        #region IDisposable members

        /// <inheritdoc cref="IDisposable.Dispose" />
        public void Dispose()
        {
#if FW35 || WINMOBILE || POCKETPC

            _mutex.Close();

#else

            _mutex.Dispose();

#endif

            lock (Sync)
            {
                LockList.Remove(this);
            }
        }

        #endregion
    }
}
