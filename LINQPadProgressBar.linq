<Query Kind="Statements" />

var pb = new Util.ProgressBar().Dump();
pb.Caption = "Packs";

var counter = 0;
pb.Visible = true;
var max = 10000;

for (var i = 0; i < max; i++)
{
  counter++;
  pb.Fraction = (double)counter/max;
}