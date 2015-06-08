<Query Kind="Program" />

void Main()
{
	var digitsOnly = new Regex(@"[^\d]");
	var numbers = new List<MyCheck>() {
	  new MyCheck() {CheckNumber = "CHS00123"},
		new MyCheck() {CheckNumber = "AB001"},
		new MyCheck() {CheckNumber = "PAY-NO0012"},
	};
	
	numbers.ForEach(e => e.CheckNumber = digitsOnly.Replace(e.CheckNumber, "").TrimStart('0'));
	numbers.Dump();
}

// Define other methods and classes here
class MyCheck
{
  public string CheckNumber {get; set;}
}