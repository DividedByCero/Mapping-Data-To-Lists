#Getting Data

```csharp
string ConnectionString = "...";

//Instance of ISqlConnection
SqlConnection Conn = new SqlConnection(ConnectionString);

//Querying The Respective Statement
List<Supplier> Suppliers = Mapper.Get<Supplier>(Conn, "SELECT * FROM Suppliers");

//Printing Data.
Suppliers.ForEach(x => {
    Console.WriteLine(x.City);
});
```