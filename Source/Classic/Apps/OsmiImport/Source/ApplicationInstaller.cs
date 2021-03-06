﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* ApplicationInstaller.cs --
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

using JetBrains.Annotations;

using ManagedIrbis;

#endregion

namespace OsmiImport
{
    /// <summary>
    /// Нужно для инфраструктуры installutil.
    /// </summary>
    [PublicAPI]
    [RunInstaller(true)]
    public class ApplicationInstaller
        : Installer
    {
        #region Construction

        /// <summary>
        /// Constructor.
        /// </summary>
        public ApplicationInstaller()
        {
            ServiceProcessInstaller processInstaller = new ServiceProcessInstaller
            {
                Account = ServiceAccount.NetworkService
            };

            string version = IrbisConnection.ClientVersion.ToString();
            ServiceInstaller serviceInstaller = new ServiceInstaller
            {
                Description = "DiCARDs import bot for IRBIS64",
                DisplayName = ImportService.ImportDaemon + " v" + version,
                ServiceName = ImportService.ImportDaemon,
                StartType = ServiceStartMode.Automatic,
                DelayedAutoStart = true
            };

            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }

        #endregion
    }
}
