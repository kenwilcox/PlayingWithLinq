<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <NuGetReference>TaskScheduler</NuGetReference>
  <NuGetReference>TaskSchedulerEditor</NuGetReference>
  <Namespace>Microsoft.Win32.TaskScheduler</Namespace>
  <Namespace>Microsoft.Win32.TaskScheduler.Fluent</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
</Query>

var server = Util.GetPassword("task.servername");
var userName = Util.GetPassword("task.username");
var accountName = Util.GetPassword("task.accountname");
var password = Util.GetPassword("task.password");

var originalName = @"\BadAddressImporter";
var newName = @"\mbsi\BadAddressImporter";

using (TaskService ots = new TaskService(server, userName, accountName, password))
{
	var task = ots.GetTask(originalName);
	if (task != null) 
	{
		using (TaskService nts = new TaskService(server, userName, accountName, password))
		{
			try 
			{
				var rootFolder = nts.RootFolder;
				var newTask = rootFolder.RegisterTask(newName, task.Xml, TaskCreation.CreateOrUpdate, null, null, TaskLogonType.InteractiveToken, null);
				
		    var editorForm = new TaskEditDialog(newTask, true, true);
          if (editorForm.ShowDialog() == DialogResult.OK) {
				    ots.RootFolder.DeleteTask(task.Path, true);
				}
				
				Console.WriteLine("Done");
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	} 
	else 
	{
		Console.WriteLine("Could not find specified task");
	}	
}