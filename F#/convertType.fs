#light
type Volume =
 | Litre of float
 | USPint of float
 | ImperialPint of float
 
let vol1 = Litre 2.5
let vol2 = USPint 2.5
let vol3 = ImperialPint (2.5)

let convertVolumeToLitre x =
  match x with 
  | Litre x -> x
  | USPint x -> x * 0.473
  | ImperialPint x -> x * 0.568

let convertVolumeToUSPint x =
  match x with 
  | Litre x -> x * 2.113
  | USPint x -> x
  | ImperialPint x -> x * 1.201

let convertVolumeToImperialPint x =
  match x with 
  | Litre x -> x * 1.760
  | USPint x -> x * 0.833
  | ImperialPint x -> x

let printVolumes x =
    printfn "Volume in liters = %f, 
in us pints = %f, 
in imperial pints = %f"
        (convertVolumeToLitre x)
        (convertVolumeToUSPint x)
        (convertVolumeToImperialPint x)
  
printVolumes vol1
printVolumes vol2
printVolumes vol3