<Query Kind="Statements">
  <NuGetReference>BankFileParsers</NuGetReference>
  <Namespace>BankFileParsers</Namespace>
</Query>

//const string fileName = @"C:\temp\bank_files\BAI.txt";
const string fileName = @"C:\temp\bank_files\OCT-7-8-9.txt";
var parser = new BaiParser();
var bai = parser.Parse(fileName);
var trans = BaiTranslator.Translate(bai);
var addendaKey = "ADDENDA INFORMATION";
var preauthKey = "PREAUTHORIZED ACH FROM";
var tracerKey = "TRACER ID NUMBER";

var dictionaryKeys = new List<string> { addendaKey, preauthKey, tracerKey };
var detail = BaiTranslator.GetDetailInformation(trans, dictionaryKeys);
// Filter out only those items that have addenda information
var detailDictionary = detail.Where(p => p.TextDictionary.ContainsKey(addendaKey)  && p.TextDictionary[addendaKey].StartsWith("TRN") && p.TypeCode == "165").ToList();
//detailDictionary.ExportToCsv(dictionaryKeys, new List<string> {"Date", "Amount", "TypeCode", "TypeDescription"}).Dump();

//var reference = detailDictionary.Select(i => i.BankReferenceNumber).OrderBy(i=> i);
//var reference = detailDictionary.GroupBy(d => d.BankReferenceNumber).ToLookup(g => g.Key, g => g.Count()).Where(g=> g.Count() == 1).Select(g => g.Key);
//var reference = detailDictionary.GroupBy(i => i.BankReferenceNumber).Select(g => new { ID = g.Key, Count = g.Count() }).OrderByDescending(x => x.Count);
//var str = "";
//foreach (var r in reference)
//{
//  str += r.ID + ",";
//}
//reference.Dump();
//str.Dump();
//return;
var count = 0;
foreach (var item in detailDictionary)
{
  count++;
  //if (count == 216)
  //item.Dump();  
  //if (count == 5) break;
  
  var checkNumber = "";
  var preauth = "";
  var routeNumber = "0";
  var tracer = "";
  //if (item.TextDictionary.ContainsKey(addendaKey))
  {
    var addenda = item.TextDictionary[addendaKey];
    tracer = item.TextDictionary[tracerKey];
    
    preauth = item.TextDictionary[preauthKey].Replace(item.Date.ToString("MMddyy"), "").Trim();
    
    var parts = addenda.Replace(' ', '*').Split('*');
    if (parts.Length >= 3 && parts[0] == "TRN")
    {
      checkNumber = parts[2].Trim();
      //routeNumber = parts[3].Split(' ')[0].Replace("-", "");
    }
    else if (parts.Length >= 2 && parts[0] == "TRN1")
    {
      // Yup - they can screw this up
      checkNumber = parts[1].Trim();
    }

    if (string.IsNullOrEmpty(checkNumber))
    {
      addenda.Dump();
      item.Dump();
    }
  }
  //Console.WriteLine("Route Number: {0} - Count: {1}", routeNumber, count);
  Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}", item.BankReferenceNumber, item.Date, item.TypeCode, item.TypeDescription, item.Amount, item.CustomerAccountNumber, checkNumber, preauth, long.Parse(routeNumber), tracer);
}