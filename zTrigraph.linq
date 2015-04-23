<Query Kind="Program" />

void Main()
{
  if (!ErrorHasOccured() || HandleError()) {
    Console.WriteLine("I'm here");
  }
}

// Define other methods and classes here
bool ErrorHasOccured() {
  Console.WriteLine("Checking Error");
  return true;
}

bool HandleError() {
  Console.WriteLine("Handling Error");
  return true;
}