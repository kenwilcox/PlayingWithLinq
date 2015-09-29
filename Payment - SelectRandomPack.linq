<Query Kind="SQL">
  <Connection>
    <ID>1a4f8074-aaf1-4e8a-a275-8148f1366393</ID>
    <Persist>true</Persist>
    <Server>mbsi-srvprod01</Server>
    <IsProduction>true</IsProduction>
    <Database>Payments</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

select * from Checks where PackId in (
select top 100 id
from Packs p
WHERE (ABS(CAST((BINARY_CHECKSUM(*) * RAND()) as int)) % 100) < 10
)