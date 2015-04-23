<Query Kind="Statements" />

//"This_is_a_test".Remove(10).Dump();
var s = "This_is_a_test_or_something";
s.Substring(0, Math.Min(10, s.Length)).Dump();


var crap = @"9/24/2007 8:20 AM -07:00
�U";
var newcrap = crap.Remove(crap.IndexOf('\r', 0));
newcrap.Dump();
//DateTime.Parse(newcrap);