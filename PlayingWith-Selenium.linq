<Query Kind="Statements">
  <NuGetReference>NUnit</NuGetReference>
  <NuGetReference>Selenium.RC</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>Selenium</Namespace>
</Query>

// Trying out Selenium
// http://www.seleniumhq.org/docs/05_selenium_rc.jsp

var sel = new DefaultSelenium("localhost", 5555, "*iexplore", "http://www.google.com/");
sel.Start();
sel.Open("http://www.google.com/");
Assert.AreEqual("Google", sel.GetTitle());
sel.Type("q", "Selenium OpenQA");
Assert.AreEqual("Selenium OpenQA", sel.GetValue("q"));
sel.Click("btnG");
sel.WaitForPageToLoad("5000");
Assert.IsTrue(sel.IsTextPresent("www.openqa.org"));
Assert.AreEqual("Selenium OpenQA - Google Search", sel.GetTitle());
sel.Stop();