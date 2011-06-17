#light
let printMessages()=
 //define initial message
 let message = "Important"
 printfn "%s" message;
 
 let innerFun()=
  let message = "Very Important"
  printfn "%s" message
  
 innerFun()
 
 printfn "%s" message
 
 
printMessages()