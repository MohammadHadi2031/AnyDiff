using AnyDiff.Tests.TestObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AnyDiff.Tests
{
   [TestClass]
    public class NullableIntegralDeltaTests
    {
        [TestMethod]
        public void ShouldDetect_NullableInt_AdditionDelta()
        {
            var provider = new DiffProvider();

            var obj1 = new TestObject { NullableIntValue = null };
            var obj2 = new TestObject { NullableIntValue = 5 };
            var diff = provider.ComputeDiff<TestObject>(obj1, obj2);
            Assert.AreEqual(1, diff.Count);
            Assert.AreEqual(5, diff.First().Delta);
        }

        [TestMethod]
        public void ShouldDetect_NullableInt_AdditionDeltaWithValue()
        {
            var provider = new DiffProvider();

            var obj1 = new TestObject { NullableIntValue = 1 };
            var obj2 = new TestObject { NullableIntValue = 5 };
            var diff = provider.ComputeDiff<TestObject>(obj1, obj2);
            Assert.AreEqual(1, diff.Count);
            Assert.AreEqual(4, diff.First().Delta);
        }

        [TestMethod]
        public void ShouldDetect_NullableDecimal_AdditionDelta()
        {
            var provider = new DiffProvider();

            var obj1 = new TestObject { NullableDecimalValue = null };
            var obj2 = new TestObject { NullableDecimalValue = 5M };
            var diff = provider.ComputeDiff<TestObject>(obj1, obj2);
            Assert.AreEqual(1, diff.Count);
            Assert.AreEqual(5M, diff.First().Delta);
        }

        [TestMethod]
        public void ShouldDetect_NullableDecimal_AdditionDeltaWithValue()
        {
            var provider = new DiffProvider();

            var obj1 = new TestObject { NullableDecimalValue = 1M };
            var obj2 = new TestObject { NullableDecimalValue = 5M };
            var diff = provider.ComputeDiff<TestObject>(obj1, obj2);
            Assert.AreEqual(1, diff.Count);
            Assert.AreEqual(4M, diff.First().Delta);
        }

        [TestMethod]
        public void ShouldDetect_NullableInt_SubtractionDelta()
        {
            var provider = new DiffProvider();

            var obj1 = new TestObject { NullableIntValue = 7 };
            var obj2 = new TestObject { NullableIntValue = null };
            var diff = provider.ComputeDiff<TestObject>(obj1, obj2);
            Assert.AreEqual(1, diff.Count);
            Assert.AreEqual(-7, diff.First().Delta);
        }

        [TestMethod]
        public void ShouldDetect_NullableInt_SubtractionDeltaWithValue()
        {
            var provider = new DiffProvider();

            var obj1 = new TestObject { NullableIntValue = 7 };
            var obj2 = new TestObject { NullableIntValue = 2 };
            var diff = provider.ComputeDiff<TestObject>(obj1, obj2);
            Assert.AreEqual(1, diff.Count);
            Assert.AreEqual(-5, diff.First().Delta);
        }

        [TestMethod]
        public void ShouldDetect_NullableDecimal_SubtractionDelta()
        {
            var provider = new DiffProvider();

            var obj1 = new TestObject { NullableDecimalValue = 7M };
            var obj2 = new TestObject { NullableDecimalValue = null };
            var diff = provider.ComputeDiff<TestObject>(obj1, obj2);
            Assert.AreEqual(1, diff.Count);
            Assert.AreEqual(-7M, diff.First().Delta);
        }

        [TestMethod]
        public void ShouldDetect_NullableDecimal_SubtractionDeltaWithValue()
        {
            var provider = new DiffProvider();

            var obj1 = new TestObject { NullableDecimalValue = 7M };
            var obj2 = new TestObject { NullableDecimalValue = 2M };
            var diff = provider.ComputeDiff<TestObject>(obj1, obj2);
            Assert.AreEqual(1, diff.Count);
            Assert.AreEqual(-5M, diff.First().Delta);
        }
    }
}
