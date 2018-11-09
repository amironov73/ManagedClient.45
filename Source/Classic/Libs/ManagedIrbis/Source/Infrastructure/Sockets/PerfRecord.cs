// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* PerfRecord.cs --
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;
using System.Xml.Serialization;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

using Newtonsoft.Json;

#endregion

namespace ManagedIrbis.Infrastructure.Sockets
{
    /// <summary>
    /// Запись о произведенной сетевой транзакции.
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    [XmlRoot("transaction")]
    public sealed class PerfRecord
    {
        #region Properties

        /// <summary>
        /// Moment.
        /// </summary>
        [XmlAttribute("moment")]
        [JsonProperty("moment", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime Moment { get; set; }

        /// <summary>
        /// Код операции.
        /// </summary>
        [XmlAttribute("code")]
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        /// <summary>
        /// Размер исходящего пакета (байты).
        /// </summary>
        [XmlAttribute("outgoing")]
        [JsonProperty("outgoing", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int OutgoingSize { get; set; }

        /// <summary>
        /// Размер входящего пакета (байты).
        /// </summary>
        [XmlAttribute("incoming")]
        [JsonProperty("incoming", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int IncomingSize { get; set; }

        /// <summary>
        /// Затрачено времени (миллисекунды).
        /// </summary>
        [XmlAttribute("elapsed")]
        [JsonProperty("elapsed", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long ElapsedTime { get; set; }

        /// <summary>
        /// Сообщение об ошибке (если есть).
        /// </summary>
        [XmlElement("error")]
        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMessage { get; set; }

        #endregion
    }
}