<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Globalization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.dll</Reference>
  <Namespace>System.Globalization</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

var eatThis = new {
  // You can pass the url
  Icon = Util.Image("http://www.linqpad.net/favicon.ico"),
  // or the image data
  PNG = Util.Image(new WebClient().DownloadData("https://www.google.com/logos/doodles/2015/start-of-the-2015-us-open-tennis-championship-5723562658758656.2-res.png")),
  XML = XElement.Parse("<root type='foo'><inner>test</inner></root>"),
  CultureInfo.CurrentCulture.Calendar
};
eatThis.Dump();

var path=@"C:\Gow\"; 
var dirSwitch="/s/b";
var x=Util.Cmd(String.Format(@"dir ""{0}"" {1}", path, dirSwitch), true);
var q=from d in x 
        where d.Contains(".exe") || d.Contains(".dll")              
        orderby d
    select d;
q.Dump();

for(var i = 0; i < 100; i+=10) {
  Util.Progress = i;
  System.Threading.Thread.Sleep(100);
}

Action showUrl = delegate() {Process.Start("iexplore.exe", "http://stackoverflow.com"); };
var url = new Hyperlinq(showUrl, "this link", true);
Util.HorizontalRun(true, "Click", url, "for details.").Dump("Check StackOverflow");
Util.HorizontalRun(true, "Click", url, "for details.").Dump("Check StackOverflow");
