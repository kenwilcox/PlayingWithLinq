<Query Kind="Statements">
  <NuGetReference>TaskScheduler</NuGetReference>
  <Namespace>Microsoft.Win32.TaskScheduler</Namespace>
  <Namespace>Microsoft.Win32.TaskScheduler.Fluent</Namespace>
</Query>

var server = "-serverName-";
var userName = "-userName-";
var accountName = "-domainName-";
var password = "-password-";
Task task = null;

using (TaskService ts = new TaskService(server, userName, accountName, password))
{
  //task = ts.GetTask(@"\mbsi\KenTest");
	task = ts.GetTask(@"\mbsi\LF Exporter");
	//task = ts.GetTask(@"\Microsoft\Windows\Active Directory Rights Management Services Client\AD RMS Rights Policy Template Management (Automated)");
	//task.Definition.Principal.Dump(2);
}

//return;
if (task != null) 
{
	using (TaskService lts = new TaskService())
	{
	  try 
		{
		  var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
			
//		  //task.Path.Dump();
//		  var trigger = task.Definition.Triggers[0];
//			trigger.Dump();
//			var action = task.Definition.Actions[0];
//			action.Dump();
//			var p = action.Path;
//			//task.Definition.Principal.UserId = ;
//		  lts.AddTask(task.Path, trigger, action);
			
			// Looks like it's going to be harder than that.
			//var taskFile = @"C:\temp\task.xml";
			//File.WriteAllText(taskFile, task.Xml);
			//var newTask = lts.NewTaskFromFile(taskFile);
			
			TaskFolder folder;
			try 
			{
			  folder = lts.GetFolder(@"\mbsi");
			}
			catch 
			{
			  lts.RootFolder.CreateFolder(@"\MBSI");
				folder = lts.GetFolder(@"\mbsi");
			}
			
//			task.Definition.Principal.UserId = user;
//			task.Xml.Dump();
//			folder.RegisterTask(task.Name, task.Xml);

      var newVer = (lts.HighestSupportedVersion >= new Version(1, 2));
			//newVer = false;
			
			var td = lts.NewTask();
			td.Data = task.Definition.Data;
			td.Principal.UserId = user;
			td.Principal.LogonType = TaskLogonType.InteractiveToken;
			td.RegistrationInfo.Author = task.Definition.RegistrationInfo.Author + " (TaskCloner)";
			td.RegistrationInfo.Description = task.Definition.RegistrationInfo.Description;
		  td.RegistrationInfo.Documentation = task.Definition.RegistrationInfo.Documentation;
			td.RegistrationInfo.Date = DateTime.Now;
			
			td.Settings.DisallowStartIfOnBatteries = task.Definition.Settings.DisallowStartIfOnBatteries;
			td.Settings.Enabled = false; //task.Definition.Settings.Enabled;
			td.Settings.ExecutionTimeLimit = task.Definition.Settings.ExecutionTimeLimit;
			td.Settings.Hidden = task.Definition.Settings.Hidden;
			td.Settings.IdleSettings.IdleDuration = task.Definition.Settings.IdleSettings.IdleDuration;
			td.Settings.IdleSettings.RestartOnIdle = task.Definition.Settings.IdleSettings.RestartOnIdle;
      td.Settings.IdleSettings.StopOnIdleEnd = task.Definition.Settings.IdleSettings.StopOnIdleEnd;
      td.Settings.IdleSettings.WaitTimeout = task.Definition.Settings.IdleSettings.WaitTimeout;
      td.Settings.Priority = task.Definition.Settings.Priority;
      td.Settings.RunOnlyIfIdle = task.Definition.Settings.RunOnlyIfIdle;
      td.Settings.RunOnlyIfNetworkAvailable = task.Definition.Settings.RunOnlyIfNetworkAvailable;
			//td.Settings.RunOnlyIfLoggedOn = task.Definition.Settings.RunOnlyIfLoggedOn;
      td.Settings.StopIfGoingOnBatteries = task.Definition.Settings.StopIfGoingOnBatteries;
			
			if (newVer)
			{
			  td.Principal.RunLevel = task.Definition.Principal.RunLevel;
        td.RegistrationInfo.Source = task.Definition.RegistrationInfo.Source;
        td.RegistrationInfo.URI = task.Definition.RegistrationInfo.URI;
        td.RegistrationInfo.Version = task.Definition.RegistrationInfo.Version;
        td.Settings.AllowDemandStart = task.Definition.Settings.AllowDemandStart;
        td.Settings.AllowHardTerminate = task.Definition.Settings.AllowHardTerminate;
        td.Settings.Compatibility = task.Definition.Settings.Compatibility;
        td.Settings.DeleteExpiredTaskAfter = task.Definition.Settings.DeleteExpiredTaskAfter;
        td.Settings.MultipleInstances = task.Definition.Settings.MultipleInstances;
        td.Settings.StartWhenAvailable = task.Definition.Settings.StartWhenAvailable;
        td.Settings.WakeToRun = task.Definition.Settings.WakeToRun;
        td.Settings.RestartCount = task.Definition.Settings.RestartCount;
        td.Settings.RestartInterval = task.Definition.Settings.RestartInterval;
			}
			
			// Example of changing trigger interval
			//var trigger = (Trigger)task.Definition.Triggers[0].Clone();
			//Console.WriteLine(trigger.Repetition.Interval);
			//trigger.Repetition.Interval = trigger.Repetition.Interval.Add(new TimeSpan(0, 4, 0));
			//Console.WriteLine(trigger.Repetition.Interval);
			//td.Triggers.Add(trigger);//(Trigger)task.Definition.Triggers[0].Clone());
			foreach(var trigger in task.Definition.Triggers)
			{
			  // adding four minutes to an existing daily trigger
				// but only if the existing daily trigger has an existing repetition
//				if (trigger.TriggerType == TaskTriggerType.Daily && trigger.Repetition.Interval > TimeSpan.MinValue)
//				{
//				  trigger.Repetition.Interval += new TimeSpan(0, 4, 0);
//				}
				td.Triggers.Add((Trigger)trigger.Clone());
			}
			
			
			//td.Actions.Add((Microsoft.Win32.TaskScheduler.Action)task.Definition.Actions[0].Clone());
			foreach(var action in task.Definition.Actions)
			{
			  td.Actions.Add((Microsoft.Win32.TaskScheduler.Action)action.Clone());
			}
			
			folder.RegisterTaskDefinition(task.Name, td, TaskCreation.CreateOrUpdate, null, null, TaskLogonType.InteractiveToken, null);
			
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