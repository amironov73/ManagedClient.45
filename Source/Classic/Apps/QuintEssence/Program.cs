﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using AM;

using ManagedIrbis.Direct;

// ReSharper disable LocalizableElement

namespace QuintEssence
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                return;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();

            try
            {

                string inputFile = args[0];
                string outputFile = args[1];
                List<string> list = new List<string>();

                using (DirectAccess64 accessor
                    = new DirectAccess64(inputFile, DirectAccessMode.Exclusive))
                {
                    int maxMfn = accessor.GetMaxMfn();
                    list.Capacity = maxMfn;
                    for (int mfn = 1; mfn < maxMfn; mfn++)
                    {
                        if ((mfn % 10000) == 1)
                        {
                            Console.Write(".");
                        }

                        MstRecord64 record;
                        try
                        {
                            record = accessor.ReadRawRecord(mfn);
                        }
                        catch
                        {
                            continue;
                        }

                        if (ReferenceEquals(record, null))
                        {
                            continue;
                        }

                        string index = record.GetField(903);
                        string countText = record.GetField(999);
                        if (string.IsNullOrEmpty(index) || string.IsNullOrEmpty(countText))
                        {
                            continue;
                        }

                        int count;
                        if (!int.TryParse(countText, out count) || (count == 0))
                        {
                            continue;
                        }

                        string text = index + "\t" + countText;
                        list.Add(text);
                    }

                    list.Sort();
                    File.WriteAllLines(outputFile, list);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            Console.WriteLine();
            Console.WriteLine("Elapsed: {0}", stopwatch.Elapsed.ToAutoString());
        }
    }
}