<Query Kind="Program">
  <NuGetReference>TaskScheduler</NuGetReference>
  <Namespace>Microsoft.Win32.TaskScheduler</Namespace>
</Query>

void Main()
{
	DateTime punchIn = DateTime.Now;
	DateTime lunchTime = punchIn.AddHours(5);
  DateTime punchOut = punchIn.AddHours(8).AddMinutes(30);
  Console.WriteLine(punchOut.ToShortTimeString());
	
	var dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
	var name = DateTime.Now.ToString("ddd M-dd-yyyy");
	var file = String.Format(@"{0}\Daily\{1}.txt", dir, name);
	
	if (!File.Exists(file)) {
	  string[] lines = {
		  String.Format("Start Time  : {0}", punchIn.ToShortTimeString()),
			String.Format("Lunch Before: {0}", lunchTime.ToShortTimeString()),
			String.Format("End Time    : {0}", punchOut.ToShortTimeString())
		};
	  File.WriteAllLines(file, lines);
    
    using (TaskService ts = new TaskService())
    {
      TimeTrigger trigger = new TimeTrigger(punchOut);
      var msgTitle = "Punch Out";
      var msgBody = "It's time to go home!";
      ShowMessageAction action = new ShowMessageAction(msgBody, msgTitle);
      ts.AddTask(@"MBSI\_TimeOut", trigger, action);
      
      Console.WriteLine("TimeOut Updated");
    }
	}
	
	Process.Start("notepad", file);  
}

// Define other methods and classes here