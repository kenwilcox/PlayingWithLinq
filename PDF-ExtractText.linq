<Query Kind="Program">
  <NuGetReference>iTextSharp</NuGetReference>
  <Namespace>iTextSharp.text.pdf</Namespace>
  <Namespace>iTextSharp.text.pdf.parser</Namespace>
</Query>

// 12K documents in a minute and change!
void Main()
{ 
  //var list = new ConcurrentDictionary<string, string>();
  var list = new ConcurrentBag<Tuple<string, string>>();
  var path = @"C:\E25 Balance\";
  //path = @"C:\Dev\PDF\";
  
  Parallel.ForEach(Directory.GetFiles(path, "*.pdf", SearchOption.TopDirectoryOnly), file => {
  	//var output = Path.ChangeExtension(file, ".txt");
    var bytes = File.ReadAllBytes(file);
	//File.WriteAllText(output, ConvertToText(bytes), Encoding.UTF8);
	string dump = ConvertToText(file, bytes);
	var rex = Regex.Match(dump, @"ACT# (\d+)").Groups[1];
	//list.TryAdd(Path.GetFileName(file), rex.Value);// .Captures[0]);
	list.Add(Tuple.Create(Path.GetFileName(file), rex.Value));
  });
  
//  foreach(var file in Directory.GetFiles(path, "*.pdf", SearchOption.TopDirectoryOnly)) 
//  {
//	var output = Path.ChangeExtension(file, ".txt");
//	if(File.Exists(file)) 
//	{
//	  var bytes = File.ReadAllBytes(file);
//	  //File.WriteAllText(output, ConvertToText(bytes), Encoding.UTF8);
//	  string dump = ConvertToText(bytes);
//	  var rex = Regex.Match(dump, @"ACT# ([0-9]+)").Groups[1];
//	  list.Add(Tuple.Create(Path.GetFileName(file), rex.Value));// .Captures[0]);
//	}
//  }
  
  //list.OrderBy(o=> o.Key).Dump("Account Numbers " + list.Count());
  list.OrderBy(o => o.Item1).Dump("By File Name " + list.Count());
  //list.OrderBy(o => o.Item2).Dump("By Account Numbers " + list.Count());
}

// Define other methods and classes here
string ConvertToText(string file, byte[] bytes)
{
  var sb = new StringBuilder();
  try
  {
    var reader = new PdfReader(bytes);
    //var numberOfPages = reader.NumberOfPages;

    //for (var currentPageIndex = 1; currentPageIndex <= numberOfPages; currentPageIndex++)
    //{
    //  sb.Append(PdfTextExtractor.GetTextFromPage(reader, currentPageIndex));
    //}
	sb.Append(PdfTextExtractor.GetTextFromPage(reader, 1));
  }
  catch (Exception exception)
  {
      Console.WriteLine(file + " " + exception.Message);
  }

  return sb.ToString();
}