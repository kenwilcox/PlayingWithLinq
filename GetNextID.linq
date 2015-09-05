<Query Kind="Program" />

void Main()
{
  IdManager.GetNextId(100).Dump();
  IdManager.GetNextId().Dump();
  IdManager.GetNextId().Dump();
  IdManager.GetNextId(200).Dump();
  IdManager.GetNextId().Dump();
  IdManager.GetNextId().Dump();
  IdManager.GetNextId().Dump();
}

// Define other methods and classes here
public static class IdManager {
  private static int i = 0;
  public static IEnumerable<int> GetNextId(int? newId = null) {
    if (newId.HasValue) i = newId.Value;
    yield return i++;
  }
}