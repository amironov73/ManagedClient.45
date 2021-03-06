/* UpdateProgressForm.cs --
   Ars Magna project, http://library.istu.edu/am */

#region Using directives

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

using CodeJam;

using JetBrains.Annotations;

//using RC=AM.LibFX.Properties.Resources;

#endregion

namespace AM.Deployment
{
    /// <summary>
    ///
    /// </summary>
    public partial class UpdateProgressForm
        : Form
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="UpdateProgressForm"/> class.
        /// </summary>
        public UpdateProgressForm()
        {
            InitializeComponent();
            _canClose = false;
        }

        #endregion

        #region Private members

        //private ApplicationUpdater _updater;

        private bool _canClose;
        //private bool _needRestart;

        private void _backgroundWorker_DoWork
            (
            object sender,
            DoWorkEventArgs e
            )
        {
            //_updater.BeforeFileCopy += _BeforeFileCopy;
            //_needRestart = _updater.UpdateApplication();
        }

        private void _backgroundWorker_RunWorkerCompleted
            (
                object sender,
                RunWorkerCompletedEventArgs e
            )
        {
            _canClose = true;
            Close();
            //if (_needRestart)
            //{
            //    //MessageBox.Show(RC.ApplicationNeedsRestart);
            //    Application.Restart();
            //}
        }

        private void _backgroundWorker_ProgressChanged
            (
                object sender,
                ProgressChangedEventArgs e
            )
        {
            string fileName = e.UserState as string;
            _fileNameLabel.Text = fileName;
        }

        void _BeforeFileCopy
            (
                object sender,
                UpdateFileEventArgs e
            )
        {
            _backgroundWorker.ReportProgress(0, e.DestinationFile);
        }

        private void _Form_Load
            (
                object sender,
                EventArgs e
            )
        {
            //_sourceLabel.Text = _updater.GetSourcePath();
            _backgroundWorker.RunWorkerAsync();
        }

        private void UpdateProgressForm_FormClosing
            (
                object sender,
                FormClosingEventArgs e
            )
        {
            e.Cancel = !_canClose;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Updates the application.
        /// </summary>
        /// <param name="updater">The updater.</param>
        public static void UpdateApplication
            (
                [NotNull] ApplicationUpdater updater
            )
        {
            Code.NotNull(updater, "updater");

            UpdateProgressForm form = new UpdateProgressForm
            {
                // _updater = updater
            };

            if (!Debugger.IsAttached)
            {
                form.TopMost = true;
            }

            form.ShowDialog();
        }

        #endregion
    }
}
