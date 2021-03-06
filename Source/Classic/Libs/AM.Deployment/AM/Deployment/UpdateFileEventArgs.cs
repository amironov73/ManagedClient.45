// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* UpdateFileEventArgs.cs -- 
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;

using CodeJam;

using JetBrains.Annotations;

#endregion

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local

namespace AM.Deployment
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateFileEventArgs
        : EventArgs
    {
        #region Properties

        ///<summary>
        /// Destination file name.
        ///</summary>
        [NotNull]
        public string DestinationFile { get; private set; }

        ///<summary>
        /// Source file name.
        ///</summary>
        [NotNull]
        public string SourceFile { get; private set; }

        #endregion

        #region Construction

        /// <summary>
        /// Constructor.
        /// </summary>
        public UpdateFileEventArgs
            (
                [NotNull] string destinationFile,
                [NotNull] string sourceFile
            )
        {
            Code.NotNullNorEmpty(destinationFile, "destinationFile");
            Code.NotNullNorEmpty(sourceFile, "sourceFile");

            DestinationFile = destinationFile;
            SourceFile = sourceFile;
        }

        #endregion

        #region Private members

        #endregion

        #region Public methods

        #endregion
    }
}