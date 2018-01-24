using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data;
namespace SimpleDbToolkit.Tests
{
    [TestClass]
    public class MapperTestCase
    {
        [TestMethod]
        public void DidTheLogicFlowGoesWell()
        {
            var connection = new Mock<IDbConnection>();
            var reader = new Mock<IDataReader>();
            var command = new Mock<IDbCommand>();

            connection.Setup(x => x.CreateCommand()).Returns(() => command.Object);
            command.Setup(x => x.ExecuteReader()).Returns(() => reader.Object);


            //...

        }
    }
}
