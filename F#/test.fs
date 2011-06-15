#light

printfn "Simple F# test program"

let halfway a b =
 let dif = b - a
 let mid = dif / 2
 mid + a

printfn "(halfway 5 11) = %i" (halfway 5 11)
printfn "(halfway 11 5) = %i" (halfway 11 5)
