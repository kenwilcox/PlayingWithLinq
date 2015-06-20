<Query Kind="Program" />

void Main()
{
  var routes = new [] {"071121866", "321171184", "122238420", "122000247", "123456789", "987654321"};
  foreach(var route in routes) {
    RouteCheckSum(route).Dump(route);
  }
}

// Define other methods and classes here
bool RouteCheckSum(string routeNumber) {
  var d = routeNumber.ToCharArray();
  var checksum = ( 
    7 * (Char.GetNumericValue(d[0]) + Char.GetNumericValue(d[3]) + Char.GetNumericValue(d[6])) + 
    3 * (Char.GetNumericValue(d[1]) + Char.GetNumericValue(d[4]) + Char.GetNumericValue(d[7])) + 
    9 * (Char.GetNumericValue(d[2]) + Char.GetNumericValue(d[5]))
    ) % 10;
  
  checksum.Dump();
  var pass = checksum == Char.GetNumericValue(d[8]);
  pass.Dump();
  return pass;
}