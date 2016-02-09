using System;
using ADCSBDEMOS.Chapter_4;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ADCSBDEMOS.Tests
{
    [TestClass]
    public class DynamicTest
    {
        [TestMethod]
        public void TestOverloadWithDynamic()
        {
            var c = new C();
            dynamic str = "hey";

            string result = c.SomeMethod(str);
            Assert.IsTrue(result.Contains("string"));
        }
        [TestMethod]
        public void TestOverloadWithString()
        {
            var c = new C();
            string str = "hey";

            string result = c.SomeMethod(str);
            result.Should().Contain("string");
        }
    }
}
