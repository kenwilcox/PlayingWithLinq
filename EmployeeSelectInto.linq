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
		group e by String.Format("{0}{1}", e.Name[0], e.Name[1]) into letter
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
	
	// Another group example
	var groupByDate = 
	  from employee in employees
	  orderby employee.HireDate.Year, employee.Name[0]
	  group employee by new {Year = employee.HireDate.Year,
	  						FirstLetter = employee.Name[0]};
							
	foreach (var group in groupByDate)
	{
		Console.WriteLine("\t{0} = {1}", group.Key.Year, group.Key.FirstLetter);
		foreach (var employee in group)
		{
			Console.WriteLine(employee.Name);
		}
	}
	
	// Grouping and Projecting
	var groupedEmployees = 
		from employee in employees
		group employee
		by new {Year = employee.HireDate.Year,
	  			FirstLetter = employee.Name[0]}
		into gEmployee
		where gEmployee.Count() > 1
		select new {Year = gEmployee.Key.Year,
	  				FirstLetter = gEmployee.Key.FirstLetter,
					Count = gEmployee.Count() 
		};
		
	Console.WriteLine("Grouping and Projecting");
	foreach (var group in groupedEmployees)
	{
		Console.WriteLine("\t{0} = {1}", group.Year, group.FirstLetter);
//		foreach (var employee in group)
//		{
//			Console.WriteLine(employee.Name);
//		}
	}
}

public class Employee
{
  public int ID {get; set;}
  public string Name {get; set;}
  public DateTime HireDate {get; set;}
}