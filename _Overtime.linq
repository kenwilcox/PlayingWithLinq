<Query Kind="Statements" />

var sat = new TimeSpan(0, 22, 12);
var mon = new TimeSpan(8, 44, 24);
var tues = new TimeSpan(9, 30, 36);
var wed = new TimeSpan(8, 27, 0);
var thur = new TimeSpan(8, 40, 48);

var total = sat + mon + tues + wed + thur;
total.Dump("Total for the week");

var workDay = new TimeSpan(8, 0, 0);
total.TotalHours.Dump("Total Hours");

var totalSeconds = sat.TotalSeconds + mon.TotalSeconds + tues.TotalSeconds + wed.TotalSeconds + thur.TotalSeconds;
totalSeconds.Dump();
(totalSeconds / workDay.TotalSeconds).Dump("overtme?");