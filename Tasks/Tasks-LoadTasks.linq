<Query Kind="Program">
  <NuGetReference>TaskScheduler</NuGetReference>
  <Namespace>Microsoft.Win32.TaskScheduler</Namespace>
  <Namespace>Microsoft.Win32.TaskScheduler.Fluent</Namespace>
</Query>

List<Task> tasks = new List<Task>();

void Main()
{
	EnumAllTasks();
	tasks.Count.Dump("Total Count");
}

void EnumAllTasks()
{
  var server = Util.GetPassword("task.servername");
  var userName = Util.GetPassword("task.username");
  var accountName = Util.GetPassword("task.accountname");
  var password = Util.GetPassword("task.password");

	 using (TaskService ts = new TaskService())//server, userName, accountName, password))
      EnumFolderTasks(ts.RootFolder);
}

void EnumFolderTasks(TaskFolder fld)
{
  try {
	 foreach (Task task in fld.Tasks)
      tasks.Add(task);
	} catch (Exception e) {
	  Util.Metatext(e.Message).Dump("EXCEPTION");
	}
   foreach (TaskFolder sfld in fld.SubFolders)
      EnumFolderTasks(sfld);
}
