﻿/* PftComparison.cs --
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AM;
using CodeJam;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

#endregion

namespace ManagedIrbis.Pft.Infrastructure.Ast
{
    /// <summary>
    /// 
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public sealed class PftComparison
        : PftCondition
    {
        #region Properties

        /// <summary>
        /// Left operand.
        /// </summary>
        [CanBeNull]
        public PftNode LeftOperand { get; set; }

        /// <summary>
        /// Operation.
        /// </summary>
        [CanBeNull]
        public string Operation { get; set; }

        /// <summary>
        /// Right operand.
        /// </summary>
        [CanBeNull]
        public PftNode RightOperand { get; set; }

        #endregion

        #region Construction

        /// <summary>
        /// Constructor.
        /// </summary>
        public PftComparison()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public PftComparison
            (
                [NotNull] PftToken token
            )
            : base(token)
        {
        }

        #endregion

        #region Private members

        #endregion

        #region Public methods

        /// <summary>
        /// Do the operation.
        /// </summary>
        public bool DoOperation
            (
                [NotNull] PftContext context,
                [NotNull] string leftValue,
                [NotNull] string operation,
                [NotNull] string rightValue
            )
        {
            Code.NotNull(context, "context");
            Code.NotNullNorEmpty(operation, "operation");

            operation = operation.ToLowerInvariant();
            bool result;
            switch (operation)
            {
                case ":":
                    result = PftUtility.ContainsSubString(leftValue, rightValue);
                    break;

                case "=":
                    result = leftValue.SameString(rightValue);
                    break;

                case "!=":
                case "<>":
                    result = leftValue.SameString(rightValue);
                    break;

                case "<":
                    result = PftUtility.CompareStrings(leftValue, rightValue) < 0;
                    break;

                case "<=":
                    result = PftUtility.CompareStrings(leftValue, rightValue) <= 0;
                    break;

                case ">":
                    result = PftUtility.CompareStrings(leftValue, rightValue) > 0;
                    break;

                case ">=":
                    result = PftUtility.CompareStrings(leftValue, rightValue) >= 0;
                    break;

                case "~":
                    result = Regex.IsMatch(leftValue, rightValue);
                    break;

                default:
                    throw new PftSyntaxException(this);
            }

            return result;
        }

        #endregion

        #region PftNode members

        /// <inheritdoc />
        public override void Execute
            (
                PftContext context
            )
        {
            OnBeforeExecution(context);

            if (ReferenceEquals(LeftOperand, null))
            {
                throw new PftSyntaxException(this);
            }
            if (string.IsNullOrEmpty(Operation))
            {
                throw new PftSyntaxException(this);
            }
            if (ReferenceEquals(RightOperand, null))
            {
                throw new PftSyntaxException(this);
            }

            string leftValue = context.Evaluate(LeftOperand);
            string rightValue = context.Evaluate(RightOperand);
            Value = DoOperation
                (
                    context,
                    leftValue,
                    Operation.ThrowIfNull(),
                    rightValue
                );

            OnAfterExecution(context);
        }

        /// <inheritdoc/>
        public override void PrintDebug
            (
                TextWriter writer,
                int level
            )
        {
            for (int i = 0; i < level; i++)
            {
                writer.Write("| ");
            }
            writer.WriteLine("Left:");
            if (!ReferenceEquals(LeftOperand, null))
            {
                LeftOperand.PrintDebug(writer, level + 1);
            }

            for (int i = 0; i < level; i++)
            {
                writer.Write("| ");
            }
            writer.WriteLine("Operation:");
            for (int i = 0; i <= level; i++)
            {
                writer.Write("| ");
            }
            writer.WriteLine(Operation);

            for (int i = 0; i < level; i++)
            {
                writer.Write("| ");
            }
            writer.WriteLine("Right:");
            if (!ReferenceEquals(RightOperand, null))
            {
                RightOperand.PrintDebug(writer, level + 1);
            }
        }

        #endregion
    }
}