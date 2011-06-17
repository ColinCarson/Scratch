open Microsoft.FSharp.Compatibility.OCaml
#light
let mathsPuzzle()=
  print_string "Enter day of the month on which you were born: "
  let input = read_int()
  let x = input * 4 
  let x = x + 13
  let x = x * 25
  let x = x - 200
  print_string "Enter number of the month you were born: "
  let input = read_int()
  let x = x + input
  let x = x * 2
  let x = x - 40
  let x = x * 50
  print_string "Enter the last two digits of the year of your birth: "
  let input = System.Console.ReadLine() |> int
  let x = x + input
  let x = x - 10500
  printfn "Date of birth (ddmmyy): %i" x
  
mathsPuzzle()