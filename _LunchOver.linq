<Query Kind="Statements" />

var endTime = DateTime.Now.AddMinutes(30);
Process.Start("notify.exe", "Lunch Over - " + endTime.ToShortTimeString() + "|00:30:00");
endTime.Dump();