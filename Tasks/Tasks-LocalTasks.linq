<Query Kind="Program">
  <NuGetReference>TaskScheduler</NuGetReference>
  <Namespace>Microsoft.Win32.TaskScheduler</Namespace>
  <Namespace>Microsoft.Win32.TaskScheduler.Fluent</Namespace>
</Query>

void Main()
{
	using (TaskService ts = new TaskService())
	{
		//bool newVer = (ts.HighestSupportedVersion >= new Version(1, 2));
		//newVer.Dump();
		//ts.AllTasks.Where(p=>!p.Path.Contains("Microsoft"))
	  var folder = ts.GetFolder(@"\Microsoft\Windows");
		//*
		foreach(var item in folder.AllTasks)//.Take(1))
		{
			//if (item.Path.Contains("Microsoft")) break;
			//if (item.Path.Contains("Activation")) break;
			//item.Stop();
			//item.Name.Dump();
			var ret = (uint)item.LastTaskResult;
			var status = String.Format("Unknown Status Code (0x{0})", ret.ToString("X"));
			if (MyExtensions.ReturnValues.ContainsKey(ret)) {
			  status = String.Format("{0} (0x{1})", MyExtensions.ReturnValues[ret], ret.ToString("X"));
			}
			var display = String.Format("Status: {0}\nNext Run Time: {1}\nNumber of Missed Runs: {2}\nPath: {3}", status, item.NextRunTime, item.NumberOfMissedRuns, item.Path);
		  display.Dump(item.Name);
			//Util.Metatext(String.Format("Next Run Time: {0}", item.NextRunTime)).Dump();
			//Util.Metatext(String.Format("Number of Missed Runs: {0}", item.NumberOfMissedRuns)).Dump();
			//item.Dump(2);
//			if (item.Definition.Actions[0] is ExecAction)
//			{
//			  var action = (ExecAction)item.Definition.Actions[0];
//			  action.Path.Dump();
//				action.Arguments.Dump();
//				action.WorkingDirectory.Dump();
//			}
			
//			if (item.Definition.Triggers[0] is DailyTrigger)
//			{
//			  var trigger = (DailyTrigger)item.Definition.Triggers[0];
//				trigger.Dump();
//			}			

//			item.GetRunTimes(DateTime.MinValue, DateTime.Now).Count().Dump();
			
			//item.Definition.Dump();
//			foreach(var trigger in item.Definition.Triggers)
//			{
//			  //trigger.Repetition.Interval
//				//if (item.LastRunTime - trigger.Repetition.Interval < DateTime.Now.AddHours(-1))
//				//  "Failed".Dump();
//				trigger.Repetition.Interval.Dump();
//			}
			//break;
		}//*/
		
		/*
		var tt = new DailyTrigger();
		tt.Enabled = true;
		tt.StartBoundary = DateTime.Now.AddMinutes(1);
		tt.EndBoundary = DateTime.Today.AddDays(2);
		tt.Repetition.Interval = TimeSpan.FromMinutes(1);
		//tt.Repetition.Duration = TimeSpan.FromMinutes(1);
		tt.Repetition.StopAtDurationEnd = true;
		tt.Id = Guid.NewGuid().ToString();
		tt.ExecutionTimeLimit = TimeSpan.FromMinutes(2);
		
		var action = new ExecAction("notepad.exe", @"C:\temp\KenTask.txt", @"C:\Temp\");
		//action.Path = "notepad.exe";
		
		var td = ts.NewTask();
		td.RegistrationInfo.Date = DateTime.Now;
		td.RegistrationInfo.Author = "LINQPad";
		td.RegistrationInfo.Description = "Just opens and closes notepad according to the scheduled time";
		td.RegistrationInfo.Documentation = "lol, that's a good one";
		td.RegistrationInfo.Source = "TaskScheduleWrapper";
		//td.RegistrationInfo.URI = "";
		td.Data = "This is data, I don't see it anywhere in the dialog";
	  td.Actions.Add(action);
		td.Triggers.Add(tt);
		
		var newTask = folder.RegisterTaskDefinition("KenTest", td);
		newTask.Dump(2);
		//newTask.Definition.Dump();
		//newTask.NumberOfMissedRuns.Dump("Missed Runs");
		//newTask.GetRunTimes(DateTime.MinValue, DateTime.MaxValue).Dump("Run Times");
		//newTask.State.Dump("State");
		//*/
	}
}