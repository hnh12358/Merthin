#r @"..\..\Merthin.Extensions\bin\Debug\Merthin.Extensions.dll"
#r @"..\..\Merthin.Math.Algebra.Matrix\bin\Debug\Merthin.FSharp.dll"
#r @"..\..\Merthin.Math.Algebra.Matrix\bin\Debug\Merthin.Math.Algebra.Matrix.dll"
#r "FSharp.PowerPack.Parallel.Seq.dll"

open System
open System.IO
open System.Reflection
open Microsoft.FSharp.Collections

open Merthin.FSharp
open Merthin.Extensions
open Merthin.Math.Algebra.Matrix
open Merthin.Math.Algebra.Matrix.Interactive
open Merthin.Math.Algebra.Matrix.FMatrix

Console.Title <- "Merthin Interactive"
Console.BackgroundColor <- ConsoleColor.DarkBlue
Console.ForegroundColor <- ConsoleColor.White

let matrixPrinter (m : FMatrix) = 
    Interactive.ToConsoleStringOptions(m,Some(fsi.PrintLength),Some(fsi.PrintWidth),fsi.FormatProvider, "\n",' ')
 
fsi.AddPrinter matrixPrinter

let credits() =
    "\nMerthin Interactive is a customization of the F# Interactive tool that load modules, data types and operators from " +
    "the Merthin project allowing the user to work with these resources F# REPL console.\n" +
    "\nThe Merthin project is written and maintained by:\n" +
    "Horacio Nuñez (hnh12358@gmail.com)\n" +
    "\nYour feedback is welcome!\n"
    |> Console.WriteLine

//TODO: FIX BUGS
//TODO: ADD STRASSEN
let functions() =
    
    let retrieveStaticFunctions assembliesPaths = 
        let FMatrixType = typeof<FMatrix>
        let assemblies = assembliesPaths
                         |> Array.filter (fun x -> File.Exists(x))
                         |> Array.map Assembly.LoadFrom
        seq { 
            for assembly in assemblies do
                for dataType in assembly.GetExportedTypes() do
                    for methodMember in dataType.GetMethods(BindingFlags.Static ||| BindingFlags.Public) do
                        let count = methodMember.GetParameters()
                                    |> Array.filter (fun x -> x.ParameterType = FMatrixType)
                                    |> Array.length
                        if count > 0 then
                           yield methodMember
            }

    let aggrupedFuncs = [| @"..\..\Merthin.Math.Algebra.Matrix\bin\Debug\Merthin.Math.Algebra.Matrix.dll" |]
                        |> retrieveStaticFunctions
                        |> Seq.groupBy (fun x -> x.DeclaringType)

    Console.WriteLine()
    for (declaringType,funcs) in aggrupedFuncs do
        Console.WriteLine("    [{0}]:",declaringType)
        for func in funcs do
            let funcDesc = String.Format("    {0}",FSharpCodes.methodSignature(func).EllipsisIfNeeded(fsi.PrintWidth - 4))
            Console.WriteLine(funcDesc)
        Console.WriteLine()

Console.Clear()

#time "on"
               
"Merthin Interactive [powered by F# 2.0 Interactive]\n" +
"Type \"functions()\",\"credits()\" for more information.\n" 
|> Console.WriteLine
