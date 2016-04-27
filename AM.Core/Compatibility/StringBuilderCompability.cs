﻿/* StringBuilderCompatibility.cs -- compatibility with StringBuilder
 * Ars Magna project, http://arsmagna.ru
 */

#region Using directives

using System.Text;

using JetBrains.Annotations;

#endregion

namespace Compatibility
{

#if FW35

    /// <summary>
    /// Compatibility with <see cref="StringBuilder"/>.
    /// </summary>
    [PublicAPI]
    public static class StringBuilderCompatibility
    {
        #region Public methods

        /// <summary>
        /// Removes all characters from the given
        /// <see cref="StringBuilder"/> instance.
        /// </summary>
        [NotNull]
        public static StringBuilder Clear
            (
                [NotNull] this StringBuilder builder
            )
        {
            builder.Length = 0;

            return builder;
        }

        #endregion
    }

#endif

}
