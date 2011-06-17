#light

type Organisation1 = { boss : string ; lackeys : string list }

let rainbow =
  { boss = "Jeffrey";
    lackeys = ["Zippy"; "George"; "Bungle"] }


printfn "%A" rainbow