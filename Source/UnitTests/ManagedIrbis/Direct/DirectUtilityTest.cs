﻿using System;
using System.IO;
using System.IO.MemoryMappedFiles;

using AM;
using AM.IO;

using JetBrains.Annotations;

using ManagedIrbis;
using ManagedIrbis.Direct;

using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable InvokeAsExtensionMethod

namespace UnitTests.ManagedIrbis.Direct
{
    [TestClass]
    public class DirectUtilityTest
        : Common.CommonUnitTest
    {
        [NotNull]
        private string _GetReadFileName()
        {
            return Path.Combine(TestDataPath, "record.txt");
        }

        [NotNull]
        private string _GetWriteFileName()
        {
            Random random = new Random();
            string result = Path.Combine
                (
                    Path.GetTempPath(),
                    random.Next().ToInvariantString()
                );

            return result;
        }

        [TestMethod]
        public void DirectUlility_CreateDatabase32_1()
        {
            Random random = new Random();
            string directory = Path.Combine
                (
                    Path.GetTempPath(),
                    random.Next().ToInvariantString() + "_1"
                );
            Directory.CreateDirectory(directory);
            string path = Path.Combine(directory, "database");
            DirectUtility.CreateDatabase32(path);
            string[] files = Directory.GetFiles(directory);
            Assert.AreEqual(8, files.Length);
        }

        [TestMethod]
        public void DirectUlility_CreateDatabase64_1()
        {
            Random random = new Random();
            string directory = Path.Combine
                (
                    Path.GetTempPath(),
                    random.Next().ToInvariantString() + "_2"
                );
            Directory.CreateDirectory(directory);
            string path = Path.Combine(directory, "database");
            DirectUtility.CreateDatabase64(path);
            string[] files = Directory.GetFiles(directory);
            Assert.AreEqual(5, files.Length);
        }

        [TestMethod]
        public void DirectUtility_OpenFile_1()
        {
            string fileName = _GetReadFileName();
            Stream stream = DirectUtility.OpenFile
                (
                    fileName,
                    DirectAccessMode.ReadOnly
                );
            Assert.IsNotNull(stream);
            stream.Dispose();
        }

        [TestMethod]
        public void DirectUtility_OpenFile_2()
        {
            string fileName = _GetWriteFileName();
            FileUtility.Touch(fileName);
            Stream stream = DirectUtility.OpenFile
                (
                    fileName,
                    DirectAccessMode.Shared
                );
            Assert.IsNotNull(stream);
            stream.Dispose();
            File.Delete(fileName);
        }

        [TestMethod]
        public void DirectUtility_OpenFile_3()
        {
            string fileName = _GetWriteFileName();
            FileUtility.Touch(fileName);
            Stream stream = DirectUtility.OpenFile
                (
                    fileName,
                    DirectAccessMode.Exclusive
                );
            Assert.IsNotNull(stream);
            stream.Dispose();
            File.Delete(fileName);
        }

        [TestMethod]
        [ExpectedException(typeof(IrbisException))]
        public void DirectUtility_OpenFile_4()
        {
            string fileName = _GetWriteFileName();
            FileUtility.Touch(fileName);
            DirectUtility.OpenFile
                (
                    fileName,
                    (DirectAccessMode)100
                );
        }

        [TestMethod]
        public void DirectUtility_OpenMemoryMappedFile_1()
        {
            string fileName = _GetReadFileName();
            MemoryMappedFile mmf = DirectUtility.OpenMemoryMappedFile(fileName);
            Assert.IsNotNull(mmf);
            mmf.Dispose();
        }

        [TestMethod]
        public void DirectUtility_ReadNetworkInt32_1()
        {
            string fileName = _GetReadFileName();
            MemoryMappedFile mmf = DirectUtility.OpenMemoryMappedFile(fileName);
            MemoryMappedViewAccessor accessor
                = mmf.CreateViewAccessor(0, 100, MemoryMappedFileAccess.Read);
            try
            {
                int expected = 0x3639323A;
                int actual = DirectUtility.ReadNetworkInt32(accessor, 4);
                Assert.AreEqual(expected, actual);
            }
            finally
            {
                accessor.Dispose();
                mmf.Dispose();
            }
        }

        [TestMethod]
        public void DirectUtility_ReadNetworkInt32_2()
        {
            string fileName = _GetReadFileName();
            MemoryMappedFile mmf = DirectUtility.OpenMemoryMappedFile(fileName);
            MemoryMappedViewStream stream
                = mmf.CreateViewStream(0, 100, MemoryMappedFileAccess.Read);
            try
            {
                int expected = unchecked((int)0xEFBBBF23);
                int actual = DirectUtility.ReadNetworkInt32(stream);
                Assert.AreEqual(expected, actual);
            }
            finally
            {
                stream.Dispose();
                mmf.Dispose();
            }
        }

        [TestMethod]
        public void DirectUtility_ReadNetworkInt64_1()
        {
            string fileName = _GetReadFileName();
            MemoryMappedFile mmf = DirectUtility.OpenMemoryMappedFile(fileName);
            MemoryMappedViewAccessor accessor
                = mmf.CreateViewAccessor(0, 100, MemoryMappedFileAccess.Read);
            try
            {
                long expected = 0x205E42323639323AL;
                long actual = DirectUtility.ReadNetworkInt64(accessor, 4);
                Assert.AreEqual(expected, actual);
            }
            finally
            {
                accessor.Dispose();
                mmf.Dispose();
            }
        }

        [TestMethod]
        public void DirectUtility_ReadNetworkInt64_2()
        {
            string fileName = _GetReadFileName();
            MemoryMappedFile mmf = DirectUtility.OpenMemoryMappedFile(fileName);
            MemoryMappedViewStream stream
                = mmf.CreateViewStream(0, 100, MemoryMappedFileAccess.Read);
            try
            {
                long expected = 0x3639323AEFBBBF23;
                long actual = DirectUtility.ReadNetworkInt64(stream);
                Assert.AreEqual(expected, actual);
            }
            finally
            {
                stream.Dispose();
                mmf.Dispose();
            }
        }
    }
}
