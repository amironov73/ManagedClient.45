﻿using System;
using System.Collections;
using AM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using AM.Collections;

namespace UnitTests.AM.Collections
{
    [TestClass]
    public class TripletTest
    {
        [TestMethod]
        public void Triplet_Construction_1()
        {
            Triplet<int, string, double> triplet 
                = new Triplet<int, string, double>();
            Assert.AreEqual(0, triplet.First);
            Assert.AreEqual(null, triplet.Second);
            Assert.AreEqual(0.0, triplet.Third);
        }

        [TestMethod]
        public void Triplet_Construction_2()
        {
            Triplet<int, string, double> firstTriplet 
                = new Triplet<int, string, double>(1, "Hello", 3.14);
            Triplet<int, string, double> secondTriplet 
                = new Triplet<int, string, double>(firstTriplet);
            Assert.AreEqual(firstTriplet.First, secondTriplet.First);
            Assert.AreEqual(firstTriplet.Second, secondTriplet.Second);
            Assert.AreEqual(firstTriplet.Third, secondTriplet.Third);
        }

        [TestMethod]
        public void Triplet_Construction_3()
        {
            Triplet<int, string, double> triplet 
                = new Triplet<int, string, double>(1);
            Assert.AreEqual(1, triplet.First);
            Assert.AreEqual(null, triplet.Second);
            Assert.AreEqual(0.0, triplet.Third);
        }

        [TestMethod]
        public void Triplet_Construction_4()
        {
            Triplet<int, string, double> triplet 
                = new Triplet<int, string, double>(1, "Hello");
            Assert.AreEqual(1, triplet.First);
            Assert.AreEqual("Hello", triplet.Second);
            Assert.AreEqual(0.0, triplet.Third);
        }

        [TestMethod]
        public void Triplet_Construction_5()
        {
            Triplet<int, string, double> triplet
                = new Triplet<int, string, double>(1, "Hello", 3.14);
            Assert.AreEqual(1, triplet.First);
            Assert.AreEqual("Hello", triplet.Second);
            Assert.AreEqual(3.14, triplet.Third);
        }

