
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MathTests
{
    // Bài 1: Kiểm thử chức năng tính tổng
    [TestFixture]
    public class SumTests
    {
        private int Sum(int a, int b)
        {
            checked { return a + b; }
        }

        [Test]
        public void Sum_PositiveNumbers_ReturnsCorrectResult()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(5, Sum(2, 3));

        }

        [Test]
        public void Sum_NegativeNumbers_ReturnsCorrectResult()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(5, Sum(2, 3));

        }

        [Test]
        public void Sum_MixedNumbers_ReturnsCorrectResult()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, Sum(4, -3));
        }

        [Test]
        public void Sum_MaxValueAndZero_ReturnsMaxValue()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(int.MaxValue, Sum(int.MaxValue, 0));
        }

        [Test]
        public void Sum_MinValueAndZero_ReturnsMinValue()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(int.MinValue, Sum(int.MinValue, 0));
        }

        [Test]
        public void Sum_Overflow_ThrowsException()
        {
            Assert.Throws<OverflowException>(() => Sum(int.MaxValue, 1));
        }

        [Test]
        public void Sum_InputNotInteger_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Sum(Convert.ToInt32("a"), 1));
        }

        [Test]
        public void Sum_NullInputs_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Sum(0, 1));
        }

        // Thêm các test case khác tại đây nếu cần...
    }

    // Bài 2: Kiểm thử chức năng tính tích
    [TestFixture]
    public class MultiplyTests
    {
        private int Multiply(int a, int b)
        {
            checked { return a * b; }
        }

        [Test]
        public void Multiply_PositiveNumbers_ReturnsCorrectResult()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(6, Multiply(2, 3));
        }

        [Test]
        public void Multiply_NegativeNumbers_ReturnsCorrectResult()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(6, Multiply(-2, -3));
        }

        [Test]
        public void Multiply_MixedNumbers_ReturnsCorrectResult()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(-6, Multiply(2, -3));
        }

        [Test]
        public void Multiply_MaxValueAndOne_ReturnsMaxValue()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(int.MaxValue, Multiply(int.MaxValue, 1));
        }

        [Test]
        public void Multiply_ByZero_ReturnsZero()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, Multiply(0, 5));
        }

        [Test]
        public void Multiply_Overflow_ThrowsException()
        {
            Assert.Throws<OverflowException>(() => Multiply(int.MaxValue, 2));
        }

        // Thêm các test case khác tại đây...
    }

    // Bài 3: Kiểm thử chức năng tính hiệu
    [TestFixture]
    public class SubtractTests
    {
        private int Subtract(int a, int b)
        {
            checked { return a - b; }
        }

        [Test]
        public void Subtract_PositiveNumbers_ReturnsCorrectResult()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, Subtract(4, 3));
        }

        [Test]
        public void Subtract_NegativeNumbers_ReturnsCorrectResult()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, Subtract(-2, -3));
        }

        [Test]
        public void Subtract_MixedNumbers_ReturnsCorrectResult()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(5, Subtract(2, -3));
        }

        [Test]
        public void Subtract_MaxValueAndMaxValue_ReturnsZero()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, Subtract(int.MaxValue, int.MaxValue));
        }

        [Test]
        public void Subtract_MinValueAndOne_ThrowsOverflow()
        {
            Assert.Throws<OverflowException>(() => Subtract(int.MinValue, 1));
        }

        // Thêm các test case khác tại đây...
    }

    // Bài 4: Kiểm thử trung bình và truy xuất phần tử
    [TestFixture]
    public class AverageAndArrayAccessTests
    {
        private double Average(IEnumerable<int> numbers)
        {
            if (numbers == null || !numbers.Any())
                throw new ArgumentException("List cannot be empty or null.");
            return numbers.Average();
        }

        private int GetElement(int[] array, int index)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (index < 0 || index >= array.Length)
                throw new IndexOutOfRangeException("Index is out of bounds.");
            return array[index];
        }

        [Test]
        public void Average_ValidList_ReturnsCorrectResult()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(3, Average(new List<int> { 1, 3, 5 }));
        }

        [Test]
        public void Average_EmptyList_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => Average(new List<int>()));
        }

        [Test]
        public void Average_ListWithNegativeNumbers_ReturnsCorrectResult()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(-1, Average(new List<int> { -1, -2, 0 }));
        }

        [Test]
        public void GetElement_ValidIndex_ReturnsElement()
        {
            var array = new int[] { 1, 2, 3 };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2, GetElement(array, 1));
        }

        [Test]
        public void GetElement_IndexOutOfBounds_ThrowsException()
        {
            var array = new int[] { 1, 2, 3 };
            Assert.Throws<IndexOutOfRangeException>(() => GetElement(array, 5));
        }

        [Test]
        public void GetElement_NullArray_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => GetElement(null, 0));
        }

        // Thêm các test case khác tại đây...
    }
}
