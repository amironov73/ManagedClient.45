﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* ClientRunner.cs -- запускает клиент с заданными логином и паролем.
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml.Serialization;

using AM;
using AM.IO;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

using Newtonsoft.Json;

#endregion

namespace ManagedIrbis.Client
{
    /// <summary>
    /// Запускает указанный клиент с заданными логином и паролем.
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    [ExcludeFromCodeCoverage]
    public sealed class ClientRunner
    {
        #region Properties

        /// <summary>
        /// Database name (required if <see cref="UserName"/>
        /// and <see cref="Password"/> are specified).
        /// </summary>
        [CanBeNull]
        [XmlElement("database")]
        [JsonProperty("database")]
        public string Database { get; set; }

        /// <summary>
        /// Executable file name.
        /// </summary>
        [JsonIgnore]
        public NonNullValue<string> Executable { get; set; }

        /// <summary>
        /// INI-file name.
        /// </summary>
        public NonNullValue<string> IniFileName { get; set; }

        /// <summary>
        /// Current MFN.
        /// </summary>
        [XmlElement("mfn")]
        [JsonProperty("mfn")]
        public int Mfn { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [XmlElement("password")]
        [JsonProperty("password")]
        public string Password { get; set; }

        /// <summary>
        /// User name.
        /// </summary>
        [XmlElement("username")]
        [JsonProperty("username")]
        public string UserName { get; set; }

        /// <summary>
        /// Working directory.
        /// </summary>
        [XmlIgnore]
        [JsonIgnore]
        public NonNullValue<string> WorkingDirectory { get; set; }

        #endregion

        #region Construction

        /// <summary>
        /// Constructor.
        /// </summary>
        public ClientRunner()
        {
            // Starting with 2018.1: cirbis_plus.exe
            Executable = "cirbisc_new_unicode.exe";
            IniFileName = "cirbisc.ini";
            WorkingDirectory = @"C:\IRBIS64";
        }

        #endregion

        #region Private members

        private string _copyIniPath;

#if !UAP

        private void _ProcessExited
            (
                object sender,
                EventArgs e
            )
        {
            Process process = (Process) sender;

            File.Delete(_copyIniPath);
            process.Dispose();
        }

#endif

        #endregion

        #region Public methods

        /// <summary>
        /// Run the client and optionally wait for it.
        /// </summary>
        public void RunClient
            (
                bool wait
            )
        {
#if UAP

            throw new NotImplementedException();

#else

            if (!Directory.Exists(WorkingDirectory))
            {
                throw new IrbisException("Working directory not exists");
            }

            string executablePath = Path.Combine
                (
                    WorkingDirectory,
                    Executable
                );
            if (!File.Exists(executablePath))
            {
                throw new IrbisException("Executable file not exists");
            }

            string mainIniPath = Path.Combine
                (
                    WorkingDirectory,
                    IniFileName
                );
            if (!File.Exists(mainIniPath))
            {
                throw new IrbisException
                    (
                        "INI file not exists: "
                        + mainIniPath
                    );
            }

            string copyIniName =
                "_"
                + DateTime.Now.Ticks.ToInvariantString()
                + ".ini";
            _copyIniPath = Path.Combine
                (
                    WorkingDirectory,
                    copyIniName
                );
            File.Copy(mainIniPath, _copyIniPath);

            using (IniFile iniFile = new IniFile
                (
                    _copyIniPath,
                    IrbisEncoding.Ansi,
                    false
                ))
            using (ContextIniSection unused = new ContextIniSection(iniFile)
                {
                    Database = Database,
                    Mfn = Mfn,
                    Password = Password,
                    UserName = UserName
                })
            {
                iniFile.Save(_copyIniPath);
            }

            ProcessStartInfo startInfo = new ProcessStartInfo
                (
                    executablePath,
                    copyIniName
                )
            {
                UseShellExecute = false,
                WorkingDirectory = WorkingDirectory
            };
            Process process = new Process
            {
                StartInfo = startInfo
            };
            process.Exited += _ProcessExited;

            process.Start();

            if (wait)
            {
                process.WaitForExit();
            }

#endif
        }

        #endregion
    }
}
