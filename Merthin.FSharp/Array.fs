(*
 * Merthin Project         - (http://merthin.codeplex.com)
 * Horacio Núñez Hernández - (hnh12358 at gmail.com)
 * 23/06/2010
 *)

namespace Merthin.FSharp

module Array =

    let public foldc folder state array  =
       array 
       |> Array.fold(fun (c,state) current -> (c + 1, folder state current)) (0,state)

    let public foldi folder state array  =
       array 
       |> Array.fold(fun (i,state) current -> (i + 1, folder i state current)) (0,state)
       |> snd

    let public foldic folder state array =
       array 
       |> Array.fold(fun (i,state) current -> (i + 1, folder i state current)) (0,state)      