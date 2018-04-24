using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleDbToolkit;
using SimpleDbToolkit.Annotations;
using SimpleDbToolkit.Tests.MockObjects;

namespace SimpleDbToolkit.Tests
{
    [TestClass]
    public class QueryConstructorTest
    {
        [TestMethod]
        public void GenerateAValidInsertStatement()
        {
            string expected = "INSERT INTO CUSTOMERS(Name, CreditNumber, Identification, LastName) VALUES('Bar', 1231231, 0, 'Foo');";
            Customer customer = new Customer();
            customer.CreditNumber = 1231231;
            customer.Id = 42;
            customer.LastName = "Foo";
            customer.Name = "Bar";

            var constructor = new QueryConstructor<Customer>();
            string result = constructor.Insert(customer);

            Assert.AreEqual(result, expected);

        }
    }
}
