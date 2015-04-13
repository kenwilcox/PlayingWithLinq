<Query Kind="Statements" />

// Actions

Action printEmptyLine = () => Console.WriteLine();
Action<int> printNumber = (x) => Console.WriteLine(x);
Action<string> print = x => Console.WriteLine(x);
Action<int, int> addAndPrintTwoNumbers = (x, y) =>
  Console.WriteLine(String.Format("{0} + {1} = {2}", x, y, x+y));

Func<DateTime> getDate = () => DateTime.Now;
Func<int, int> square = x => x * x;
Func<int, int, int> multiply = (x, y) => x * y;



printEmptyLine();
printNumber(10);
addAndPrintTwoNumbers(5, 10);
print(getDate().ToShortDateString());
printNumber(square(5));