<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

class Something {
  public string Name {get;set;}
  public int Age {get; set;}
  public string Food {get; set;}
}
	
void Main()
{
	List<Something> me = new List<Something>{
	  new Something{Name = "Foo", Age= 2, Food="Pizza"},
	  new Something{Name = "Else", Age = 15, Food="Popcorn"},
	  new Something{Name = "Else", Age = 51, Food="Popcorn"},
	  new Something{Name = "Else", Age = 4, Food="Popcorn"},
	  new Something{Name = "Else", Age = 4, Food="Popcorn"},
	  new Something{Name = "Else", Age = 4, Food="Popcorn"},
	  new Something{Name = "Else", Age = 91, Food="Popcorn"},
	  new Something{Name = "Else", Age = 91, Food="Pizza"},
	  
	};
	
	me.GroupBy(x => new {x.Age, x.Name})
	.Select(x => new {x.Key.Age, count = x.Count(), total = x.Sum(y=>y.Age), food = x.Select(p=>p.Food)})
	.Dump();
	
	
}

// Define other methods and classes here
