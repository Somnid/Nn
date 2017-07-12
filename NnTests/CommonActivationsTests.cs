using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nn;
using System;
using System.Collections.Generic;
using System.Text;

namespace NnTests
{
    [TestClass]
    public class CommonActivationsTests
    {
        [TestMethod]
        public void Rectifier_should_return_positive_value()
        {
            var result = CommonActivations.Rectifier(4);
            Assert.AreEqual(result, 4);
        }
        [TestMethod]
        public void Rectifier_should_not_go_negative()
        {
            var result = CommonActivations.Rectifier(-4);
            Assert.AreEqual(result, 0);
        }
    }
}
