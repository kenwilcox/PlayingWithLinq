<Query Kind="Program">
  <GACReference>IBM.Data.DB2.iSeries, Version=12.0.0.0, Culture=neutral, PublicKeyToken=9cdb2ebfb1f93a26</GACReference>
  <NuGetReference>FluentData</NuGetReference>
  <NuGetReference>Npgsql</NuGetReference>
  <Namespace>FluentData</Namespace>
  <Namespace>Npgsql</Namespace>
  <Namespace>Npgsql.Logging</Namespace>
  <Namespace>NpgsqlTypes</Namespace>
</Query>

// I'm liking this - https://fluentdata.codeplex.com/documentation

void Main()
{
  //AppDomain.CurrentDomain.SetupInformation.ConfigurationFile.Dump();
  ///*
  var notes = Context.TestSQL01.Sql("select * from OpenBatchNotes").QueryMany<OpenBatchNote, MyList>();
  //notes.Dump();
  
  var myNotes = notes.UserNotes("wilcoxk");
  myNotes.Dump();
  
  var D01Notes = notes.NotesForSite("D01");
  D01Notes.Dump();
  
  // get a single note as a DataTable
  var noteDT = Context.TestSQL01.Sql("select * from OpenBatchNotes where Id = 1").QuerySingle<DataTable>();
  noteDT.Dump();
  
  // get a single strongly typed item
  var note = Context.TestSQL01.Sql("select * from OpenBatchNotes where Id = 1").QuerySingle<OpenBatchNote>();
  note.Dump();
  
  // dynamic
  var noteD = Context.TestSQL01.Sql("select * from OpenBatchNotes where Id = 1").QuerySingle<dynamic>();
  (noteD as object).Dump();
  
  // scalar value
  var noteCount = Context.TestSQL01.Sql("select count(*) from OpenBatchNotes").QuerySingle<int>();
  noteCount.Dump("Note Count");
  
  // just get the id's for a site
  var A12NoteIds = Context.TestSQL01.Sql("select Id from OpenBatchNotes where siteId = 'A12'").QueryMany<int>();
  A12NoteIds.Dump();

  // with parameters
  var J09NoteIds = Context.TestSQL01.Sql("select * from OpenBatchNotes where SiteId = @0", "J09").QueryMany<dynamic>();
  J09NoteIds.Dump();

  // or named
  var D01NoteIds = Context.TestSQL01.Sql("select * from OpenBatchNotes where SiteId = @SiteID").Parameter("SiteId", "D01").QueryMany<dynamic>();
  //var D01NoteIds = Context().Sql("select * from OpenBatchNotes where SiteId = @SiteID").Parameter("SiteId", "D01").QueryMany<OpenBatchNote, MyList>();
  D01NoteIds.Dump();

var GetEraChecksQuery = @"
SELECT
    H.ohAcro as SiteId,
    H.ohBtch as BatchId,
    rtrim(H.ohChk#) as CheckNumber,
    SUM(H.ohPAmt) AS PayAmount,
    COUNT(*) AS TransCount,
    rtrim(T.ttUser) as UserName
FROM
    Dmart.Ctrwrkoph H
JOIN
    Dmart.Ctrwrktot T ON H.ohAcro=T.ttAcro AND H.ohBtch=T.ttBtch
WHERE
    T.ttSpcl='P' -- and H.ohPAmt > 0
GROUP BY
    H.ohAcro, H.ohBtch, H.ohChk#, T.ttUser
FETCH FIRST 10 ROW ONLY";
    
  var eras = Context.DB2.Sql(GetEraChecksQuery).QueryMany<dynamic>();
  eras.Dump("DB2");
  
  foreach (var era in eras)
  {
    Console.WriteLine("SiteId: " + era.SITEID + " BatchId: " + era.BATCHID + " etc...");
//    foreach (var property in (IDictionary<string, object>)era)
//    {
//      Console.WriteLine(property.Key + ": " + property.Value);
//    }
    Console.WriteLine();
  }  
  
  // And Postgres
  var accounts = Context.Postgres.Sql("select * from accounts limit 10").QueryMany<dynamic>();
  accounts.Dump("POSTGRES");
  //*/
  
  // packs with batches
  var packsWithBatches = Context.TestSQL01.Sql("select p.id, p.referencenumber, p.packtype, b.id as Batch_Id, b.siteid as Batch_SiteId, b.paymentTotal as Batch_PaymentTotal from packs p inner join batches b on p.id = b.packId where p.id = 109").QueryMany<Pack>();
  packsWithBatches.Dump();

  // multiple result sets
  using (var command = Context.TestSQL01.MultiResultSql)
  {
    var packs = command.Sql(
      @"select top 10 * from packs; 
      select top 10 * from batches;
      select top 10 * from checks"
      ).QueryMany<dynamic>();
    var batches = command.QueryMany<dynamic>();
    var checks = command.QueryMany<dynamic>();
    
    packs.Dump("Multi Result");
    batches.Dump("Multi Result");
    checks.Dump("Multi Result");
  }
}

// Define other methods and classes here
public static class Context
{
  public static IDbContext TestSQL01
  {
    get
    {
      var connectionString = "<sql server connection string>";
      return new DbContext().ConnectionString(connectionString, new SqlServerProvider());
    }
  }

  public static IDbContext DB2
  {
    get
    {
      var connectionString = "<db2 connection string";
      return new DbContext().ConnectionString(connectionString, new DB2Provider(), "IBM.Data.DB2.iSeries");
    }
  }

  public static IDbContext Postgres
  {
    get
    {
      var connectionString = "<postgresql connection string>";
      return new DbContext().ConnectionString(connectionString, new PostgreSqlProvider(), "Npgsql");
    }
  }
}

public class OpenBatchNote
{
  public int Id { get; set; }
  public string SiteId { get; set; }
  public int BatchId { get; set; }
  public string Notes { get; set; }
  public DateTimeOffset DateDeleted { get; set; }
}

public class Batch
{
  public int Id { get; set; }
  public string SiteId { get; set;}
  public decimal PaymentTotal { get; set; }
}

public enum PackType
{
  Transmodus = 10,
  UnionBank = 20
}

public class Pack
{
  public int Id { get; set; }
  public string ReferenceNumber { get; set; }
  public PackType PackType { get; set;}
  public Batch Batch { get; set;}
}

public class MyList : List<OpenBatchNote>
{
  public List<OpenBatchNote> UserNotes(string userName)
  {
    var list = new List<OpenBatchNote>();
    foreach (var note in this)
    {
      if (note.Notes.Contains(userName))
      {
        list.Add(note);
      }
    }
    return list;
  }

  public List<OpenBatchNote> NotesForSite(string siteId)
  {
    var list = new List<OpenBatchNote>();
    foreach (var note in this)
    {
      if (note.SiteId.Equals(siteId))
      {
        list.Add(note);
      }
    }
    return list;
  }

}