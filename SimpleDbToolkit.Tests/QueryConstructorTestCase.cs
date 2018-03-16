using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleDbToolkit.Tests
{
    [TestClass]
    public class QueryConstructorTestCase
    {
        [TestMethod]
        public void DoesSelectAllReturnCorrectly()
        {
            var query = QueryConstructor<MockObjects.MockItem>.SelectAll();

            Assert.AreEqual(query, "SELECT Id, Name, FROM MockItem");

        }
    }
}
