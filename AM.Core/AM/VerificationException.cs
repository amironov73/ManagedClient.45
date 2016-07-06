﻿/* VerificationException.cs -- exception for IVerifiable interface.
 * Ars Magna project, http://arsmagna.ru
 */

#region Using directives

using System;

using JetBrains.Annotations;

#endregion

namespace AM
{
    /// <summary>
    /// Exception for <see cref="IVerifiable"/> interface.
    /// </summary>
    [PublicAPI]
    [Serializable]

    public sealed class VerificationException
        : ArsMagnaException
    {
        #region Construction

        /// <summary>
        /// Constructor.
        /// </summary>
        public VerificationException()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public VerificationException
            (
                string message
            )
            : base(message)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public VerificationException
            (
                string message,
                Exception innerException
            )
            : base(message, innerException)
        {
        }

        #endregion
    }
}
