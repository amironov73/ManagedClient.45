﻿/* PftPercent.cs --
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System.IO;

using CodeJam;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

#endregion

namespace ManagedIrbis.Pft.Infrastructure.Ast
{
    /// <summary>
    /// Команда % подавляет все последовательно
    /// расположенные пустые строки(если они имеются)
    /// между текущей строкой и последней непустой строкой.
    /// Таким образом, формат
    /// 
    /// %##V10%##V20%##V30 ...
    /// 
    /// приведет к созданию одной и только одной пустой
    /// строки между каждым полем, независимо от их наличия
    /// или отсутствия в документе.
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public sealed class PftPercent
        : PftNode
    {
        #region Properties

        #endregion

        #region Construction

        /// <summary>
        /// Constructor.
        /// </summary>
        public PftPercent()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public PftPercent
            (
                [NotNull] PftToken token
            )
        {
            Code.NotNull(token, "token");
            token.MustBe(PftTokenKind.Percent);
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

            if (!context.BreakFlag)
            {
                context.Output.RemoveEmptyLine();
            }

            OnAfterExecution(context);
        }

        /// <inheritdoc />
        public override void Write
            (
                StreamWriter writer
            )
        {
            // Обрамляем пробелами
            writer.Write(" % ");
        }


        #endregion
    }
}