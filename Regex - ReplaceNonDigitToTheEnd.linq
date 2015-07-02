<Query Kind="Statements">
  <Namespace>System.Text.RegularExpressions</Namespace>
</Query>

Regex DigitsOnlyToEnd = new Regex(@"\d(?=[^\d]).*$");
var numbers = new List<string>() {
  "0010264908SA500",
  "00102908SA",
  "0010264908500",
  "CHKHST14908966",
};

foreach(var number in numbers) {
  DigitsOnlyToEnd.Replace(number, "").TrimStart('0').Dump(number);
}