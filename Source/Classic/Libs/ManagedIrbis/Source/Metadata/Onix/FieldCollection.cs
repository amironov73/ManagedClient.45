﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* FieldCollection.cs --
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

using AM.Collections;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

#endregion

namespace ManagedIrbis.Metadata.Onix
{
    /// <summary>
    ///
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public sealed class FieldCollection
        : NonNullCollection<OnixField>
    {
    }
}