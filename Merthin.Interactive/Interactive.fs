namespace Merthin
open System
open System.Globalization
open System.Runtime.CompilerServices
open System.Reflection
open System.IO;

open Merthin.FSharp
open Merthin.Extensions
open Merthin.Math.Algebra.Matrix

module Interactive =

    let (@|) (a: FMatrix) (b : FMatrix) = 
        a.ConcatVertical(b)

    let (@-) (a: FMatrix) (b : FMatrix) = 
        a.ConcatHorizontal(b)
    
    let ToConsoleStringOptions (m : FMatrix,rowCount,columnCount,format : IFormatProvider,prefix,padChar : Char) =
        let adaptData data maxValid = match data with
                                      | Some(value) when value <= maxValid -> value 
                                      | _ -> maxValid
        
        let maxRowCount, maxColumnCount = adaptData rowCount m.RowCount, 
                                          adaptData columnCount m.ColumnCount

        let columnEnd = if maxColumnCount < m.ColumnCount then " .\n" else "\n"
        let startCell, lastCell = (fun next -> (fun pad -> next(pad))), (fun pad -> String.Empty)
        let stringFold i (command,large) (current : float) = 
            let newCommand = 
                if (i + 1) % Math.Min(m.ColumnCount,maxColumnCount) = 1  then
                   (fun next -> (fun pad -> current.ToString(format).PadLeft(pad,padChar) + next(pad)))
                elif (i + 1) % Math.Min(m.ColumnCount,maxColumnCount) = 0 then
                   (fun next -> (fun pad -> " " + current.ToString(format).PadLeft(pad,padChar) + columnEnd + next(pad)))
                else 
                   (fun next -> (fun pad -> " " + current.ToString(format).PadLeft(pad,padChar) + next(pad)))
            (fun next -> command(newCommand(next))), Math.Max(current.ToString(format).Length,large)

        let items = m.[.. maxRowCount,.. maxColumnCount].Items        
        let continuation, length =  Seq.foldi stringFold (startCell,0) items
        
        match maxRowCount,m.RowCount with
        | _ when (maxRowCount < m.RowCount) && maxColumnCount < m.ColumnCount ->
            prefix + (continuation lastCell (length)) + ".".PadLeft(length) + String.replicate (maxColumnCount - 1) (".".PadLeft(length + 1,' ')) + " ."
        | _ when maxRowCount < m.RowCount -> 
            prefix + (continuation lastCell (length)) + ".".PadLeft(length) + String.replicate (maxColumnCount - 1) (".".PadLeft(length + 1,' '))
        | _ -> 
            prefix + String.removeFromEnd (continuation lastCell (length)) 0
        
    let ToConsoleStringNullables (m : FMatrix,rowCount,columnCount,format,prefix, padChar) =
        ToConsoleStringOptions(m,NullableToOption(rowCount),NullableToOption(columnCount),format,prefix,padChar)

    let credits() =
        "\nMerthin Interactive is a customization of the F# Interactive tool that load modules, data types and operators from " +
        "the Merthin project allowing the experimentation over the F# repl console.\n" +
        "\nThe Merthin project is written and maintained by:\n" +
        "Horacio Nunez (hnh12358@gmail.com)\n" +
        "\nYour feedback is welcome!\n"
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


        let aggrupedFuncs = [|Path.Combine(Environment.CurrentDirectory,@"Merthin.Math.Algebra.Matrix.dll");
                              @"..\..\Merthin.Math.Algebra.Matrix\bin\Debug\Merthin.Math.Algebra.Matrix.dll"|]
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