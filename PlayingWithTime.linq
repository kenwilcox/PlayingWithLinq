<Query Kind="Statements" />

var currentTime = DateTime.Parse("06/12/2015 10:00 AM");
var lastLoad = DateTime.Parse("06/11/2015 10:00 AM");
var runByTime = new TimeSpan(10,0,0);

(lastLoad.Date < currentTime.Date && runByTime <= currentTime.TimeOfDay).Dump();
string.Format("{0} < {1} && {2} <= {3}", lastLoad.Date, currentTime.Date, runByTime, currentTime.TimeOfDay).Dump();