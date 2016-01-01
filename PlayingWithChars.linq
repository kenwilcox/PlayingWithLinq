<Query Kind="Program" />

void Main()
{
  // This is so we can do string comparison on the GPU
  
  var test1 = "EFT1234523";
  var test2 = "12345#2";
  
  var bits1 = System.Text.Encoding.UTF8.GetBytes(test1);
  var bits2 = System.Text.Encoding.UTF8.GetBytes(test2);
  
  bytesInBytes(bits1, bits2, true).Dump();
}

// Define other methods and classes here
bool bytesInBytes(byte[] bits1, byte[] bits2, bool partial = false)
{
  var matchBuffer = new List<byte>();
  var shortest = Math.Max(bits1.Length, bits2.Length);
  var i = 0;
  var j = 0;
  while (i < shortest)
  {
    if (bits1[i] == bits2[j])
    {
      matchBuffer.Add(bits2[j]);
      j++;
    }
    else
    {
      if (!partial)
      {
        matchBuffer.Clear();
      }
    }
    i++;
    if (j >= bits2.Length) break;
  }
  //matchBuffer.Dump();
  //System.Text.Encoding.UTF8.GetString(matchBuffer.ToArray()).Dump();
  if (partial) return matchBuffer.Count() > 0;
  return bits2.Length == matchBuffer.Count();
}
