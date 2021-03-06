﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* NullMonitoringSink.cs -- sink take no action
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using JetBrains.Annotations;

using MoonSharp.Interpreter;

#endregion

namespace ManagedIrbis.Monitoring
{
    /// <summary>
    /// Sink take no action.
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public sealed class NullMonitoringSink
        : MonitoringSink
    {
        #region MonitoringSink members

        /// <inheritdoc cref="MonitoringSink.WriteData" />
        public override bool WriteData
            (
                MonitoringData data
            )
        {
            // Nothing to do here.

            return true;
        }

        #endregion
    }
}
