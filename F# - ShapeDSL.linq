<Query Kind="FSharpProgram" />

type FluentShape = {
  label: string;
  color: string;
  onClick: FluentShape->FluentShape
}

let defaultShape = 
  {label=""; color=""; onClick=fun shape->shape}
let click shape = 
  shape.onClick shape
let display shape = 
  printfn "My label=%s and my color=%s" shape.label shape.color
  shape
let setLabel label shape =
  {shape with FluentShape.label = label}
let setColor color shape =
  {shape with FluentShape.color = color}
// add a click action to what is already there
let appendClickAction action shape =
  {shape with FluentShape.onClick = shape.onClick >> action}

// helper functions
let setRedBox = setColor "red" >> setLabel "box"
let setBlueBox = setRedBox >> setColor "blue"
let changeColorOnClick color = appendClickAction (setColor color)

// setup some test values
let redBox = defaultShape |> setRedBox
let blueBox = defaultShape |> setBlueBox

// create a shape that changes color when clicked
redBox
  |> display
  |> changeColorOnClick "green"
  |> click
  |> display
  |> ignore

blueBox
  |> display
  |> appendClickAction (setLabel "box2" >> setColor "green")
  |> click
  |> display
  |> ignore

let rainbow = ["red";"orange";"yellow";"green";"blue";"indigo";"violet"]
let showRainbow = 
  let setColorAndDisplay color = setColor color >> display
  rainbow
  |> List.map setColorAndDisplay
  |> List.reduce(>>)

defaultShape |> showRainbow |> ignore
