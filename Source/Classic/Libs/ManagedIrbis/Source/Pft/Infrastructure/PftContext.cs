/* PftContext.cs --
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;

using AM;
using AM.Text;

using CodeJam;

using JetBrains.Annotations;

using ManagedIrbis.Client;
using ManagedIrbis.Pft.Infrastructure.Ast;
using ManagedIrbis.Pft.Infrastructure.Diagnostics;

using MoonSharp.Interpreter;

using Newtonsoft.Json;

#endregion

namespace ManagedIrbis.Pft.Infrastructure
{
    /// <summary>
    /// �������� ��������������
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public sealed class PftContext
        : IDisposable
    {
        #region Properties

        /// <summary>
        /// Environment.
        /// </summary>
        [NotNull]
        //public PftEnvironmentAbstraction Environment { get; private set; }
        public AbstractClient Environment { get; private set; }

        /// <summary>
        /// ������������ ��������.
        /// </summary>
        public PftContext Parent { get { return _parent; } }

        /// <summary>
        /// ������ ��� ����� � ��������.
        /// </summary>
        public IrbisConnection Connection { get; set; }

        /// <summary>
        /// ������� ������������� ������.
        /// </summary>
        public MarcRecord Record { get; set; }

        /// <summary>
        /// �������� �����, � ������� ������������� ���������
        /// ��������������, � ����� ������ � ��������������.
        /// </summary>
        public PftOutput Output { get; internal set; }

        /// <summary>
        /// ����������� ����� � �������� ������ ��������� ������,
        /// �. �. ���������� ��������� ����������������� ������.
        /// </summary>
        public string Text { get { return Output.ToString(); } }

        #region ����� ������

        /// <summary>
        /// ����� ������ �����.
        /// </summary>
        public PftFieldOutputMode FieldOutputMode { get; set; }

        /// <summary>
        /// ����� �������� ������ � ������� ������� ��� ������ �����.
        /// </summary>
        public bool UpperMode { get; set; }

        #endregion

        #region ������ � ��������

        /// <summary>
        /// ������� ������ (���� ����).
        /// </summary>
        [CanBeNull]
        public PftGroup CurrentGroup { get; internal set; }

        /// <summary>
        /// ����� ���������� � ������� ������.
        /// </summary>
        public int Index { get; internal set; }

        /// <summary>
        /// ����, ��������������� ��� ������� ������ ��� �������� ����������.
        /// </summary>
        public bool OutputFlag { get; internal set; }

        ///// <summary>
        ///// ����, ��������������� ��� ������������ ��������� break.
        ///// </summary>
        //public bool BreakFlag { get; internal set; }

        /// <summary>
        /// ������� �������������� ���� ������, ���� ����.
        /// </summary>
        [CanBeNull]
        public PftField CurrentField { get; internal set; }

        #endregion

        /// <summary>
        /// ���������� ����������.
        /// </summary>
        public PftGlobalManager Globals { get; private set; }

        /// <summary>
        /// ���������� ����������.
        /// </summary>
        public PftVariableManager Variables { get; private set; }

        /// <summary>
        /// �������, ������������������ � ������ ���������.
        /// </summary>
        [NotNull]
        public PftFunctionManager Functions { get; private set; }

        /// <summary>
        /// ���������, ������� �� ������� ���������.
        /// </summary>
        [NotNull]
        public PftProcedureManager Procedures { get; internal set; }

        /// <summary>
        /// ������������� �������.
        /// </summary>
        public int UniversalCounter { get; set; }

        /// <summary>
        /// Debugger (if attached).
        /// </summary>
        [CanBeNull]
        public PftDebugger Debugger { get; set; }

        /// <summary>
        /// Post processing flags.
        /// </summary>
        public PftCleanup PostProcessing { get; set; }

        #endregion

        #region Construction

        /// <summary>
        /// Constructor.
        /// </summary>
        public PftContext
            (
                [CanBeNull] PftContext parent
            )
        {
            _parent = parent;

            Environment = ReferenceEquals(parent, null)
                //? new PftLocalEnvironment()
                ? new LocalClient()
                : parent.Environment;

            PftOutput parentBuffer = parent == null
                ? null
                : parent.Output;

            Output = new PftOutput(parentBuffer);

            Globals = ReferenceEquals(parent, null)
                ? new PftGlobalManager()
                : parent.Globals;

            Variables = ReferenceEquals(parent, null)
                ? new PftVariableManager(null)
                : parent.Variables;

            Procedures = ReferenceEquals(parent, null)
                ? new PftProcedureManager()
                : parent.Procedures;

            if (!ReferenceEquals(parent, null))
            {
                CurrentGroup = parent.CurrentGroup;
                CurrentField = parent.CurrentField;
                Index = parent.Index;
            }

            Record = ReferenceEquals(parent, null)
                ? new MarcRecord()
                : parent.Record;

            Connection = ReferenceEquals(parent, null)
                ? new IrbisConnection()
                : parent.Connection;

            Functions = new PftFunctionManager();
        }

        #endregion

        #region Private members

        private readonly PftContext _parent;

        #endregion

        #region Public methods

        /// <summary>
        /// Activate debugger (if attached).
        /// </summary>
        public void ActivateDebugger
        (
            [NotNull] PftNode node
        )
        {
            Code.NotNull(node, "node");

            if (!ReferenceEquals(Debugger, null))
            {
                PftDebugEventArgs args = new PftDebugEventArgs
                (
                    this,
                    node
                );
                Debugger.Activate(args);
            }
        }

        /// <summary>
        /// ������ ������� ���� �������: � ���������,
        /// � ��������������, � ������.
        /// </summary>
        public PftContext ClearAll()
        {
            Output.ClearText();
            Output.ClearError();
            Output.ClearWarning();

            return this;
        }

        /// <summary>
        /// ������� ��������� ��������� ������.
        /// </summary>
        public PftContext ClearText()
        {
            Output.ClearText();

            return this;
        }

        /// <summary>
        /// ��������� ������������� ������.
        /// </summary>
        public void DoRepeatableAction
            (
                [NotNull] Action<PftContext> action,
                int count
            )
        {
            Code.NotNull(action, "action");
            Code.Nonnegative(count, "count");

            count = Math.Min(count, PftConfig.MaxRepeat);

            for (Index = 0; Index < count; Index++)
            {
                OutputFlag = false;

                action(this);

                if (!OutputFlag
                    // || BreakFlag
                    )
                {
                    break;
                }
            }
        }

        /// <summary>
        /// ��������� ������������� ������
        /// ����������� ��������� ����� ���.
        /// </summary>
        public void DoRepeatableAction
            (
                [NotNull] Action<PftContext> action
            )
        {
            DoRepeatableAction(action, int.MaxValue);
        }

        /// <summary>
        /// ���������� ��������� �� ��������� ����� ���������.
        /// </summary>
        [NotNull]
        public string Evaluate
            (
                [NotNull] PftNode node
            )
        {
            Code.NotNull(node, "node");

            PftContext copy = Push();
            node.Execute(copy);
            string result = copy.ToString();
            Pop();

            return result;
        }

        /// <summary>
        /// ���������� ��������� �� ��������� ����� ���������.
        /// </summary>
        [NotNull]
        public string Evaluate
            (
                [NotNull] IEnumerable<PftNode> items
            )
        {
            Code.NotNull(items, "items");

            PftContext copy = Push();
            foreach (PftNode node in items)
            {
                node.Execute(copy);
            }
            string result = copy.ToString();
            Pop();

            return result;
        }

        /// <summary>
        /// Execute the nodes.
        /// </summary>
        public void Execute
            (
                [CanBeNull] IEnumerable<PftNode> nodes
            )
        {
            if (!ReferenceEquals(nodes, null))
            {
                foreach (PftNode node in nodes)
                {
                    node.Execute(this);
                }
            }
        }

        /// <summary>
        /// Get processed output.
        /// </summary>
        [NotNull]
        public string GetProcessedOutput()
        {
            string result = Output.Text;

            if ((PostProcessing & PftCleanup.Rtf) != 0)
            {
                result = RichTextStripper.StripRichTextFormat(result);
            }

            if ((PostProcessing & PftCleanup.Html) != 0)
            {
                result = HtmlText.HtmlToPlainText(result);
            }

            if ((PostProcessing & PftCleanup.DoubleText) != 0)
            {
                result = IrbisText.CleanupText(result);
            }

            if (ReferenceEquals(result, null))
            {
                result = string.Empty;
            }

            return result;
        }

        //=================================================

        /// <summary>
        /// Get root context.
        /// </summary>
        [NotNull]
        public PftContext GetRootContext()
        {
            PftContext result = this;

            while (!ReferenceEquals(result.Parent, null))
            {
                result = result.Parent;
            }

            return result;
        }

        //=================================================

        /// <summary>
        /// Get numeric argument value.
        /// </summary>
        [CanBeNull]
        public double? GetNumericArgument
            (
                [NotNull] PftNode[] arguments,
                int index
            )
        {
            Code.NotNull(arguments, "arguments");

            PftNode node = arguments.GetOccurrence(index);
            if (ReferenceEquals(node, null))
            {
                return null;
            }

            double? result = null;

            PftNumeric numeric = node as PftNumeric;
            if (ReferenceEquals(numeric, null))
            {
                string text = GetStringArgument(arguments, index);
                double val;
                if (double.TryParse(text, out val))
                {
                    result = val;
                }
            }
            else
            {
                Evaluate(numeric);
                result = numeric.Value;
            }

            return result;
        }

        //=================================================

        /// <summary>
        /// Get string argument value.
        /// </summary>
        [CanBeNull]
        public string GetStringArgument
            (
                [NotNull] PftNode[] arguments,
                int index
            )
        {
            Code.NotNull(arguments, "arguments");

            PftNode node = arguments.GetOccurrence(index);
            if (ReferenceEquals(node, null))
            {
                return null;
            }

            string result = Evaluate(node);

            return result;
        }

        //=================================================

        /// <summary>
        /// ��������� ������������ ��������� (��������,
        /// ��� ���������� ��������� �������).
        /// </summary>
        [NotNull]
        public PftContext Push()
        {
            PftContext result = new PftContext(this);

            return result;
        }

        /// <summary>
        /// Pop the context.
        /// </summary>
        public void Pop()
        {
            if (!ReferenceEquals(Parent, null))
            {
                // Nothing to do?
            }
        }

        /// <summary>
        /// Set environment.
        /// </summary>
        public void SetEnvironment
            (
                //[NotNull] PftEnvironmentAbstraction environment
                [NotNull] AbstractClient environment
            )
        {
            Code.NotNull(environment, "environment");

            Environment = environment;
        }

        /// <summary>
        /// Set variables.
        /// </summary>
        /// <param name="variables"></param>
        public void SetVariables
            (
                [NotNull] PftVariableManager variables
            )
        {
            Code.NotNull(variables, "variables");

            Variables = variables;
        }

        /// <summary>
        /// Write text.
        /// </summary>
        [NotNull]
        [StringFormatMethod("format")]
        public PftContext Write
            (
                PftNode node,
                string format,
                params object[] arg
            )
        {
            if (!string.IsNullOrEmpty(format))
            {
                Output.Write(format, arg);
            }

            return this;
        }

        /// <summary>
        /// Write text.
        /// </summary>
        [NotNull]
        public PftContext Write
            (
                PftNode node,
                string value
            )
        {
            if (!string.IsNullOrEmpty(value))
            {
                Output.Write(value);
            }

            return this;
        }

        /// <summary>
        /// Write line.
        /// </summary>
        [NotNull]
        public PftContext WriteLine
            (
                PftNode node,
                string format,
                params object[] arg
            )
        {
            if (!string.IsNullOrEmpty(format))
            {
                Output.WriteLine(format, arg);
            }

            return this;
        }

        /// <summary>
        /// Write line.
        /// </summary>
        [NotNull]
        public PftContext WriteLine
            (
                PftNode node,
                string value
            )
        {
            if (!string.IsNullOrEmpty(value))
            {
                Output.WriteLine(value);
            }

            return this;
        }

        /// <summary>
        /// Write line.
        /// </summary>
        [NotNull]
        public PftContext WriteLine
            (
                PftNode node
            )
        {
            Output.WriteLine();

            return this;
        }

        #endregion

        #region IDisposable members

        /// <inheritdoc/>
        public void Dispose()
        {
            Environment.Dispose();
        }

        #endregion

        #region Object members

        /// <summary>
        /// Returns a <see cref="System.String" />
        /// that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> 
        /// that represents this instance.</returns>
        public override string ToString()
        {
            return Output.ToString();
        }

        #endregion
    }
}
