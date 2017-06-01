﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* UniversalForm.cs -- 
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using AM;
using AM.Collections;
using AM.Logging;
using AM.Text.Output;
using AM.Threading;
using AM.Windows.Forms;

using CodeJam;

using JetBrains.Annotations;

using ManagedIrbis;
using ManagedIrbis.Client;

using MoonSharp.Interpreter;

#endregion

namespace IrbisUI.Universal
{
    /// <summary>
    /// Universal form.
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public partial class UniversalForm
        : Form
    {
        #region Events

        /// <summary>
        /// Raised when the form needs initialization;
        /// </summary>
        public event EventHandler Initialize;

        #endregion

        #region Properties

        /// <summary>
        /// Busy state indicator.
        /// </summary>
        [NotNull]
        public IrbisBusyStripe BusyStripe { get { return _busyStripe; } }

        /// <summary>
        /// Central (working) control of the form.
        /// </summary>
        [CanBeNull]
        public Control CentralControl
        {
            get
            {
                var controls = CentralPanel.Controls;
                Control result = controls.Count == 0
                    ? null
                    : controls[0];

                return result;
            }
        }

        /// <summary>
        /// Central panel.
        /// </summary>
        [NotNull]
        public SplitterPanel CentralPanel
        {
            get
            {
                return _splitContainer.Panel1;
            }
        }

        /// <summary>
        /// Provider.
        /// </summary>
        [CanBeNull]
        public IrbisProvider Provider { get; private set; }

        /// <summary>
        /// LogBox.
        /// </summary>
        [NotNull]
        public LogBox LogBox { get { return _logBox; } }

        /// <summary>
        /// Main menu.
        /// </summary>
        [NotNull]
        public MenuStrip MainMenu { get { return _mainMenu; } }

        /// <summary>
        /// Output.
        /// </summary>
        [NotNull]
        public AbstractOutput Output { get { return LogBox.Output; } }

        /// <summary>
        /// Status strip.
        /// </summary>
        [NotNull]
        public StatusStrip StatusStrip { get { return _statusStrip; } }

        /// <summary>
        /// Tool strip.
        /// </summary>
        [NotNull]
        public ToolStrip ToolStrip { get { return _toolStrip; } }

        #endregion

        #region Construction

        /// <summary>
        /// Constructor.
        /// </summary>
        public UniversalForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Private members

        static void _ThreadException
            (
                object sender,
                ThreadExceptionEventArgs eventArgs
            )
        {
            ExceptionBox.Show(eventArgs.Exception);

#if FW4

            Environment.FailFast
                (
                    "Exception occurred. Shutting down",
                    eventArgs.Exception
                );

#else

            Environment.Exit(1);

#endif
        }


        private void _firstTimer_Tick
            (
                object sender,
                EventArgs e
            )
        {
            _firstTimer.Enabled = false;
            OnInitialize();
        }

        /// <summary>
        /// Initialize the form.
        /// </summary>
        protected virtual void OnInitialize()
        {
            Initialize.Raise(this, EventArgs.Empty);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Get <see cref="IrbisProvider"/>.
        /// </summary>
        [NotNull]
        public virtual IrbisProvider GetIrbisProvider()
        {
            IrbisProvider result
                = ProviderManager.GetPreconfiguredProvider();
            SubscribeToBusyState(result);
            Provider = result;

            return result;
        }

        /// <summary>
        /// Hide main menu strip.
        /// </summary>
        public void HideMainMenu()
        {
            MainMenu.Hide();
        }

        /// <summary>
        /// Hide tool strip.
        /// </summary>
        public void HideToolStrip()
        {
            ToolStrip.Hide();
        }

        /// <summary>
        /// Hide status strip.
        /// </summary>
        public void HideStatusStrip()
        {
            StatusStrip.Hide();
        }

        /// <summary>
        /// Process command line arguments.
        /// </summary>
        public virtual void ProcessArguments
            (
                [NotNull] string[] args
            )
        {
            Code.NotNull(args, "args");

            string formatted = StringUtility.Join
                (
                    ", ",
                    args.Select(a => a.NullableToVisibleString())
                );
            WriteLine("Arguments: {0}", formatted);
        }

        /// <summary>
        /// Release currenlty used <see cref="IrbisProvider"/>.
        /// </summary>
        public virtual void ReleaseProvider()
        {
            IrbisProvider provider = Provider;
            if (!ReferenceEquals(provider, null))
            {
                UnsubscribeFromBusyState(provider);
                provider.Dispose();
            }
            Provider = null;
        }

        /// <summary>
        /// Run the main form.
        /// </summary>
        public static void Run<T>
            (
                T form,
                string[] args
            )
            where T : UniversalForm
        {
            try
            {
                Application.ThreadException += _ThreadException;

                using (form)
                {
                    form.Show();
                    form.ShowSystemInformation();
                    form.ProcessArguments(args);

                    form._firstTimer.Enabled = true;

                    Application.Run(form);
                }

                Application.ThreadException -= _ThreadException;
            }
            catch (Exception exception)
            {
                ExceptionBox.Show(exception);
            }
        }

        /// <summary>
        /// Setup central control.
        /// </summary>
        public void SetupCentralControl
            (
                [CanBeNull] Control centralControl
            )
        {
            var controls = CentralPanel.Controls;

            // Remove previous controls if any
            foreach (Control control in controls)
            {
                control.Dispose();
            }
            controls.Clear();

            // Set new control if specified
            if (!ReferenceEquals(centralControl, null))
            {
                controls.Add(centralControl);
            }
        }

        /// <summary>
        /// Show system information.
        /// </summary>
        public void ShowSystemInformation()
        {
            Output.PrintSystemInformation();
            this.ShowVersionInfoInTitle();
        }

        /// <summary>
        /// Subscribe to <see cref="IrbisProvider"/>
        /// <see cref="BusyState"/>.
        /// </summary>
        public void SubscribeToBusyState
            (
                [NotNull] IrbisProvider provider
            )
        {
            Code.NotNull(provider, "provider");

            BusyState busyState = provider.GetBusyState();
            if (!ReferenceEquals(busyState, null))
            {
                BusyStripe.SubscribeTo(busyState);
            }
        }

        /// <summary>
        /// Test <see cref="Provider"/> connection.
        /// </summary>
        public bool TestProviderConnection()
        {
            bool result = false;

            try
            {
                PseudoAsync.Run
                    (
                        () => GetIrbisProvider ()
                    );

                result = true;
            }
            catch (Exception exception)
            {
                Log.TraceException
                (
                    "MainForm::_Initialize: ",
                    exception
                );

                WriteLine
                (
                    exception.GetType().Name
                    + ": "
                    + exception.Message
                );
            }
            ReleaseProvider();

            return result;
        }

        /// <summary>
        /// Unsubscribe from <see cref="IrbisProvider"/>
        /// <see cref="BusyState"/>.
        /// </summary>
        public void UnsubscribeFromBusyState
        (
            [NotNull] IrbisProvider provider
        )
        {
            Code.NotNull(provider, "provider");

            BusyState busyState = provider.GetBusyState();
            if (!ReferenceEquals(busyState, null))
            {
                BusyStripe.UnsubscribeFrom(busyState);
            }
        }

        /// <summary>
        /// Write log line.
        /// </summary>
        public void WriteLine
            (
                [NotNull] string format,
                params object[] args
            )
        {
            Code.NotNull(format, "format");

            Output.WriteLine(format, args);
        }

        #endregion
    }
}
