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

// Union/Sum type
type IntOrBool = 
 | IntChoice of int
 | BoolChoice of bool

let y = IntChoice 42
let z = BoolChoice true

y.Dump()
z.Dump()
