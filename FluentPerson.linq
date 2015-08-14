<Query Kind="Program" />

// Another fluent example

public class Person {
  public string FirstName {get;set;}
  public string LastName {get;set;}
  public int Age {get;set;}
  public bool IsActive {get;set;}
  public FluentPerson With {get;private set;}
  
  public Person() {
    With = new FluentPerson(this);
  }
  
  public class FluentPerson
  {
    private readonly Person _person;
    
    public FluentPerson(Person person) {
      _person = person;
    }
    
    public FluentPerson FirstName(string firstName) {
      _person.FirstName = firstName;
      return this;
    }
    
    public FluentPerson LastName(string lastName) {
      _person.LastName = lastName;
      return this;
    }
    
    public FluentPerson Age(int age) {
      _person.Age = age;
      return this;
    }
    
    public FluentPerson IsActive() {
      _person.IsActive = true;
      return this;
    }
    
    public FluentPerson IsNotActive() {
      _person.IsActive = false;
      return this;
    }
  }
}

void Main()
{
  var person = new Person();
  person.With.FirstName("Jose").LastName("Jones").Age(30).IsActive().IsNotActive().FirstName("Silly");
  person.Dump();
}

