<Query Kind="Program" />

void Main()
{
  1.Second().Dump();
  2.Seconds().Dump();
  2.Minutes().Dump();
  1.Day().Dump();
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
}