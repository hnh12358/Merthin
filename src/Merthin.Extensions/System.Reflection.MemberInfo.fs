namespace Merthin.Extensions
open System
open System.Reflection
open System.Runtime.CompilerServices

open Merthin.FSharp

[<Extension>]
[<AutoOpen>]
module SystemReflectionMemberInfo =
    
    [<Extension>]
    let HasAttribute<'a when 'a :> Attribute>(source : MemberInfo) =
        requires (source <> null) "Null Argument"
        source.GetCustomAttributes(true)
        |> Seq.exists(fun x -> x.GetType() = typeof<'a>)

    type System.Reflection.MemberInfo with
        member this.HasAttribute<'a when 'a :> Attribute>() = HasAttribute<'a>(this) 