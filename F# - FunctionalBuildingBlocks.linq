<Query Kind="FSharpProgram" />

let add2 x = x + 2
let mult3 x = x * 3
let square x = x * x

[1..10] |> List.map add2 |> printfn "%A"
[1..10] |> List.map mult3 |> printfn "%A"
[1..10] |> List.map square |> printfn "%A"
