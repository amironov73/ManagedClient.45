﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* AbstractMetadataFormat.cs --
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JetBrains.Annotations;

#endregion

namespace ManagedIrbis.Metadata
{
    //
    // https://en.wikipedia.org/wiki/Metadata_standard
    //

    /// <summary>
    /// Абстрактный формат метаданных.
    /// </summary>
    [PublicAPI]
    public abstract class AbstractMetadataFormat
    {
    }
}
