<Query Kind="Program">
  <NuGetReference>TaskScheduler</NuGetReference>
  <Namespace>Microsoft.Win32.TaskScheduler</Namespace>
</Query>

void Main()
{
  //Util.CurrentQueryPath.Dump();
  using (TaskService ts = new TaskService())
  {
    var punchOut = DateTime.Now.AddMinutes(10);
    TimeTrigger trigger = new TimeTrigger(punchOut);
    var msgBody = "It's time to switch users!";
    ExecAction action = new ExecAction("notify.exe", msgBody, ".");
    ts.AddTask(@"MBSI\_TimesUp", trigger, action);
    
    Console.WriteLine("TimesUp Updated");
  }
}

// Define other methods and classes here