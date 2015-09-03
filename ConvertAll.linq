<Query Kind="Statements" />

List<int> original = new List<int> {0, 1, 2, 3, 4, 5};
var halved = original.ConvertAll(x => x/2.0);
halved.Dump();

var strings = original.ConvertAll(c => c.ToString());
strings.Dump();

var ints = strings.ConvertAll(s => Int32.Parse(s));
ints.Dump();
