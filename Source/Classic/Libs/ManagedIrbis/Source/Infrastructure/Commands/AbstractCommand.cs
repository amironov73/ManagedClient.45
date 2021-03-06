﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* AbstractCommand.cs -- abstract command of IRBIS protocol
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AM;
using AM.Logging;

using CodeJam;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

using Newtonsoft.Json;

#endregion

namespace ManagedIrbis.Infrastructure.Commands
{
    /// <summary>
    /// Abstract command of IRBIS protocol.
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public abstract class AbstractCommand
        : IVerifiable
    {
        #region Properties

        /// <summary>
        /// Connection.
        /// </summary>
        [NotNull]
        public IIrbisConnection Connection { get; private set; }

        /// <summary>
        /// Good return codes.
        /// </summary>
        public virtual int[] GoodReturnCodes
        {
            get
            {
                return new int[0];
            }
        }

        /// <summary>
        /// Relax (may be malformed) server response.
        /// </summary>
        public bool RelaxResponse { get; set; }

        /// <summary>
        /// Does the command require established connection?
        /// </summary>
        public virtual bool RequireConnection { get { return true; } }

        /// <summary>
        /// Kind of the command.
        /// </summary>
        public virtual CommandKind Kind { get { return CommandKind.None; } }

        #endregion

        #region Construction

        /// <summary>
        /// Constructor.
        /// </summary>
        protected AbstractCommand
            (
                [NotNull] IIrbisConnection connection
            )
        {
            Code.NotNull(connection, "connection");

            Log.Trace("AbstractCommand::Constructor");

            Connection = connection;
        }

        #endregion

        #region Private members

        #endregion

        #region Public methods

        /// <summary>
        /// Check the server response.
        /// </summary>
        public virtual void CheckResponse
            (
                [NotNull] ServerResponse response
            )
        {
            Code.NotNull(response, "response");

            int returnCode = response.ReturnCode;
            if (returnCode < 0)
            {
                int[] goodCodes = GoodReturnCodes;

                if (!goodCodes.Contains(returnCode))
                {
                    Log.Error
                        (
                            "AbstractCommand::CheckResponse: code="
                            + returnCode
                        );

                    throw new IrbisException(returnCode);
                }
            }
        }

        /// <summary>
        /// Create client query.
        /// </summary>
        public virtual ClientQuery CreateQuery()
        {
            Log.Trace("AbstractCommand::CreateQuery");

            // TODO fix it!

            ClientQuery result = new ClientQuery(Connection)
            {
                Workstation = Connection.Workstation,
                ClientID = Connection.ClientID,
                CommandNumber = 1,
                UserLogin = Connection.Username,
                UserPassword = Connection.Password
            };
            IrbisConnection connection = Connection as IrbisConnection;
            if (!ReferenceEquals(connection, null))
            {
                result.CommandNumber = connection.IncrementCommandNumber();
            }

            return result;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        [NotNull]
        public virtual ServerResponse Execute
            (
                [NotNull] ClientQuery query
            )
        {
            Code.NotNull(query, "query");

            ServerResponse result = Connection.Executive.ObtainResponse
                (
                    query,
                    RelaxResponse
                );

            return result;
        }

        /// <summary>
        /// Parse client query.
        /// </summary>
        public virtual void ParseClientQuery
            (
                [NotNull] byte[] clientQuery
            )
        {
            Code.NotNull(clientQuery, "clientQuery");
        }

        #endregion

        #region IVerifiable members

        /// <inheritdoc cref="IVerifiable.Verify"/>
        public virtual bool Verify
            (
                bool throwOnError
            )
        {
            return true;
        }

        #endregion
    }
}
