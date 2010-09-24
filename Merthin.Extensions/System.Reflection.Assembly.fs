namespace Merthin.Extensions
open System
open System.Reflection
open System.Runtime.CompilerServices

[<Extension>]
[<AutoOpen>]
module SystemReflectionAssembly =

    [<Extension>]
    let GetAllTypes(source : Type) =
        source

    type System.Type with
        member this.GetAllTypes() = GetAllSubTypes(this) 