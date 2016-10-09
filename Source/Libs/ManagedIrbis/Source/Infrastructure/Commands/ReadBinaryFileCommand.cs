﻿/* ReadBinaryFileCommand.cs -- read binary file from the server
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: moderate
 */

#region Using directives

using System.Text;

using AM;

using CodeJam;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

#endregion

namespace ManagedIrbis.Infrastructure.Commands
{
    /// <summary>
    /// Read binary file from the server.
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public sealed class ReadBinaryFileCommand
        : AbstractCommand
    {
        #region Constants

        /// <summary>
        /// Preamble for binary data.
        /// </summary>
        public const string Preamble = "IRBIS_BINARY_DATA";

        #endregion

        #region Properties

        /// <summary>
        /// File to read.
        /// </summary>
        [CanBeNull]
        public FileSpecification File { get; set; }

        /// <summary>
        /// File content.
        /// </summary>
        [CanBeNull]
        public byte[] Content { get; set; }

        #endregion

        #region Construction

        /// <summary>
        /// Constructor.
        /// </summary>
        public ReadBinaryFileCommand
            (
                [NotNull] IrbisConnection connection
            )
            : base(connection)
        {
        }

        #endregion

        #region Private members

        private static int _FindPreamble
            (
                byte[] buffer,
                byte[] preamble
            )
        {
            int bufferLength = buffer.Length;
            int preambleLength = preamble.Length;
            bufferLength -= preambleLength;

            for (int i = 0; i < bufferLength; i++)
            {
                bool found = true;
                for (int j = 0; j < preamble.Length; j++)
                {
                    if (buffer[i + j] != preamble[j])
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    return i;
                }
            }

            return -1;
        }

        #endregion

        #region Public methods

        #endregion

        #region AbstractCommand members

        /// <summary>
        /// Check the server response.
        /// </summary>
        public override void CheckResponse
            (
                ServerResponse response
            )
        {
            Code.NotNull(response, "response");

            // Don't check: there's no return code
            response.RefuseAnReturnCode();
        }

        /// <summary>
        /// Create client query.
        /// </summary>
        public override ClientQuery CreateQuery()
        {
            ClientQuery result = base.CreateQuery();
            result.CommandCode = CommandCode.ReadDocument;

            if (ReferenceEquals(File, null))
            {
                throw new IrbisException("File is null");
            }
            File.BinaryFile = true;
            result.Add(File.ToString());

            return result;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        public override ServerResponse Execute
            (
                ClientQuery query
            )
        {
            Code.NotNull(query, "query");

            ServerResponse result = base.Execute(query);

            byte[] buffer = result.RawAnswer;
            Encoding encoding;

#if SILVERLIGHT || WIN81

            encoding = Encoding.GetEncoding("windows-1251");

#else

            encoding = Encoding.ASCII;

#endif

            byte[] preamble = encoding.GetBytes(Preamble);
            int offset = _FindPreamble(buffer, preamble);
            if (offset < 0)
            {
                throw new IrbisNetworkException("No binary data received");
            }
            offset += preamble.Length;
            Content = result.RawAnswer.GetSpan(offset);

            return result;
        }

        /// <summary>
        /// Verify object state.
        /// </summary>
        public override bool Verify
            (
                bool throwOnError
            )
        {
            Verifier<ReadBinaryFileCommand> verifier
                = new Verifier<ReadBinaryFileCommand>
                    (
                        this,
                        throwOnError
                    );

            verifier
                .NotNull(File, "File");

            return verifier.Result;
        }

        #endregion
    }
}
