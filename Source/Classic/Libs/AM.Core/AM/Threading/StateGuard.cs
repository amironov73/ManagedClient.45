﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* StateGuard.cs --
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

using AM.IO;
using AM.Runtime;

using CodeJam;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

#endregion

namespace AM.Threading
{
    /// <summary>
    /// 
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public sealed class StateGuard<T>
        : IDisposable
        where T: IEquatable<T>
    {
        #region Properties

        /// <summary>
        /// Current value.
        /// </summary>
        public T CurrentValue { get { return _state.Value; } }

        /// <summary>
        /// Saved value.
        /// </summary>
        public T SavedValue { get { return _savedValue; } }

        /// <summary>
        /// State.
        /// </summary>
        public StateHolder<T> State { get { return _state; } }

        #endregion

        #region Construction

        /// <summary>
        /// Constructor.
        /// </summary>
        public StateGuard
            (
                [NotNull] StateHolder<T> state
            )
        {
            Code.NotNull(state, "state");

            _state = state;
            _savedValue = state.Value;
        }

        #endregion

        #region Private members

        private T _savedValue;

        private StateHolder<T> _state;

        private void _RestoreValue()
        {
            T currentValue = CurrentValue;
            T savedValue = SavedValue;

            bool null1 = ReferenceEquals(currentValue, null);
            bool null2 = ReferenceEquals(savedValue, null);

            bool restore = null1 != null2;

            if (!restore)
            {
                if (!null1)
                {
                    restore = !currentValue.Equals(savedValue);
                }
            }

            if (restore)
            {
                State.SetValue(savedValue);
            }
        }

        #endregion

        #region Public methods

        #endregion

        #region IDisposable members

        /// <inheritdoc cref="IDisposable.Dispose"/>
        public void Dispose()
        {
            _RestoreValue();
        }

        #endregion
    }
}
