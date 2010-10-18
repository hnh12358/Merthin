namespace Merthin.Extensions
open System
open System.Drawing
open System.Runtime.CompilerServices

[<Extension>]
[<AutoOpen>]
module SystemString =

    [<Extension>]
    [<CompiledNameAttribute("EllipsisIfNeeded")>]
    let _EllipsisIfNeeded(source : String,length) =
        if source.Length > length then
           source.Substring(0,length - 3) + "..."
        else 
            source

    type System.String with
        member this.EllipsisIfNeeded(length) = _EllipsisIfNeeded(this,length)