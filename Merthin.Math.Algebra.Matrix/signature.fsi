

namespace Merthin.Math.Algebra.Matrix
  module internal StringsResources = begin
    val MATRIX_MULTIPLICATION_MISMATCH : string
    val MATRIX_INDEXER_BADINDEXES : string
    val MATRIX_SUM_MISMATCH : string
    val MATRIX_CONCATVERTICAL_MISMATCH : string
    val MATRIX_CONCATHORIZONTAL_MISMATCH : string
    val MATRIX_SUBMATRIX_INVALIDBOUNDS : string
    val MATRIX_CREATION_NONPOSITIVE : string
    val MATRIX_GENCREATION_ROWCOUNTMISMATCH : string
    val MATRIX_DIAGONAL_BADINDEX : string
    val MATRIX_CONCATSELF_NEGATIVETIME : string
    val MATRIX_HANKELFORM_DIAGONALSMISMATCH : string
    val MATRIX_MAPSLICE_BADDIMENSION : string
  end

namespace Merthin.Math.Algebra.Matrix
  type FMatrix =
    class
      new : rows:int * columns:int * gen:(int * int -> float) -> FMatrix
      new : rows:int * columns:int * gen:System.Func<int,int,float> -> FMatrix
      member AreValidIndexes : i:int * j:int -> bool
      member ChangeItem : changeElementPairs:seq<int * int * float> -> FMatrix
      member ChangeItem : w:int * z:int * value:float -> FMatrix
      member ConcatHorizontal : a:FMatrix -> FMatrix
      member ConcatHorizontal : concatHorizontalMatrixs:seq<FMatrix> -> FMatrix
      member ConcatVertical : a:FMatrix -> FMatrix
      member ConcatVertical : concatVerticalMatrixs:seq<FMatrix> -> FMatrix
      override Equals : a:obj -> bool
      member GetDiagonalNumber : i:int * j:int -> int
      override GetHashCode : unit -> int
      member GetItemsBy : c:seq<int * int> -> seq<float>
      member PermuteColumns : permuteColumnsPairs:seq<int * int> -> FMatrix
      member PermuteColumns : c1:int * c2:int -> FMatrix
      member PermuteRows : permuteRowsPairs:seq<int * int> -> FMatrix
      member PermuteRows : r1:int * r2:int -> FMatrix
      member SelfConcatHorizontal : times:int -> FMatrix
      member SelfConcatVertical : times:int -> FMatrix
      member Transpose : unit -> FMatrix
      
      member MainDiagonalCount : int
      member ColumnCount : int
      member RowCount : int
      member Columns : seq<seq<float>>
      member Dimension : int * int
      member Rows : seq<seq<float>>
      member Count : int
      member GetSlice : rowStart:int option * rowEnd:int option * columnStart:int option * columnEnd:int option -> FMatrix with get
      member IsColumnVector : bool
      member IsRowVector : bool
      member IsSquare : bool
      member Item : i:int * j:int -> float with get
      member Items : seq<float>
      member MainDiagonal : seq<float>      
      //Utils
      static member CreateGen : sparseOption:float option -> source:seq<#seq<float>> -> FMatrix
      static member CreateSeqFromList : source:'a list list -> seq<seq<'a>>
      static member CreateSeqFromString : source:string -> seq<seq<float>>
      static member FromEnumerable : source:seq<#seq<float>> -> FMatrix
      static member FromEnumerable : sparseValue:float * source:seq<#seq<float>> -> FMatrix
      static member FromList : source:float list list -> FMatrix
      static member FromList : sparseValue:float * source:float list list -> FMatrix
      static member FromString : source:string -> FMatrix
      static member FromString : sparseValue:float * source:string -> FMatrix
      //Operators
      static member ( + ) : a:FMatrix * b:FMatrix -> FMatrix
      static member ( / ) : scalar:float * matrix:FMatrix -> FMatrix
      static member ( / ) : m:FMatrix * s:double -> FMatrix
      static member ( * ) : a:FMatrix * b:FMatrix -> FMatrix
      static member ( * ) : scalar:float * matrix:FMatrix -> FMatrix
      static member ( * ) : m:FMatrix * s:double -> FMatrix
      static member ( - ) : a:FMatrix * b:FMatrix -> FMatrix
    end

namespace Merthin.Math.Algebra.Matrix
  module FMatrix = begin
    val Identity : int -> FMatrix
    val Diagonal : int * float -> FMatrix
    val Zero : int * int -> FMatrix
    val Hilbert : int * int -> FMatrix
    val AreValidIndexes : int * int * int * int -> bool
    val GetDiagonalNumber : int * int * int * int -> int
    val Hankel : int * int * seq<float> -> FMatrix
    val CreateHankelOfN : int * int -> FMatrix
    val CreateHankelOfNWithOffset : int * int * int -> FMatrix
    val SaveToFile : string * FMatrix -> unit
    val LoadFromFile : string -> FMatrix
    val Map : (float -> float) -> FMatrix -> FMatrix
    val Mapi : (int * int * float -> float) -> FMatrix -> FMatrix
    val proj : (FMatrix -> float) -> int * int -> FMatrix -> FMatrix
    val proji :
      (int * int -> FMatrix -> float) -> int * int -> FMatrix -> FMatrix
    val ToString : FMatrix -> string
  end

namespace Merthin.Math.Algebra.Matrix
  module Operators = begin
    val ( @| ) : FMatrix -> FMatrix -> FMatrix
    val ( @- ) : FMatrix -> FMatrix -> FMatrix
    val ( ~~ ) : FMatrix -> FMatrix
  end

namespace Merthin.Math.Algebra.Matrix
  module CommandLine = begin
    type matrix = FMatrix
    val load : string -> FMatrix
    val save : string * FMatrix -> unit
    val fromlist : float list list -> FMatrix
    val hilbert : int * int -> FMatrix
    val hilberts : int -> FMatrix
    val hankels : int * seq<float> -> FMatrix
    val hankel : int * int * seq<float> -> FMatrix
    val hankeln : int * int -> FMatrix
    val hankelns : int -> FMatrix
    val hankelnso : int * int * int -> FMatrix
    val trace : FMatrix -> float
    val sum : FMatrix -> FMatrix
    val proj : (FMatrix -> float) * (int * int) * FMatrix -> FMatrix
    val proji :
      (int * int -> FMatrix -> float) * (int * int) * FMatrix -> FMatrix
    val test_proj : (int * int) * FMatrix -> bool
    val wavelet : int * FMatrix -> FMatrix * FMatrix
    val test_wavelet : int * FMatrix -> bool
    [<CompiledNameAttribute ("PrintMatrix")>]
    val print : FMatrix -> unit
  end

