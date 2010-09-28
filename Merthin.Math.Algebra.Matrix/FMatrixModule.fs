namespace Merthin.Math.Algebra.Matrix
open System
open System.IO
open Microsoft.FSharp.Collections
open Merthin.FSharp

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module FMatrix =

    let areValidIndexes (i,j) (m : FMatrix) =
        (i >= 1 && i <= m.RowCount && j >= 1 && j <= m.ColumnCount)

    let areValidSubMatrixBounds (r1,r2,c1,c2) (m : FMatrix)=
        r1 >= 0 && c1 >= 0 && r2 - r1 >= 0 && c2 - c1 >= 0 && r2 <= m.RowCount && c2 <= m.ColumnCount

    let getDiagonalNumber (rows,columns,i,j) (m : FMatrix) =
        requires (areValidIndexes (i,j) m) MATRIX_INDEXER_BADINDEXES
        i + j - 1

    let trace (a : FMatrix) = a.MainDiagonal |> PSeq.reduce (+)

    let empty m n = 
        requires (m = 0 || n = 0) MATRIX_EMPTYCREATION_BADDIMENSIONS
        new FMatrix(m,n, fun (i,j) -> failwith MATRIX_EMPTY )

    let identity m =
        requires (m >= 0) MATRIX_IDENTITYCREATION_BADDIMENSIONS
        if m = 0 then
           empty 0 0
        else
            new FMatrix(m,m, fun (i,j) -> if i = j then 1.0 else 0.0)

    let diagonal m v =
        requires (m > 0) MATRIX_CUSTOMCREATION_BADDIMENSIONS
        new FMatrix(m,m, fun (i,j) -> if i = j then v else 0.0)

    let zero m n =
        requires (m > 0 && n > 0) MATRIX_CUSTOMCREATION_BADDIMENSIONS
        new FMatrix(m,n, fun (i,j) -> 0.0)

    let scalar m n value =
        requires (m > 0 && n > 0) MATRIX_CUSTOMCREATION_BADDIMENSIONS
        new FMatrix(m,n, fun (i,j) -> value)

    let hilbert m n =
        requires (m > 0 && n > 0) MATRIX_CUSTOMCREATION_BADDIMENSIONS
        let newGen = (fun (i,j) -> 1.0 / (float(i) + float(j) - 1.0))
        new FMatrix(m,n,newGen)

    let upperTriangular m n v =
        requires (m > 0 && n > 0) MATRIX_CUSTOMCREATION_BADDIMENSIONS
        let newGen = (fun (i,j) -> if float(i) > float(j) then 0.0 else v)
        new FMatrix(m,n,newGen)

    let lowerTriangular m n v =
        requires (m > 0 && n > 0) MATRIX_CUSTOMCREATION_BADDIMENSIONS
        let newGen = (fun (i,j) -> if float(i) < float(j) then 0.0 else v)
        new FMatrix(m,n,newGen)

    let sign (i,j,v) = if i + j % 2 = 0 then v else v * -1

