(*
 * Merthin Project         - (http://merthin.codeplex.com)
 * Horacio Núñez Hernández - (hnh at lab.matcom.uh.cu)
 * 23/06/2010
 *)

namespace Merthin.FSharp
open Microsoft.FSharp.Collections

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