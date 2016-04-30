﻿/* ControlUtility.cs -- useful extensions for Control
 * Ars Magna project, http://arsmagna.ru
 */

#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CodeJam;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

using Newtonsoft.Json;

#endregion

namespace IrbisUI.Extensions
{
    /// <summary>
    /// Useful extension for <see cref="Control"/>.
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public static class ControlUtility
    {
        #region Properties

        #endregion

        #region Private members

        #endregion

        #region Public methods

        /// <summary>
        /// Invoke specified <paramref name="action"/>
        /// strictly in UI thread for specified
        /// <paramref name="control"/>.
        /// </summary>
        public static void InvokeIfRequired
            (
                [CanBeNull] this Control control,
                [CanBeNull] MethodInvoker action
            )
        {
            if (ReferenceEquals(control, null)
                || ReferenceEquals(action, null))
            {
                return;
            }

            // When the form, thus the control, isn't visible yet,
            // InvokeRequired returns false, resulting still
            // in a cross-thread exception.
            while (!control.Visible)
            {
                System.Threading.Thread.Sleep(50);
            }

            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }

        #endregion
    }
}
