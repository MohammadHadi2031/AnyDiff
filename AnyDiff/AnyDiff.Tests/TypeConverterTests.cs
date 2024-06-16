﻿using AnyDiff.Tests.TestObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnyDiff.Tests
{
   [TestClass]
    public class TypeConverterTests
    {
        [TestMethod]
        public void ShouldDetect_TimeSpanDifference_UsingTypeConverter()
        {
            var provider = new DiffProvider();

            var obj1 = new TypeConverterObject(1) { StartTime = "04:05:00" };
            var obj2 = new TypeConverterObject(1) { StartTime = "04:06:00" };
            var diff = provider.ComputeDiff(obj1, obj2);
            Assert.AreEqual(1, diff.Count);
            Assert.AreEqual(TimeSpan.FromMinutes(1), diff.First().Delta);
        }

        [TestMethod]
        public void ShouldNotDetect_TimeSpanDifference_WithoutTypeConverter()
        {
            var provider = new DiffProvider();

            var obj1 = new NonTypeConverterObject(1) { StartTime = "04:05:00" };
            var obj2 = new NonTypeConverterObject(1) { StartTime = "04:06:00" };
            var diff = provider.ComputeDiff(obj1, obj2);
            Assert.AreEqual(1, diff.Count);
            Assert.AreNotEqual(TimeSpan.FromMinutes(1), diff.First().Delta);
        }
    }
}
