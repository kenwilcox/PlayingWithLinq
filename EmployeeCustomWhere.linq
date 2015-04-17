<Query Kind="Program" />

// Using my own Where - does not work in LINQPad
void Main()
{
	List<Employee> employees = new List<Employee>()
	{
		new Employee {ID=1, Name="Scott", HireDate=new DateTime(2002, 3, 5) },
		new Employee {ID=2, Name="Poonam", HireDate=new DateTime(2002, 10, 15) },
		new Employee {ID=3, Name="Paul", HireDate=new DateTime(2007, 10, 11) },
		new Employee {ID=4, Name="John", HireDate=new DateTime(2002, 4, 7) },
		new Employee {ID=5, Name="George", HireDate=new DateTime(2007, 3, 21) },
		
	};
	
	var query = 
		from e in employees
		where e.HireDate.Year < 2005
		orderby e.Name
		select e;
		
	foreach (Employee e in query) {
		Console.WriteLine(e.Name);
	}
	
	Console.WriteLine("Or Done Another Way");
	
	var items = employees.Where(s => s.HireDate.Year > 2003).OrderBy(k => k.Name);
	foreach(Employee item in items) {
	  Console.WriteLine(item.Name);
	}
	
	Console.WriteLine("Proving delayed execution");
	employees.Add(new Employee {ID=6, Name="Ringo", HireDate=new DateTime(2007, 6, 14) });
	foreach(Employee item in items) {
	  Console.WriteLine(item.Name);
	}
}

public class Employee
{
  public int ID {get; set;}
  public string Name {get; set;}
  public DateTime HireDate {get; set;}
}

//public static class EmployeeExtensions
//{
//	public static IEnumerable<Employee>Where(this, IEnumerable<Employee> sequence, Func<Employee, bool> predicate)
//	{
//		foreach(Employee e in sequence)
//		{
//			if (Predicate(e)) 
//			{
//				yield return e;
//			}
//		}
//	}
//}
