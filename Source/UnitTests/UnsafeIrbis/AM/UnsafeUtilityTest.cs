﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnsafeAM;

namespace UnitTests.UnsafeAM
{
    [TestClass]
    public class UnsafeUtilityTest
    {
        [TestMethod]
        public void UnsafeUtility_Alloc_1()
        {
            const int size = 1024;
            var span = UnsafeUtility.Alloc(size);
            for (int i = 0; i < size; i++)
            {
                span[i] = 1;
            }

            for (int i = 0; i < size; i++)
            {
                Assert.AreEqual(1, span[i]);
            }

            UnsafeUtility.Free(span);
        }

        [TestMethod]
        public void UnsafeUtility_AsSpan_1()
        {
            // Little endian machine required

            int value = 0;
            var span = UnsafeUtility.AsSpan(ref value, 4);
            span[0] = 0x01;
            span[1] = 0x02;
            span[2] = 0x03;
            span[3] = 0x04;
            Assert.AreEqual(0x04030201, value);
        }

        [TestMethod]
        public void UnsafeUtility_AsSpan_2()
        {
            // Little endian machine required

            int value = 0;
            var span = UnsafeUtility.AsSpan(ref value);
            span[0] = 0x01;
            span[1] = 0x02;
            span[2] = 0x03;
            span[3] = 0x04;
            Assert.AreEqual(0x04030201, value);
        }
    }
}
