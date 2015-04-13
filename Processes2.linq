<Query Kind="Statements" />

var processList = Process.GetProcesses()
	.OrderByDescending(p => p.Threads.Count)
	.ThenBy(p=> p.ProcessName)
	.Select(process => new {process.ProcessName, ThreadCount = process.Threads.Count});

Console.WriteLine("Process List");
foreach(var process in processList)
{
	Console.WriteLine("{0,25} {1,4:D}",
		process.ProcessName,
		process.ThreadCount
		);
}