        [TestMethod]
        public void Triplet_Construction_6()
        {
            Triplet<int, string, double> triplet
                = new Triplet<int, string, double>(1, "Hello", 3.14, true);
            Assert.AreEqual(1, triplet.First);
            Assert.AreEqual("Hello", triplet.Second);
            Assert.AreEqual(3.14, triplet.Third);
            Assert.AreEqual(true, triplet.ReadOnly);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Triplet_Add_1()
        {
            IList triplet = new Triplet<int, string, double>();
            triplet.Add("hello");
        }

        [TestMethod]
        public void Triplet_Contains_1()
        {
            IList triplet = new Triplet<int, string, double>(1, "Hello", 3.14);
            Assert.AreEqual(true, triplet.Contains(1));
            Assert.AreEqual(true, triplet.Contains("Hello"));
            Assert.AreEqual(true, triplet.Contains(3.14));
            Assert.AreEqual(false, triplet.Contains("World"));
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Triplet_Clear_1()
        {
            IList triplet = new Triplet<int, string, double>();
            triplet.Clear();
        }

        [TestMethod]
        public void Triplet_IndexOf_1()
        {
            IList triplet = new Triplet<int, string, double>(1, "Hello", 3.14);
            Assert.AreEqual(0, triplet.IndexOf(1));
            Assert.AreEqual(1, triplet.IndexOf("Hello"));
            Assert.AreEqual(2, triplet.IndexOf(3.14));
            Assert.AreEqual(-1, triplet.IndexOf("World"));
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Triplet_Insert_1()
        {
            IList triplet = new Triplet<int, string, double>();
            triplet.Insert(0, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Triplet_Remove_1()
        {
            IList triplet = new Triplet<int, string, double>();
            triplet.Remove(1);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Triplet_RemoveAt_1()
        {
            IList triplet = new Triplet<int, string, double>();
            triplet.RemoveAt(1);
        }

        [TestMethod]
        public void Triplet_Indexer_1()
        {
            IList triplet = new Triplet<int, string, double>(1, "Hello", 3.14);
            Assert.AreEqual(1, triplet[0]);
            Assert.AreEqual("Hello", triplet[1]);
            Assert.AreEqual(3.14, triplet[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Triplet_Indexer_2()
        {
            IList triplet = new Triplet<int, string, double>(1, "Hello", 3.14);
            object o = triplet[3];
        }

        [TestMethod]
        public void Triplet_Indexer_3()
        {
            Triplet<int, string, double> triplet
                = new Triplet<int, string, double>();
            triplet[0] = 1;
            Assert.AreEqual(1, triplet.First);
            triplet[1] = "Hello";
            Assert.AreEqual("Hello", triplet.Second);
            triplet[2] = 3.14;
            Assert.AreEqual(3.14, triplet.Third);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void Triplet_Indexer_4()
        {
            Triplet<int, string, double> triplet
                = new Triplet<int, string, double>();
            triplet[0] = "Hello";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Triplet_Indexer_5()
        {
            IList triplet = new Triplet<int, string, double>(1, "Hello", 3.14);
            triplet[3] = null;
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Triplet_Indexer_6()
        {
            IList triplet = new Triplet<int, string, double>(1, "Hello", 3.14, true);
            triplet[0] = 2;
        }

        [TestMethod]
        public void Triplet_IsReadOnly_1()
        {
            IList triplet = new Triplet<int, string, double>();
            Assert.AreEqual(false, triplet.IsReadOnly);

            triplet = new Triplet<int, string, double>(1, "Hello", 3.14, true);
            Assert.AreEqual(true, triplet.IsReadOnly);
        }

        [TestMethod]
        public void Triplet_IsFixedSize_1()
        {
            IList triplet = new Triplet<int, string, double>();
            Assert.AreEqual(true, triplet.IsFixedSize);
        }

        [TestMethod]
        public void Triplet_CopyTo_1()
        {
            IList triplet = new Triplet<int, string, double>();
            object[] array = new object[3];
            triplet.CopyTo(array, 0);
        }

        [TestMethod]
        public void Triplet_Count_1()
        {
            IList triplet = new Triplet<int, string, double>();
            Assert.AreEqual(3, triplet.Count);
        }

        [TestMethod]
        public void Triplet_SyncRoot_1()
        {
            IList triplet = new Triplet<int, string, double>();
            Assert.IsNotNull(triplet.SyncRoot);
        }

        [TestMethod]
        public void Triplet_IsSynchronized_1()
        {
            IList triplet = new Triplet<int, string, double>();
            Assert.AreEqual(false, triplet.IsSynchronized);
        }

        [TestMethod]
        public void Triplet_GetEnumerator_1()
        {
            IList triplet = new Triplet<int, string, double>(1, "Hello", 3.14);
            object[] array = new object[3];
            IEnumerator enumerator = triplet.GetEnumerator();
            enumerator.MoveNext();
            array[0] = enumerator.Current;
            enumerator.MoveNext();
            array[1] = enumerator.Current;
            enumerator.MoveNext();
            array[2] = enumerator.Current;
            Assert.AreEqual(1, array[0]);
            Assert.AreEqual("Hello", array[1]);
            Assert.AreEqual(3.14, array[2]);
        }

        [TestMethod]
        public void Triplet_Clone_1()
        {
            Triplet<int, string, double> first 
                = new Triplet<int, string, double>(1, "Hello", 3.14);
            Triplet<int, string, double> second = (Triplet<int, string, double>)first.Clone();
            Assert.AreEqual(first.First, second.First);
            Assert.AreEqual(first.Second, second.Second);
            Assert.AreEqual(first.Third, second.Third);
        }

        [TestMethod]
        public void Triplet_ReadOnly_1()
        {
            Triplet<int, string, double> triplet
                = new Triplet<int, string, double>();
            Assert.AreEqual(false, triplet.ReadOnly);

            triplet = new Triplet<int, string, double>(1, "Hello", 3.14, true);
            Assert.AreEqual(true, triplet.ReadOnly);
        }

        [TestMethod]
        public void Triplet_AsReadOnly_1()
        {
            Triplet<int, string, double> first
                = new Triplet<int, string, double>(1, "Hello", 3.14);
            Assert.AreEqual(false, first.ReadOnly);

            Triplet<int, string, double> second = first.AsReadOnly();
            Assert.AreEqual(first.First, second.First);
            Assert.AreEqual(first.Second, second.Second);
            Assert.AreEqual(first.Third, second.Third);
            Assert.AreEqual(true, second.ReadOnly);
        }

        [TestMethod]
        [ExpectedException(typeof(ReadOnlyException))]
        public void Triplet_ThrowIfReadOnly_1()
        {
            Triplet<int, string, double> triplet
                = new Triplet<int, string, double>(1, "Hello", 3.14, true);
            triplet.ThrowIfReadOnly();
        }

        [TestMethod]
        public void Triplet_Equals_1()
        {
            Triplet<int, string, double> first 
                = new Triplet<int, string, double>(1, "Hello", 3.14);
            Triplet<int, string, double> second
                = new Triplet<int, string, double>(1, "Hello", 3.14);
            Assert.AreEqual(true, first.Equals(second));

            second = new Triplet<int, string, double>(2, "World", 3.15);
            Assert.AreEqual(false, first.Equals(second));
        }

        [TestMethod]
        public void Triplet_Equals_2()
        {
            Triplet<int, string, double> first
                = new Triplet<int, string, double>(1, "Hello", 3.14);
            object second = new Triplet<int, string, double>(1, "Hello", 3.14);
            Assert.AreEqual(true, first.Equals(second));

            second = new Triplet<int, string, double>(2, "World", 3.15);
            Assert.AreEqual(false, first.Equals(second));

            Assert.AreEqual(false, first.Equals(null));
            Assert.AreEqual(true, first.Equals((object)first));
            Assert.AreEqual(false, first.Equals("Hello"));
        }

        [TestMethod]
        public void Triplet_GetHashCode_1()
        {
            Triplet<int, string, double> first
                = new Triplet<int, string, double>(1, "Hello", 3.14);
            Triplet<int, string, double> second
                = new Triplet<int, string, double>(2, "World", 3.15);
            Assert.AreNotEqual
                (
                    first.GetHashCode(),
                    second.GetHashCode()
                );
        }

        [TestMethod]
        public void Triplet_ToString_1()
        {
            Triplet<int, string, double> triplet
                = new Triplet<int, string, double>(1, "Hello", 3.14);
            string expected = "1;Hello;" + 3.14;
            Assert.AreEqual(expected, triplet.ToString());
        }

        [TestMethod]
        public void Triplet_SetReadOnly_1()
        {
            Triplet<int, string, double> Triplet
                = new Triplet<int, string, double>(1, "Hello", 3.14);
            Assert.AreEqual(false, Triplet.ReadOnly);
            Triplet.SetReadOnly();
            Assert.AreEqual(true, Triplet.ReadOnly);
        }
    }
}
