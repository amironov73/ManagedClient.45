﻿/* SearchQueryUtility.cs --
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

using AM;
using AM.Text;

using CodeJam;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

#endregion

namespace ManagedIrbis.Search.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public static class SearchQueryUtility
    {
        #region Private members

        private static List<ISearchTree> GetDescendants
            (
                ISearchTree node
            )
        {
            List<ISearchTree> result = new List<ISearchTree>
            {
                node
            };

            foreach (ISearchTree child in node.Children)
            {
                List<ISearchTree> descendants = GetDescendants(child);
                result.AddRange(descendants);
            }

            return result;
        }

        /// <summary>
        /// Require syntax element.
        /// </summary>
        internal static string RequireSyntax
            (
                [CanBeNull] this string element,
                [NotNull] string message
            )
        {
            if (ReferenceEquals(element, null))
            {
                throw new SearchSyntaxException(message);
            }

            return element;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Extract search terms from the query.
        /// </summary>
        [NotNull]
        public static string[] ExtractTerms
            (
                [NotNull] SearchProgram program
            )
        {
            Code.NotNull(program, "program");

            List<ISearchTree> nodes = GetDescendants(program);
            SearchTerm[] terms = nodes.OfType<SearchTerm>().ToArray();
            string[] result = terms.Select(term => term.Term).ToArray();

            return result;
        }

        #endregion
    }
}