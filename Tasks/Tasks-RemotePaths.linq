<Query Kind="Program">
  <NuGetReference>TaskScheduler</NuGetReference>
  <Namespace>Microsoft.Win32.TaskScheduler</Namespace>
  <Namespace>Microsoft.Win32.TaskScheduler.Fluent</Namespace>
</Query>

void Main()
{
	var server = "-serverName-";
	var userName = "-userName-";
	var accountName = "-domainName";
	var password = "-password-";
	using (TaskService ts = new TaskService(server, userName, accountName, password))
	{
	  //var folders = ts.RootFolder;
		//foreach(var folder in folders.SubFolders.Dump(folder.Name, 1);
		EnumAllFolders(ts.RootFolder);
	}
}

void EnumAllFolders(TaskFolder fld, string rootPath = "~")
{
  foreach(var folder in fld.SubFolders)
	{
	  Console.WriteLine(folder.Path.Replace(rootPath, "\t"));
		EnumAllFolders(folder, folder.Path);
	}
}