<Query Kind="Statements" />

var words = "The quick brown fox jumps over the lazy dog".Split().OrderBy(w => w.ToUpper());
//words.Dump();

var dupes = words.GroupBy(w => w.ToUpper())//.Where(w=>w.Count() > 1)
.Select(w => w.Key);
//.Select(w=> new {w.Key, Count = w.Count()} );
dupes.Dump();
