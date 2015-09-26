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

// Pattern matching with union types
type Shape = 
| Circle of int
| Rectangle of int * int
| Polygon of (int * int) list
| Point of (int * int)

let draw shape =
  match shape with
  | Circle radius ->
    printfn "The circle has a radius of %d" radius
  | Rectangle (height, width) ->
    printfn "The rectangle is %d high by %d wide" height width
  | Polygon points ->
    printfn "The polygon is made of these points %A" points
  | _ -> printfn "I don't recognize this shape"

let circle = Circle(10)
let rect = Rectangle(4,5)
let polygon = Polygon([(1,1); (2,2); (3,3)])
let point = Point(2,3)

[circle; rect; polygon; point] |> List.iter draw
