namespace Merthin.Math.Algebra.Matrix
open System
open System.Globalization
open System.Runtime.CompilerServices
open Merthin.FSharp

module Interactive =

    let (@|) (a: FMatrix) (b : FMatrix) = 
        a.ConcatVertical(b)

    let (@-) (a: FMatrix) (b : FMatrix) = 
        a.ConcatHorizontal(b)
    
    let ToConsoleStringOptions (m : FMatrix,rowCount,columnCount,format : IFormatProvider,prefix,padChar : Char) =
        let adaptData data maxValid = match data with
                                      | Some(value) when value <= maxValid -> value 
                                      | _ -> maxValid
        
        let maxRowCount, maxColumnCount = adaptData rowCount m.RowCount, 
                                          adaptData columnCount m.ColumnCount

        let columnEnd = if maxColumnCount < m.ColumnCount then " .\n" else "\n"
        let startCell, lastCell = (fun next -> (fun pad -> next(pad))), (fun pad -> String.Empty)
        let stringFold i (command,large) (current : float) = 
            let newCommand = 
                if (i + 1) % Math.Min(m.ColumnCount,maxColumnCount) = 1  then
                   (fun next -> (fun pad -> current.ToString(format).PadLeft(pad,padChar) + next(pad)))
                elif (i + 1) % Math.Min(m.ColumnCount,maxColumnCount) = 0 then
                   (fun next -> (fun pad -> " " + current.ToString(format).PadLeft(pad,padChar) + columnEnd + next(pad)))
                else 
                   (fun next -> (fun pad -> " " + current.ToString(format).PadLeft(pad,padChar) + next(pad)))
            (fun next -> command(newCommand(next))), Math.Max(current.ToString(format).Length,large)

        let items = m.[.. maxRowCount,.. maxColumnCount].Items        
        let continuation, length =  Seq.foldi stringFold (startCell,0) items
        
        match maxRowCount,m.RowCount with
        | _ when (maxRowCount < m.RowCount) && maxColumnCount < m.ColumnCount ->
            prefix + (continuation lastCell (length)) + ".".PadLeft(length) + String.replicate (maxColumnCount - 1) (".".PadLeft(length + 1,' ')) + " ."
        | _ when maxRowCount < m.RowCount -> 
            prefix + (continuation lastCell (length)) + ".".PadLeft(length) + String.replicate (maxColumnCount - 1) (".".PadLeft(length + 1,' '))
        | _ -> 
            prefix + String.removeFromEnd (continuation lastCell (length)) 0
        
    let ToConsoleStringNullables (m : FMatrix,rowCount,columnCount,format,prefix, padChar) =
        ToConsoleStringOptions(m,NullableToOption(rowCount),NullableToOption(columnCount),format,prefix,padChar)