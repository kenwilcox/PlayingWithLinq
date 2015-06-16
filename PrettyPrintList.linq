<Query Kind="Statements">
  <Connection>
    <ID>1a4f8074-aaf1-4e8a-a275-8148f1366393</ID>
    <Persist>true</Persist>
    <Server>mbsi-srvprod01</Server>
    <IsProduction>true</IsProduction>
    <Database>Payments</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

List<string> list = new List<string> {
"one",
"two",
};

list.Dump();
var stringIn = "'" + string.Join("','", list.ToArray()) + "'";
stringIn.Dump();
