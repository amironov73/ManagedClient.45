﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* SiberianRow.cs -- 
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    public class SiberianRow
    {
        #region Constants

        /// <summary>
        /// Default height.
        /// </summary>
        public const int DefaultHeight = 20;

        #endregion

        #region Events

        /// <summary>
        /// Fired on click.
        /// </summary>
        public event EventHandler<SiberianClickEventArgs> Click;

        #endregion

        #region Properties

        /// <summary>
        /// Index.
        /// </summary>
        public int Index { get; internal set; }

        /// <summary>
        /// Data.
        /// </summary>
        [CanBeNull]
        public object Data { get; set; }

        /// <summary>
        /// Grid.
        /// </summary>
        [NotNull]
        public SiberianGrid Grid { get; internal set; }

        /// <summary>
        /// Cells.
        /// </summary>
        [NotNull]
        public NonNullCollection<SiberianCell> Cells { get; private set; }

        /// <summary>
        /// Height.
        /// </summary>
        [DefaultValue(DefaultHeight)]
        public int Height { get; set; }

        #endregion

        #region Construction

        /// <summary>
        /// Constructor.
        /// </summary>
        internal SiberianRow()
        {
            Height = DefaultHeight;
            Cells = new NonNullCollection<SiberianCell>();
        }

        #endregion

        #region Private members

        /// <summary>
        /// Handle <see cref="Click"/> event.
        /// </summary>
        protected internal void HandleClick
            (
                [NotNull] SiberianClickEventArgs eventArgs
            )
        {
             Click.Raise(this, eventArgs);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Get data from the bound object
        /// and put it to the cells.
        /// </summary>
        public virtual void GetData()
        {
            foreach (SiberianCell cell in Cells)
            {
                cell.Column.GetData
                    (
                        Data,
                        cell
                    );
            }
        }

        /// <summary>
        /// Get first editable cell in the row.
        /// </summary>
        [CanBeNull]
        public SiberianCell GetFirstEditableCell()
        {
            foreach (SiberianCell cell in Cells)
            {
                if (!cell.Column.ReadOnly)
                {
                    return cell;
                }
            }

            return null;
        }

        /// <summary>
        /// Measure cells.
        /// </summary>
        public virtual void MeasureCells()
        {
            int height = Height;

            foreach (SiberianCell cell in Cells)
            {
                SiberianDimensions dimensions = new SiberianDimensions
                {
                    Width = cell.Column.Width,
                    Height = height
                };

                cell.MeasureContent(dimensions);
            }

            if (height > Height)
            {
                Height = height;
            }
        }

        /// <summary>
        /// Handles click on the row.
        /// </summary>
        public virtual void OnClick
            (
                [NotNull] SiberianClickEventArgs eventArgs
            )
        {
            // Nothing to do here?
        }

        /// <summary>
        /// Draw the column.
        /// </summary>
        public virtual void Paint
            (
                PaintEventArgs args
            )
        {
            Graphics graphics = args.Graphics;
            Rectangle clip = args.ClipRectangle;

            if (ReferenceEquals(this, Grid.CurrentRow))
            {
                using (Brush brush = new SolidBrush(Color.DarkBlue))
                {
                    graphics.FillRectangle(brush, clip);
                }
            }
        }

        /// <summary>
        /// Get data from the cells
        /// and put it to the bound object.
        /// </summary>
        public virtual void PutData()
        {
            foreach (SiberianCell cell in Cells)
            {
                cell.Column.PutData
                    (
                        Data,
                        cell
                    );
            }

            Grid.Invalidate();
        }

        #endregion

        #region Object members

        /// <inheritdoc />
        public override string ToString()
        {
            return string.Format
                (
                    "Index: {0}, Data: {1}",
                    Index,
                    Data
                );
        }

        #endregion
    }
}
