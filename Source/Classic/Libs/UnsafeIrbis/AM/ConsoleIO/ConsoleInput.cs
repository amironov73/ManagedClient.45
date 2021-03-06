﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* ConsoleInput.cs --
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;

using UnsafeCode;

using JetBrains.Annotations;

#endregion

namespace UnsafeAM.ConsoleIO
{
    /// <summary>
    /// Console input.
    /// </summary>
    [PublicAPI]
    public static class ConsoleInput
    {
        #region Properties

        /// <summary>
        /// Background color.
        /// </summary>
        public static ConsoleColor BackgroundColor
        {
            get => Driver.BackgroundColor;
            set => Driver.BackgroundColor = value;
        }

        /// <summary>
        /// Driver for the console.
        /// </summary>
        [NotNull]
        public static IConsoleDriver Driver { get; private set; }

        /// <summary>
        /// Foreground color.
        /// </summary>
        public static ConsoleColor ForegroundColor
        {
            get => Driver.ForegroundColor;
            set => Driver.ForegroundColor = value;
        }

        /// <summary>
        /// Key available?
        /// </summary>
        public static bool KeyAvailable => Driver.KeyAvailable;

        /// <summary>
        /// Console title.
        /// </summary>
        public static string Title
        {
            get => Driver.Title;
            set => Driver.Title = value;
        }

        #endregion

        #region Construction

        static ConsoleInput()
        {
            Driver = new SystemConsole();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Clear the console.
        /// </summary>
        public static void Clear()
        {
            Driver.Clear();
        }

        /// <summary>
        /// Read one character.
        /// </summary>
        public static int Read()
        {
            return Driver.Read();
        }

        /// <summary>
        /// Read one key.
        /// </summary>
        public static ConsoleKeyInfo ReadKey
            (
                bool intercept
            )
        {
            return Driver.ReadKey(intercept);
        }

        /// <summary>
        /// Read line.
        /// </summary>
        [CanBeNull]
        public static string ReadLine()
        {
            return Driver.ReadLine();
        }

        /// <summary>
        /// Set driver.
        /// </summary>
        [NotNull]
        public static IConsoleDriver SetDriver
            (
                [NotNull] IConsoleDriver driver
            )
        {
            Code.NotNull(driver, nameof(driver));

            IConsoleDriver previousDriver = Driver;

            Driver = driver;

            return previousDriver;
        }

        /// <summary>
        /// Write text.
        /// </summary>
        public static void Write
            (
                string text
            )
        {
            if (!string.IsNullOrEmpty(text))
            {
                Driver.Write(text);
            }
        }

        /// <summary>
        /// Goto next line.
        /// </summary>
        public static void WriteLine()
        {
            Driver.WriteLine();
        }

        /// <summary>
        /// Write text and goto next line.
        /// </summary>
        public static void WriteLine
            (
                string text
            )
        {
            Write(text);
            WriteLine();
        }

        #endregion
    }
}
