// Learn more about F# at http://fsharp.org

open System

let replaceAt value index list =
    printfn "Replacing value %i at index %i" value index
    Array.mapi (fun i x -> if i = index then value else x) list

let rec processOpCode index integers =
    match Array.item index integers with
    | 1 ->  processOpCode
                (index + 4)
                (replaceAt (integers.[integers.[index + 1]] + integers.[integers.[index + 2]]) integers.[index + 3] integers)
    | 2 -> processOpCode
                (index + 4)
                (replaceAt (integers.[integers.[index + 1]] * integers.[integers.[index + 2]]) integers.[index + 3] integers)
    | 99 -> integers
    | code -> raise (InvalidOperationException(sprintf "Invalid opCode %i at index %i" code index))

let processOpCode1 integers =
    processOpCode 0 integers

[<EntryPoint>]
let main argv =
    (Array.item 0 argv).Split ','
    |> Array.map int
    |> processOpCode1
    |> Array.map string
    |> String.concat ","
    |> printfn "Result is %s"
    0 // return an integer exit code
