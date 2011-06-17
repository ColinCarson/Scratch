#light
let listOfLists = [[2; 3; 5]; [7; 11; 13]; [17; 19; 29]]

let rec concatListOriginal l = 
  if List.nonempty l then
   let head = List.hd l in
   let tail = List.tl l in
   head @ (concatListOriginal tail)
  else
   []
   
let rec concatList l =
 match l with
 | head :: tail -> head @ (concatList tail)
 | [] -> []
   
let primes = concatList listOfLists

printfn "%A" primes