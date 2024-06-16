﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnyDiff;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AnyDiff.Tests
{
   [TestClass]
    public class DifferenceWordsTests
    {
        [TestMethod]
        public void Should_Detect_WordDifference()
        {
            var diff = DifferenceWords.DiffWords("Lorem ipsum dolor sit amet", "Lorem ipsum dolor amet");
            Assert.AreEqual(1, diff.Additions.Count);
            Assert.AreEqual(1, diff.Deletions.Count);
            Assert.AreEqual("amet", diff.Additions.First());
            Assert.AreEqual("sit", diff.Deletions.First());
        }

        [TestMethod]
        public void Should_Detect_WordDifferenceIgnoreCase()
        {
            var diff = DifferenceWords.DiffWords("lorem ipsum Dolor sit amet", "Lorem ipsum dolor amet", true);
            Assert.AreEqual(1, diff.Additions.Count);
            Assert.AreEqual(1, diff.Deletions.Count);
            Assert.AreEqual("amet", diff.Additions.First());
            Assert.AreEqual("sit", diff.Deletions.First());
        }
    }
}
