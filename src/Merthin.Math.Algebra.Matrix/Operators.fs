namespace Merthin.Math.Algebra.Matrix

open Merthin.FSharp
open Merthin.Math.Algebra.Matrix

module Operators =

        let (@|) (a: FMatrix) (b : FMatrix) = 
            a.ConcatVertical(b)

        let (@-) (a: FMatrix) (b : FMatrix) = 
            a.ConcatHorizontal(b)

        let (@*) (a: FMatrix) (b : FMatrix) = 
            FMatrix.strassenMultiplication a b