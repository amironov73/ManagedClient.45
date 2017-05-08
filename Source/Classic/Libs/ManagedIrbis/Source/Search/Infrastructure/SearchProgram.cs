﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* SearchProgram.cs --
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using JetBrains.Annotations;

using ManagedIrbis.Client;

using MoonSharp.Interpreter;

#endregion

namespace ManagedIrbis.Search.Infrastructure
{
    /// <summary>
    /// Root of the syntax tree.
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public sealed class SearchProgram
        : ISearchTree
    {
        #region Properties

        /// <summary>
        /// No parent.
        /// </summary>
        public ISearchTree Parent
        {
            get { return null; }
            set { /* Do nothing */ }
        }

        /// <summary>
        /// Program entry point - root of syntax tree.
        /// </summary>
        [CanBeNull]
        internal SearchLevel6 EntryPoint { get; set; }

        #endregion

        #region ISearchTree members

        ISearchTree[] ISearchTree.Children
        {
            get
            {
                ISearchTree[] result 
                    = ReferenceEquals(EntryPoint, null)
                    ? new ISearchTree[0]
                    : EntryPoint.Children;

                return result;
            }
        }

        string ISearchTree.Value { get { return null; } }

        /// <inheritdoc cref="ISearchTree.Find"/>
        public TermLink[] Find
            (
                SearchContext context
            )
        {
            TermLink[] result = ReferenceEquals(EntryPoint, null)
                ? new TermLink[0]
                : EntryPoint.Find(context);

            return result;
        }

        /// <inheritdoc cref="ISearchTree.ReplaceChild"/>
        public void ReplaceChild
            (
                ISearchTree fromChild,
                ISearchTree toChild
            )
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Object members

        /// <inheritdoc cref="object.ToString" />
        public override string ToString()
        {
            if (ReferenceEquals(EntryPoint, null))
            {
                return string.Empty;
            }

            string result = EntryPoint.ToString()
                .Trim();

            return result;
        }

        #endregion
    }
}
