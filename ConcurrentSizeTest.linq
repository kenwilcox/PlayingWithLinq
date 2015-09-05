<Query Kind="Statements">
  <Namespace>System.Collections.Concurrent</Namespace>
</Query>

var queue = new ConcurrentQueue<ulong>();
//var bag = new ConcurrentBag<ulong>(); //61,982,831

for(ulong i = 0; i< ulong.MaxValue; i++) {
  try {
    queue.Enqueue(i);
    //bag.Add(i);
  } catch (Exception e)  {
    Console.WriteLine (e.Message);
    Console.WriteLine (i);
    break;
  }
}