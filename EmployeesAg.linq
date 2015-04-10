<Query Kind="Program" />

void Main()
{
	IEnumerable<Employee> employees = new List<Employee>()
	{
		new Employee {ID=1, Name="Scott", HireDate=new DateTime(2002, 3, 5) },
		new Employee {ID=2, Name="Poonam", HireDate=new DateTime(2002, 10, 15) },
		new Employee {ID=3, Name="Paul", HireDate=new DateTime(2007, 10, 11) },
		new Employee {ID=4, Name="John", HireDate=new DateTime(2002, 4, 7) },
		new Employee {ID=5, Name="George", HireDate=new DateTime(2007, 3, 21) },
		
	};
	
	Console.WriteLine("How About Aggirgate?");
	
	var items = employees.Aggregate("Employee Names: ", (current, item) => current + (item.Name.ToLower() + " "));
	
	Console.WriteLine(items);
}

public class Employee
{
  public int ID {get; set;}
  public string Name {get; set;}
  public DateTime HireDate {get; set;}
}