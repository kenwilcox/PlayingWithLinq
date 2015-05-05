<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <NuGetReference>TaskScheduler</NuGetReference>
  <NuGetReference>TaskSchedulerEditor</NuGetReference>
  <Namespace>Microsoft.Win32.TaskScheduler</Namespace>
  <Namespace>Microsoft.Win32.TaskScheduler.Fluent</Namespace>
</Query>

Task task = null;
TaskFolder oldFolder = null;

using (TaskService ts = new TaskService())
{
  task = ts.GetTask(@"\AddendumSender");
	oldFolder = ts.RootFolder;
}

if (task != null) 
{

	using (TaskService lts = new TaskService())
	{
	  try 
		{
		  //var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
			
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
			
      var newVer = (lts.HighestSupportedVersion >= new Version(1, 2));
			
			var td = lts.NewTask();
			td.Data = task.Definition.Data;
			td.Principal.UserId = task.Definition.Principal.UserId;
			td.Principal.LogonType = task.Definition.Principal.LogonType;
			//td.Principal.UserId = user;
			//td.Principal.LogonType = TaskLogonType.InteractiveToken;
			td.RegistrationInfo.Author = task.Definition.RegistrationInfo.Author;//.Replace(" (TaskCloner)", "");
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
			
			foreach(var action in task.Definition.Actions)
			{
			  td.Actions.Add((Microsoft.Win32.TaskScheduler.Action)action.Clone());
			}
			var newTask = folder.RegisterTaskDefinition(task.Name, td, TaskCreation.CreateOrUpdate, null, null, TaskLogonType.InteractiveToken, null);
			var editorForm = new TaskEditDialog(newTask, true, true);
      editorForm.ShowDialog();
			
			// Remove the old/previus task
			oldFolder.DeleteTask(task.Name, true);
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