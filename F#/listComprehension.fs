#light

let numericList = [ 0 .. 9 ]
let alphaList = [ 'A' .. 'Z' ]

printfn "Numeric list:"
printfn "%A" numericList

printfn ""
printfn "Alphanumeric list:"
printfn "%A" alphaList

printfn ""
printfn "Sequence of squares:"
let squares = 
 seq { for x in 1 .. 100 -> x * x }
 
printf "%A" squares

printfn ""
printfn "Sequence of even numbers:"
let evens num =
 seq { for x in 1 .. num do if x % 2 = 0 then yield x }
    
printf "%A" (evens 20)

printfn ""
printfn "Sequence of points:"
let squarePoints sqPts =
 seq { for x in 1 .. sqPts do for y in 1 .. sqPts -> x,y }
    
printf "%A" (squarePoints 2)

printfn ""