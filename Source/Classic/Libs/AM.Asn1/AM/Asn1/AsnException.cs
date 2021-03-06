﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* AsnException.cs --
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;

using JetBrains.Annotations;

#endregion

namespace AM.Asn1
{
    /// <summary>
    ///
    /// </summary>
    [PublicAPI]
    public class AsnException
        : Exception
    {
        #region Construciton

        /// <summary>
        /// Constructor.
        /// </summary>
        public AsnException()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public AsnException
            (
                string message
            )
            : base(message)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public AsnException
            (
                string message,
                Exception innerException
            )
            : base
            (
                message,
                innerException
            )
        {
        }

        #endregion
    }
}
