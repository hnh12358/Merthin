open System
open System.IO

if fsi.CommandLineArgs.Length > 0 then
   System.Environment.CurrentDirectory <- Path.GetDirectoryName(fsi.CommandLineArgs.[0])

let mutable out =  "\n"
                  + "* Merthin Project         - (http://merthin.codeplex.com)\n"
                  + "* Horacio Núñez Hernández - (hnh12358 at gmail.com)\n"
                  + "* 23/06/2010\n"
                  + "*)\n"
                  + "namespace Merthin.FSharp.Compatibility\n"
                  + "open System\n"
                  + "open System.Runtime.CompilerServices\n\n"
                  + "[<Extension>]\n"
                  + "module DelegateExtensions =\n\n"

for c in [0..16] do
    
    let functionTupledBaseString = "\t[<Extension>]\n"
                                  + "\t[<CompiledNameAttribute(\"AsFSharpTupledFunction\")>]\n"
                                  + "\tlet {0}FuncToFSharpTupledFunc(func : Func<{1}>) =\n"
                                  + "\t\tlet result = (fun ({2}) -> func.Invoke({2}))\n"
                                  + "\t\tresult\n\n"
    let actionTupledBaseString = "\t[<Extension>]\n"
                               + "\t[<CompiledNameAttribute(\"AsFSharpTupledFunction\")>]\n"
                               + "\tlet {0}ActionToFSharpTupledFunc(action : Action{1}) =\n"
                               + "\t\tlet result = (fun ({2}) -> action.Invoke({2}))\n"
                               + "\t\tresult\n\n"
    let functionBaseString = "\t[<Extension>]\n"
                             + "\t[<CompiledNameAttribute(\"AsFSharpFunction\")>]\n"
                             + "\tlet {0}FuncToFSharpFunc(func : Func<{1}>) =\n"
                             + "\t\tlet result = (fun {2} -> func.Invoke({3}))\n"
                             + "\t\tresult\n\n"
    let actionBaseString = "\t[<Extension>]\n"
                             + "\t[<CompiledNameAttribute(\"AsFSharpFunc\")>]\n"
                             + "\tlet {0}ActionToFSharpFunc(action : Action{1}) =\n"
                             + "\t\tlet result = (fun {2} -> action.Invoke({3}))\n"
                             + "\t\tresult\n\n"
    
    let slots = [1 .. c]

    let prefixName = slots |> List.map (fun x -> "T" + x.ToString())
                           |> List.fold (+) String.Empty
   
    let genericSignature = slots |> List.map (fun x -> "'T" + x.ToString())
                                 |> List.fold(fun c p -> c + p + ",") String.Empty

    let parameters ch = slots |> List.map (fun x -> "p" + x.ToString() + ch)
                              |> List.fold (+) String.Empty

    let parametersTupled = parameters ","
    let parametersCurry = parameters " "

    let parametersTupled = if parametersTupled.Length >= 1 then parametersTupled.Substring(0,parametersTupled.Length - 1) else ""
    let parametersCurry = if parametersCurry.Length >= 1 then parametersCurry.Substring(0,parametersCurry.Length - 1) else ""
    
    let genericSignatureForAction = if genericSignature.Length > 1 then "<" + genericSignature.Substring(0,genericSignature.Length - 1) + ">" else ""

    let functionTupled = System.String.Format(functionTupledBaseString,prefixName,genericSignature + "'R", parametersTupled)
    let functionCurry = System.String.Format(functionBaseString,prefixName,genericSignature + "'R", parametersCurry,parametersTupled)

    let actionTupled = System.String.Format(actionTupledBaseString,prefixName,genericSignatureForAction, parametersTupled)
    let actionCurry = System.String.Format(actionBaseString,prefixName,genericSignatureForAction, parametersCurry,parametersTupled)

    if c = 0 then
        out <- out + functionTupled + actionTupled
    else
        out <- out + functionTupled + functionCurry + actionTupled + actionCurry 

let file = File.CreateText("Compatibility.DelegateExtensions.fs")
file.Write(out.Replace("\t","    "))
file.Close()
Console.WriteLine("Done!")
Console.Read();