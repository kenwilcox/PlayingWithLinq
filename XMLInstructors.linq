<Query Kind="Statements" />

XElement instructors = 
	new XElement("instructors",
		new XElement("instructor", "Aaron"),
		new XElement("instructor", "Fritz"),
		new XElement("instructor", "Keith"),
		new XElement("instructor", "Scott")
	);
instructors.ToString().Dump();