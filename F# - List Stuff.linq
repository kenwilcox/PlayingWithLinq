<Query Kind="FSharpProgram" />

let Where source predicate = 
  Seq.filter predicate source

let GroupBy source keySelector =
  Seq.groupBy keySelector source

let fruits = ["red apple";"green apple";"yellow apple";"banana";"red apple"]
let apples = Where fruits (fun x -> x.Contains("apple"))
let sorted = GroupBy apples (fun x -> x)

apples.Dump()
sorted.Dump()