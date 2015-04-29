<Query Kind="Statements">
  <Namespace>System.Globalization</Namespace>
</Query>

var badValues = new string[] {"800703E9", "80070002", "800703E9"};
foreach(var value in badValues.Distinct())
{
  var dec = uint.Parse(value, NumberStyles.HexNumber);
	String.Format("{0} = {1}", value, dec).Dump();
}