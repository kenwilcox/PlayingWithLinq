<Query Kind="Statements" />

// I tried all the Get* methods. They don't seem to work in LINQPad
Assembly.GetExecutingAssembly().GetTypes()
	//.Where(t => t.IsPublic)
	//.Select(t => t.FullName)
	.Dump();