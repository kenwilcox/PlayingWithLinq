<Query Kind="Statements">
  <Connection>
    <ID>8fff5a69-ea8a-476c-83ed-dd02a3ee2b0d</ID>
    <Persist>true</Persist>
    <Server>mbsi-testsql01.mbsi-dev.local</Server>
    <Database>PARMDev</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
</Query>

Packs
  .Where(p => p.PostingStatus == 3 && p.ScheduledPostDate.Value.Date > DateTime.Now.Date.AddDays(-9) && p.PosterDomainName == "wilcoxk")//p.Notes == null)
  .ToList()
  .ForEach(p => { 
    p.PosterDomainName = null; 
    p.Notes = null;
    }
   );
SubmitChanges();

//Packs.Where(p => p.PostingStatus == 3 && p.ScheduledPostDate.Value.Date > DateTime.Now.Date.AddDays(-9) && p.Notes == null)
