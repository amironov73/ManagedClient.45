﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* MenuSpecification.cs -- 
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System.IO;
using System.Xml.Serialization;

using AM;
using AM.IO;
using AM.Runtime;
using AM.Text;

using CodeJam;

using JetBrains.Annotations;

using ManagedIrbis.Infrastructure;

using MoonSharp.Interpreter;

using Newtonsoft.Json;

#endregion

namespace ManagedIrbis.Menus
{
    //
    // Official documentation says:
    //
    // 1 - ввод через простое меню (неиерархический справочник).
    //
    // Параметр ДОП.ИНФ. имеет следующую структуру:
    // <Menu_file_name>\<SYS|DBN>,<N>\<MnuSort> где:
    // <Menu_file_name> - имя файла справочника (с расширением);
    // <SYS|DBN>,<N> - указывает путь, по которому находится
    // файл справочника. Может принимать следующие значения: 
    // SYS,0 - директория исполняемых модулей; 
    // SYS,N - (N>0) рабочая директория (указываемая в параметре WORKDIR);
    // DBN,N - директория БД ввода (N - любая цифра);
    // <MnuSort> - порядок сортировки справочника:
    // 0-без сортировки;
    // 1-по значениям (по элементам меню);
    // 2-по пояснениям.
    //

    /// <summary>
    /// 
    /// </summary>
    [PublicAPI]
    [XmlRoot("menu")]
    [MoonSharpUserData]
    public sealed class MenuSpecification
        : IHandmadeSerializable,
        IVerifiable
    {
        #region Properties

        /// <summary>
        /// File name (with extension).
        /// </summary>
        [CanBeNull]
        [XmlAttribute("file")]
        [JsonProperty("file")]
        public string FileName { get; set; }

        /// <summary>
        /// Database name.
        /// </summary>
        [CanBeNull]
        [XmlAttribute("db")]
        [JsonProperty("db")]
        public string Database { get; set; }

        /// <summary>
        /// Path.
        /// </summary>
        [XmlAttribute("path")]
        [JsonProperty("path")]
        public IrbisPath Path { get; set; }

        /// <summary>
        /// Sort mode.
        /// </summary>
        [XmlAttribute("sort")]
        [JsonProperty("sort")]
        public int SortMode { get; set; }

        #endregion

        #region Construction

        #endregion

        #region Private members

        #endregion

        #region Public methods

        /// <summary>
        /// Convert <see cref="FileSpecification"/> to menu specification.
        /// </summary>
        [NotNull]
        public static MenuSpecification FromFileSpecification
            (
                [NotNull] FileSpecification specification
            )
        {
            Code.NotNull(specification, "specification");

            MenuSpecification result = new MenuSpecification
            {
                Database = specification.Database,
                Path = specification.Path,
                FileName = specification.FileName
            };

            return result;
        }

        /// <summary>
        /// Parse the text.
        /// </summary>
        [NotNull]
        public static MenuSpecification Parse
            (
                [CanBeNull] string text
            )
        {
            MenuSpecification result = new MenuSpecification
            {
                Path = IrbisPath.MasterFile
            };

            if (!string.IsNullOrEmpty(text))
            {
                TextNavigator navigator = new TextNavigator(text);
                result.FileName = navigator.ReadUntil('\\');
                if (navigator.PeekChar() == '\\')
                {
                    navigator.ReadChar();
                }
                if (!navigator.IsEOF)
                {
                    string db = navigator.ReadUntil('\\');
                    if (navigator.PeekChar() == '\\')
                    {
                        navigator.ReadChar();
                    }

                    result.Database = db; 

                    if (!navigator.IsEOF)
                    {
                        string sortText = navigator.GetRemainingText();
                        int sortMode;
                        NumericUtility.TryParseInt32(sortText, out sortMode);
                        result.SortMode = sortMode;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Should serialize <see cref="Database"/> field?
        /// </summary>
        public bool ShouldSerializeDatabase()
        {
            return !string.IsNullOrEmpty(Database);
        }

        /// <summary>
        /// Should serialize <see cref="SortMode"/> field?
        /// </summary>
        public bool ShouldSerializeSortMode()
        {
            return SortMode != 0;
        }

        /// <summary>
        /// Convert menu specification to <see cref="FileSpecification"/>.
        /// </summary>
        [NotNull]
        public FileSpecification ToFileSpecification()
        {
            FileSpecification result = new FileSpecification
                (
                    Path,
                    Database,
                    FileName.ThrowIfNull("FileName")
                );

            return result;
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

            FileName = reader.ReadNullableString();
            Database = reader.ReadNullableString();
            Path = (IrbisPath) reader.ReadPackedInt32();
            SortMode = reader.ReadPackedInt32();
        }

        /// <inheritdoc cref="IHandmadeSerializable.SaveToStream" />
        public void SaveToStream
            (
                BinaryWriter writer
            )
        {
            Code.NotNull(writer, "writer");

            writer
                .WriteNullable(FileName)
                .WriteNullable(Database)
                .WritePackedInt32((int)Path)
                .WritePackedInt32(SortMode);
        }

        #endregion

        #region IVerifiable members

        /// <inheritdoc cref="IVerifiable.Verify" />
        public bool Verify
            (
                bool throwOnError
            )
        {
            Verifier<MenuSpecification> verifier
                = new Verifier<MenuSpecification>
                    (
                        this,
                        throwOnError
                    );

            verifier
                .NotNullNorEmpty(FileName, "FileName");

            return verifier.Result;
        }

        #endregion

        #region Object members

        /// <inheritdoc cref="object.ToString" />
        public override string ToString()
        {
            return FileName.ToVisibleString();
        }

        #endregion
    }
}
