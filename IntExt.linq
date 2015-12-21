<Query Kind="Program" />

void Main()
{
  1.Second().Dump();
  2.Seconds().Dump();
  1.Minute().Dump();
  2.Minutes().Dump();
  1.Day().Dump();
  (1.Second() + 1.Minute()).Dump();
  1.Second().And(1.Minute()).Dump();
  1.Minute().Less(1.Second()).Dump();
  3.Hours().And(54.Minutes()).And(12.Seconds()).Dump();
  
  // Some tests
  (60.Seconds() == 1.Minute()).Dump("Minute");
  (180.Seconds() == 3.Minutes()).Dump("Minutes");
  (60.Minutes() == 1.Hour()).Dump("Hour");
  (240.Minutes() == 4.Hours()).Dump("Hours");
  (24.Hours() == 1.Day()).Dump("Day");
  (48.Hours() == 2.Days()).Dump("Days");
  
  (3.Hours().And(60.Minutes()) == 4.Hours()).Dump("Hour Math");
  (60.Seconds().And(60.Seconds()) == 2.Minutes()).Dump("Second Math");
  (60.Seconds().And(60.Seconds()).And(65.Seconds().Less(5.Seconds())) == 3.Minutes()).Dump("Second Math");
}

// Define other methods and classes here
public static class IntExt
{
  public static int Second(this int integer)
  {
    return 1000 * integer;
  }

  public static int Seconds(this int integer)
  {
    return integer.Second();
  }

  public static int Minute(this int integer)
  {
    return Seconds(integer) * 60;
  }

  public static int Minutes(this int integer)
  {
    return integer.Minute();
  }

  public static int Hour(this int integer)
  {
    return Minutes(integer) * 60;
  }

  public static int Hours(this int integer)
  {
    return integer.Hour();
  }

  public static int Day(this int integer)
  {
    return Hours(integer) * 24;
  }

  public static int Days(this int integer)
  {
    return integer.Day();
  }

  public static int And(this int integer, int add)
  {
    return integer + add;
  }
  
  public static int Less(this int integer, int less)
  {
    return integer - less;
  }
}