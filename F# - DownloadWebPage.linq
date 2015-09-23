<Query Kind="FSharpProgram" />

open System.Net
open System
open System.IO

let fetchUrl callback url =
  let req = WebRequest.Create(Uri(url))
  use resp = req.GetResponse()
  use stream = resp.GetResponseStream()
  use reader = new IO.StreamReader(stream)
  callback reader url

let myCallback (reader:IO.StreamReader) url = 
  let html = reader.ReadToEnd()
  let html1000 = html.Substring(0,1000)
  printfn "Downloading %s. First 1000 is %s" url html1000
  html

let google = fetchUrl myCallback "http://google.com"

// build a function with the callback "baked in"
let fetchUrl2 = fetchUrl myCallback

let google2 = fetchUrl2 "http://google.com"
let bbc = fetchUrl2 "http://news.bbc.co.uk"

// test with a list of sites
let sites = ["http://www.bing.com";"http://www.google.com";"http://www.yahoo.com"]
let data = sites |> List.map fetchUrl2


