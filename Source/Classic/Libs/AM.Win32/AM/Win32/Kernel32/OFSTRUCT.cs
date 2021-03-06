﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* OFSTRUCT.cs -- information about a file that the OpenFile function opened or attempted to open
   Ars Magna project, http://arsmagna.ru */

#region Using directives

using System;
using System.Runtime.InteropServices;

using JetBrains.Annotations;

#endregion

// ReSharper disable InconsistentNaming

namespace AM.Win32
{
    /// <summary>
    /// Contains information about a file that the OpenFile function
    /// opened or attempted to open.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Size = SIZE)]
    public struct OFSTRUCT
    {
        /// <summary>
        /// Size of the structure, in bytes.
        /// </summary>
        public const int SIZE = 136;

        /// <summary>
        /// 
        /// </summary>
        public const int OFS_MAXPATHNAME = 128;

        /// <summary>
        /// Length of the structure, in bytes.
        /// </summary>
        public byte cBytes;

        /// <summary>
        /// If this member is nonzero, the file is on a hard 
        /// (fixed) disk. Otherwise, it is not.
        /// </summary>
        public byte fFixedDisk;

        /// <summary>
        /// MS-DOS error code if the OpenFile function failed.
        /// </summary>
        public short nErrCode;

        /// <summary>
        /// Reserved; do not use.
        /// </summary>
        public short Reserved1;

        /// <summary>
        /// Reserved; do not use.
        /// </summary>
        public short Reserved2;

        /// <summary>
        /// Path and file name of the file.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = OFS_MAXPATHNAME)]
        public string szPathName;
    }
}