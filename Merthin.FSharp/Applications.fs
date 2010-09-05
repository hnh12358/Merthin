(*
 * Merthin Project         - (http://merthin.codeplex.com)
 * Horacio Núñez Hernández - (hnh12358 at gmail.com)
 * 23/06/2010
 *)

namespace Merthin.FSharp

[<AutoOpen>]
module Applications =
    let rec Factorial n = if n = 0 then 1.0 else System.Convert.ToDouble(n) * Factorial(n - 1)
    let Abs n = if n < 0 then n * -1 else n
    let Mito a b x = 
        let result = (fun () -> (a b) x)
        result