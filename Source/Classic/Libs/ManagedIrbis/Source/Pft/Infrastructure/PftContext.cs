/* PftContext.cs --
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System.Collections;
using System.Collections.Generic;

using CodeJam;

using JetBrains.Annotations;
using ManagedIrbis.Pft.Infrastructure.Ast;
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
    {
        #region Properties

        /// <summary>
        /// ���������
        /// </summary>
        public PftFormatter Formatter { get { return _formatter; } }

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

        /// <summary>
        /// ����� ������ �����.
        /// </summary>
        public PftFieldOutputMode FieldOutputMode { get; set; }

        /// <summary>
        /// ����� �������� ������ � ������� ������� ��� ������ �����.
        /// </summary>
        public bool UpperMode { get; set; }

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

        /// <summary>
        /// ����, ��������������� ��� ������������ ��������� break.
        /// </summary>
        public bool BreakFlag { get; internal set; }

        /// <summary>
        /// ������� �������������� ���� ������, ���� ����.
        /// </summary>
        [CanBeNull]
        public PftField CurrentField { get; internal set; }

        ///// <summary>
        ///// ���������� ����������.
        ///// </summary>
        //public PftGlobalManager Globals { get; private set; }

        ///// <summary>
        ///// ���������� ����������.
        ///// </summary>
        //public PftVariableManager Variables { get; set; }

        ///// <summary>
        ///// ���������.
        ///// </summary>
        //public PftProcedureManager Procedures { get; set; }

        #endregion

        #region Construction

        /// <summary>
        /// Constructor.
        /// </summary>
        public PftContext
            (
                [CanBeNull] PftFormatter formatter,
                [CanBeNull] PftContext parent
            )
        {
            _formatter = formatter;

            _parent = parent;

            PftOutput parentBuffer = (parent == null)
                ? null
                : parent.Output;

            Output = new PftOutput(parentBuffer);

            //Globals = (parent == null)
            //    ? new PftGlobalManager()
            //    : parent.Globals;

            //// ���������� � ������ ��������� ����
            //Variables = new PftVariableManager();

            //// ��������� � ������ ��������� ����
            //Procedures = new PftProcedureManager();

            Record = (parent == null)
                ? new MarcRecord()
                : parent.Record;

            Connection = (parent == null)
                ? new IrbisConnection()
                : parent.Connection;
        }

        #endregion

        #region Private members

        private PftFormatter _formatter;

        private readonly PftContext _parent;

        internal void _SetFormatter
            (
                PftFormatter formatter
            )
        {
            _formatter = formatter;
        }

        #endregion

        #region Public methods

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
        /// ��������� ������������ ��������� (��������,
        /// ��� ���������� ��������� �������).
        /// </summary>
        [NotNull]
        public PftContext Push()
        {
            PftContext result = new PftContext(Formatter,this);

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

        /// <summary>
        /// ���������� ��������� �� ��������� ����� ���������.
        /// </summary>
        [NotNull]
        public string Evaluate
            (
                PftNode node
            )
        {
            PftContext copy = Push();
            node.Execute(copy);
            string result = copy.ToString();
            Pop();

            return result;
        }

        /// <summary>
        /// ���������� ��������� �� ��������� ����� ���������.
        /// </summary>
        public string Evaluate
            (
                IEnumerable<PftNode> items
            )
        {
            PftContext copy = Push();
            foreach (PftNode ast in items)
            {
                ast.Execute(copy);
            }
            string result = copy.ToString();
            Pop();
            return result;
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