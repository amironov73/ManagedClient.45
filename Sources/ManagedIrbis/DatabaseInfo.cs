﻿/* DatabaseInfo.cs -- информация о базе данных ИРБИС
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using AM;
using AM.IO;
using AM.Runtime;

using CodeJam;

using JetBrains.Annotations;

using ManagedIrbis.Infrastructure;

using MoonSharp.Interpreter;

using Newtonsoft.Json;

#endregion

namespace ManagedIrbis
{
    /// <summary>
    /// Информация о базе данных ИРБИС
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    [DebuggerDisplay("{Name} {Description}")]
    public sealed class DatabaseInfo
        : IHandmadeSerializable
    {
        #region Constants

        /// <summary>
        /// Разделитель элементов
        /// </summary>
        public const char ItemDelimiter = (char)0x1E;

        #endregion

        #region Properties

        /// <summary>
        /// Имя базы данных.
        /// </summary>
        [CanBeNull]
        [XmlAttribute("name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Описание базы данных
        /// </summary>
        [CanBeNull]
        [XmlAttribute("description")]
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Максимальный MFN.
        /// </summary>
        [XmlAttribute("max-mfn")]
        [JsonProperty("max-mfn")]
        public int MaxMfn { get; set; }

        /// <summary>
        /// Список логически удаленных записей.
        /// </summary>
        [CanBeNull]
        [XmlArray("logically-deleted")]
        [XmlArrayItem("mfn")]
        [JsonProperty("logically-deleted")]
        public int[] LogicallyDeletedRecords { get; set; }

        /// <summary>
        /// Список физически удаленных записей.
        /// </summary>
        [CanBeNull]
        [XmlArray("physically-deleted")]
        [XmlArrayItem("mfn")]
        [JsonProperty("physically-deleted")]
        public int[] PhysicallyDeletedRecords { get; set; }

        /// <summary>
        /// Список неактуализированных записей.
        /// </summary>
        [CanBeNull]
        [XmlArray("nonactualized-records")]
        [XmlArrayItem("mfn")]
        [JsonProperty("nonactualized-records")]
        public int[] NonActualizedRecords { get; set; }

        /// <summary>
        /// Список заблокированных записей.
        /// </summary>
        [CanBeNull]
        [XmlArray("locked-records")]
        [XmlArrayItem("mfn")]
        [JsonProperty("locked-records")]
        public int[] LockedRecords { get; set; }

        /// <summary>
        /// Флаг монопольной блокировки базы данных.
        /// </summary>
        [XmlAttribute("database-locked")]
        [JsonProperty("database-locked")]
        public bool DatabaseLocked { get; set; }

        /// <summary>
        /// База данных только для чтения.
        /// </summary>
        [XmlAttribute("read-only")]
        [JsonProperty("read-only")]
        public bool ReadOnly { get; set; }

        #endregion

        #region Private members

        private static int[] _ParseLine(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new int[0];
            }

            string[] items = text.Split(ItemDelimiter);
            int[] result = items
                // ReSharper disable once ConvertClosureToMethodGroup
                // Due to .NET 3.5
                .Select(_ => int.Parse(_))
                .OrderBy(_ => _)
                .ToArray();

            return result;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Разбор ответа сервера.
        /// </summary>
        [NotNull]
        public static DatabaseInfo ParseServerResponse
            (
                [NotNull] ServerResponse response
            )
        {
            Code.NotNull(response, "response");

            DatabaseInfo result = new DatabaseInfo
                {
                    LogicallyDeletedRecords
                        = _ParseLine(response.GetAnsiString()),
                    PhysicallyDeletedRecords
                    = _ParseLine(response.GetAnsiString()),
                    NonActualizedRecords
                        = _ParseLine(response.GetAnsiString()),
                    LockedRecords
                        = _ParseLine(response.GetAnsiString()),
                    MaxMfn = _ParseLine(response.GetAnsiString())
                        .GetItem(0,0),
                    DatabaseLocked
                        = _ParseLine(response.GetAnsiString())
                        .GetItem(0,0) != 0
                };

            return result;
        }

        /// <summary>
        /// Разбор файла меню
        /// </summary>
        [NotNull]
        [ItemNotNull]
        public static DatabaseInfo[] ParseMenu
            (
                [NotNull] string[] text
            )
        {
            Code.NotNull(text, "text");

            List<DatabaseInfo> result = new List<DatabaseInfo>();

            for (int i = 0; i < text.Length; i += 2)
            {
                string name = text[i];
                if (string.IsNullOrEmpty(name)
                    || name.StartsWith("*"))
                {
                    break;
                }
                bool readOnly = false;
                if (name.StartsWith("-"))
                {
                    name = name.Substring(1);
                    readOnly = true;
                }
                string description = text[i + 1];
                DatabaseInfo oneBase = new DatabaseInfo
                    {
                        Name = name,
                        Description = description,
                        ReadOnly = readOnly
                    };
                result.Add(oneBase);
            }

            return result.ToArray();
        }

        #endregion

        #region IHandmadeSerializable membrs

        /// <summary>
        /// Просим объект восстановить свое состояние из потока.
        /// </summary>
        public void RestoreFromStream
            (
                BinaryReader reader
            )
        {
            Name = reader.ReadNullableString();
            Description = reader.ReadNullableString();
            MaxMfn = reader.ReadPackedInt32();
            LogicallyDeletedRecords 
                = reader.ReadNullableInt32Array();
            PhysicallyDeletedRecords
                = reader.ReadNullableInt32Array();
            NonActualizedRecords
                = reader.ReadNullableInt32Array();
            LockedRecords
                = reader.ReadNullableInt32Array();
            DatabaseLocked = reader.ReadBoolean();
        }

        /// <summary>
        /// Просим объект сохранить себя в потоке.
        /// </summary>
        public void SaveToStream
            (
                BinaryWriter writer
            )
        {
            writer
                .WriteNullable(Name)
                .WriteNullable(Description)
                .WritePackedInt32(MaxMfn)
                .WriteNullableArray(LogicallyDeletedRecords)
                .WriteNullableArray(PhysicallyDeletedRecords)
                .WriteNullableArray(NonActualizedRecords)
                .WriteNullableArray(LockedRecords)
                .Write(DatabaseLocked);
        }

        #endregion

        #region Object members

        /// <summary>
        /// Returns a <see cref="System.String" />
        /// that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" />
        /// that represents this instance.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("Name: {0}", Name);
            result.AppendLine();

            result.AppendFormat("Description: {0}", Description);
            result.AppendLine();

            result.Append("Logically deleted records: ");
            result.AppendLine(NumericUtility.CompressRange
                (
                    LogicallyDeletedRecords
                ));

            result.Append("Physically deleted records: ");
            result.AppendLine(NumericUtility.CompressRange
                (
                    PhysicallyDeletedRecords
                ));

            result.Append("Non-actualized records: ");
            result.AppendLine(NumericUtility.CompressRange
                (
                    NonActualizedRecords
                ));

            result.Append("Locked records: ");
            result.AppendLine(NumericUtility.CompressRange
                (
                    LockedRecords
                ));

            result.AppendFormat("Max MFN: {0}", MaxMfn);
            result.AppendLine();

            result.AppendFormat("Database locked: {0}", DatabaseLocked);
            result.AppendLine();

            return result.ToString();
        }

        #endregion
    }
}
