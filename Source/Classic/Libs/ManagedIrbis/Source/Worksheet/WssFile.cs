﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* WssFile.cs -- вложенный рабочий лист
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Xml.Serialization;

using AM;
using AM.Collections;
using AM.IO;
using AM.Runtime;

using CodeJam;

using JetBrains.Annotations;

using ManagedIrbis.Client;
using ManagedIrbis.Infrastructure;

using MoonSharp.Interpreter;

using Newtonsoft.Json;

#endregion

namespace ManagedIrbis.Worksheet
{
    /// <summary>
    /// Вложенный рабочий лист.
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    [XmlRoot("wss")]
    [DebuggerDisplay("{Name}")]
    public sealed class WssFile
        : IHandmadeSerializable,
        IVerifiable
    {
        #region Properties

        /// <summary>
        /// Имя рабочего листа.
        /// </summary>
        [CanBeNull]
        [XmlAttribute("name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Элементы рабочего листа.
        /// </summary>
        [NotNull]
        [XmlArray("items")]
        [XmlArrayItem("item")]
        [JsonProperty("items")]
        public NonNullCollection<WorksheetItem> Items { get; private set; }

        #endregion

        #region Construction

        /// <summary>
        /// Конструктор
        /// </summary>
        public WssFile()
        {
            Items = new NonNullCollection<WorksheetItem>();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Разбор потока.
        /// </summary>
        [NotNull]
        public static WssFile ParseStream
            (
                [NotNull] TextReader reader
            )
        {
            Code.NotNull(reader, "reader");

            WssFile result = new WssFile();

            int count = int.Parse(reader.RequireLine());

            for (int i = 0; i < count; i++)
            {
                WorksheetItem item = WorksheetItem.ParseStream(reader);
                result.Items.Add(item);
            }

            return result;
        }

        /// <summary>
        /// Read from server.
        /// </summary>
        [CanBeNull]
        public static WssFile ReadFromServer
            (
                [NotNull] IrbisProvider provider,
                [NotNull] FileSpecification specification
            )
        {
            Code.NotNull(provider, "provider");
            Code.NotNull(specification, "specification");

            string content = provider.ReadFile(specification);
            if (string.IsNullOrEmpty(content))
            {
                return null;
            }

            using (StringReader reader = new StringReader(content))
            {
                return ParseStream(reader);
            }
        }

        /// <summary>
        /// Считывание из локального файла.
        /// </summary>
        [NotNull]
        public static WssFile ReadLocalFile
            (
                [NotNull] string fileName,
                [NotNull] Encoding encoding
            )
        {
            Code.NotNullNorEmpty(fileName, "fileName");
            Code.NotNull(encoding, "encoding");

            using (StreamReader reader = TextReaderUtility.OpenRead
                (
                    fileName,
                    encoding
                ))
            {
                WssFile result = ParseStream(reader);

                result.Name = Path.GetFileName(fileName);

                return result;
            }
        }

        /// <summary>
        /// Считывание из локального файла.
        /// </summary>
        [NotNull]
        public static WssFile ReadLocalFile
            (
                [NotNull] string fileName
            )
        {
            return ReadLocalFile
                (
                    fileName,
                    IrbisEncoding.Ansi
                );
        }

        /// <summary>
        /// Should serialize the <see cref="Items"/> collection?
        /// </summary>
        [ExcludeFromCodeCoverage]
        public bool ShouldSerializeItems()
        {
            return Items.Count != 0;
        }

        #endregion

        #region IHandmadeSerializable members

        /// <inheritdoc cref="IHandmadeSerializable.RestoreFromStream" />
        public void RestoreFromStream
            (
                BinaryReader reader
            )
        {
            Code.NotNull(reader, "reader");

            Name = reader.ReadNullableString();
            Items = reader.ReadNonNullCollection<WorksheetItem>();
        }

        /// <inheritdoc cref="IHandmadeSerializable.SaveToStream" />
        public void SaveToStream
            (
                BinaryWriter writer
            )
        {
            Code.NotNull(writer, "writer");

            writer.WriteNullable(Name);
            writer.Write(Items);
        }

        #endregion

        #region IVerifiable members

        /// <inheritdoc cref="IVerifiable.Verify" />
        public bool Verify
            (
                bool throwOnError
            )
        {
            Verifier<WssFile> verifier
                = new Verifier<WssFile>(this, throwOnError);

            foreach (WorksheetItem item in Items)
            {
                verifier.VerifySubObject(item, "item");
            }

            return verifier.Result;
        }

        #endregion

        #region Object members

        /// <inheritdoc cref="object.ToString" />
        public override string ToString()
        {
            return Name.ToVisibleString();
        }

        #endregion
    }
}
