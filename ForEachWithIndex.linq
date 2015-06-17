<Query Kind="Statements" />

var list = new List<string>() {"one", "two", "three", "four"};
foreach(var item in list.Select((value, index) => new {value, index})) 
{
  item.value.Dump(item.index.ToString());
}
