namespace Merthin.Math

open System
open System.Linq.Expressions
open Merthin.FSharp
open Merthin.FSharp.Operators
open Merthin.Math.DoubleExpressionTrees

type Interpolation() =  
    class

        static let rec GetDifferences lst =
                match lst with
                | h::t -> h :: GetDifferences (List.MapEx (-~) lst)
                | _ -> []

        static let ExtractCommonDifference lst =
                match (List.MapEx (-~) lst)  with
                | [] -> None
                | d::differences -> if List.filter ((=) d) differences = differences then Some(d) else None

        static member NewtonInterpolation points  =
            let axis, images = points |> Array.toList |> List.unzip
            let h = axis |> ExtractCommonDifference 
                         |> GetValueOrFailwith "There isn't a common difference in the axis." 
                         |> Constant_double

            let CreateMember i difference =
                let rec product n = 
                         match n with
                         | -1 -> Unit
                         | n -> (product (n - 1)) @* (PX @- Constant_double (fst points.[n]))
                let numerator = (Constant_double difference) @* (product i)
                let denominator = (Constant_double (Factorial i)  @* (h @^  (Constant_double i)))
                numerator @/ denominator

            images |> GetDifferences 
                   |> List.mapi CreateMember 
                   |> List.fold (@+) Zero 
                   |> CreateLambda [|PX|]
    end

