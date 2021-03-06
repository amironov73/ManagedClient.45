/* StandardSuggester.cs --
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

using CodeJam;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

#endregion

namespace AM.Suggestions
{
    /// <summary>
    /// Standart suggester.
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public sealed class StandardSuggester
        : ISuggester
    {
        #region Properties

        ///<summary>
        /// Standard values.
        ///</summary>
        [NotNull]
        public ICollection StandardValues { get; set; }

        #endregion

        #region Construction

        /// <summary>
        /// Default constructor.
        /// </summary>
        public StandardSuggester()
        {
            StandardValues = new List<object>();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public StandardSuggester
            (
                ICollection values
            )
        {
            StandardValues = values;
        }

        #endregion

        #region ISuggester Members

        /// <inheritdoc />
        public ICollection SuggestedValues()
        {
            return StandardValues;
        }

        #endregion
    }
}
