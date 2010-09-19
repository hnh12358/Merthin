﻿namespace Merthin.Math.Algebra.Matrix

[<AutoOpen>]
module internal StringsResources =
    let MATRIX_MULTIPLICATION_MISMATCH = "The column count of the first must be equal to the row count of the later." 
    let MATRIX_INDEXER_BADINDEXES = "The indexes are not valid."
    let MATRIX_MINOREXTRACTION_BADINDEXES = "The indexes are not valid."
    let MATRIX_PERMUTECOLUMNS_BADINDEXES = "The columns indexes are not valid."
    let MATRIX_PERMUTEROWS_BADINDEXES = "The row indexes are not valid."
    let MATRIX_SUM_MISMATCH = "Must have the same size."
    let MATRIX_CONCATVERTICAL_MISMATCH = "Must have the same number of columns."
    let MATRIX_CONCATHORIZONTAL_MISMATCH = "Must have the same number of rows."
    let MATRIX_SUBMATRIX_INVALIDBOUNDS = "The slices are not valid."
    let MATRIX_CREATION_BADDIMENSIONS = "The row and columns count must be no negative."
    let MATRIX_GENCREATION_COLUMNCOUNTMISMATCH = "Rows must have equal length."
    let MATRIX_DIAGONAL_BADINDEX = "The diagonal index is not valid"
    let MATRIX_CONCATSELF_NEGATIVETIME = "The argument times must be positive."
    let MATRIX_HANKELFORM_DIAGONALSMISMATCH = "The amount of diagonals values must be equal to the matrix diagonals."
    let MATRIX_MAPSLICE_BADDIMENSION = "The given dimensions for submatriz are not valid."
    let MATRIX_DIVISION_ZERO = "The division by zero is not valid."
    let MATRIX_DETERMINANT_NOTSQUARE = "The matrix must be square."
    let MATRIX_CREATION_NULLDELEGATE = "The gen parameter can't be null."
    let MATRIX_EMPTYCREATION_BADDIMENSIONS = "One or both dimensions must be zero."
    let MATRIX_CUSTOMCREATION_BADDIMENSIONS = "The row and columns count must be positive."
    let MATRIX_IDENTITYCREATION_BADDIMENSIONS = "The order must be non negative."
    let MATRIX_EMPTY = "empty-matrix"