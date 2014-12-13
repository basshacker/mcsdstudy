using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTestExampleOne : ContextAwareTest
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

            UnitTestWriteLine writeLine = new UnitTestWriteLine(TestContext);

            example.Run(new string[1], writeLine);

            Assert.AreEqual(1, writeLine.Lines.Count);
        }

        [TestMethod]
        public void TestCollect()
        {
            Examples.ExampleOne example = new Examples.ExampleOne();

            Assert.IsTrue(example.Initialize());

            List<Type> types = new List<Type>();

            example.CollectValueTypes(types);

            Assert.AreEqual(1, types.Count);
        }
    }
}
