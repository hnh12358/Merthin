namespace Merthin.Math.Algebra.Matrix
open System
open Microsoft.FSharp.Collections
open Merthin.FSharp

type FMatrix(rows,columns,gen) =  
    
    do requires (rows >= 0 && columns >= 0)  MATRIX_CREATION_BADDIMENSIONS    

    new (rows, columns, gen :  Func<Int32,Int32,Double>) =
        requires (gen <> null) MATRIX_CREATION_NULLDELEGATE
        let newGen = (fun (i,j) -> gen.Invoke(i,j))
        new FMatrix(rows, columns, newGen)

    member public this.RowCount 
           with get() = rows

    member public this.ColumnCount
           with get() = columns

    member public this.Dimension
           with get() = (rows,columns)

    member public this.Count
           with get() = rows * columns

    member public this.MainDiagonalCount
           with get() = Math.Min(rows,columns)
           
    member public this.IsSquare
           with get() = rows = columns

    member public this.IsEmpty
           with get() = rows = 0 || columns = 0

    member public this.IsRowVector
           with get() = rows = 1
    
    member public this.IsColumnVector
           with get() = columns = 1

    member public this.IsTall
           with get() = columns = 0 && rows > 0

    member public this.IsFat
           with get() = rows = 0 && columns > 0

    member public this.MainDiagonal
           with get() = 
                seq { for i = 1 to Math.Min(rows,columns) do
                          yield this.[i,i] }

    member public this.Items
           with get() = 
                seq { for i = 1 to rows do
                          for j = 1 to columns do
                              yield this.[i,j] }

    member public this.ItemsIndexed
           with get() = 
                seq { for i = 1 to rows do
                          for j = 1 to columns do
                              yield (i,j,this.[i,j]) }
    
    member public this.Columns
           with get() =
                seq { for j = 1 to columns do
                          yield seq { for i = 1 to rows do
                                          yield this.[i,j] }}

    member public this.Rows
           with get() =
                seq { for i = 1 to rows do
                      yield seq { for j = 1 to columns do
                                      yield this.[i,j] }}

    member public this.GetItemsBy(c) =
           c |> Seq.map(fun (i,j) -> this.[i,j])

    member public this.GetItemsIndexedBy(c) =
           c |> Seq.map(fun (i,j) -> (i,j,this.[i,j]))
               
    member public this.GetDiagonalNumber(i,j) =
           requires (this.AreValidIndexes(i,j)) MATRIX_INDEXER_BADINDEXES
           i + j - 1

    member public this.AreValidIndexes (i,j) =
           (i >= 1 && i <= rows && j >= 1 && j <= columns)

    member public this.Item
           with get (i,j) = 
                requires (this.AreValidIndexes(i,j)) MATRIX_INDEXER_BADINDEXES
                gen(i,j) 

    member public this.GetSlice
           with get (rowStart,rowEnd,columnStart,columnEnd) =
                let areValidSlices (r1,r2,c1,c2) =
                    r1 >= 0 && c1 >= 0 && r2 - r1 >= 0 && c2 - c1 >= 0 && r2 <= rows && c2 <= columns
                let adaptSlice first second count =
                    match first, second with
                    | Some(p1), Some(p2) -> (p1, p2)
                    | Some(p1), None -> (p1, count)
                    | None, Some(p2) -> (1, p2)
                    | None, None -> (1, count)

                let (r1,r2), (c1,c2) = (adaptSlice rowStart rowEnd rows),
                                       (adaptSlice  columnStart columnEnd columns)
                requires (areValidSlices (r1,r2,c1,c2)) MATRIX_SUBMATRIX_INVALIDBOUNDS
                let newGen = fun (i,j) -> this.[r1 + i - 1, c1 + j - 1]              
                new FMatrix(r2 - r1 + 1,c2 - c1 + 1,newGen)
             
    member public this.GetSlice
           with get (rowStart,rowEnd,columnStart,columnEnd,allowEmpty) =
                let areValidSlices (r1,r2,c1,c2) =
                    r1 >= 0 && c1 >= 0 && r2 - r1 >= 0 && c2 - c1 >= 0 && r2 <= rows && c2 <= columns
             
                let adaptSlice first second count =
                    match first, second with
                    | Some(p1), Some(p2) -> (p1, p2,p2 - p1 + 1)
                    | Some(p1), None -> (p1, count, count - p1 + 1)
                    | None, Some(p2) -> (1, p2, p2)
                    | None, None -> (1, count,count)

                let (r1,r2,deltar), (c1,c2,deltac) = (adaptSlice rowStart rowEnd rows),
                                                     (adaptSlice  columnStart columnEnd columns)
                if areValidSlices (r1,r2,c1,c2) then
                   let newGen = fun (i,j) -> this.[r1 + i - 1, c1 + j - 1]              
                   new FMatrix(deltar,deltac,newGen)
                elif allowEmpty then
                   let newGen = fun (i,j) -> failwith MATRIX_EMPTY
                   new FMatrix(0,0,newGen)
                else 
                   failwith MATRIX_SUBMATRIX_INVALIDBOUNDS

    member public this.ChangeItem(w,z,value) = 
           requires (this.AreValidIndexes(w,z)) MATRIX_INDEXER_BADINDEXES
           let newGen = fun (i,j) -> if (i,j) = (w,z) then value else this.[i,j]
           new FMatrix(rows, columns, newGen)

    member public this.ChangeItem(changeElementPairs) =      
           changeElementPairs
           |> Seq.fold (fun (previous : FMatrix) (w,z,v) -> previous.ChangeItem(w,z,v)) this

    member public this.PermuteRows(r1,r2) =
           requires (r1 >= 0 && r1 <= rows && r2 >= 0 && r2 <= rows) MATRIX_PERMUTEROWS_BADINDEXES
           let newGen = fun (i,j) -> if i = r1 then this.[r2,j]
                                     elif i = r2 then this.[r1,j]
                                     else this.[i,j]
           new FMatrix(rows,columns,newGen)

    member public this.PermuteRows(permuteRowsPairs) =
           permuteRowsPairs
           |> Seq.fold (fun (p : FMatrix) (r1,r2) -> p.PermuteRows(r1,r2)) this

    member public this.PermuteColumns(c1, c2) =
           requires (c1 >= 0 && c1 <= columns && c2 >= 0 && c2 <= columns) MATRIX_PERMUTECOLUMNS_BADINDEXES
           let newGen = fun (i,j) -> if j = c1 then this.[i,c2]
                                     elif j = c2 then this.[i,c1]
                                     else this.[i,j]
           new FMatrix(rows,columns, newGen)

    member public this.PermuteColumns(permuteColumnsPairs) =
           permuteColumnsPairs
           |> Seq.fold (fun (p : FMatrix) (c1,c2) -> p.PermuteColumns(c1,c2)) this

    member public this.Transpose() =
           let newGen = fun (i,j) -> this.[j,i]
           new FMatrix(columns,rows,newGen)

    member public this.ConcatHorizontal(a : FMatrix) =
           requires (rows = a.RowCount) MATRIX_CONCATHORIZONTAL_MISMATCH
           let newGen = if this.IsEmpty && a.IsEmpty then
                           fun (i,j) -> failwith MATRIX_EMPTY
                        else
                           fun (i,j) -> if j > columns then a.[i,j - columns]
                                        else this.[i,j]
           new FMatrix(rows, columns + a.ColumnCount, newGen)
    
    member public this.ConcatHorizontal(concatHorizontalMatrixs) =
           concatHorizontalMatrixs
           |> Seq.fold (fun (p : FMatrix) (c : FMatrix) -> p.ConcatHorizontal(c))  this

    member public this.SelfConcatHorizontal(times) =                    
           requires (times > 0) MATRIX_CONCATSELF_NEGATIVETIME
           Seq.init  times (fun _ -> this)
           |> this.ConcatHorizontal
        
    member public this.ConcatVertical(a : FMatrix) =
           requires (columns = a.ColumnCount) MATRIX_CONCATVERTICAL_MISMATCH
           let newGen = if this.IsEmpty && a.IsEmpty then
                           fun (i,j) -> failwith MATRIX_EMPTY
                        else
                           fun (i,j) -> if i > rows then a.[i - rows,j]
                                        else this.[i,j]
           new FMatrix(rows + a.RowCount,columns,newGen)

    member public this.ConcatVertical(concatVerticalMatrixs) =
           concatVerticalMatrixs
           |> Seq.fold (fun (p : FMatrix) (c : FMatrix) -> p.ConcatVertical(c))  this

    member public this.SelfConcatVertical(times) = 
           requires (times > 0) MATRIX_CONCATSELF_NEGATIVETIME
           Seq.init  times (fun _ -> this)
           |> this.ConcatVertical

    static member public (+) (a : FMatrix,b : FMatrix) =
           requires (a.Dimension = b.Dimension) MATRIX_SUM_MISMATCH
           if a.IsEmpty then
              a
           else
              let newGen = fun (i,j) -> a.[i,j] + b.[i,j]
              new FMatrix(a.RowCount,a.ColumnCount, newGen)

    static member public (-) (a : FMatrix,b : FMatrix) =
           requires (a.Dimension = b.Dimension) MATRIX_SUM_MISMATCH
           if a.IsEmpty then
              a
           else
              let newGen = fun (i,j) -> a.[i,j] - b.[i,j]
              new FMatrix(a.RowCount,a.ColumnCount, newGen)

    static member public ( * ) (a : FMatrix,b : FMatrix) =
           requires (a.ColumnCount = b.RowCount) MATRIX_MULTIPLICATION_MISMATCH
           let newGen = if (a.IsEmpty && b.IsEmpty) then
                           fun (i,j) -> 0.0
                        elif (a.IsEmpty || b.IsEmpty) then
                           fun (i,j) -> failwith MATRIX_EMPTY
                        else
                           fun (i,j) -> seq {1 .. b.RowCount} 
                                         |> Seq.fold (fun accu c -> accu + a.[i,c] * b.[j,c]) 0.0
           new FMatrix(a.RowCount,b.ColumnCount,newGen)

    static member public ( * ) (scalar,a : FMatrix) =
           if a.IsEmpty then
              a
           else
              let newGen = fun (i,j) -> a.[i,j] * scalar
              new FMatrix(a.RowCount,a.ColumnCount, newGen)

    static member public ( * ) (a : FMatrix,scalar : Double) = 
           scalar * a

    static member public ( * ) (scalar,a : FMatrix) = 
           float(scalar) * a    

    static member public ( * ) (a : FMatrix,scalar) = 
           float(scalar) * a

    static member public (/) (a : FMatrix, scalar) =
           requires (scalar <> 0.0) MATRIX_DIVISION_ZERO
           let newGen = fun (i,j) -> a.[i,j] / scalar
           new FMatrix(a.RowCount,a.ColumnCount, newGen)

    static member public (/) (a : FMatrix, scalar) = 
           a / float(scalar)

    override this.Equals (a) =
        match a with
        | :? FMatrix as fa when fa.Dimension = this.Dimension ->
                if fa.IsEmpty then
                   true
                else    
                   seq { for i = 1 to rows do
                            for j = 1 to columns do
                                yield fa.[i,j] = this.[i,j] }
                   |> PSeq.forall((=) true)
        | _ -> false


    override this.GetHashCode() =
             this.Items
             |> PSeq.fold (fun a b -> let c = b.GetHashCode() in ((a <<< 5) + a) ^^^ c) 
                          (rows.GetHashCode() &&& columns.GetHashCode())
        
    member public this.GetFastHashCode() =
           let a = rows.GetHashCode() &&& columns.GetHashCode() 
           ((a <<< 5) + a) ^^^ ((gen :> obj).GetHashCode())
