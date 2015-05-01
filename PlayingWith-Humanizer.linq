<Query Kind="Program">
  <NuGetReference>Humanizer</NuGetReference>
  <Namespace>Humanizer</Namespace>
  <Namespace>Humanizer.Configuration</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Globalization</Namespace>
  <Namespace>Humanizer.Localisation</Namespace>
</Query>

// https://github.com/MehdiK/Humanizer

void Main()
{
  LogHuman("PascalCaseInputStringIsTurnedIntoSentence");
  LogHuman("Underscored_input_string_is_turned_into_sentence");
	
  LogDeHuman("Pascal case input string is turned into sentence");
  LogDeHuman("Pascal case input string is turned into sentence".Truncate(5, Truncator.FixedNumberOfWords));
	
  "{0:N2}".FormatWith(new CultureInfo("en-US"), 6666.66).Dump();
  EnumUnderTest.MemberWithDescriptionAttribute.Humanize().Dump();
  EnumUnderTest.MemberWithoutDescriptionAttribute.Humanize().Dump();
	
  "Member without description attribute".DehumanizeTo<EnumUnderTest>().ToString().Dump();
  "PascalCaseWithWords".Humanize().Replace(" ", "_").Dump();
	
  DateTime.UtcNow.AddHours(-30).Humanize().Dump();
  DateTime.UtcNow.AddHours(-2).Humanize().Dump();
  DateTime.UtcNow.AddHours(-1).Humanize().Dump();
  DateTime.UtcNow.AddSeconds(-1).Humanize().Dump();

  "".Dump("TimeSpan precision");
  for(var i = 1; i < 6; i++)
    TimeSpan.FromMilliseconds(1299630020).Humanize(i).Dump(i.ToString());

  //TimeSpan.FromDays(7).Humanize(maxUnit: TimeUnit.Day).Dump();
  
  "Man".Pluralize().Dump();
  "string".Pluralize().Dump();
  "item".ToQuantity(2, ShowQuantityAs.Words).Dump();
  "DateOfService".Camelize().Dump();
}

// Define other methods and classes here
public enum EnumUnderTest
{
  [Description("Custom description")]
  MemberWithDescriptionAttribute,
  MemberWithoutDescriptionAttribute,
  ALLCAPITALS
}

private void LogHuman(string msg)
{
  msg.Humanize().Dump(msg);
}

private void LogDeHuman(string msg)
{
  msg.Dehumanize().Dump(msg);
}