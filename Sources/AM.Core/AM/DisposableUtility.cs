﻿/* TaskEx.cs -- helper methods for IDisposable
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

#endregion

namespace AM
{
    /// <summary>
    /// Helper methods for <see cref="IDisposable"/>.
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public static class DisposableUtility
    {
        #region Public methods

        /// <summary>
        /// Check for <c>null</c>. Dispose only if
        /// not <c>null</c>.
        /// </summary>
        public static void SafeDispose
            (
                [CanBeNull] this IDisposable obj
            )
        {
            if (!ReferenceEquals(obj, null))
            {
                obj.Dispose();
            }
        }

        #endregion
    }
}
