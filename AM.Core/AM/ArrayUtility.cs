/* ArrayUtility.cs -- array manipulation helpers
 * Ars Magna project, http://arsmagna.ru 
 */

#region Using directives

using System;
using System.Collections.Generic;

using CodeJam;

using JetBrains.Annotations;

#endregion

namespace AM
{
    /// <summary>
    /// <see cref="Array"/> manipulation helper methods.
    /// </summary>
    [PublicAPI]
    public static class ArrayUtility
    {
        #region Public methods

        /// <summary>
        /// Changes type of given array to the specified type.
        /// </summary>
        /// <param name="sourceArray">Source array.</param>
        /// <typeparam name="FROM">Type of source array.</typeparam>
        /// <typeparam name="TO">Type of destination array.</typeparam>
        /// <returns>Allocated array with converted items.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="sourceArray"/> is <c>null</c>.
        /// </exception>
        [NotNull]
        public static TO[] ChangeType<FROM, TO>
            (
                [NotNull] FROM[] sourceArray
            )
        {
            Code.NotNull(sourceArray, "sourceArray");

            TO[] result = new TO[sourceArray.Length];
            Array.Copy(sourceArray, result, sourceArray.Length);

            return result;
        }

        /// <summary>
        /// Changes type of given array to the specified type.
        /// </summary>
        /// <param name="sourceArray">Source array.</param>
        /// <typeparam name="TO">Type of destination array.</typeparam>
        /// <returns>Allocated array with converted items.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="sourceArray"/> is <c>null</c>.
        /// </exception>
        [NotNull]
        public static TO[] ChangeType<TO>
            (
                [NotNull] Array sourceArray
            )
        {
            Code.NotNull(sourceArray, "sourceArray");

            TO[] result = new TO[sourceArray.Length];
            Array.Copy(sourceArray, result, sourceArray.Length);

            return result;
        }

        /// <summary>
        /// Compares two specified arrays by elements.
        /// </summary>
        /// <param name="firstArray">First array to compare.</param>
        /// <param name="secondArray">Second array to compare.</param>
        /// <returns><para>Less than zero - first array is less.</para>
        /// <para>Zero - arrays are equal.</para>
        /// <para>Greater than zero - first array is greater.</para>
        /// </returns>
        /// <typeparam name="T">Array element type.</typeparam>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="firstArray"/> or 
        /// <paramref name="secondArray"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">Length of
        /// <paramref name="firstArray"/> is not equal to length of
        /// <paramref name="secondArray"/>.
        /// </exception>
        public static int Compare<T>
            (
                [NotNull] T[] firstArray, 
                [NotNull] T[] secondArray
            )
            where T : IComparable<T>
        {
            Code.NotNull(firstArray, "firstArray");
            Code.NotNull(secondArray, "secondArray");

            if (firstArray.Length
                 != secondArray.Length)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < firstArray.Length; i++)
            {
                int result = firstArray[i].CompareTo(secondArray[i]);
                if (result != 0)
                {
                    return result;
                }
            }

            return 0;
        }

        /// <summary>
        /// Converts the specified array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns></returns>
        public static TO[] Convert<FROM, TO>(FROM[] array)
        {
            Code.NotNull(array, "array");

            TO[] result = new TO[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                result[i] = ConversionUtility.ConvertTo<TO>(array[i]);
            }

            return result;
        }

        /// <summary>
        /// Creates the array of specified length initializing it with
        /// specified value.
        /// </summary>
        /// <param name="length">Desired length of the array.</param>
        /// <param name="initialValue">The initial value of
        /// array items.</param>
        /// <returns>Created and initialized array.</returns>
        /// <typeparam name="T">Type of array item.</typeparam>
        public static T[] Create<T>(int length, T initialValue)
        {
            Code.Nonnegative(length, "length");

            T[] result = new T[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = initialValue;
            }

            return result;
        }

        /// <summary>
        /// Determines whether the specified array is null or empty
        /// (has zero length).
        /// </summary>
        /// <param name="array">Array to check.</param>
        /// <returns><c>true</c> if the array is null or empty;
        /// otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty
            (
                [CanBeNull] Array array
            )
        {
            return (ReferenceEquals(array, null)
                     || (array.Length == 0));
        }

        /// <summary>
        /// Merges the specified arrays.
        /// </summary>
        /// <param name="arrays">Arrays to merge.</param>
        /// <returns>Array that consists of all <paramref name="arrays"/>
        /// items.</returns>
        /// <typeparam name="T">Type of array item.</typeparam>
        /// <exception cref="ArgumentNullException">
        /// At least one of <paramref name="arrays"/> is <c>null</c>.
        /// </exception>
        [NotNull]
        public static T[] Merge<T>
            (
                [NotNull] params T[][] arrays
            )
        {
            int resultLength = 0;
            for (int i = 0; i < arrays.Length; i++)
            {
                if (arrays[i] == null)
                {
                    throw new ArgumentNullException("arrays");
                }
                resultLength += arrays[i].Length;
            }

            T[] result = new T[resultLength];
            int offset = 0;
            for (int i = 0; i < arrays.Length; i++)
            {
                arrays[i].CopyTo(result, offset);
                offset += arrays[i].Length;
            }

            return result;
        }


        /// <summary>
        /// Toes the string.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns></returns>
        public static string[] ToString<T>
            (
                [NotNull] T[] array
            )
        {
            Code.NotNull(array, "array");

            string[] result = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                object o = array[i];
                if (o != null)
                {
                    result[i] = array[i].ToString();
                }
            }

            return result;
        }

        #endregion
    }
}