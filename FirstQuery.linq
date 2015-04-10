<Query Kind="Program" />

void Main()
{
	string[] instructors = {"Aaron", "Fritz", "Scott", "Keith" };
	
	IEnumerable<string> query = from s in instructors
								where s.Length == 5
								orderby s descending
								select s;
   	
	foreach(string name in query) {
	  Console.WriteLine(name);
	}
	
	Console.WriteLine("Or Done Another Way");
	
	var items = instructors.Where(s => s.Length == 5).OrderBy(k => k);
	foreach(string item in items) {
	  Console.WriteLine(item);
	}
}

// Define other methods and classes here
