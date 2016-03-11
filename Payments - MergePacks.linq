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

--This has been merged with Trace # 1264643697
--select * from Packs where id = 9355756486
-- select sum(CheckCount), sum(Amount) from Packs where id in (1264643697,9355756486)
--select * from Checks where packid in (9355756486)

--update Packs set PackStatus = 99, Notes = 'This has been merged with Trace # 1264643697' where id = 9355756486
--update Packs set CheckCount = 775, Amount = 69427.72 where id = 1264643697
--update Checks set packid = 1264643697 where packid in (9355756486)