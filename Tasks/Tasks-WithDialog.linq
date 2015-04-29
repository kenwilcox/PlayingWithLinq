<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <NuGetReference>TaskScheduler</NuGetReference>
  <NuGetReference>TaskSchedulerEditor</NuGetReference>
  <Namespace>Microsoft.Win32.TaskScheduler</Namespace>
  <Namespace>Microsoft.Win32.TaskScheduler.Fluent</Namespace>
</Query>

// Get the service on the local machine
using (TaskService ts = new TaskService())
{
   // Create a new task
   const string taskName = "Test";
   Task t = ts.AddTask(taskName, 
      new TimeTrigger() { StartBoundary = DateTime.Now + TimeSpan.FromHours(1),
         Enabled = false },
      new ExecAction("notepad.exe", "c:\\test.log", "C:\\"));

   // Edit task and re-register if user clicks Ok
   TaskEditDialog editorForm = new TaskEditDialog();
   editorForm.Editable = true;
   editorForm.RegisterTaskOnAccept = true;
   editorForm.Initialize(t);
   // ** The four lines above can be replaced by using the full constructor
   // TaskEditDialog editorForm = new TaskEditDialog(t, true, true);
   editorForm.ShowDialog();

   // Remove the task we just created
   ts.RootFolder.DeleteTask(taskName);
}