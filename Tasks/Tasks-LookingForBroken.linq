<Query Kind="Program">
  <NuGetReference>TaskScheduler</NuGetReference>
  <Namespace>Microsoft.Win32.TaskScheduler</Namespace>
  <Namespace>Microsoft.Win32.TaskScheduler.Fluent</Namespace>
</Query>

int count;
void Main()
{
	using (TaskService ts = new TaskService())
	{
	  count = 0;
	  var folder = ts.RootFolder;
		//var folder = ts.GetFolder(@"\mbsi");
		//var folder = ts.GetFolder(@"\Microsoft\Windows\Media Center");
		EnumAllFolders(folder);
		Console.WriteLine(count);
	}
}

void EnumAllFolders(TaskFolder fld)
{
  Util.Metatext("EnumAllFolders: " + fld.Path).Dump();
	try 
	{
		foreach(var task in fld.AllTasks)//.ToList())
		{
		  count++;
			Console.WriteLine(Path.Combine(task.Folder.ToString(), task.Name));
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