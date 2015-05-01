<Query Kind="Program" />

void Main()
{
	// Write code to test your extensions here. Press F5 to compile and run.
}

public static class MyExtensions
{
	// Write custom extension methods here. They will be available to all queries.
  
	// Windows return values
  public static Dictionary<uint, string> ReturnValues = new Dictionary<uint, string>() {
	  {0x0, "The operation completed successfully"},
    { 0x00041300, "The task is ready to run at its next scheduled time." },
    { 0x00041301, "The task is currently running." },
    { 0x00041302, "The task will not run at the scheduled times because it has been disabled." },
    { 0x00041303, "The task has not yet run." },
    { 0x00041304, "There are no more runs scheduled for this task." },
    { 0x00041305, "One or more of the properties that are needed to run this task on a schedule have not been set." },
    { 0x00041306, "The last run of the task was terminated by the user." },
    { 0x00041307, "Either the task has no triggers or the existing triggers are disabled or not set." },
    { 0x00041308, "Event triggers do not have set run times." },
    { 0x80041309, "A task's trigger is not found." },
    { 0x8004130A, "One or more of the properties required to run this task have not been set." },
    { 0x8004130B, "There is no running instance of the task." },
    { 0x8004130C, "The Task Scheduler service is not installed on this computer." },
    { 0x8004130D, "The task object could not be opened." },
    { 0x8004130E, "The object is either an invalid task object or is not a task object." },
    { 0x8004130F, "No account information could be found in the Task Scheduler security database for the task indicated." },
    { 0x80041310, "Unable to establish existence of the account specified." },
    { 0x80041311, "Corruption was detected in the Task Scheduler security database; the database has been reset." },
    { 0x80041312, "Task Scheduler security services are available only on Windows NT." },
    { 0x80041313, "The task object version is either unsupported or invalid." },
    { 0x80041314, "The task has been configured with an unsupported combination of account settings and run time options." },
    { 0x80041315, "The Task Scheduler Service is not running." },
    { 0x80041316, "The task XML contains an unexpected node." },
    { 0x80041317, "The task XML contains an element or attribute from an unexpected namespace." },
    { 0x80041318, "The task XML contains a value which is incorrectly formatted or out of range." },
    { 0x80041319, "The task XML is missing a required element or attribute." },
    { 0x8004131A, "The task XML is malformed." },
    { 0x0004131B, "The task is registered, but not all specified triggers will start the task." },
    { 0x0004131C, "The task is registered, but may fail to start. Batch logon privilege needs to be enabled for the task principal." },
    { 0x8004131D, "The task XML contains too many nodes of the same type." },
    { 0x8004131E, "The task cannot be started after the trigger end boundary." },
    { 0x8004131F, "An instance of this task is already running." },
    { 0x80041320, "The task will not run because the user is not logged on." },
    { 0x80041321, "The task image is corrupt or has been tampered with." },
    { 0x80041322, "The Task Scheduler service is not available." },
    { 0x80041323, "The Task Scheduler service is too busy to handle your request. Please try again later." },
    { 0x80041324, "The Task Scheduler service attempted to run the task, but the task did not run due to one of the constraints in the task definition." },
    { 0x00041325, "The Task Scheduler service has asked the task to run." },
    { 0x80041326, "The task is disabled." },
    { 0x80041327, "The task has properties that are not compatible with earlier versions of Windows." },
    { 0x80041328, "The task settings do not allow the task to start on demand." },
		// Ones I've figured out
		{ 0x80070002, "The system cannot find the file specified." },
		{ 0x1, "The specified task has never run." },
		{ 0x800704DD, "The operation being requested was not performed because the user has not logged on to the network. The specified service does not exist." },
	};	
}

// You can also define non-static classes, enums, etc.