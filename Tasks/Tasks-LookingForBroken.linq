<Query Kind="Program">
  <NuGetReference>TaskScheduler</NuGetReference>
  <Namespace>Microsoft.Win32.TaskScheduler</Namespace>
  <Namespace>Microsoft.Win32.TaskScheduler.Fluent</Namespace>
</Query>

List<Task> tasks = new List<Task>();

void Main()
{
  // 341 - 1:42.255
  var server = Util.GetPassword("task.servername");
  var userName = Util.GetPassword("task.username");
  var accountName = Util.GetPassword("task.accountname");
  var password = Util.GetPassword("task.password");
	
	using (TaskService ts = new TaskService(server, userName, accountName, password))
	{
	  var folder = ts.RootFolder;
		//var folder = ts.GetFolder(@"\mbsi");
		//var folder = ts.GetFolder(@"\Microsoft\Windows\Media Center");
		EnumAllFolders(folder);
		var count = 0;
		foreach(var item in tasks)
		{
			var ret = (uint)item.LastTaskResult;
			var status = String.Format("Unknown Status Code (0x{0})", ret.ToString("X"));
			if (MyExtensions.ReturnValues.ContainsKey(ret)) {
			  status = String.Format("{0} (0x{1})", MyExtensions.ReturnValues[ret], ret.ToString("X"));
			}
			var display = String.Format("Status: {0}\nNext Run Time: {1}\nNumber of Missed Runs: {2}\nPath: {3}", status, item.NextRunTime, item.NumberOfMissedRuns, item.Path);
		  display.Dump(item.Name);
			count++;
		}
		count.Dump("Total Count");
	}
}

void EnumAllFolders(TaskFolder fld)
{
  //Util.Metatext("EnumAllFolders: " + fld.Path).Dump();
	try 
	{
		foreach(var task in fld.AllTasks)//.ToList())
		{
			//Console.WriteLine(Path.Combine(task.Folder.ToString(), task.Name));
			tasks.Add(task);
		}
	}
	catch (Exception e) 
	{
		Util.Metatext(e.Message).Dump("EXCEPTION");
	}
	
  foreach(var folder in fld.SubFolders)//.ToList())
	{
		EnumAllFolders(folder);	
	}
}