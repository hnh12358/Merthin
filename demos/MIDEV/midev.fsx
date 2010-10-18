#r @"bin\FSharp.PowerPack.Parallel.Seq.dll"
#r @"bin\Merthin.FSharp.dll"
#r @"bin\Merthin.Extensions.dll"
#r @"bin\Merthin.Math.Algebra.Matrix.dll"
#r @"bin\Merthin.Interactive.dll"

open System

open Microsoft.FSharp.Collections

open Merthin.FSharp
open Merthin.Extensions
open Merthin.Interactive
open Merthin.Math.Algebra.Matrix
open Merthin.Math.Algebra.Matrix.FMatrix
open Merthin.Math.Algebra.Matrix.Operators

Console.Title <- "Merthin Interactive"
Console.BackgroundColor <- ConsoleColor.DarkBlue
Console.ForegroundColor <- ConsoleColor.White

fsi.AddPrinter (fun (m : FMatrix) -> 
                     m.ToString(NetOption.Some(fsi.PrintLength),NetOption.Some(fsi.PrintWidth),fsi.FormatProvider, "\n",' '))

#time "on"

Console.Clear()
               
logo()
