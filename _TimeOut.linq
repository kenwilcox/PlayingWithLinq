<Query Kind="Program" />

void Main()
{
	DateTime punchIn = DateTime.Now;
    DateTime punchOut = punchIn.AddHours(8).AddMinutes(30);
    Console.WriteLine(punchOut.ToShortTimeString());
	
	var dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
	var name = DateTime.Now.ToString("ddd M-dd-yyyy");
	var file = String.Format(@"{0}\{1}.txt", dir, name);
	
	if (!File.Exists(file)) {
	  string[] lines = {punchIn.ToShortTimeString(), punchOut.ToShortTimeString()};
	  File.WriteAllLines(file, lines);
	}
	
	Process.Start("notepad", file);
}

// Define other methods and classes here