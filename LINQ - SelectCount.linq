<Query Kind="Statements" />

var list = new List<string> { "one", "one", "two", "two", "three" };
list.GroupBy(p => p)
.Select(p => new { Item = p.Key, Count = p.Count() })
.Where(p => p.Count > 1)
.Dump();