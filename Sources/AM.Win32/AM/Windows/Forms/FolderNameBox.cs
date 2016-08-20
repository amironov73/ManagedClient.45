﻿/* FolderNameBox.cs -- 
 * Ars Magna project, http://arsmagna.ru 
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

using JetBrains.Annotations;

#endregion

namespace AM.Windows.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [PublicAPI]
    [System.ComponentModel.DesignerCategory("Code")]
    public class FolderNameBox
        : ButtonedTextBox
    {
        #region Properties

        private FolderBrowserDialog _dialog;

        /// <summary>
        /// Gets the dialog.
        /// </summary>
        /// <value>The dialog.</value>
        [DesignerSerializationVisibility
            (DesignerSerializationVisibility.Content)]
        public FolderBrowserDialog Dialog
        {
            [DebuggerStepThrough]
            get
            {
                return _dialog;
            }
        }

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="FolderNameBox"/> class.
        /// </summary>
        public FolderNameBox()
        {
            _dialog = new FolderBrowserDialog();
            Button.Click += _Button_Click;
        }

        #endregion

        #region Private members

        private void _Button_Click
            (
                object sender,
                EventArgs e
            )
        {
            Dialog.SelectedPath = Text;
            if (Dialog.ShowDialog(Parent)
                 == DialogResult.OK)
            {
                Text = Dialog.SelectedPath;
            }
        }

        #endregion

        #region Public methods

        #endregion

        #region Control members

        /// <summary>
        /// Releases the unmanaged resources used by the
        /// <see cref="T:System.Windows.Forms.TextBox"/>
        /// and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release
        /// both managed and unmanaged resources;
        /// false to release only unmanaged resources.
        /// </param>
        protected override void Dispose
            (
                bool disposing
            )
        {
            if (_dialog != null)
            {
                _dialog.Dispose();
                _dialog = null;
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}