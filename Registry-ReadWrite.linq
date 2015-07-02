<Query Kind="Statements">
  <Namespace>Microsoft.Win32</Namespace>
</Query>

var key = @"HKEY_LOCAL_MACHINE\SOFTWARE\MBSI\Payments";
Registry.SetValue(key, "KenLastRunTime", DateTime.Now);
Registry.GetValue(key, "KenLastRunTime", null).Dump();