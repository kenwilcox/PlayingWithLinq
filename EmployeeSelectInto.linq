<Query Kind="Program" />

void Main()
{
	List<Employee> employees = new List<Employee>()
	{
		new Employee {ID=1, Name="Scott", HireDate=new DateTime(2002, 3, 5) },
		new Employee {ID=2, Name="Poonam", HireDate=new DateTime(2002, 10, 15) },
		new Employee {ID=3, Name="Paul", HireDate=new DateTime(2007, 10, 11) },
		new Employee {ID=4, Name="John", HireDate=new DateTime(2002, 4, 7) },
		new Employee {ID=5, Name="George", HireDate=new DateTime(2007, 3, 21) },
		new Employee {ID=6, Name="Steve", HireDate=new DateTime(2002, 3, 10) },
		
	};
	
	var query = 
		from e in employees
		where e.HireDate.Year < 2005
		orderby e.Name
		select e
		 	into pEmployees
			where pEmployees.Name.Length < 5
			select pEmployees
			;
		
	foreach (Employee e in query) {
		Console.WriteLine(e.Name);
	}
	
	Console.WriteLine();
	
	// With Group
	var groups = 
		from e in employees
		group e by e.Name[0] into letter
		orderby letter.Key ascending
		select letter;
	
	foreach (var grouping in groups)
	{
		Console.WriteLine(grouping.Key);
		foreach (var employee in grouping)
		{
			Console.WriteLine("\t{0}", employee.Name);
		}
	}
}

public class Employee
{
  public int ID {get; set;}
  public string Name {get; set;}
  public DateTime HireDate {get; set;}
}
