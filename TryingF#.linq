<Query Kind="FSharpProgram" />

let myInt = 5
let myFloat = 3.14
let myString = "hello"

let twoToFive = [2;3;4;5]
let oneToFive = 1 :: twoToFive
let zeroToFive = [0;1] @ twoToFive

let square x = x * x
let s3 = square 3

let add x y = x + y
let add2_3 = add 2 3

let evens list = 
  let isEven x = x%2 = 0
  List.filter isEven list

let eList = evens oneToFive
eList.Dump()

let sumOfSquaresTo100 =
  List.sum (List.map square [1..100])
sumOfSquaresTo100.Dump()

let sumOfSquaresTo100Piped =
  [1..100] |> List.map square |> List.sum
let sumOfSquaresTo100Fun =
  [1..100] |> List.map (fun x->x*x) |> List.sum
sumOfSquaresTo100Piped.Dump()
sumOfSquaresTo100Fun.Dump()


let simplePatternMatch = 
  let x = "a"
  match x with
    | "a" -> printfn "x is a"
    | "b" -> printfn "x is b"
    | _ -> printfn "x is something else" // _ matches anything
simplePatternMatch.Dump()

let validValue = Some(99) // Optional
let invalidValue = None
validValue.Dump()
invalidValue.Dump()

let optionPatternMatch input = 
  match input with
   | Some i -> printfn "input is an int=%d" i
   | None -> printfn "input is missing"
let opm = optionPatternMatch validValue
let ipm = optionPatternMatch invalidValue
opm.Dump()
ipm.Dump()

// tuples are quick anonymous types
let twoTuple = 1,2
let threeTuple = "a",2,true
twoTuple.Dump()
threeTuple.Dump()

// record types have named fields
type Person = {First:string; Last:string}
let person1 = {First="John"; Last="Doe"}
person1.Dump()

// union types have choices
type Temp =
  | DegreesC of float
  | DegreesF of float
let temp = DegreesF 98.6
temp.Dump()

// types can be combined recursively in complex ways
type Employee = 
  | Worker of Person
  | Manager of Employee list
let jdoe = {First="John"; Last="Doe"}
let worker = Worker jdoe
worker.Dump()

// Printing
printfn "Printing an int %i, a float %f, a bool %b" 1 2.0 true
printfn "A string %s, and something generic %A" "hello" [1;2;3;4]

// all complex types have pretty printing built in
printfn "twoTuple=%A,\nPerson=%A,\nTemp%A,\nEmployee=%A"
  twoTuple person1 temp worker
