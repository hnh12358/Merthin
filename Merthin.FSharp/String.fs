(*
 * Merthin Project         - (http://merthin.codeplex.com)
 * Horacio Núñez Hernández - (hnh12358 at gmail.com)
 * 23/06/2010
 *)

namespace Merthin.FSharp
open System

module String =
    let trim (str : string ) = str.Trim()
    let split (separator : string array) (options : StringSplitOptions) (str : string) = str.Split(separator,options)
    let toCharArray (str : string) = str.ToCharArray()
    let toStringArray (str : string) = str.ToCharArray() |> Array.map (string)
    let replace (oldStr : string) (newStr) (str : string) = str.Replace(oldStr,newStr)
    let join (separator : string) (strs : seq<string>) = String.Join(separator,strs)
    let reverse (str : string) = str |> toStringArray |> Array.rev |> join String.Empty
    let isPalindrome (str : string) = seq {0 .. str.Length / 2} |> Seq.forall(fun x -> str.[x] = str.[str.Length - x - 1])
    let add (str : string) str2 = str2 + str