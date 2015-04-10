<Query Kind="Statements">
  <Output>DataGrids</Output>
</Query>

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

doc.Dump();