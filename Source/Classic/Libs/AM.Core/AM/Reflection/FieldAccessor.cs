﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* FieldAccessor.cs -- get access to private fields via reflection
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#if !NETCORE

#region Using directives

using System;
using System.Reflection;

using CodeJam;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

#endregion

namespace AM.Reflection
{
    /// <summary>
    /// Get access to private fields via reflection.
    /// </summary>
    /// <typeparam name="TTarget">Main object type.</typeparam>
    /// <typeparam name="TField">Field type</typeparam>
    [PublicAPI]
    [MoonSharpUserData]
    public class FieldAccessor<TTarget, TField>
        where TTarget : class
    {
        #region Property

        /// <summary>
        /// Gets or sets the name of the field.
        /// </summary>
        /// <value>The name of the field.</value>
        public string FieldName { get; set; }

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="FieldAccessor{TTarget, TField}"/> 
        /// class.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        public FieldAccessor
            (
                [NotNull] string fieldName
            )
        {
            Code.NotNull(fieldName, "fieldName");

            _info = typeof(TTarget).GetField
                (
                    fieldName,
                    BindingFlags.Instance | BindingFlags.Static
                    | BindingFlags.Public | BindingFlags.NonPublic
                );
            if (_info == null)
            {
                throw new ArgumentException("fieldName");
            }
        }

        #endregion

        #region Private members

        private readonly FieldInfo _info;

        #endregion

        #region Public methods

        /// <summary>
        /// Gets the specified target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public TField Get(TTarget target)
        {
            return (TField)_info.GetValue(target);
        }

        /// <summary>
        /// Sets the specified target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="value">The value.</param>
        public void Set(TTarget target, TField value)
        {
            _info.SetValue(target, value);
        }

        #endregion
    }
}

#endif
