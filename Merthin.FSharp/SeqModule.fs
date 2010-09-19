namespace Merthin.FSharp

open System
open System.Linq

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Seq =

    let public foldc folder state source  =
       source 
       |> Seq.fold(fun (c,state) current -> (c + 1, folder state current)) (0,state)

    let public foldi folder state source  =
       source 
       |> Seq.fold(fun (i,state) current -> (i + 1, folder i state current)) (0,state)
       |> snd

    let public foldic folder state source =
       source 
       |> Seq.fold(fun (i,state) current -> (i + 1, folder i state current)) (0,state)

    let public tryFirst source =
        let result = Enumerable.FirstOrDefault(source)
        if result = null then None else Some(result)
       
    let public partition n source =
        let first = source |> Seq.take n
        let second = source |> Seq.skip n
        first, second

      