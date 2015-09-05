<Query Kind="Statements" />

var start = DateTime.Now;
var top = 100000u;
for(ulong i = 0; i <= ulong.MaxValue; i++) {
  if (i % top == 0) {
    var end = DateTime.Now;
    var time = end - start;
    Console.WriteLine("Couted to {0} and it took {1}", i, time);
    start = DateTime.Now;
  }
}