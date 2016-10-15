﻿/* PftComma.cs -- оператор "запятая"
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CodeJam;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

#endregion

namespace ManagedIrbis.Pft.Infrastructure.Ast
{
    /// <summary>
    /// Оператор "запятая".
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public sealed class PftComma
        : PftNode
    {
        #region Properties

        #endregion

        #region Construction

        /// <summary>
        /// Constructor.
        /// </summary>
        public PftComma()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public PftComma
            (
                [NotNull] PftToken token
            )
        {
            Code.NotNull(token, "token");
            token.MustBe(PftTokenKind.Comma);
        }

        #endregion

        #region Private members

        #endregion

        #region Public methods

        #endregion

        #region PftNode members

        /// <inheritdoc />
        public override void Execute
            (
                PftContext context
            )
        {
            OnBeforeExecution(context);

            OnAfterExecution(context);
        }

        /// <inheritdoc />
        public override void Write
            (
                StreamWriter writer
            )
        {
            // Добавляем пробел для читабельности
            writer.Write(", ");
        }

        #endregion
    }
}