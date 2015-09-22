<Query Kind="FSharpProgram" />

(*
If the list is empty, there is nothing to do.
Otherwise: 
  1. Take the first element of the list
  2. Find all elements in the rest of the list that 
      are less than the first element, and sort them. 
  3. Find all elements in the rest of the list that 
      are >= than the first element, and sort them
  4. Combine the three parts together to get the final result: 
      (sorted smaller elements + firstElement + 
       sorted larger elements)

Note that this is a simplified algorithm and is not optimized (and it does not sort in place, like a true quicksort); we want to focus on clarity for now.
*)

let rec quicksort list = 
  match list with
  | [] -> // If the list is empty
    []    // return an empty list
  | firstElem::otherElements -> // If the list is not empty
    let smallerElements =       // extract the smaller ones
      otherElements
      |> List.filter (fun e -> e < firstElem)
      |> quicksort
    let largerElements = 
      otherElements
      |> List.filter (fun e -> e >= firstElem)
      |> quicksort
    // Combine the 3 parts into a new list and return it
    List.concat [smallerElements; [firstElem]; largerElements]

printfn "%A" (quicksort [1;5;23;18;9;1;3])
printfn "%A" (quicksort ["Jose";"Jones";"Smith";"Apple";"Zebra";"Jones"])