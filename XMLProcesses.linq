<Query Kind="Statements" />

XDocument doc = new XDocument(
	new XElement("Processes",
		Process.GetProcesses()
			.OrderBy(p => p.ProcessName)
			.Select(p => new XElement("Process",
				new XAttribute("Name", p.ProcessName),
				new XAttribute("PID", p.Id)
				)
			)
		)
	);

//doc.Dump();

// Find visual studio process
var pids = doc.Descendants("Process")
	.Where(e => e.Attribute("Name").Value.StartsWith("devenv"));
pids.Dump();