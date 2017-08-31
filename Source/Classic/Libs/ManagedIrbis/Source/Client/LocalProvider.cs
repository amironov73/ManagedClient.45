﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* LocalProvider.cs -- 
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

using AM;
using AM.Collections;
using AM.IO;
using AM.Logging;
using AM.Parameters;
using AM.Runtime;
using AM.Threading;

using CodeJam;

using JetBrains.Annotations;

using ManagedIrbis.Direct;
using ManagedIrbis.Infrastructure;
using ManagedIrbis.Pft;
using ManagedIrbis.Pft.Infrastructure;
using ManagedIrbis.Search;
using ManagedIrbis.Server;
using MoonSharp.Interpreter;

#endregion

namespace ManagedIrbis.Client
{
    /// <summary>
    /// 
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public class LocalProvider
        : IrbisProvider
    {
        #region Properties

        /// <inheritdoc cref="IrbisProvider.BusyState" />
        [NotNull]
        public override BusyState BusyState
        {
            get { return _busyState; }
        }

        /// <inheritdoc cref="IrbisProvider.Connected" />
        public override bool Connected
        {
            get { return true; }
        }

        /// <summary>
        /// Data path.
        /// </summary>
        public string DataPath { get; set; }

        /// <summary>
        /// Root path.
        /// </summary>
        public string RootPath { get; set; }

        /// <summary>
        /// Access mode.
        /// </summary>
        public DirectAccessMode Mode { get; private set; }

        /// <summary>
        /// Current database PFT path.
        /// </summary>
        [NotNull]
        public string DatabasePftPath
        {
            get
            {
                string result = Path.Combine
                    (
                        DataPath,
                        Database
                    );

                return result;
            }
        }

        /// <summary>
        /// PFT search path alternatives.
        /// </summary>
        [NotNull]
        [ItemNotNull]
        public string[] PftSearchPath
        {
            get
            {
                string[] result = new string[3];

                string systemPath = DataPath;
                result[0] = Path.Combine
                    (
                        systemPath,
                        "Deposit_USER"
                    );
                result[1] = DatabasePftPath;
                result[2] = Path.Combine
                    (
                        systemPath,
                        "Deposit"
                    );

                return result;
            }
        }

        #endregion

        #region Construction

        /// <summary>
        /// Constructor.
        /// </summary>
        public LocalProvider()
        {
            Log.Trace("LocalProvider::Constructor");

            // ReSharper disable VirtualMemberCallInConstructor
            RootPath = "C:/IRBIS64";
            DataPath = "C:/IRBIS64/DataI";
            Database = "IBIS";
            Mode = DirectAccessMode.Exclusive;
            // ReSharper restore VirtualMemberCallInConstructor

            _busyState = new BusyState();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public LocalProvider
            (
                string rootPath
            )
            : this(rootPath, DirectAccessMode.Exclusive, true)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public LocalProvider
            (
                string rootPath,
                DirectAccessMode mode,
                bool persistent
            )
            : this()
        {
            _persistentAccessor = persistent;
            RootPath = rootPath;
            DataPath = rootPath + "/DataI";
            Mode = mode;
        }

        /// <summary>
        /// Finalizer.
        /// </summary>
        ~LocalProvider()
        {
#if !WIN81 && !PORTABLE && !SILVERLIGHT

            if (!ReferenceEquals(_accessor, null))
            {
                _accessor.Dispose();
                _accessor = null;
            }

#endif
        }

        #endregion

        #region Private members

        private readonly BusyState _busyState;

        private bool _persistentAccessor;

#if !WIN81 && !PORTABLE && !SILVERLIGHT

        private DirectAccess64 _accessor;

        private string _ExpandPath
            (
                [NotNull] FileSpecification fileSpecification
            )
        {
            string fileName = fileSpecification.FileName;
            if (string.IsNullOrEmpty(fileName))
            {
                throw new IrbisException("fileName");
            }

            string result = null;
            string database = fileSpecification.Database ?? Database;

            switch (fileSpecification.Path)
            {
                case IrbisPath.System:
                    result = Path.Combine
                        (
                            RootPath,
                            fileName
                        );
                    break;

                case IrbisPath.Data:
                    result = Path.Combine
                        (
                            DataPath,
                            fileName
                        );
                    break;

                case IrbisPath.MasterFile:
                    result = Path.Combine
                        (
                            Path.Combine
                                (
                                    DataPath,
                                    database
                                ),
                            fileName
                        );
                    if (!File.Exists(result))
                    {
                        result = Path.Combine
                            (
                                Path.Combine
                                    (
                                        DataPath,
                                        "Deposit"
                                    ),
                                fileName
                            );
                    }
                    break;

                case (IrbisPath)11:
                    result = fileName;
                    break;
            }

            if (string.IsNullOrEmpty(result))
            {
                throw new IrbisException("filePath");
            }

            return result;
        }

        private DirectAccess64 _GetAccessor()
        {
            if (ReferenceEquals(_accessor, null))
            {
                string fileName = Path.Combine
                    (
                        Path.Combine
                            (
                                DataPath,
                                Database
                            ),
                        Database + ".mst"
                    );

                _accessor = new DirectAccess64(fileName, Mode);
            }

            return _accessor;
        }

#endif

        #endregion

        #region Public methods

        #endregion

        #region IrbisProvider members

        /// <inheritdoc cref="IrbisProvider.AcquireFormatter" />
        public override IPftFormatter AcquireFormatter()
        {
            PftContext context = new PftContext(null);
            PftFormatter result = new PftFormatter(context);
            result.SetProvider(this);

            return result;
        }

        /// <inheritdoc cref="IrbisProvider.Configure" />
        public override void Configure
            (
                string configurationString
            )
        {
            Code.NotNullNorEmpty(configurationString, "configurationString");

            Parameter[] parameters = ParameterUtility.ParseString
                (
                    configurationString
                );

            foreach (Parameter parameter in parameters)
            {
                string name = parameter.Name
                    .ThrowIfNull("parameter.Name")
                    .ToLower();
                string value = parameter.Value
                    .ThrowIfNull("parameter.Value");

                switch (name)
                {
                    case "path":
                    case "root":
                        RootPath = value;
                        DataPath = value + "/DataI";
                        break;

                    case "db":
                    case "database":
                        Database = value;
                        break;

                    case "provider": // pass through
                        break;

                    default:
                        throw new IrbisException();
                }
            }
        }

        /// <inheritdoc cref="IrbisProvider.FileExist" />
        public override bool FileExist
            (
                FileSpecification fileSpecification
            )
        {
            Code.NotNull(fileSpecification, "fileSpecification");

#if WIN81 || PocketPC || WINMOBILE || PORTABLE || SILVERLIGHT

            return false;

#else

            using (new BusyGuard(BusyState))
            {
                string resultPath = _ExpandPath(fileSpecification);
                bool result = File.Exists(resultPath);

                return result;
            }

#endif
        }

        /// <inheritdoc cref="IrbisProvider.FormatRecord" />
        public override string FormatRecord
            (
                MarcRecord record,
                string format
            )
        {
            Code.NotNull(record, "record");
            Code.NotNull(format, "format");

            PftProgram program = PftUtility.CompileProgram(format);
            PftContext context = new PftContext(null)
            {
                Record = record
            };
            context.SetProvider(this);
            program.Execute(context);
            string result = context.GetProcessedOutput();

            return result;
        }

        /// <inheritdoc cref="IrbisProvider.GetFileSearchPath" />
        public override string[] GetFileSearchPath()
        {
            return PftSearchPath;
        }

        /// <inheritdoc cref="IrbisProvider.GetMaxMfn" />
        public override int GetMaxMfn()
        {
            int result = 0;

#if !WIN81 && !SILVERLIGHT && !PORTABLE

            DirectAccess64 accessor = null;
            using (new BusyGuard(BusyState))
            {
                try
                {
                    accessor = _GetAccessor();
                    if (!ReferenceEquals(accessor, null))
                    {
                        result = accessor.GetMaxMfn();
                    }
                }
                catch (Exception exception)
                {
                    Log.TraceException
                        (
                            "LocalProvider::GetMaxMfn",
                            exception
                        );
                    }
                finally
                {
                    if (!ReferenceEquals(accessor, null)
                        && !_persistentAccessor)
                    {
                        accessor.Dispose();
                    }
                }
            }

#endif

            return result;
        }

        /// <inheritdoc cref="IrbisProvider.ListDatabases" />
        public override DatabaseInfo[] ListDatabases()
        {
#if WIN81 || PocketPC || WINMOBILE || PORTABLE || SILVERLIGHT

            return new DatabaseInfo[0];

#else

            using (new BusyGuard(BusyState))
            {
                string fileName = Path.Combine
                    (
                        DataPath,
                        "dbnam1.mnu"
                    );

                string[] lines = File.ReadAllLines
                (
                    fileName,
                    IrbisEncoding.Ansi
                );

                DatabaseInfo[] result = DatabaseInfo.ParseMenu(lines);

                return result;
            }

#endif
        }

        /// <inheritdoc cref="IrbisProvider.ReadFile" />
        public override string ReadFile
            (
                FileSpecification fileSpecification
            )
        {
            Code.NotNull(fileSpecification, "fileSpecification");

#if WIN81 || PocketPC || WINMOBILE || SILVERLIGHT || PORTABLE

            return string.Empty;

#else
            using (new BusyGuard(BusyState))
            {
                string result = string.Empty;
                try
                {
                    string resultPath = _ExpandPath(fileSpecification);
                    result = File.ReadAllText
                        (
                            resultPath,
                            IrbisEncoding.Ansi
                        );
                }
                catch (Exception exception)
                {
                    Log.TraceException
                        (
                            "LocalProvider::ReadFile",
                            exception
                        );
                }

                return result;
            }

#endif
        }

        /// <inheritdoc cref="IrbisProvider.ReadRecord" />
        public override MarcRecord ReadRecord
            (
                int mfn
            )
        {
            if (mfn <= 0)
            {
                return null;
            }

            MarcRecord result = null;

#if !WIN81 && !SILVERLIGHT && !PORTABLE

            using (new BusyGuard(BusyState))
            {
                DirectAccess64 accessor = null;
                try
                {
                    accessor = _GetAccessor();
                    if (accessor != null)
                    {
                        result = accessor.ReadRecord(mfn);
                    }
                }
                catch (Exception exception)
                {
                    Log.TraceException
                        (
                            "LocalProvider::ReadRecord",
                            exception
                        );
                }
                finally
                {
                    if (!ReferenceEquals(accessor, null)
                        && !_persistentAccessor)
                    {
                        accessor.Dispose();
                    }
                }
            }

#endif

            return result;
        }

        /// <inheritdoc cref="IrbisProvider.ReadRecordVersion" />
        public override MarcRecord ReadRecordVersion
            (
                int mfn,
                int version
            )
        {
            if (mfn <= 0)
            {
                return null;
            }

            MarcRecord result = null;

#if !WIN81 && !SILVERLIGHT && !PORTABLE

            using (new BusyGuard(BusyState))
            {
                DirectAccess64 accessor = null;
                try
                {
                    accessor = _GetAccessor();
                    if (!ReferenceEquals(accessor, null))
                    {
                        MarcRecord[] versions 
                            = accessor.ReadAllRecordVersions(mfn);
                        int index = version;
                        if (version < 0)
                        {
                            index = versions.Length + version;
                        }
                        if (index >= 0 && index < versions.Length)
                        {
                            result = versions[index];
                        }
                    }
                }
                catch (Exception exception)
                {
                    Log.TraceException
                        (
                            "LocalProvider::ReadRecordVersion",
                            exception
                        );
                }
                finally
                {
                    if (!ReferenceEquals(accessor, null)
                        && !_persistentAccessor)
                    {
                        accessor.Dispose();
                    }
                }

            }

#endif

            return result;
        }

        /// <inheritdoc cref="IrbisProvider.ReadTerms" />
        public override TermInfo[] ReadTerms
            (
                TermParameters parameters
            )
        {
            TermInfo[] result = new TermInfo[0];

#if !WIN81 && !SILVERLIGHT && !PORTABLE

            using (new BusyGuard(BusyState))
            {
                DirectAccess64 accessor = null;
                try
                {
                    accessor = _GetAccessor();
                    if (!ReferenceEquals(accessor, null))
                    {
                        result = accessor.ReadTerms(parameters);
                    }
                }
                catch (Exception exception)
                {
                    Log.TraceException
                        (
                            "LocalProvider::ReadTerms",
                            exception
                        );
                }
                finally
                {
                    if (!ReferenceEquals(accessor, null)
                        && !_persistentAccessor)
                    {
                        accessor.Dispose();
                    }
                }
            }

#endif

            return result;
        }

        /// <inheritdoc cref="IrbisProvider.ReleaseFormatter" />
        public override void ReleaseFormatter
            (
                IPftFormatter formatter
            )
        {
            // Nothing to do here
        }

        /// <inheritdoc cref="IrbisProvider.Search" />
        public override int[] Search
            (
                string expression
            )
        {
            int[] result = new int[0];

            if (string.IsNullOrEmpty(expression))
            {
                return result;
            }

#if !WIN81 && !SILVERLIGHT && !PORTABLE

            using (new BusyGuard(BusyState))
            {
                DirectAccess64 accessor = null;
                try
                {
                    accessor = _GetAccessor();
                    if (!ReferenceEquals(accessor, null))
                    {
                        result = accessor.SearchSimple(expression);
                    }
                }
                catch (Exception exception)
                {
                    Log.TraceException
                        (
                            "LocalProvider::Search",
                            exception
                        );
                }
                finally
                {
                    if (!ReferenceEquals(accessor, null)
                        && !_persistentAccessor)
                    {
                        accessor.Dispose();
                    }
                }
            }

#endif

            return result;
        }

#endregion

        #region IDisposable members

        /// <inheritdoc cref="IDisposable.Dispose" />
        public override void Dispose()
        {
            Log.Trace("LocalProvider::Dispose");

            BusyState.WaitFreeState();

#if !WIN81 && !PORTABLE && !SILVERLIGHT

            if (!ReferenceEquals(_accessor, null))
            {
                _accessor.Dispose();
                _accessor = null;
            }

#endif

            base.Dispose();

            GC.SuppressFinalize(this);
        }

        #endregion

        #region Object members

        #endregion
    }
}

