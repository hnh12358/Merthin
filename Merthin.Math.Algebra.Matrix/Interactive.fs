(*
 * Merthin Project         - (http://merthin.codeplex.com)
 * Horacio Núñez Hernández - (hnh12358 at gmail.com)
 * 23/06/2010
 *)

namespace Merthin.Math.Algebra.Matrix
open Merthin.FSharp
open System

module Interactive =

    let (@|) (a: FMatrix) (b : FMatrix) = 
        a.ConcatVertical(b)

    let (@-) (a: FMatrix) (b : FMatrix) = 
        a.ConcatHorizontal(b)

    let (~~) (a : FMatrix) = a.Transpose()
    
    let ToConsoleStringF (m : FMatrix) maxRowDisplay maxColumnDisplay (format : string) (provider : IFormatProvider) =
        let columnEnd = if maxColumnDisplay < m.ColumnCount then 
                           " ...\n" 
                        else 
                           "\n"

        let start, last = (fun next -> (fun pad -> next(pad))), (fun pad -> String.Empty)

        let fold i (command,large) (current : float) = 
            let newCommand = if (i + 1) % Math.Min(m.ColumnCount,maxColumnDisplay) = 0 then 
                                (fun next -> 
                                    (fun pad -> current.ToString(format,provider).PadLeft(pad) + columnEnd + next(pad)))
                             else 
                                (fun next -> 
                                    (fun pad -> current.ToString(format,provider).PadLeft(pad) + next(pad)))
            (fun next -> command(newCommand(next))), Math.Max(current.ToString(provider).Length,large)

        let continuation, length =  Seq.foldi fold (start,0) m.[.. Math.Min(m.RowCount,maxRowDisplay),.. Math.Min(m.ColumnCount,maxColumnDisplay)].Items        
        let result = "\n" + (continuation last (length + 1))
        let result2 = result.Remove(result.Length - 1)
        if maxRowDisplay < m.RowCount then 
            result2 + (String.replicate 3 ((String.replicate maxColumnDisplay (".".ToString().PadLeft(length))) + "\n"))
        else 
            result2
        
    let ToConsoleString (m : FMatrix) rowCount columnCount =
        ToConsoleStringF m rowCount columnCount String.Empty null