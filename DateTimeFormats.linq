<Query Kind="Statements" />

DateTime.Today.ToString("o").Dump();
var d1 = DateTime.Today.ToString("o").Substring(0,10);
var d2 = DateTime.Today.ToString("yyyy-MM-dd");

d1.Dump();
d2.Dump();

(d1 == d2).Dump();