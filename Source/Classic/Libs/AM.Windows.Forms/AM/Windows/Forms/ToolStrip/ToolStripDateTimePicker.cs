﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* ToolStripDateTimePicker.cs -- DateTimePicker that appears in ToolStrip.
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.Design;

using JetBrains.Annotations;

#endregion

namespace AM.Windows.Forms
{
    /// <summary>
    /// <see cref="T:System.Windows.Forms.DateTimePicker"/> that
    /// appears in <see cref="T:System.Windows.Forms.ToolStrip"/>.
    /// </summary>
    [PublicAPI]
    [System.ComponentModel.DesignerCategory("Code")]
    [ToolStripItemDesignerAvailability
        (ToolStripItemDesignerAvailability.ToolStrip
          | ToolStripItemDesignerAvailability.StatusStrip)]
    public class ToolStripDateTimePicker
        : ToolStripControlHost
    {
        #region Properties

        /// <summary>
        /// Gets the DateTimePicker.
        /// </summary>
        [NotNull]
        [DesignerSerializationVisibility
            (DesignerSerializationVisibility.Content)]
        public DateTimePicker DateTimePicker
        {
            [DebuggerStepThrough]
            get
            {
                return (DateTimePicker) Control;
            }
        }

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ToolStripDateTimePicker"/> class.
        /// </summary>
        public ToolStripDateTimePicker()
            : base(new DateTimePicker())
        {
        }

        #endregion
    }
}