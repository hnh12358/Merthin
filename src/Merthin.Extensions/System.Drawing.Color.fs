namespace Merthin.Extensions
open System.Drawing
open System.Runtime.CompilerServices

[<Extension>]
[<AutoOpen>]
module SystemDrawingColor =

    [<Extension>]
    [<CompiledNameAttribute("GetGrayScale")>]
    let _GetGrayScale(source : Color) =
        let mean = int((source.R + source.B + source.G) / 3uy)
        Color.FromArgb(int(source.A),mean,mean,mean)

    type System.Drawing.Color with
        member this.GetGrayScale() = _GetGrayScale(this)