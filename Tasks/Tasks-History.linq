<Query Kind="Statements">
  <Output>DataGrids</Output>
  <NuGetReference>TaskScheduler</NuGetReference>
  <Namespace>Microsoft.Win32.TaskScheduler</Namespace>
  <Namespace>Microsoft.Win32.TaskScheduler.Fluent</Namespace>
</Query>

Task task = null;
using (TaskService ts = new TaskService())
{
  task = ts.GetTask(@"\mbsi\KenBasicTask");
  TaskEventLog log = new TaskEventLog(task.Path);
	log.Count.Dump("Count:");
	//log.OrderByDescending(l=>l.TimeCreated).Dump(1);
	log.Dump(1);
	
	//List<ListViewItem> c = new List<ListViewItem>(100);
//	var list = new List<TaskEvent>();
//	foreach (TaskEvent item in log)	  
//  	c.Add(new ListViewItem(new string[] { item.Level, item.TimeCreated.ToString(),
//      item.EventId.ToString(), item.TaskCategory, item.OpCode,
//      item.ActivityId.ToString() }));	
			
}