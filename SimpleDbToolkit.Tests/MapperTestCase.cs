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
    public class MapperTestCase
    {
        [TestMethod]
        public void DoesTheFlowGoesAsExpected()
        {
            var connection = new Mock<IDbConnection>();
            var reader = new Mock<IDataReader>();
            var command = new Mock<IDbCommand>();

            DataTable Schema = new DataTable();
            Schema.Columns.AddRange(new DataColumn[] { new DataColumn("ColumnName") });
            DataRow[] schemaRows = new DataRow[2];
            schemaRows[0] = Schema.NewRow();
            schemaRows[0]["ColumnName"] = "Id";
            schemaRows[1] = Schema.NewRow();
            schemaRows[1]["ColumnName"] = "Name";

            connection.Setup(x => x.CreateCommand()).Returns(() => command.Object);
            connection.Setup(x => x.Open()).Callback(() => { });
            connection.Setup(x => x.Close()).Callback(() => { });
            command.Setup(x => x.ExecuteReader()).Returns(() => reader.Object);
            command.Setup(x => x.CommandText).Returns(() => "NULL");

            reader.Setup(x => x.GetSchemaTable()).Returns(() => Schema);
            int number = 0;
            reader.Setup(x => x.Read()).Returns(() => number++ == 2 ? false : true);

            reader.Setup(x => x.GetOrdinal(It.IsAny<string>())).Returns<string>(x => x == "Id" ? 0 : 1);
            reader.Setup(x => x.GetValue(It.IsAny<int>())).Returns<int>(x => x == 0 ? (object)1 : "asd");
            List<MockItem> resultGet = Mapper.Get<MockItem>(connection.Object, "");

            Assert.AreEqual(resultGet.Count, 2);
            Assert.AreEqual(resultGet[0].Id, 1);
            Assert.AreEqual(resultGet[0].Name, "asd");
            Assert.AreEqual(resultGet[1].Id, 1);
            Assert.AreEqual(resultGet[1].Name, "asd");
        }
    }
}
