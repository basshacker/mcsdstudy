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

        [TestMethod]
        public void TestRun()
        {
            Examples.ExampleOne example = new Examples.ExampleOne();

            Assert.IsTrue(example.Initialize());

            example.Run(new string[1]);
        }
    }
}
