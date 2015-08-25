<Query Kind="Program" />

void Main()
{
  var numbers = "1,5,4,8,10-12,2280-2299;3000|3002,4830-4849,5900-6099,6600-6699,6880-6899,7240-7279,7300-7599,2,3,4,5";
  FigureOutRange(numbers, true).Dump();
  FigureOutRange(numbers, false).Dump();
}

// Define other methods and classes here
private IEnumerable<int> FigureOutRange(string numbers, bool distinct)
{
  List<int> list = new List<int>();

  string[] items = numbers.Split(new char[] { ',', ';', '|' }, StringSplitOptions.RemoveEmptyEntries);
  foreach (string item in items)
  {
    string[] range = item.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
    if (range.Count() == 2)
    {
      int low = Int32.Parse(range[0]);
      int high = Int32.Parse(range[1]);

      for (int i = low; i <= high; i++)
      {
        list.Add(i);
      }
    }
    else if (range.Count() == 1)
    {
      list.Add(Int32.Parse(item));
    }
    else
    {
      Console.Error.WriteLine("'" + item + "'" + Environment.NewLine + " is a format I currently don't understand");
    }
  }
  
  list.Sort();
  if (distinct) {
    var distinctList = list.Distinct();  
    return distinctList;
  }
  return list;
}