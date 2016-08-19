﻿/* CreationDisposition.cs --  
   Ars Magna project, http://library.istu.edu/am */

#region Using directives

using System;

#endregion

namespace AM.Win32
{
	/// <summary>
	/// File creation disposition
	/// </summary>
	public enum CreationDisposition
	{
		/// <summary>
		/// Creates a new file. The function fails if the specified 
		/// file already exists.
		/// </summary>
		CREATE_NEW = 1,

		/// <summary>
		/// Creates a new file. If the file exists, the function 
		/// overwrites the file, clears the existing attributes, 
		/// combines the specified file attributes and flags with 
		/// FILE_ATTRIBUTE_ARCHIVE, but does not set the security 
		/// descriptor specified by the SECURITY_ATTRIBUTES structure.
		/// </summary>
		CREATE_ALWAYS = 2,

		/// <summary>
		/// Opens the file. The function fails if the file does not exist. 
		/// </summary>
		OPEN_EXISTING = 3,

		/// <summary>
		/// Opens the file, if it exists. If the file does not exist, 
		/// the function creates the file as if dwCreationDisposition 
		/// were CREATE_NEW.
		/// </summary>
		OPEN_ALWAYS = 4,

		/// <summary>
		/// Opens the file and truncates it so that its size is zero 
		/// bytes. The calling process must open the file with the 
		/// GENERIC_WRITE access right. The function fails if the file 
		/// does not exist. 
		/// </summary>
		TRUNCATE_EXISTING = 5
	}
}
