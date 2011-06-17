#light
let rec concatStringList =
  function head :: tail -> head + concatStringList tail | [] -> ""
    
let jabber = ["'Twas "; "brillig, "; "and "; "the "; "slithy "; "toves "; "..."]

let completeJabber = concatStringList jabber
printfn "%A" completeJabber