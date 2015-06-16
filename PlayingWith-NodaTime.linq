<Query Kind="Statements">
  <NuGetReference>NodaTime</NuGetReference>
  <Namespace>NodaTime</Namespace>
  <Namespace>NodaTime.Calendars</Namespace>
  <Namespace>NodaTime.Text</Namespace>
  <Namespace>NodaTime.TimeZones</Namespace>
  <Namespace>NodaTime.TimeZones.Cldr</Namespace>
  <Namespace>NodaTime.Utility</Namespace>
</Query>

var now = SystemClock.Instance.Now;
now.InUtc().Dump();

Duration.FromMinutes(3).Dump();
var zoneDateTime = now.InUtc() + Duration.FromMinutes(30);
zoneDateTime.Dump();

var london = DateTimeZoneProviders.Tzdb["Europe/London"];
london.Dump();
var localDate = new LocalDateTime(2015, 3, 27, 0, 45, 00);
localDate.Dump();
var before = london.AtStrictly(localDate);
before.Dump();

DateTime utc = DateTime.UtcNow;
DateTime local = DateTime.Now;
utc.Dump();
local.Dump();
bool same = local == utc;
same.Dump();