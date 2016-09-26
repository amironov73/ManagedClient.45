﻿/* QAstLevel9.cs --
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using AM;
using AM.IO;

using CodeJam;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

using Newtonsoft.Json;

#endregion

namespace ManagedIrbis.Search.Infrastructure
{
    /// <summary>
    /// Level 9.
    /// </summary>
    public sealed class QAstLevel9
    {
        #region Properties

        public QAstLevel8 Left { get; set; }

        public QAstLevel8[] Right { get; set; }

        #endregion

        #region Object members

        /// <inheritdoc/>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(Left);
            if (!ReferenceEquals(Right, null))
            {
                foreach (QAstLevel8 right in Right)
                {
                    result.Append(" + ");
                    result.Append(right);
                }
            }

            return result.ToString();
        }

        #endregion
    }
}
