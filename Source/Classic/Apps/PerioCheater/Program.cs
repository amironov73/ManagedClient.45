﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* Program.cs -- 
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AM;
using AM.Collections;
using AM.IO;
using AM.Logging;
using AM.Runtime;
using AM.Text;

using CodeJam;

using ManagedIrbis;
using ManagedIrbis.Magazines;

#endregion

// ReSharper disable UseNullPropagation

namespace PerioCheater
{
    class Program
    {
        private static IrbisConnection Connection;
        private static MagazineManager Manager;
        static string year;
        static string fromSigla;
        static string toSigla;

        static void ProcessBinding(string inventory, string index)
        {
            int[] found = Connection.Search("\"II={0}\"", index);
            foreach (int mfn in found)
            {
                MarcRecord r = Connection.ReadRecord(mfn);
                foreach (RecordField f in r.Fields.GetField(910))
                {
                    if (f.GetFirstSubFieldValue('i') == inventory)
                    {
                        f.SetSubField('d', toSigla);
                        Connection.WriteRecord(r);
                        Console.Write(" >");
                        break;
                    }
                }
            }
        }

        static void ProcessIssue(MagazineIssueInfo issue)
        {
            bool modified = false;
            MarcRecord record = issue.Record;
            if (ReferenceEquals(record, null))
            {
                return;
            }

            string worksheet = issue.Worksheet;
            if (string.IsNullOrEmpty(worksheet))
            {
                return;
            }
            if (!worksheet.Contains("NJ"))
            {
                return;
            }

            string index = record.FM(903);
            foreach (RecordField field in record.Fields.GetField(910))
            {
                string inventory = field.GetFirstSubFieldValue('b');
                if (string.IsNullOrEmpty(inventory))
                {
                    continue;
                }

                if (!inventory.StartsWith("П"))
                {
                    continue;
                }

                //string binding = field.GetFirstSubFieldValue('p');
                //if (!string.IsNullOrEmpty(binding))
                //{
                //    field.SetSubField('d', toSigla);
                //    modified = true;
                //    continue;
                //}

                if (field.GetFirstSubFieldValue('d').SameString(fromSigla))
                {
                    field.SetSubField('d', toSigla);
                    Connection.WriteRecord(record);
                    Console.Write("\t" + issue);
                    modified = true;
                }

                ProcessBinding(inventory, index);
            }

            if (modified)
            {
                Console.WriteLine();
            }
        }

        static void ProcessMagazine(MagazineInfo magazine)
        {
            Console.WriteLine(magazine.ExtendedTitle);
            if (!magazine.IsNewspaper)
            {
                return;
            }

            if (ReferenceEquals(magazine.Cumulation, null))
            {
                return;
            }

            MagazineCumulation[] matching = magazine.Cumulation
                .Where(c => c.Year.SameString(year) && c.Place.SameString(fromSigla))
                .ToArray();
            if (matching.Length == 0)
            {
                return;
            }

            foreach (MagazineCumulation cumulation in matching)
            {
                if (!ReferenceEquals(cumulation.Field, null))
                {
                    cumulation.Field.SetSubField('d', toSigla);
                }
            }

            Connection.WriteRecord(magazine.Record);
            Console.WriteLine("\t* * *");

            MagazineIssueInfo[] issues = Manager.GetIssues(magazine, year);
            foreach (MagazineIssueInfo issue in issues)
            {
                ProcessIssue(issue);
            }
        }

        static void Main(string[] args)
        {
            if (args.Length != 4)
            {
                return;
            }

            string connectionString = args[0];
            year = args[1];
            fromSigla = args[2];
            toSigla = args[3];

            try
            {
                using (Connection = new IrbisConnection(connectionString))
                {
                    Manager = new MagazineManager(Connection);
                    MagazineInfo[] allMagazines = Manager.GetAllMagazines();
                    foreach (MagazineInfo magazine in allMagazines)
                    {
                        ProcessMagazine(magazine);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
