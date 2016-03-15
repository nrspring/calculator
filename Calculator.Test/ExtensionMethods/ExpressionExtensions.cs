using System;
using System.Collections.Generic;
using Calculator.Core.ExtensionMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Test.ExtensionMethods
{
    [TestClass]
    public class ExpressionExtensions
    {
        [TestMethod]
        public void AreTokensAddedCorrectly()
        {
            string original = "10+20-30/40*50";
            string correct = "10|+|20|-|30|/|40|*|50";

            Assert.AreEqual(correct,original.AddAllTokens());
        }
    }
}
