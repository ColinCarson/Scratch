open Microsoft.FSharp.Compatibility.OCaml
#light
let emptyList = []
let oneItem = "one " :: []
let twoItems = "one " :: "two " :: []

let shortHand = ["apples "; "pairs "]
let twoLists = ["one "; "two "] @ ["buckle "; "my "; "shoe "]
let objList = [box 1; box 2.0; box "three"]

let printList l =
 List.iter print_string l
 print_newline()
 
let main()=
 printList emptyList
 printList oneItem
 printList twoItems
 printList shortHand
 printList twoLists

 for x in objList do
  printf "%A" x
  print_char ' '
 print_newline()
 
main()