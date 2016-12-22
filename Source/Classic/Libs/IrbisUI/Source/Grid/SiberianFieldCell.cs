﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* SiberianFieldCell.cs -- 
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

using AM;
using AM.Collections;
using AM.IO;
using AM.Runtime;

using CodeJam;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

#endregion

namespace IrbisUI.Grid
{
    /// <summary>
    /// 
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public class SiberianFieldCell
        : SiberianCell
    {
        #region Properties

        #endregion

        #region Construction

        #endregion

        #region Private members

        #endregion

        #region Public methods

        #endregion

        #region SiberianCell members

        /// <inheritdoc />
        public override void CloseEditor
            (
                bool accept
            )
        {
            if (!ReferenceEquals(Grid.Editor, null))
            {
                if (accept)
                {
                    SiberianField field = (SiberianField)Row.Data;
                    if (!ReferenceEquals(field, null))
                    {
                        field.Value = Grid.Editor.Text;
                    }
                }
            }

            base.CloseEditor(accept);
        }

        /// <inheritdoc/>
        public override void Paint
            (
                PaintEventArgs args
            )
        {
            Graphics graphics = args.Graphics;
            Rectangle rectangle = args.ClipRectangle;

            Color foreColor = Color.Black;
            if (ReferenceEquals(Row, Grid.CurrentRow))
            {
                foreColor = Color.White;
            }

            if (ReferenceEquals(this, Grid.CurrentCell))
            {
                Color backColor = Color.Blue;
                using (Brush brush = new SolidBrush(backColor))
                {
                    graphics.FillRectangle(brush, rectangle);
                }
            }

            SiberianField field = (SiberianField) Row.Data;

            if (!ReferenceEquals(field, null))
            {
                string text = field.Value;

                if (!string.IsNullOrEmpty(text))
                {

                    TextFormatFlags flags
                        = TextFormatFlags.TextBoxControl
                          | TextFormatFlags.EndEllipsis
                          | TextFormatFlags.NoPrefix
                          | TextFormatFlags.VerticalCenter;

                    TextRenderer.DrawText
                        (
                            graphics,
                            text,
                            Grid.Font,
                            rectangle,
                            foreColor,
                            flags
                        );
                }
            }
        }

        #endregion

        #region Object members

        /// <inheritdoc/>
        public override string ToString()
        {
            // ReSharper disable ConditionIsAlwaysTrueOrFalse
            int row = ReferenceEquals(Row, null) ? -1 : Row.Index,
                column = ReferenceEquals(Column, null) ? -1 : Column.Index;
            // ReSharper restore ConditionIsAlwaysTrueOrFalse

            SiberianField field = (SiberianField)Row.Data;
            string text = string.Empty;
            if (!ReferenceEquals(field, null))
            {
                text = string.Format
                    (
                        "{0}/{1}: {2} ({3})",
                        field.Tag,
                        field.Repeat,
                        field.Value,
                        field.OriginalValue
                    );
            }

            return string.Format
                (
                    "FieldCell [{0}, {1}]: {2}",
                    column,
                    row,
                    text
                );
        }

        #endregion
    }
}