﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* RuleUtility.cs -- utility routines for quality rules
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using AM;
using AM.Logging;

using CodeJam;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

#endregion

namespace ManagedIrbis.Quality
{
    /// <summary>
    /// Utility routines for quality rules.
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public static class RuleUtility
    {
        #region Public fields

        /// <summary>
        /// Плохие символы, которые не должны встречаться в записях.
        /// </summary>
        public static char[] BadCharacters
        {
            get { return _badCharacters; }
        }

        #endregion

        #region Private members

        private static readonly char[] _badCharacters =
        {
            // Управляющие символы
            '\x00', '\x01', '\x02', '\x03', '\x04', '\x05', '\x06',
            '\x07', '\x08', '\x09', '\x0A', '\x0B', '\x0C', '\x0D',
            '\x0E', '\x0F', '\x10', '\x11', '\x12', '\x13', '\x14',
            '\x15', '\x16', '\x17', '\x18', '\x19', '\x1A', '\x1B',
            '\x1C', '\x1D', '\x1E', '\x1F',

            '\x7F', '\x80', '\x81', '\x82', '\x83', '\x84', '\x85',
            '\x86', '\x87', '\x88', '\x89', '\x8A', '\x8B', '\x8C',
            '\x8D', '\x8E', '\x8F', '\x90', '\x91', '\x92', '\x93',
            '\x94', '\x95', '\x96', '\x97', '\x98', '\x99', '\x9A',
            '\x9B', '\x9C', '\x9D', '\x9E', '\x9F',
            
            // Пунктуация
            '\xA0', // Non breaking space
            '\xAD', // Soft hyphen

            // Расширенная пунктуация
            '\u2000', // En quad
            '\u2001', // Em quad
            '\u2002', // En space
            '\u2003', // Em space
            '\u2004', // Three per em space
            '\u2005', // Four per em space
            '\u2006', // Six per em space
            '\u2007', // Figure space
            '\u2008', // Punctuation space
            '\u2009', // Thin space
            '\u200A', // Hair space
            '\u200B', // Zero width space
            '\u200C', // Zero width non-joiner
            '\u200D', // Zero width joiner
            '\u200E', '\u200F',

            '\u2010', // Hyphen
            '\u2011', // Non breaking hyphen
            '\u2012', // Figure dash
            '\u2013', // En dash
            '\u2014', // Em dash
            '\u2015', // Horizontal bar
            '\u2016', // Double vertical line
            '\u2017', // Double low line
            '\u2018', // Left single quotation mark
            '\u2019', // Right single quotation mark
            '\u201A', // Single low-9 quotation mark
            '\u201B', // Single high reversed-9 quotation mark
            '\u201C', // Left double quotation mark
            '\u201D', // Right double quotation mark
            '\u201E', // Double low-9 quotation mark
            '\u201F', // Double high reversed-9 quotation mark

            '\u2028', // Line separator
            '\u2029', // Paragraph separator
            '\u202F', // Narrow no-break space
            
            '\u205F', // Medium mathematical space
            '\u2060', // Word joiner

            '\u2420', // Symbol for space
            '\u2422', // Blank symbol
            '\u2423', // Open box
            
            '\u3000', // Ideographic space

            '\uFEFF'  // Zero width no-break space
        };

        private static readonly char[] _delimiters = {';', ',', ' ', '\t'};

        // ReSharper disable PossibleMultipleEnumeration

        private static IEnumerable<RecordField> _GetField1
            (
                IEnumerable<RecordField> fields,
                string oneSpec
            )
        {
            if (string.IsNullOrEmpty(oneSpec))
            {
                return new RecordField[0];
            }
            if (oneSpec.Contains("x"))
            {
                oneSpec = oneSpec.Replace("x", "[0-9]");
            }
            if (oneSpec.Contains("X"))
            {
                oneSpec = oneSpec.Replace("X", "[0-9]");
            }
            return oneSpec.Contains("[")
                ? fields.GetFieldRegex(oneSpec)
                : fields.GetField(NumericUtility.ParseInt32(oneSpec));
        }

        private static IEnumerable<RecordField> _GetField2
            (
                IEnumerable<RecordField> fields,
                string allSpec
            )
        {
            List<RecordField> result = new List<RecordField>();
            
            string[] parts;

#if WINMOBILE

            parts = allSpec.Split(_delimiters);

#else

            parts = allSpec.Split
                (
                    _delimiters,
                    StringSplitOptions.RemoveEmptyEntries
                );

#endif

            foreach (string oneSpec in parts)
            {
                result.AddRange(_GetField1(fields, oneSpec));
            }

            return result.ToArray();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Get field by specification.
        /// </summary>
        [NotNull]
        public static RecordField[] GetFieldBySpec
            (
                [NotNull] this IEnumerable<RecordField> fields,
                [CanBeNull] string allSpec
            )
        {
            if (string.IsNullOrEmpty(allSpec))
            {
                return new RecordField[0];
            }
            
            List<RecordField> result = new List<RecordField>();

            string[] parts = allSpec.Split('!');
            if (parts.Length > 2)
            {
                Log.Error
                    (
                        "RuleUtility::GetFieldBySpec: "
                        + "bad spec format="
                        + allSpec.ToVisibleString()
                    );

                throw new FormatException("allSpec");
            }

            string include = parts[0].Trim(_delimiters);
            string exclude = parts.Length == 2
                ? parts[1].Trim(_delimiters)
                : string.Empty;
            if (string.IsNullOrEmpty(include))
            {
                if (!string.IsNullOrEmpty(exclude))
                {
                    result.AddRange(fields);
                }
            }
            else
            {
                result.AddRange(_GetField2(fields, include));
            }

            result = result
                .Distinct()
                .ToList();
            if (result.Count != 0)
            {
                result = result
                    .Except(_GetField2(fields, exclude))
                    .ToList();
            }

            return result.ToArray();
        }

        /// <summary>
        /// Whether the character is bad?
        /// </summary>
        public static bool IsBadCharacter
            (
                char c
            )
        {
            return Array.IndexOf
                (
                    BadCharacters,
                    c
                ) >= 0;
        }

        /// <summary>
        /// Индекс первого найденного плохого символа в строке
        /// </summary>
        public static int BadCharacterPosition
            (
                [NotNull] string text
            )
        {
            Code.NotNull(text, "text");

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (IsBadCharacter(c))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Renumber fields.
        /// </summary>
        [NotNull]
        public static MarcRecord RenumberFields
            (
                [NotNull] MarcRecord record
            )
        {
            Code.NotNull(record, "record");

            RenumberFields
                (
                    record,
                    record.Fields
                );

            return record;
        }

        /// <summary>
        /// Renumber fields.
        /// </summary>
        public static void RenumberFields
            (
                [NotNull] MarcRecord record,
                [NotNull] IEnumerable<RecordField> fields
            )
        {
            Code.NotNull(record, "record");
            Code.NotNull(fields, "fields");

            List<int> seen = new List<int>();

            foreach (RecordField field in fields)
            {
                field.Record = record;
                int count = 1;
                foreach (int s in seen)
                {
                    if (s == field.Tag)
                    {
                        count++;
                    }
                }
                seen.Add(field.Tag);
                field.Repeat = count;
                foreach (SubField subField in field.SubFields)
                {
                    subField.Field = field;
                }
            }

        }

        #endregion
    }
}
