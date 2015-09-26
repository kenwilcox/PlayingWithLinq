<Query Kind="FSharpProgram" />

type NameAndSize = {Name: string; Size:int}

let list = [
  {Name="Alice"; Size=10}
  {Name="Bob"; Size=1}
  {Name="Carol"; Size=12}
  {Name="David"; Size=5}
  ]

let builtinMax = list |> List.maxBy (fun item -> item.Size)
builtinMax.Dump()

// Builtin doesn't work with an empty list
//let builtinEmpty = [] |> List.maxBy (fun item -> item.Size)
//builtinEmpty.Dump()

let maxNameAndSize list =
  match list with
  | [] ->
    None
  | _ -> 
    let max = list |> List.maxBy (fun item -> item.Size)
    Some max

let max = maxNameAndSize list
max.Value.Dump()

let empty = maxNameAndSize []
empty.Dump()