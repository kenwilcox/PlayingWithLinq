<Query Kind="Program">
  <NuGetReference>Tamarack</NuGetReference>
  <Namespace>Tamarack</Namespace>
  <Namespace>Tamarack.Configuration</Namespace>
  <Namespace>Tamarack.Pipeline</Namespace>
  <Namespace>Tamarack.Pipeline.Extensions</Namespace>
</Query>

void Main()
{
  var pipeline = new Pipeline<string, string>()
    .Add(new FooFilter())
    .Add(new FunFilter())
    .Finally(p => p);

  var ret = pipeline.Execute("This is foo, foo is fun!");
  ret.Dump("Pipeline");
}

// Define other methods and classes here
public class FooFilter : IFilter<string, string>
{
  public string Execute(string text, Func<string, string> executeNext)
  {
    var ret = executeNext(text);
    ret = ret.Replace("foo", "FOO");
    return ret;
  }
}

public class FunFilter : IFilter<string, string>
{
  public string Execute(string text, Func<string, string> executeNext)
  {
    var ret = executeNext(text);
    ret = ret.Replace("fun", "funny");
    return ret;
  }
}