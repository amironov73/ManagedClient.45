﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* ExemplarInfoComparer.cs -- 
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System.Collections.Generic;

using AM;
using AM.Text;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

#endregion

namespace ManagedIrbis.Fields
{
    /// <summary>
    /// 
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public static class ExemplarInfoComparer
    {
        #region Nested classes

        class ByDescriptionComparer
            : IComparer<ExemplarInfo>
        {
            /// <inheritdoc cref="IComparer{T}.Compare" />
            public int Compare
                (
                    ExemplarInfo x,
                    ExemplarInfo y
                )
            {
                return NumberText.Compare
                    (
                        x.ThrowIfNull().Description,
                        y.ThrowIfNull().Description
                    );
            }
        }

        class ByNumberComparer
            : IComparer<ExemplarInfo>
        {
            /// <inheritdoc cref="IComparer{T}.Compare" />
            public int Compare
                (
                    ExemplarInfo x,
                    ExemplarInfo y
                )
            {
                return NumberText.Compare
                    (
                        x.ThrowIfNull().Number,
                        y.ThrowIfNull().Number
                    );
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Compare <see cref="ExemplarInfo"/>
        /// by <see cref="ExemplarInfo.Description"/> field.
        /// </summary>
        public static IComparer<ExemplarInfo> ByDescription()
        {
            return new ByDescriptionComparer();
        }

        /// <summary>
        /// Compare <see cref="ExemplarInfo"/>
        /// by <see cref="ExemplarInfo.Number"/> field.
        /// </summary>
        public static IComparer<ExemplarInfo> ByNumber()
        {
            return new ByNumberComparer();
        }

        #endregion
    }
}
