#light
let listOfLists = [[2; 3; 5]; [7; 11; 13]; [17; 19; 29]]

let rec concatList l = 
  if not List.isEmpty l then
   let head = List.hd l in
   let tail = List.tl l in
   head @ (concatList tail)
  else
   []
   
let primes = concatList listOfLists

printfn "%A" primes