namespace Merthin
open System
open System.Globalization
open System.Runtime.CompilerServices
open System.Reflection
open System.IO;

open Merthin.FSharp
open Merthin.Extensions
open Merthin.Math.Algebra.Matrix

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Interactive =
    
    let credits() =
        "\nMerthin Interactive is a customization of the F# Interactive tool that load modules, data types and operators from " +
        "the Merthin project assemblies. Any opinion will be welcome at hnh12358@gmail.com.\n" +
        "Horacio Nunez (hnh12358@gmail.com)\n"
        |> Console.WriteLine

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

        let aggrupedFuncs = [|Path.Combine(Environment.CurrentDirectory, @"bin\Merthin.Math.Algebra.Matrix.dll")|]
                            |> retrieveStaticFunctions
                            |> Seq.groupBy (fun x -> x.DeclaringType)

        Console.WriteLine()
        for (declaringType,funcs) in aggrupedFuncs do
            Console.WriteLine("    [{0}]:",declaringType)
            for func in funcs do
                let funcDesc = String.Format("    {0}",FSharpCodes.methodSignature(func).EllipsisIfNeeded(Console.BufferWidth - 4))
                Console.WriteLine(funcDesc)
            Console.WriteLine()

    let logo() =
        "Merthin Interactive [powered by F# 2.0 Interactive]\n" +
        "Type \"functions()\",\"credits()\" for more information.\n" 
        |> Console.WriteLine
