(* JUST FOR DEVELOPEPMENT *)
#r "FSharp.PowerPack.Parallel.Seq.dll"
#r @"..\..\Merthin.Math.Algebra.Matrix\bin\Debug\Merthin.FSharp.dll"
#r @"..\..\Merthin.Extensions\bin\Debug\Merthin.Extensions.dll"
#r @"..\..\Merthin.Math.Algebra.Matrix\bin\Debug\Merthin.Math.Algebra.Matrix.dll"
#r @"..\..\Merthin.Interactive\bin\Debug\Merthin.Interactive.dll"

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
                    ToConsoleStringOptions(m,Some(fsi.PrintLength),Some(fsi.PrintWidth),fsi.FormatProvider, "\n",' '))

#time "on"

Console.Clear()
               
logo()