//    let hankel rows columns elements =
//        let passGen1 a = (fun d -> a(d)) 
//        let endDiagonalsGen = (fun d -> failwith "end-of-diagonals")
//        let buildDiagonal diagonals =
//            let fold index pgen dv =
//                let cgen = (fun elseGen -> 
//                           (fun d -> if d = index + 1 then dv else elseGen(d)))
//                (fun f -> pgen(cgen(f)))
//            let dc,dgen = diagonals |> Seq.foldic fold passGen1
//            (dc,dgen(endDiagonalsGen))
//        let dc,dgen = buildDiagonal elements
//        requires (dc = rows + columns - 1) MATRIX_HANKELFORM_DIAGONALSMISMATCH
//        let gen (i,j) = dgen(getDiagonalNumber(rows,columns,i,j))
//        new FMatrix(rows,columns,gen)
    
    let hankelOfN rows columns  =    
        let gen = (fun (i,j) ->  float(i + j - 1))
        new FMatrix(rows,columns,gen)

    let hankelOfNWithOffset offset rows columns =    
        let gen = (fun (i,j) ->  float(i + j - 1 + offset))
        new FMatrix(rows,columns,gen)

    let subMatrix (rowStart,rowEnd,columnStart,columnEnd) (m : FMatrix) =
        m.get_GetSlice(NullableToOption(rowStart),NullableToOption(rowEnd), 
                       NullableToOption(columnStart), NullableToOption(columnEnd),false)

    let subMatrixOrEmpty (rowStart,rowEnd,columnStart,columnEnd) (m : FMatrix) =
        m.get_GetSlice(NullableToOption(rowStart),NullableToOption(rowEnd), 
                       NullableToOption(columnStart), NullableToOption(columnEnd),true)

    let private createGen sparseValue rows =
        
        let isSparsed = Option.isSome(sparseValue)
        let sparsev = if isSparsed then 
                         Option.get(sparseValue) 
                      else 
                         Double.NaN

        let firstRowGen nextGen = (fun j -> nextGen(j)) 
        let lastRowGen = if isSparsed then 
                            (fun _ -> sparsev)
                         else 
                            (fun _ -> failwith "end-of-row")

        let firstMatrixGen nextGen = (fun (i,j) -> nextGen(i,j))
        let lastMatrixGen = (fun (_,_) -> failwith "end-of-matrix")
        
        let rowFold index previousGen value =
            if isSparsed && value = sparsev then
                previousGen
            else
                let currentGen elseGen = 
                    fun j -> if j = index + 1 then 
                                value 
                             else 
                               elseGen(j)
                (fun nextGen -> nextGen |> currentGen |> previousGen)
                
        let buildRowGen sequence =
            let count, currentRowGen = PSeq.foldic rowFold firstRowGen sequence
            let finalGen = lastRowGen |> currentRowGen
            count, finalGen
        
        let matrixFold index (previousColumnCountOption,previousGen) row =
            let currentColumnCount, currentRowGen = buildRowGen row
            let currentGen elseGen = 
                fun (i,j) -> if i = index + 1 then 
                                currentRowGen(j) 
                             else 
                                elseGen(i,j)
        
            match previousColumnCountOption with
            | None -> Some(currentColumnCount), (fun nextGen -> nextGen |> currentGen |> previousGen)

            | Some (previousColumnCount) when previousColumnCount = currentColumnCount -> 
                    Some(currentColumnCount), (fun nextRowGen -> nextRowGen |> currentGen |> previousGen)

            | _ -> failwith MATRIX_GENCREATION_COLUMNCOUNTMISMATCH

        
        let buildMatrixGen rows = 
            let rowCount, (columnCountOption,currentMatrixGen) = PSeq.foldic matrixFold (None,firstMatrixGen) rows
            let finalMatrixGen = lastMatrixGen |> currentMatrixGen
            rowCount,Option.get(columnCountOption),finalMatrixGen

        let rowCount,columnCount,matrixGen = buildMatrixGen rows
        new FMatrix(rowCount,columnCount,matrixGen)


    let fromSeq source = 
        createGen None source

    let fromSeqSparse (sparseValue,source) = 
        createGen (Some(sparseValue)) source 

    let fromList (source) = 
        source 
        |> List.map(List.toSeq) 
        |> List.toSeq 
        |> createGen None

    let fromListSparse (sparseValue, source) = 
        source 
        |> List.map(List.toSeq) 
        |> List.toSeq 
        |> createGen (Some(sparseValue))
    
    let private seqFromString source =
        let split (text : string) (chrs : char array) f = 
            text.Split(chrs, StringSplitOptions.RemoveEmptyEntries)
            |> Array.toSeq |> Seq.map f
        split source [|'\n';'\r'|] (fun x -> split x [|' '|] (fun y -> float(y)))

    let fromString (source) = 
        source 
        |> seqFromString 
        |> createGen None
        
    let fromStringSparse (sparseValue, source) = 
        source 
        |> seqFromString
        |> createGen (Some(sparseValue))

    let save (filename : string,matrix : FMatrix) =
        let writer = File.CreateText(filename)
        for row in matrix.Rows do
            for element in row do
                writer.Write("{0} ", element)
            writer.WriteLine()
        writer.Close()

    let load (filename : string) =
        let reader = File.OpenText(filename)
        fromString (reader.ReadToEnd()) 

    let map map (matrix : FMatrix) =
        let newGen = (fun (i,j) -> map(matrix.[i,j]))
        new FMatrix(matrix.RowCount,matrix.ColumnCount,newGen)

    let mapi mapi (matrix : FMatrix) =
        let newGen = (fun (i,j) -> mapi(i,j,matrix.[i,j]))
        new FMatrix(matrix.RowCount,matrix.ColumnCount,newGen)

    let proj proj (rsize,csize) (matrix : FMatrix) =
        requires (matrix.RowCount % rsize = 0 && matrix.ColumnCount % csize = 0) MATRIX_MAPSLICE_BADDIMENSION 
        let newGen = 
            match rsize,csize with
            | 1,1 ->  fun (i,j) -> proj matrix.[ (i * rsize) .. (i * rsize) , (j * csize) .. (j * csize)]
            | 1,x ->  fun (i,j) -> proj matrix.[ (i * rsize) .. (i * rsize) , ((j - 1) * csize) + 1 .. (j * csize)]
            | x,1 ->  fun (i,j) -> proj matrix.[ ((i - 1) * rsize) + 1 .. (i * rsize) , (j * csize) .. (j * csize)]
            | x,y ->  fun (i,j) -> proj matrix.[ ((i - 1) * rsize) + 1 .. (i * rsize) , ((j - 1) * csize) + 1 .. (j * csize)]
        new FMatrix(matrix.RowCount / rsize,matrix.ColumnCount / csize,newGen)

    let proji proji (rsize,csize) (matrix : FMatrix) =
        requires (matrix.RowCount % rsize = 0 && matrix.ColumnCount % csize = 0) MATRIX_MAPSLICE_BADDIMENSION 
        let newGen = 
            match rsize,csize with
            | 1,1 ->  fun (i,j) -> proji (i,j) matrix.[ (i * rsize) .. (i * rsize) , (j * csize) .. (j * csize)]
            | 1,x ->  fun (i,j) -> proji (i,j) matrix.[ (i * rsize) .. (i * rsize) , ((j - 1) * csize) + 1 .. (j * csize)]
            | x,1 ->  fun (i,j) -> proji (i,j) matrix.[ ((i - 1) * rsize) + 1 .. (i * rsize) , (j * csize) .. (j * csize)]
            | x,y ->  fun (i,j) -> proji (i,j) matrix.[ ((i - 1) * rsize) + 1 .. (i * rsize) , ((j - 1) * csize) + 1 .. (j * csize)]
        new FMatrix(matrix.RowCount / rsize,matrix.ColumnCount / csize,newGen)       

    let sum (a : FMatrix) =
        if a.IsColumnVector || a.IsRowVector then 
            new FMatrix(1,1,(fun _ -> a.Items |> PSeq.reduce (+)))
        else 
            let spro = (fun (i, j : int) (m : FMatrix) -> m.Items |> PSeq.reduce (+))
            proji spro (a.RowCount,1) a  

    let wavelet (order,m : FMatrix) =
        requires (m.IsRowVector) "Just row vectors."
        requires (Math.Log(float(m.ColumnCount),2.0) >= float(order)) "The order isn't valid."
        let waveProjection f m = proj (fun sm -> (f (sm.[1,1]) (sm.[1,2])) / 2.0)  (1,2) m
        let rec wave order approx (detail : FMatrix) = 
            match order with
            | x when x <= 0 -> approx,detail
            | _ -> wave (order - 1) (waveProjection (+) approx) ((waveProjection (-) approx).ConcatHorizontal(detail))
        let approx, detail = wave order m (empty 1 0)
        approx, detail

    let minor (i,j) (m : FMatrix) =
        requires (m.AreValidIndexes(i,j)) MATRIX_MINOREXTRACTION_BADINDEXES
        let getPaddedSlice (rowStart,rowEnd,columnStart,columnEnd) =
            let delta (a1,a2) count = 
                match a1,a2 with
                | Some(b1),Some(b2) -> b2 - b1 + 1
                | Some(b1),None -> count - b1 + 1
                | None, Some(b2) -> b2
                | None,None -> count                               
            let slice = m.GetSlice(rowStart,rowEnd,columnStart,columnEnd,true)
            if slice.IsEmpty then
               let rowCount = delta (rowStart,rowEnd) m.RowCount
               let columnCount = delta (columnStart,columnEnd) m.ColumnCount
               empty rowCount columnCount
            else
               slice
               
        let b1 = getPaddedSlice(None,Some(i-1),None,Some(j - 1))
        let b2 = getPaddedSlice(None,Some(i-1),Some(j + 1),None)
        let b3 = getPaddedSlice(Some(i+1),None,None,Some(j - 1))
        let b4 = getPaddedSlice(Some(i+1),None,Some(j + 1),None)
        b1.ConcatHorizontal(b2).ConcatVertical(b3.ConcatHorizontal(b4))

    let rec StrassenProduct (A : FMatrix) (B: FMatrix) =
        let (@*) a b = StrassenProduct a b
        requires (A.IsSquare && A.Dimension = B.Dimension && A.RowCount % 2 = 0)
                 FMATRIX_STRASSENPRODUCT_NOTSQUARE
        if (A.RowCount <= 20) then
            A * B
        else
            let size = A.RowCount
            let a, b = A.[ .. size / 2, .. size / 2], A.[.. size / 2, size / 2 + 1 ..]
            let c, d = A.[ size / 2 + 1 .. , .. size / 2 ], A.[ size / 2 + 1 .., size / 2 + 1 ..]
            let e, f = B.[ .. size / 2, .. size / 2], B.[.. size / 2, size / 2 + 1 ..]
            let g, h = B.[ size / 2 + 1 .. , .. size / 2 ], B.[ size / 2 + 1 .., size / 2 + 1 ..]

            let AF, AH, AE = (a @* f),(a @* h),(a @* e)
            let BG, BH = (b @* g), (b @* h) 
            let CE, CF = (c @* e),(c @* f)
            let DE, DG, DH = (d @* e), (d @* g), (d @* h)

            let P1, P2, P3, P4 = AF - AH, AH + BH, CE + DE, DG - DE
            let P5, P6 = AE + AH + DE + DH, BG + BH - DG - DH
            let P7 = AE + AF - CE - CF

            let r = P5 + P4 - P2 + P6
            let s = P1 + P2
            let t = P3 + P4
            let u = P5 + P1 - P3 - P7

            (r.ConcatHorizontal(s)).ConcatVertical(t.ConcatHorizontal(u))
            

    let determinant (m : FMatrix) =
        //TODO: This is the determinant via Minors, it is too much belated and must be replaced
        //with a method using PSeq and n-permutation generator usin PLINQ.
        requires (m.IsSquare) MATRIX_DETERMINANT_NOTSQUARE
        let sign (i,j) = if (((i + j) % 2) = 0) then 1.0 else -1.0
        let rec det n (a : FMatrix) =
            match n with
            | 0 | 1 -> 1.0
            | 2 -> (m.[1,1] * m.[2,2]) - (m.[1,2] * m.[2,1])
            | 3 -> (m.[1,1] * m.[2,2] * m.[3,3]) + (m.[1,2] * m.[2,3] * m.[3,1]) + (m.[1,3] * m.[2,1] * m.[3,2]) -
                   (m.[1,3] * m.[2,2] * m.[3,1]) - (m.[1,1] * m.[2,3] * m.[3,2]) - (m.[1,2] * m.[2,1] * m.[3,3])
            | x -> seq {1 .. x} |> PSeq.map (fun j -> (sign (1,j)) * m.[1,j] * (det (x - 1) (minor (1,j) a)))
                   |> PSeq.sum
        det m.RowCount m                             
