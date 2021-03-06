﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* ReportCell.cs --
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
using System.Xml.Serialization;

using AM;
using AM.Collections;
using AM.IO;
using AM.Logging;
using AM.Runtime;

using CodeJam;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

using Newtonsoft.Json;

#endregion

namespace ManagedIrbis.Reports
{
    /// <summary>
    ///
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public abstract class ReportCell
        : IAttributable,
        IVerifiable,
        IDisposable
    {
        #region Events

        /// <summary>
        /// Raised after <see cref="Compute"/>.
        /// </summary>
        public event EventHandler<ReportEventArgs> AfterCompute;

        /// <summary>
        /// Raised before <see cref="Compute"/>.
        /// </summary>
        public event EventHandler<ReportEventArgs> BeforeCompute;

        #endregion

        #region Properties

        /// <summary>
        /// Attributes.
        /// </summary>
        [NotNull]
        [XmlArray("attr")]
        [JsonProperty("attr")]
        public ReportAttributes Attributes { get; private set; }

        /// <summary>
        /// Band.
        /// </summary>
        [CanBeNull]
        [XmlIgnore]
        [JsonIgnore]
        public ReportBand Band { get; internal set; }

        /// <summary>
        /// Report.
        /// </summary>
        [CanBeNull]
        [XmlIgnore]
        [JsonIgnore]
        public IrbisReport Report { get; internal set; }

        /// <summary>
        /// Arbitrary user data.
        /// </summary>
        [CanBeNull]
        [XmlIgnore]
        [JsonIgnore]
        public object UserData { get; set; }

        #endregion

        #region Construction

        /// <summary>
        /// Constructor.
        /// </summary>
        protected ReportCell()
        {
            Log.Trace("ReportCell::Constructor");

            Attributes = new ReportAttributes();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        protected ReportCell
            (
                params ReportAttribute[] attributes
            )
            : this()
        {
            foreach (ReportAttribute attribute in attributes)
            {
                Attributes.Add(attribute.Name, attribute.Value);
            }
        }

        #endregion

        #region Private members

        /// <summary>
        /// Called after <see cref="Compute"/>.
        /// </summary>
        protected void OnAfterCompute
            (
                ReportContext context
            )
        {
            ReportEventArgs eventArgs
                = new ReportEventArgs(context);
            AfterCompute.Raise(eventArgs);
        }

        /// <summary>
        /// Called before <see cref="Compute"/>.
        /// </summary>
        protected void OnBeforeCompute
            (
                ReportContext context
            )
        {
            ReportEventArgs eventArgs
                = new ReportEventArgs(context);
            BeforeCompute.Raise(eventArgs);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Clone the cell.
        /// </summary>
        public virtual ReportCell Clone()
        {
            return (ReportCell) MemberwiseClone();
        }

        /// <summary>
        /// Compute value of the cell.
        /// </summary>
        [CanBeNull]
        public virtual string Compute
            (
                [NotNull] ReportContext context
            )
        {
            Code.NotNull(context, "context");

            OnBeforeCompute(context);

            // Nothing to do here

            OnAfterCompute(context);

            return null;
        }

        /// <summary>
        /// Render the cell.
        /// </summary>
        public virtual void Render
            (
                [NotNull] ReportContext context
            )
        {
            // Nothing to do here
        }

        #endregion

        #region IVerifiable members

        /// <inheritdoc cref="IVerifiable.Verify" />
        public bool Verify
            (
                bool throwOnError
            )
        {
            Verifier<ReportCell> verifier
                = new Verifier<ReportCell>(this, throwOnError);

            verifier
                .VerifySubObject(Attributes, "attributes");

            // TODO Add some verification

            return verifier.Result;
        }

        #endregion

        #region IDisposable members

        /// <inheritdoc cref="IDisposable.Dispose" />
        public virtual void Dispose()
        {
            // Nothing to do here
            Log.Trace("ReportCell::Dispose");
        }

        #endregion
    }
}
