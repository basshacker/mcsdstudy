using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTestExampleOne
    {
        [TestMethod]
        public void TestInitialize()
        {
            Examples.ExampleOne example = new Examples.ExampleOne();

            Assert.IsTrue(example.Initialize());
        }
    }
}
