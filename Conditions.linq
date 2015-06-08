<Query Kind="Program">
  <NuGetReference>CuttingEdge.Conditions</NuGetReference>
  <Namespace>CuttingEdge.Conditions</Namespace>
</Query>

void Main()
{
  var list = new List<int>{120};
  MyMethod(120, "<data>abc</data>", list);
  Console.WriteLine("Done");
}

// Define other methods and classes here
ICollection MyMethod(Nullable<int> id, string xml, IEnumerable<int> col)
{
  Condition.Requires(id, "id")
    .IsNotNull()
    .IsInRange(1, 999)
    .IsNotEqualTo(128);
  
  Condition.Requires(xml, "xml")
    .StartsWith("<data>")
    .EndsWith("</data>")
    .Evaluate(xml.Contains("abc") || xml.Contains("cba"));
  
  Condition.Requires(col, "col")
    .IsNotNull()
    .IsNotEmpty()
    .Evaluate(c=>c.Contains(id.Value) || c.Contains(0));
  
  object result = BuildResults(xml, col);
  
  Condition.Ensures(result, "result")
    .IsOfType(typeof(ICollection));
  
  return (ICollection)result;
}

ICollection BuildResults(string xml, IEnumerable<int> col)
{
  return new List<int>{1,2,3};
}