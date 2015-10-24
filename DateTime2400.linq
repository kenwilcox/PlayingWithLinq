<Query Kind="Statements">
  <Namespace>System.Globalization</Namespace>
</Query>

//DateTime.ParseExact("1510062400", "yyMMddHHmm", CultureInfo.CurrentCulture)
//DateTime.ParseExact("2400", "HHmm", CultureInfo.CurrentCulture)

string dateTimeStr = "1510062400";
const string format = "yyMMddHHmm";
var provider = CultureInfo.InvariantCulture;
int hourPos = format.IndexOf("HH");
var hour = dateTimeStr.Substring(hourPos, 2);
bool addDay = hour == "24";
if (addDay)
  dateTimeStr = dateTimeStr.Substring(0, hourPos) + "00" + dateTimeStr.Substring(hourPos + 2);
var dateTime = DateTime.ParseExact(dateTimeStr, format, provider);
if (addDay)
  dateTime += TimeSpan.FromHours(24);
dateTime.Dump();