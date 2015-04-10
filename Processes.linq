<Query Kind="Expression">
  <Output>DataGrids</Output>
</Query>

Process.GetProcesses()
	.Where(p => p.ProcessName == "svchost")
	.OrderByDescending(p => p.WorkingSet64)
	.Dump()