<Query Kind="Program">
  <NuGetReference>NodaTime</NuGetReference>
  <Namespace>NodaTime</Namespace>
  <Namespace>NodaTime.Calendars</Namespace>
  <Namespace>NodaTime.Text</Namespace>
  <Namespace>NodaTime.TimeZones</Namespace>
  <Namespace>NodaTime.TimeZones.Cldr</Namespace>
  <Namespace>NodaTime.Utility</Namespace>
</Query>

void Main()
{
  var dobs = new Dictionary<string, DateTime>() {
    {"41", new DateTime(1974, 5, 25)},
    {"17", new DateTime(1998, 2, 14)},
    {"Last Year", DateTime.Now.AddYears(-1).AddDays(-1)},
    {"Last Month", DateTime.Now.AddMonths(-1)},
    {"Tomorrow 18", DateTime.Now.AddYears(-17).AddMonths(-11).AddDays(-30)},
    {"Yesterday", DateTime.Now.AddDays(-1)},
    {"Real Old", new DateTime(1800, 1, 1)},
    {"USA", new DateTime(1776, 7, 4)},
    {"Leap Year", new DateTime(1996, 2, 29)} 
  };
  
  foreach(var dob in dobs) {
    Console.WriteLine(string.Format("{0} ({1})", dob.Value.ToShortDateString(), dob.Key));
    NodaAgeInMonths(dob.Value).Dump();
    MyAgeInMonths(dob.Value).Dump();
  }
}

// Define other methods and classes here
long NodaAgeInMonths(DateTime dob) {
  var now = DateTime.Now;
  // Convert to Noda Objects
  LocalDate birthDate = new LocalDate(dob.Year, dob.Month, dob.Day);
  LocalDate today = new LocalDate(now.Year, now.Month, now.Day);
  
  Period age = Period.Between(birthDate, today);
  
  return age.Years * 12 + age.Months;
}

long MyAgeInMonths(DateTime dob) {
  var span = DateTime.Today - dob;
  return (long)(span.TotalDays / (365.25 / 12));
}

