﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* PftTrunc.cs --
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;
using System.Linq;
using System.Text;

using CodeJam;

using JetBrains.Annotations;

using ManagedIrbis.Pft.Infrastructure.Compiler;
using ManagedIrbis.Pft.Infrastructure.Text;

using MoonSharp.Interpreter;

#endregion

namespace ManagedIrbis.Pft.Infrastructure.Ast
{
    /// <summary>
    /// 
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public sealed class PftTrunc
        : PftNumeric
    {
        #region Properties

        /// <inheritdoc cref="PftNode.ExtendedSyntax" />
        public override bool ExtendedSyntax
        {
            get { return true; }
        }

        #endregion

        #region Construction

        /// <summary>
        /// Constructor.
        /// </summary>
        public PftTrunc()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public PftTrunc
            (
                [NotNull] PftToken token
            )
            : base(token)
        {
            Code.NotNull(token, "token");
            token.MustBe(PftTokenKind.Trunc);
        }

        #endregion

        #region Private members

        #endregion

        #region Public methods

        #endregion

        #region PftNode members

        /// <inheritdoc cref="PftNode.Compile" />
        public override void Compile
            (
                PftCompiler compiler
            )
        {
            PftNumeric child = Children.FirstOrDefault() as PftNumeric;
            if (ReferenceEquals(child, null))
            {
                throw new PftCompilerException();
            }

            child.Compile(compiler);

            compiler.StartMethod(this);

            compiler
                .WriteIndent()
                .WriteLine("double value = ")
                .CallNodeMethod(child);

            compiler
                .WriteIndent()
                .WriteLine("double result = Math.Truncate(value);");

            compiler
                .WriteIndent()
                .WriteLine("return result;");

            compiler.EndMethod(this);
            compiler.MarkReady(this);
        }

        /// <inheritdoc cref="PftNumeric.Execute" />
        public override void Execute
            (
                PftContext context
            )
        {
            OnBeforeExecution(context);

            PftNumeric child = Children.FirstOrDefault() as PftNumeric;
            if (!ReferenceEquals(child, null))
            {
                child.Execute(context);

#if PocketPC || WINMOBILE || SILVERLIGHT

                Value = (int) child.Value;

#else

                Value = Math.Truncate(child.Value);

#endif
            }

            OnAfterExecution(context);
        }

        /// <inheritdoc cref="PftNode.PrettyPrint" />
        public override void PrettyPrint
            (
                PftPrettyPrinter printer
            )
        {
            printer
                .SingleSpace()
                .Write("trunc(");
            base.PrettyPrint(printer);
            printer.Write(')');
        }

        #endregion

        #region Object members

        /// <inheritdoc cref="PftNode.ToString" />
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("trunc(");
            bool first = true;
            foreach (PftNode child in Children)
            {
                if (!first)
                {
                    result.Append(' ');
                }
                result.Append(child);
                first = false;
            }
            result.Append(')');

            return result.ToString();
        }

        #endregion
    }
}
