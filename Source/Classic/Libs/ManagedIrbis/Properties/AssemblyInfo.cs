﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* AssemblyInfo.cs
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;

#endregion

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("ManagedIrbis")]
[assembly: AssemblyDescription("Managed runtime for IRBIS system")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("ManagedIrbis")]
[assembly: AssemblyCopyright("Copyright © Alexey Mironov 2006-2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(true)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("7d0f7e61-2c17-4903-b53d-0f534c5718e1")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.8.1.2050")]
[assembly: AssemblyFileVersion("1.8.1.2050")]

[assembly: CLSCompliant(true)]

[assembly: AllowPartiallyTrustedCallers]

#if FW4

[assembly: SecurityRules(SecurityRuleSet.Level1)]

#endif
