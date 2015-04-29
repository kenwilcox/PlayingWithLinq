<Query Kind="Program" />

void Main()
{
	// Test
	string cell = "ZZZZ";
	int index = GetExcelColumn(cell);
	string ret = GetExcelColumn(index);
	String.Format("{0} = {1}: {2}", ret, index, cell.Equals(ret)).Dump();
}

// Define other methods and classes here
int GetExcelColumn(string cell)
{
  int val = 0;
  foreach(var c in cell.ToCharArray())
	{
	  val = val * 26 + GetLetterValue(c) - GetLetterValue('A') + 1;
	}
	return val;
}
string GetExcelColumn(int columnNumber)
{
  int dividend = columnNumber;
  string columnName = String.Empty;
  int modulo;
	
  while (dividend > 0)
  {
    modulo = (dividend - 1) % 26;
    columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
    dividend = (int)((dividend - modulo) / 26);
  }
	
  return columnName;
}

int GetLetterValue(char letter)
{
  return (int)Convert.ToSByte(letter)-64;
}