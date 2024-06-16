﻿using AnyDiff.Tests.TestObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnyDiff.Tests
{
   [TestClass]
    public class OperatorTests
    {
        private DiffProvider _provider;
        private ComparisonOptions _comparisonOptions = ComparisonOptions.All | ComparisonOptions.AllowEqualsOverride;

        [TestInitialize]
        public void OneTimeSetup()
        {
            _provider = new DiffProvider();
        }

        [TestMethod]
        public void Should_EqualOperator_AreSame()
        {
            var obj1 = new EqualOperatorObject(1, "Test name");
            var obj2 = new EqualOperatorObject(1, "Different test name");
            var diff = _provider.ComputeDiff(obj1, obj2, _comparisonOptions);

            Assert.AreEqual(0, diff.Count);
        }

        [TestMethod]
        public void Should_EqualOperator_AreDifferent()
        {
            var obj1 = new EqualOperatorObject(1, "Test name");
            var obj2 = new EqualOperatorObject(2, "Different test name");
            var diff = _provider.ComputeDiff(obj1, obj2, _comparisonOptions);

            Assert.IsTrue(diff.Count > 0);
        }

        [TestMethod]
        public void Should_EquatableOverload_AreSame()
        {
            var obj1 = new EquatableObject(1, "Test name");
            var obj2 = new EquatableObject(1, "Different test name");
            var diff = _provider.ComputeDiff(obj1, obj2, _comparisonOptions);

            Assert.AreEqual(0, diff.Count);
        }

        [TestMethod]
        public void Should_EquatableOverload_AreDifferent()
        {
            var obj1 = new EquatableObject(1, "Test name");
            var obj2 = new EquatableObject(2, "Different test name");
            var diff = _provider.ComputeDiff(obj1, obj2, _comparisonOptions);

            Assert.IsTrue(diff.Count > 0);
        }

        [TestMethod]
        public void Should_NoEqualsOverload_AreDifferent()
        {
            var obj1 = new NonEqualsObject(1, "Test name");
            var obj2 = new NonEqualsObject(1, "Different test name");
            var diff = _provider.ComputeDiff(obj1, obj2, _comparisonOptions);

            Assert.IsTrue(diff.Count > 0);
        }

        [TestMethod]
        public void Should_Equals_AreSame()
        {
            var obj1 = new EqualsObject(1, "Test name");
            var obj2 = new EqualsObject(1, "Different test name");
            var diff = _provider.ComputeDiff(obj1, obj2, _comparisonOptions);

            Assert.AreEqual(0, diff.Count);
        }

        [TestMethod]
        public void Should_Equals_AreDifferent()
        {
            var obj1 = new EqualsObject(1, "Test name");
            var obj2 = new EqualsObject(2, "Different test name");
            var diff = _provider.ComputeDiff(obj1, obj2, _comparisonOptions);

            Assert.IsTrue(diff.Count > 0);
        }
    }
}
