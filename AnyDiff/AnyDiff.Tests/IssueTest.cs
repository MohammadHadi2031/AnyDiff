using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AnyDiff.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnyDiff.Tests;

[TestClass]
public class IssueTest
{
    [TestMethod]
    public void ExcludeByStringTest()
    {
        var B1s = new List<B> { new B { Id = 10, Name = "Test 10" }, new B { Id = 11, Name = "Test 11" } };
        var B2s = new List<B> { new B { Id = 10, Name = "Test 10" }, new B { Id = 12, Name = "Test 12" } };
        var A1 = new A();
        A1.Id = 1;
        A1.Bs = B1s;
        var A2 = new A();
        A1.Id = 2;
        A2.Bs = B2s;

        var diff = A1.Diff(A2, propertiesToExcludeOrInclude: new string[] { ".Bs.Name", ".Id" });

        Assert.AreEqual(1, diff.Count);
    }

    class A
    {
        public List<B> Bs { get; set; } = new List<B>();
        public int Id { get; set; }
    }

    class B
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
