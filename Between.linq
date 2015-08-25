<Query Kind="Program" />

void Main()
{
    CallBetween("banana", "apple, car").Dump("Is banana is between apple and car?");
    CallBetween("2", "1, 3").Dump("Is '2' between 1 and 3");
    CallBetween(2, "1, 3").Dump("Is 2 between 1 and 3");
}

private static bool CallBetween(object obj, string objList)
{
    var between = objList.Split(',').Select(x => (object)x.Trim()).ToArray();
    return Between(obj, between);
}


// Define other methods and classes here
private static int Compare<T>(T v1, object v2)
{
    return (v1 as IComparable).CompareTo(ChangeType(v2, v1));
}

private static bool LessOrEqual(object v1, object v2)
{
    return Compare(v1, v2) <= 0;
}

private static bool GreaterOrEqual(object v1, object v2)
{
    return Compare(v1, v2) >= 0;
}

public static bool Between(object v1, object[] vals)
{
    if (vals.Length < 2) throw new Exception("BAD BAD ERROR! Need two arguments");
    return GreaterOrEqual(v1, vals[0]) && LessOrEqual(v1, vals[1]);
}

private static T ChangeType<T>(object value, T toType)
{
    var result = default(T);
    if (toType is DateTime)
    {
        var s = value as string;
        if (s != null)
        {
            result = (T)(object)DateTime.Parse(s);
        }
    }
    else
    {
        result = (T)Convert.ChangeType(value, toType.GetType());
    }
    return result;
}