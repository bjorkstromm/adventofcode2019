// Learn more about F# at http://fsharp.org

open System

// Formula for calculating fuel for module
let fuelForModule mass =
    (mass / 3) - 2

// Recursive function to also take fuel for fuel into account
let rec fuelForModule2 mass =
    match fuelForModule mass with
    | x when x < 1 -> 0
    | x -> x + fuelForModule2 x

// First version, doesn't take fuel for fuel into account
let totalFuel modules =
    modules
    |> Array.sumBy fuelForModule

// Second version, takes fuel for fuel into account
let totalFuel2 modules =
    modules
    |> Array.sumBy fuelForModule2

[<EntryPoint>] 
let main argv =
    argv
    |> Array.map int
    |> totalFuel2 
    |> printfn "Total fuel needed is %i"
    0 // return an integer exit code
