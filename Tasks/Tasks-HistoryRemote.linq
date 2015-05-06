<Query Kind="Statements">
  <Output>DataGrids</Output>
  <NuGetReference>TaskScheduler</NuGetReference>
  <Namespace>Microsoft.Win32.TaskScheduler</Namespace>
  <Namespace>Microsoft.Win32.TaskScheduler.Fluent</Namespace>
</Query>

var server = Util.GetPassword("task.servername");
var userName = Util.GetPassword("task.username");
var accountName = Util.GetPassword("task.accountname");
var password = Util.GetPassword("task.password");

Task task = null;
using (TaskService ts = new TaskService(server, userName, accountName, password))
{
  task = ts.GetTask(@"\mbsi\BadAddressImporter");
  TaskEventLog log = new TaskEventLog(server, task.Path, accountName, userName, password);
	log.Count.Dump("Count:");
	//log.OrderByDescending(l=>l.TimeCreated).Dump(1);
	//log.Dump(1);
	
	//List<ListViewItem> c = new List<ListViewItem>(100);
//	var list = new List<TaskEvent>();
  var count = 0;
	var startTime = DateTime.Now;
	foreach (TaskEvent item in log){
	  count++;
	  Console.WriteLine("{0}: {1} - {2}", count, item.TimeCreated, DateTime.Now - startTime);//.Dump();
		startTime = DateTime.Now;
	}
//  	c.Add(new ListViewItem(new string[] { item.Level, item.TimeCreated.ToString(),
//      item.EventId.ToString(), item.TaskCategory, item.OpCode,
//      item.ActivityId.ToString() }));	
			
}