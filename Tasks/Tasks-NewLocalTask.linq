<Query Kind="Program">
  <NuGetReference>TaskScheduler</NuGetReference>
  <Namespace>Microsoft.Win32.TaskScheduler</Namespace>
  <Namespace>Microsoft.Win32.TaskScheduler.Fluent</Namespace>
</Query>

void Main()
{
	// Fluent Example
	using (TaskService ts = new TaskService())
	{
	  var task = @"MBSI\FluentTest";
		
		ts.Execute("notepad.exe").InWorkingDirectory(@"C:\temp\").WithArguments(@"C:\temp\KenTask.txt")
		  .OnAll(DaysOfTheWeek.Sunday).In(WhichWeek.ThirdWeek).Of(MonthsOfTheYear.May)
		  //.InTheMonthOf(MonthsOfTheYear.May).OnTheDays(1, 3, 5, 7)
		  //.Every(1).Days()
		  .Starting(DateTime.Now)
			.Ending(DateTime.Now.AddYears(30))
		  //.RepeatingEvery(TimeSpan.FromMinutes(1))
			//.RunningAtMostFor(TimeSpan.FromMinutes(2)).
		  .AsTask(task);
		
//		ts.Execute("notepad.exe").WithArguments(@"C:\temp\BIDriverInstall.log")
//			.OnBoot()
//			.AsTask(task);
		
		Console.WriteLine("Done");
	}
}