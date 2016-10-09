/* PftParser.cs --
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using AM;
using AM.IO;
using AM.Text;

using CodeJam;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

using Newtonsoft.Json;

#endregion

namespace ManagedIrbis.Pft.Infrastructure
{
    /// <summary>
    /// �������� ������ ����������.
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public sealed class PftOutput
    {
        #region Properties

        /// <summary>
        /// ������������ �����. ����� ���� <c>null</c>.
        /// </summary>
        [CanBeNull]
        public PftOutput Parent { get { return _parent; } }

        /// <summary>
        /// �������� (�������) �����.
        /// </summary>
        [NotNull]
        public TextWriter Normal { get { return _normal; } }

        /// <summary>
        /// ����� ��������������.
        /// </summary>
        [NotNull]
        public TextWriter Warning { get { return _warning; } }

        /// <summary>
        /// ����� ������.
        /// </summary>
        [NotNull]
        public TextWriter Error { get { return _error; } }

        /// <summary>
        /// ����������� ����� ��������� ������.
        /// </summary>
        [NotNull]
        public string Text { get { return Normal.ToString(); } }

        /// <summary>
        /// ����������� ����� ������ ��������������.
        /// </summary>
        [NotNull]
        public string WarningText { get { return Warning.ToString(); } }

        /// <summary>
        /// ����������� ����� ������ ������.
        /// </summary>
        [NotNull]
        public string ErrorText { get { return Error.ToString(); } }

        /// <summary>
        /// �������� �� ����� � �������� ������?
        /// </summary>
        public bool HaveText { get { return _HaveText(_normal); } }

        /// <summary>
        /// ���� �� ��������������?
        /// </summary>
        public bool HaveWarning { get { return _HaveText(_warning); } }

        /// <summary>
        /// ���� �� ������?
        /// </summary>
        public bool HaveError { get { return _HaveText(_error); } }

        #endregion

        #region Construction

        /// <summary>
        /// Constructor.
        /// </summary>
        public PftOutput()
            : this(null)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public PftOutput
            (
               [CanBeNull] PftOutput parent
            )
        {
            _parent = parent;
            _normal = new StringWriter();
            _warning = new StringWriter();
            _error = new StringWriter();
        }

        #endregion

        #region Private members

        private readonly PftOutput _parent;

        private readonly StringWriter _normal;
        private readonly StringWriter _warning;
        private readonly StringWriter _error;

        private static bool _HaveText
            (
               [NotNull] StringWriter writer
            )
        {
            return (writer.GetStringBuilder().Length != 0);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// ������� ��������� ������.
        /// </summary>
        [NotNull]
        public PftOutput ClearText()
        {
            _normal.GetStringBuilder().Length = 0;

            return this;
        }

        /// <summary>
        /// �������� ������ ��������������.
        /// </summary>
        [NotNull]
        public PftOutput ClearWarning()
        {
            _warning.GetStringBuilder().Length = 0;

            return this;
        }

        /// <summary>
        /// ������� ������ ������.
        /// </summary>
        [NotNull]
        public PftOutput ClearError()
        {
            _error.GetStringBuilder().Length = 0;

            return this;
        }

        /// <summary>
        /// ��������� ������� � ������ ������.
        /// </summary>
        [NotNull]
        public PftOutput Push()
        {
            PftOutput result = new PftOutput(this);

            return result;
        }

        /// <summary>
        /// ������� � ������� ������ � ������������
        /// � ����� ������, ������������ � �����
        /// ���������� ������.
        /// </summary>
        [NotNull]
        public string Pop()
        {
            if (!ReferenceEquals(Parent, null))
            {
                string warningText = WarningText;
                if (!string.IsNullOrEmpty(warningText))
                {
                    Parent.Warning.Write(warningText);
                }

                string errorText = ErrorText;
                if (!string.IsNullOrEmpty(errorText))
                {
                    Parent.Error.Write(errorText);
                }
            }

            return ToString();
        }

        /// <summary>
        /// Write text.
        /// </summary>
        [NotNull]
        [StringFormatMethod("format")]
        public PftOutput Write
            (
                [CanBeNull] string format,
                params object[] arg
            )
        {
            if (!string.IsNullOrEmpty(format))
            {
                Normal.Write(format, arg);
            }

            return this;
        }

        /// <summary>
        /// Write text.
        /// </summary>
        [NotNull]
        public PftOutput Write
            (
                [CanBeNull] string value
            )
        {
            if (!string.IsNullOrEmpty(value))
            {
                Normal.Write(value);
            }

            return this;
        }

        /// <summary>
        /// Write line.
        /// </summary>
        [NotNull]
        [StringFormatMethod("format")]
        public PftOutput WriteLine
            (
                [CanBeNull] string format,
                params object[] arg
            )
        {
            if (!string.IsNullOrEmpty(format))
            {
                Normal.WriteLine(format, arg);
            }

            return this;
        }

        /// <summary>
        /// Write line.
        /// </summary>
        [NotNull]
        public PftOutput WriteLine
            (
               [CanBeNull] string value
            )
        {
            if (!string.IsNullOrEmpty(value))
            {
                Normal.WriteLine(value);
            }

            return this;
        }

        /// <summary>
        /// Write line.
        /// </summary>
        [NotNull]
        public PftOutput WriteLine()
        {
            Normal.WriteLine();

            return this;
        }

        /// <summary>
        /// �������� (������������) ������� ������� �� �����������.
        /// </summary>
        public int GetCaretPosition()
        {
            StringBuilder builder = _normal.GetStringBuilder();
            int pos;
            for (pos = builder.Length - 1; pos >= 0; pos--)
            {
                if (builder[pos] == '\n')
                    break;
            }

            return (builder.Length - pos);
        }

        /// <summary>
        /// ������� ��������� ������ � ������, ���� ��� ������.
        /// </summary>
        public PftOutput RemoveEmptyLine()
        {
            StringBuilder builder = _normal.GetStringBuilder();
            int pos;
            for (pos = builder.Length - 1; pos >= 0; pos--)
            {
                if (!char.IsWhiteSpace(builder[pos]))
                {
                    break;
                }
                builder.Length = pos;
            }

            return this;
        }

        /// <summary>
        /// ������ �� ��������� ������ � �������� ������?
        /// </summary>
        public bool HaveEmptyLine()
        {
            StringBuilder builder = _normal.GetStringBuilder();

            if (builder.Length == 0)
            {
                return false;
            }

            bool result = true;
            int pos;
            for (pos = builder.Length - 1; pos >= 0; pos--)
            {
                char c = builder[pos];
                if (c == '\n')
                {
                    break;
                }
                if (!char.IsWhiteSpace(c))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        #endregion

        #region Object members

        /// <inhertidoc/>
        public override string ToString()
        {
            return Normal.ToString();
        }

        #endregion
    }
}