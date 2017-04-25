﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* SearchReference.cs --
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using JetBrains.Annotations;
using ManagedIrbis.Client;

#endregion

namespace ManagedIrbis.Search.Infrastructure
{
    /// <summary>
    /// #N
    /// </summary>
    sealed class SearchReference
        : ISearchTree
    {
        #region Properties

        /// <summary>
        /// Number.
        /// </summary>
        [CanBeNull]
        public string Number { get; set; }

        #endregion

        #region ISearchTree members

        public ISearchTree[] Children
        {
            get { return new ISearchTree[0]; }
        }

        public string Value { get { return Number; } }

        public int[] Find
            (
                IrbisProvider provider
            )
        {
            return new int[0];
        }

        #endregion

        #region Object members

        /// <inheritdoc/>
        public override string ToString()
        {
            return "#" + Number;
        }

        #endregion
    }
}
