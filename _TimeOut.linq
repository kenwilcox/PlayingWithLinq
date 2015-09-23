<Query Kind="Program">
  <NuGetReference>TaskScheduler</NuGetReference>
  <Namespace>Microsoft.Win32.TaskScheduler</Namespace>
</Query>

void Main()
{
  DateTime punchIn = DateTime.Now;
  //DateTime punchIn = new DateTime(2015, 8, 7, 8, 35, 0);
  DateTime lunchTime = punchIn.AddHours(5);
  DateTime punchOut = punchIn.AddHours(8).AddMinutes(30);
  Console.WriteLine(punchOut.ToShortTimeString());
	
  var dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Daily\";
  var import = dir + @"Import\";
  
  var ext = ".txt";
  var name = DateTime.Now.ToString("ddd M-dd-yyyy");
  var file = String.Format(@"{0}{1}{2}", dir, name, ext);
	
  if (!File.Exists(file)) {
    string[] lines = {
      String.Format("{0}", name),
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
      var action = new ExecAction("notify.exe", msgTitle + "|" + msgBody, ".");
      ts.AddTask(@"MBSI\_TimeOut", trigger, action);
      
      Console.WriteLine("TimeOut Updated");
    }
    
    using (TaskService ts = new TaskService())
    {
      TimeTrigger trigger = new TimeTrigger(punchOut);
      var msgTitle = "Time for Lunch";
      var msgBody = "00:30:00";
      var action = new ExecAction("notify.exe", msgTitle + "|" + msgBody, ".");
      ts.AddTask(@"MBSI\_LunchTime", trigger, action);
      
      Console.WriteLine("LunchTime Updated");
    }
	}
	
  // maintenance
  var files = Directory.GetFiles(dir, "*" + ext);
  foreach(var log in files)
  {
    Directory.CreateDirectory(import);
    
    // Ignore "today's" log
    if (log != file)
    {
      var newName = log.Replace(dir, import);
      try 
      {
        File.Move(log, newName);
      } 
      catch (Exception e)
      {
        e.Dump();
        e.DumpTrace();
      }
    }
  }
  
  Process.Start("notepad", file);  
}

// Define other methods and classes here