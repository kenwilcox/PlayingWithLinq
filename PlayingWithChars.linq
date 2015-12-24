<Query Kind="Statements" />

// This is so we can do string comparison on the GPU

var test1 = "EFT1234523";
var test2 = "1234523";

var bits1 = System.Text.Encoding.ASCII.GetBytes(test1);
var bits2 = System.Text.Encoding.ASCII.GetBytes(test2);

var matchBuffer = new List<byte>();
var shortest = Math.Max(bits1.Length, bits2.Length);
var i = 0;
var j = 0;
while(i < shortest)
{
  if (bits1[i] == bits2[j])
  {
    matchBuffer.Add(bits2[j]);
    j++;
  }
  else
  {
    matchBuffer.Clear();
  }
  i++;
  if (j > bits2.Length) break;
}
//matchBuffer.Dump();

System.Text.Encoding.ASCII.GetString(matchBuffer.ToArray()).Dump();