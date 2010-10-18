namespace Merthin.Extensions
open System.Drawing
open System.Runtime.CompilerServices

[<Extension>]
[<AutoOpen>]
module SystemDrawingBitmap =

    [<Extension>]
    [<CompiledNameAttribute("MakeGrayScale")>]
    let _MakeGrayScale(source : Bitmap) =
         for x = 0 to source.Width - 1 do
             for y = 0 to source.Height - 1 do
                 source.SetPixel(x,y, source.GetPixel(x,y).GetGrayScale())

    type System.Drawing.Bitmap with
        member this.MakeGrayScale() = _MakeGrayScale(this)
              
                       