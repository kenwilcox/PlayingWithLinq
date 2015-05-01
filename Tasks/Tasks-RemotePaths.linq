<Query Kind="Program">
  <NuGetReference>TaskScheduler</NuGetReference>
  <Namespace>Microsoft.Win32.TaskScheduler</Namespace>
  <Namespace>Microsoft.Win32.TaskScheduler.Fluent</Namespace>
</Query>

void Main()
{
  var server = Util.GetPassword("task.servername");
  var userName = Util.GetPassword("task.username");
  var accountName = Util.GetPassword("task.accountname");
  var password = Util.GetPassword("task.password");
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