#light
let rec concatStringList =
  function head :: tail -> head + concatStringList tail | [] -> ""
    
let jabber = ["'Twas "; "brillig, "; "and "; "the "; "slithy "; "toves "; "..."]

printfn "output string thingy"

let completeJabber = concatStringList jabber
printfn "%A" completeJabber