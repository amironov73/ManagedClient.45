﻿/* RequestManager.cs -- управление читательскими заказами
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#if !NETCORE && !SILVERLIGHT

#region Using directives

using System;
using System.IO;
using System.Linq;

using AM;

using CodeJam;

using JetBrains.Annotations;

using ManagedIrbis.Readers;

using MoonSharp.Interpreter;

#if WINMOBILE || PocketPC

using CM=OpenNETCF.Configuration.ConfigurationSettings;

#else

using CM = System.Configuration.ConfigurationManager;

#endif

#endregion

namespace ManagedIrbis.Requests
{

    /// <summary>
    /// Управление читательскими заказами.
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public sealed class RequestManager
        : IDisposable
    {
        #region Properties

        /// <summary>
        /// ИРБИС-клиент
        /// </summary>
        [NotNull]
        public IrbisConnection Connection { get; private set; }

        /// <summary>
        /// Host name.
        /// </summary>
        [NotNull]
        public string Host
        {
            get
            {
                return _GetSetting
                    (
                        "host",
                        "127.0.0.1"
                    );
            }
        }

        /// <summary>
        /// Port number.
        /// </summary>
        public int Port
        {
            get
            {
                return int.Parse(_GetSetting
                    (
                        "port",
                        "6666"
                    ));
            }
        }

        /// <summary>
        /// Request database name.
        /// </summary>
        [NotNull]
        public string RequestDatabase
        {
            get
            {
                return _GetSetting
                    (
                        "request-db",
                        "RQST"
                    );
            }
        }

        /// <summary>
        /// Catalog database name.
        /// </summary>
        [NotNull]
        public string CatalogDatabase
        {
            get
            {
                return _GetSetting
                    (
                        "catalog-db",
                        "IBIS"
                    );
            }
        }

        /// <summary>
        /// Reader database name.
        /// </summary>
        [NotNull]
        public string ReaderDatabase
        {
            get
            {
                return _GetSetting
                    (
                        "reader-db",
                        "RDR"
                    );
            }
        }

        /// <summary>
        /// User login.
        /// </summary>
        [NotNull]
        public string Login
        {
            get
            {
                return _GetSetting
                    (
                        "login",
                        "1"
                    );
            }
        }

        /// <summary>
        /// User password.
        /// </summary>
        [NotNull]
        public string Password
        {
            get
            {
                return _GetSetting
                    (
                        "password",
                        "1"
                    );
            }
        }

        /// <summary>
        /// Filter specification.
        /// </summary>
        [NotNull]
        public string FilterSpecification
        {
            get
            {
                return _GetSetting
                    (
                        "my",
                        "*"
                    );
            }
        }

        /// <summary>
        /// Places.
        /// </summary>
        [NotNull]
        public string[] Places { get; set; }

        #endregion

        #region Private members

        private string _GetSetting
            (
                string name,
                string defaultValue
            )
        {
            string result = CM.AppSettings[name];
            if (string.IsNullOrEmpty(result))
            {
                result = defaultValue;
            }

            return result;
        }

        private IrbisConnection _CreateClient()
        {
            IrbisConnection result = new IrbisConnection
                {
                    Host = Host,
                    Port = Port,
                    Database = RequestDatabase,
                    Username = Login,
                    Password = Password
                };
            result.Connect();

            return result;
        }

        #endregion

        #region Construction

        /// <summary>
        /// Constructor.
        /// </summary>
        public RequestManager()
        {
            Connection = _CreateClient();
            Places = _GetSetting("place", "*").Split(',', ';');
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Получение списка новых заказов.
        /// </summary>
        [NotNull]
        public BookRequest[] GetRequests()
        {
            int[] found = Connection.Search("I=0");

            return found
                .Select(mfn => Connection.ReadRecord(mfn))
                .Where(record => record != null)
                .Select(record => BookRequest.Parse(record))
                .Where(request => request != null)
                .ToArray();
        }

        /// <summary>
        /// Get additional info.
        /// </summary>
        public void GetAdditionalInfo
            (
                [NotNull] BookRequest request
            )
        {
            Code.NotNull(request, "request");

            if (!ReferenceEquals(request.BookCode, null))
            {
                MarcRecord record = ReadCatalog(request.BookCode);
                request.BookRecord = record;
                request.FreeNumbers = ExtractInventoryNumbers(record);
                //request.Reader = ReadReader(request.ReaderID);
                request.MyNumbers = FilterMyNumbers(request.FreeNumbers);
            }
        }

        /// <summary>
        /// Read info from catalog.
        /// </summary>
        [CanBeNull]
        public MarcRecord ReadCatalog
            (
                [NotNull] string bookCode
            )
        {
            try
            {
                Connection.PushDatabase(CatalogDatabase);
                int[] found = Connection.Search
                    (
                        "\"I={0}\"",
                        bookCode
                    );
                if (found.Length == 0)
                {
                    return null;
                }
                MarcRecord result = Connection.ReadRecord(found[0]);

                return result;
            }
            finally
            {
                Connection.PopDatabase();
            }
        }

        /// <summary>
        /// Write request.
        /// </summary>
        public void WriteRequest
            (
                [NotNull] BookRequest request
            )
        {
            MarcRecord record = request.RequestRecord;
            if (record != null)
            {
                Connection.WriteRecord(record, false, true);
            }
        }

        /// <summary>
        /// Determine, whether is our place?
        /// </summary>
        public bool IsOurPlace
            (
                [NotNull] RecordField field
            )
        {
            if (Places.Contains("*"))
            {
                return true;
            }

            string place = field.GetFirstSubFieldValue('D');

            return Places.Any(p => string.Compare(p, place,
                StringComparison.OrdinalIgnoreCase) == 0);
        }

        /// <summary>
        /// Extract inventory numbers.
        /// </summary>
        [NotNull]
        [ItemNotNull]
        public string[] ExtractInventoryNumbers
            (
                [CanBeNull] MarcRecord record
            )
        {
            if (record == null)
            {
                return new string[0];
            }

            RecordField[] allFields = record.Fields
                .GetField("910", "A", "0");

            RecordField[] ourFields = allFields
                .Where(IsOurPlace)
                .ToArray();

            if (allFields.Length > ourFields.Length)
            {
                return new string[0];
            }

            return ourFields
                .GetSubField('B')
                .GetSubFieldValue();
        }

        /// <summary>
        /// Загрузка сведений о читателе.
        /// </summary>
        [CanBeNull]
        public ReaderInfo ReadReader
            (
                [NotNull] string readerID
            )
        {
            Code.NotNullNorEmpty(readerID, "readerID");

            try
            {
                Connection.PushDatabase(ReaderDatabase);
                int[] found = Connection.Search
                    (
                        "I={0}",
                        readerID
                    );
                if (found.Length == 0)
                {
                    return null;
                }
                MarcRecord record = Connection.ReadRecord(found[0]);
                ReaderInfo result = ReaderInfo.Parse(record);

                return result;
            }
            finally
            {
                Connection.PopDatabase();
            }
        }

        /// <summary>
        /// Filter my numbers.
        /// </summary>
        [NotNull]
        public string[] FilterMyNumbers
            (
                [NotNull] string[] numbers
            )
        {
            throw new NotImplementedException();
#if NOTDEF
            NumberFilter filter = NumberFilter.ParseNumbers(FilterSpecification);
            return filter.FilterNumbers(numbers);
#endif
        }

        #endregion

        #region IDisposable members

        /// <summary>
        /// Performs application-defined tasks associated
        /// with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // ReSharper disable ConditionIsAlwaysTrueOrFalse
            if (Connection != null)
            {
                //if (Client.DebugWriter != null)
                //{
                //    Client.DebugWriter.Dispose();
                //    Client.DebugWriter = null;
                //}

                Connection.Dispose();
            }
            // ReSharper restore ConditionIsAlwaysTrueOrFalse
        }

        #endregion
    }
}

#endif
