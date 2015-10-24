<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

for (int i = 0; i < 10; i++)
{
    var progressBar = new Util.ProgressBar (i.ToString()).Dump();
    Task.Run (async () =>
    {
        for (var j = 0; j <= 64; j++)
        {
        await Task.Delay(10);
        progressBar.Fraction = (double)j / 64.0;
      }
    });
}