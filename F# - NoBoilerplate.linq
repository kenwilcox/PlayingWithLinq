<Query Kind="FSharpProgram" />

// Odd, this example is suposed to be DRY
// but, we set up an initial value
// set up an action
// use List.fold on said items
// not very DRY

let product n = 
  let initialValue = 1
  let action productSoFar x = productSoFar * x
  [1..n] |> List.fold action initialValue

let productResult = product 10
productResult.Dump("Product")

let sumOfOdds n =
  let initialValue = 0
  let action sumSoFar x = if x % 2 = 0 then sumSoFar else sumSoFar + x
  [1..n] |> List.fold action initialValue

let sumOddResult = sumOfOdds 10
sumOddResult.Dump("Sum Of Odds")

let alternatingSum n = 
  let initialValue = (true, 0)
  let action (isNeg, sumSoFar) x = if isNeg then (false, sumSoFar - x) else (true, sumSoFar + x)
  [1..n] |> List.fold action initialValue |> snd

let alternatingResult = alternatingSum 100
alternatingResult.Dump("Alternating Result")

let sumOfSquares n =
  let initialValue = 0
  let action sumSoFar x = sumSoFar + (x * x)
  [1..n] |> List.fold action initialValue

let sumResult = sumOfSquares 100
sumResult.Dump("Sum of Squares")
