namespace Merthin.Extensions
open System
open System.Reflection
open System.Runtime.CompilerServices

[<Extension>]
[<AutoOpen>]
module SystemType =
//
//    [<Extension>]
//    let GetAllSubTypes(source : Type) =
//        source
//
//    type System.Type with
//        member this.GetAllSubTypes() = SystemType.GetAllSubTypes(this) 