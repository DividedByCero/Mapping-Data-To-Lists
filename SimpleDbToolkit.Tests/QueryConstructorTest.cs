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
        public void DoesGenerateAInsertStatement()
        {
            Customer customer = new Customer();
            customer.CreditNumber = 1231231;
            customer.Id = 42;
            customer.LastName = "Foo";
            customer.Name = "Bar";

            var constructor = new QueryConstructor<Customer>();
            string result = constructor.Insert(customer);
        }
    }
}
