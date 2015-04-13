<Query Kind="Statements" />

// Actions

Action printEmptyLine = () => Console.WriteLine();
Action<int> printNumber = (x) => Console.WriteLine(x);
Action<int, int> addAndPrintTwoNumbers = (x, y) =>
  Console.WriteLine(String.Format("{0} + {1} = {2}", x, y, x+y));

printEmptyLine();
printNumber(10);
addAndPrintTwoNumbers(5, 10);