using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data;
using SimpleDbToolkit;
using SimpleDbToolkit.Tests.MockObjects;
using System.Collections.Generic;

namespace SimpleDbToolkit.Tests
{
    [TestClass]
    public class MapperExecuteTestCase
    {
        public T ExecuteScalarWrapper<T>(object value)
        {
            var conn = new Mock<IDbConnection>();
            var command = new Mock<IDbCommand>();
            conn.Setup(x => x.CreateCommand()).Returns(command.Object);
            //command.Setup(x => x.CommandText).Returns("");
            command.Setup(x => x.ExecuteScalar()).Returns(value);
            return Mapper.Execute<T>(conn.Object, "");

        }

        [TestMethod]
        public void ExecuteCastToTypes()
        {
            Assert.AreEqual(ExecuteScalarWrapper<int>(1), 1);
            Assert.AreEqual(ExecuteScalarWrapper<long>((long)1), 1);
            Assert.AreEqual(ExecuteScalarWrapper<short>((short)1), 1);
            Assert.AreEqual(ExecuteScalarWrapper<float>((float)1), 1);
            Assert.AreEqual(ExecuteScalarWrapper<double>(1.23), 1.23);
            Assert.AreEqual(ExecuteScalarWrapper<object>(null), null);
            Assert.AreEqual(ExecuteScalarWrapper<string>(""), "");
        }

        [TestMethod]
        public void ExecuteCastThrowCastException()
        {
            try
            {
                ExecuteScalarWrapper<int>("test");
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(InvalidCastException));
            }
        }

    }
}
