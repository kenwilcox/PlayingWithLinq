<Query Kind="FSharpProgram" />

// set up the vocabulary
type DateScale = Hour | Hours | Day | Days | Week | Weeks
type DateDirection = Ago | Hence

let getDate interval scale direction =
  let absHours = 
    match scale with
    | Hour | Hours -> 1 * interval
    | Day | Days -> 24 * interval
    | Week | Weeks -> 24 * 7 * interval
  let signedHours = 
    match direction with
    | Ago -> -1 * absHours
    | Hence -> absHours
  System.DateTime.Now.AddHours(float signedHours)

let example1 = getDate 5 Days Ago
let example2 = getDate 1 Hour Hence

example1.Dump("5 Days Ago")
example2.Dump("1 Hour From Now")
