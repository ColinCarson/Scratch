#light
type couple = { him : string ; her : string }

let couples = 
  [ { him = "Brad" ; her = "Angelina" };
  { him = "Becks" ; her = "Posh" };
  { him = "Chris" ; her = "Gwyneth" };
  { him = "Micheal" ; her = "Catherine" } ]

let rec findDavid l =
 match l with
 | { him = x ; her = "Posh" } :: tail -> x
 | _ :: tail -> findDavid tail
 | [] -> failwith "Unable to find David"
 
printfn "%A" (findDavid couples)