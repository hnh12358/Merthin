namespace Merthin.FSharp
open System
open System.Threading

[<AutoOpen>]
[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Utils =

    let GetValueOrFailwith text value = if value = None then failwith text else value.Value
    let requires condition message = if condition then () else failwith message
    let assertOrNone bool value = if bool then Some(value) else option.None

    let NullableToOption (a : Nullable<'a>) = if a.HasValue then 
                                                 Option.Some(a.Value) 
                                              else 
                                                 Option<'a>.None

    let NetOptionToOption (a : NetOption<'a>) = 
        match a with
        | NetOption.Some(value) -> Option.Some(value)
        | _ -> Option.None

    let print (text : string) = 
        if MerthinApplication.Current.ShowParallelEvidence then
            let cache = Console.ForegroundColor
            Console.ForegroundColor <- enum (Math.Min(16,Thread.CurrentThread.ManagedThreadId))
            Console.Write(text)
            Console.ForegroundColor <- cache
        else
            Console.Write(text)

    let printn text = 
        print text
        Console.WriteLine()




