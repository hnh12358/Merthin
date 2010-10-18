namespace Merthin.Extensions
open System
open System.Reflection
open System.Runtime.CompilerServices

open Merthin.FSharp

[<Extension>]
[<AutoOpen>]
module SystemType =
    
    [<Extension>]
    let CreateInstanceOrDefault(source : Type, parameters : obj[]) =
        requires (source <> null) "Null Argument"
        let ctr = source.GetConstructor(parameters |> Array.map (fun x -> x.GetType()))
        if ctr <> null then
           ctr.Invoke(parameters)
        else
           null

    [<Extension>]
    let HasAttribute<'a when 'a :> Attribute>(source : Type) =
        requires (source <> null) "Null Argument"
        source.GetCustomAttributes(true)
        |> Seq.exists(fun x -> x.GetType() = typeof<'a>)

    type System.Type with
        member this.HasAttribute<'a when 'a :> Attribute>() = HasAttribute<'a>(this) 
        member this.CreateInstanceOrDefault(parameters) = CreateInstanceOrDefault(this,parameters)