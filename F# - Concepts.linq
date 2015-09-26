<Query Kind="FSharpProgram" />

let square x = x * x
let squareclone = square
let result = [1..10] |> List.map squareclone

let execFunction aFunc aParam = aFunc aParam
let result2 = execFunction square 12

result.Dump()
result2.Dump()

// Algebraic Types
type IntAndBool = {intPart: int; boolPart: bool}
let x = {intPart=1; boolPart = false}
x.Dump()
