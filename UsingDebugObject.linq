<Query Kind="Program" />

void Main()
{
  //Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
  Debug.AutoFlush = true;
  Debug.IndentSize = 8;
  
  Debug.Indent();  
  Debug.WriteLine("Entering Main");
  Console.WriteLine("Hello World.");
  Debug.WriteLine("Exiting Main"); 
  Debug.Unindent();
}

// Define other methods and classes here
