<Query Kind="Statements" />

var obj2 = "123,456";
obj2.Split(',').Select(x => (object)x).ToArray().Dump();