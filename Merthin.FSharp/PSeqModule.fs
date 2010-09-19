namespace Merthin.FSharp
open Microsoft.FSharp.Collections

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module PSeq =

    let public foldc fold first source  =
       source 
       |> PSeq.fold(fun (c,previous) current -> (c + 1, fold previous current)) (0,first)

    let public foldi fold first source  =
       source 
       |> PSeq.fold(fun (i,previous) current -> (i + 1, fold i previous current)) (0,first)
       |> snd

    let public foldic fold first source  =
       source 
       |> PSeq.fold(fun (i,previous) current -> (i + 1, fold i previous current)) (0,first)