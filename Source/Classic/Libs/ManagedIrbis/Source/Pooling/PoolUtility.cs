﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* PoolUtility.cs --
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using JetBrains.Annotations;

using MoonSharp.Interpreter;

#endregion

namespace ManagedIrbis.Pooling
{
    /// <summary>
    /// Утилиты для работы пулом соединений.
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public static class PoolUtility
    {
        #region Private members

        #endregion

        #region Public methods

        /// <summary>
        /// Чтение записи с помощью пула.
        /// </summary>
        [NotNull]
        public static MarcRecord ReadRecord
            (
                [NotNull] this IrbisConnectionPool pool,
                int mfn
            )
        {
            IrbisConnection client = pool.AcquireConnection();
            MarcRecord result = client.ReadRecord(mfn);
            pool.ReleaseConnection(client);
            return result;
        }

        /// <summary>
        /// Поиск в каталоге с помощью пула.
        /// </summary>
        [NotNull]
        public static int[] Search
            (
                [NotNull] this IrbisConnectionPool pool,
                string format,
                params object[] args
            )
        {
            IrbisConnection client = pool.AcquireConnection();
            int[] result = client.Search(format, args);
            pool.ReleaseConnection(client);
            return result;
        }

        /// <summary>
        /// Сохранение записей с помощью пула.
        /// </summary>
        public static void WriteRecord
            (
                [NotNull] this IrbisConnectionPool pool,
                [NotNull] MarcRecord record
            )
        {
            IrbisConnection client = pool.AcquireConnection();
            client.WriteRecord(record, false, true);
            pool.ReleaseConnection(client);
        }

        #endregion
    }
}
