using System;
using NUnit.Framework;

namespace Merthin.Math.Algebra.Matrix.Tests
{
    /// <summary>
    ///This is a test class for a FMatrix type and is intended
    ///to contain all FMatrix type Unit Tests.
    ///</summary>
    [TestFixture]
    public class FMatrixTest
    {
        #region GetHashCode Tests

        [Test]
        public void GetHashCode_SameSizesAndValues_Equal()
        {
            var matrix1 = FMatrixModule.fromSeq(new[] { (new[] { 1.0, 2.0 }), (new[] { 1.0, 2.0 }) });
            var matrix2 = matrix1.Transpose().Transpose();
            Assert.AreEqual(matrix2.GetHashCode(), matrix1.GetHashCode());
        }

        [Test]
        public void GetFastHashCode_CompareSameSizesAndValuesWithDifferentePositions_Different()
        {
            var matrix1 = FMatrixModule.fromSeq(new[] { (new[] { 1.0, 2.0 }), (new[] { 1.0, 2.0 }) });
            var matrix2 = matrix1.Transpose();
            Assert.AreNotEqual(matrix2.GetFastHashCode(), matrix1.GetFastHashCode());
        }

        #endregion

        #region GetFastHashCode Tests

        [Test]
        public void GetFastHashCode_SameSizesAndValues_Different()
        {
            var matrix1 = FMatrixModule.fromSeq(new[] { (new[] { 1.0, 2.0 }), (new[] { 1.0, 2.0 }) });
            var matrix2 = matrix1.Transpose().Transpose();
            Assert.AreNotEqual(matrix2.GetFastHashCode(), matrix1.GetFastHashCode());
        }

        [Test]
        public void GetHashCode_CompareSameSizesAndValuesWithDifferentePositions_Different()
        {
            var matrix1 = FMatrixModule.fromSeq(new[] { (new[] { 1.0, 2.0 }), (new[] { 1.0, 2.0 }) });
            var matrix2 = matrix1.Transpose();
            Assert.AreNotEqual(matrix2.GetHashCode(), matrix1.GetHashCode());
        }

        #endregion

        #region ConcatHorizontal Tests

        [Test]
        public void ConcatHorizontal_Empty0x0Empty0x10_Empty0x10()
        {
            var empty0x0 = FMatrixModule.empty(0, 0);
            var empty0x10 = FMatrixModule.empty(0, 10);
            var result1 = empty0x0.ConcatHorizontal(empty0x10);
            var result2 = empty0x10.ConcatHorizontal(empty0x0);
            Assert.IsTrue(result1.IsFat && result1.Dimension.Item2 == 10);
            Assert.IsTrue(result2.IsFat && result2.Dimension.Item2 == 10);
        }

        [Test]
        public void ConcatHorizontal_Empty2x0Hankel2x5_Hankel2x5()
        {
            /* 1 2 3 4 5
               2 3 4 5 6 */
            var hankel2x5 = FMatrixModule.hankelOfN(2, 5);
            var empty = FMatrixModule.empty(2, 0);
            var result1 = hankel2x5.ConcatHorizontal(empty);
            var result2 = empty.ConcatHorizontal(hankel2x5);
            Assert.AreEqual(hankel2x5,result1);
            Assert.AreEqual(hankel2x5,result2);
        }

        [Test]
        public void ConcatHorizontal_Hankel2x5Hankel2x5_2x10()
        {
            /* 1 2 3 4 5
               2 3 4 5 6 */
            var hankel2x5 = FMatrixModule.hankelOfN(2, 5);
            var result1 = hankel2x5.ConcatHorizontal(hankel2x5);
            var result2 = FMatrixModule.subMatrix(null, null, null, 5, result1);
            var result3 = FMatrixModule.subMatrix(null, null, 6, null, result1);
            Assert.AreEqual(hankel2x5, result2);
            Assert.AreEqual(hankel2x5, result3);
        }

        [Test,ExpectedException(typeof(Exception))]
        public void ConcatHorizontal_Empty0x0Hankel2x5_Exception()
        {
            /* 1 2 3 4 5
               2 3 4 5 6 */
            var hankel2x5 = FMatrixModule.hankelOfN(2, 5);
            var empty = FMatrixModule.empty(0, 0);
            var result2 = empty.ConcatHorizontal(hankel2x5);
            Assert.AreEqual(hankel2x5, result2);
        }

        [Test, ExpectedException(typeof(Exception))]
        public void ConcatHorizontal_Hankel2x5Empty0x0_Exception()
        {
            /* 1 2 3 4 5
               2 3 4 5 6 */
            var hankel2x5 = FMatrixModule.hankelOfN(2, 5);
            var empty = FMatrixModule.empty(0, 0);
            var result1 = hankel2x5.ConcatHorizontal(empty);
        }

        #endregion

        #region ConcatVertical Tests

        [Test]
        public void ConcatVertical_Empty0x0Empty10x0_Empty10x0()
        {
            var empty0x0 = FMatrixModule.empty(0, 0);
            var empty10x0 = FMatrixModule.empty(10,0);
            var result1 = empty0x0.ConcatVertical(empty10x0);
            var result2 = empty10x0.ConcatVertical(empty0x0);
            Assert.IsTrue(result1.IsTall && result1.Dimension.Item1 == 10);
            Assert.IsTrue(result2.IsTall && result2.Dimension.Item1 == 10);
        }

        [Test]
        public void ConcatVertical_Empty0x5Hankel2x5_Hankel2x5()
        {
            /* 1 2 3 4 5
               2 3 4 5 6 */
            var hankel2x5 = FMatrixModule.hankelOfN(2, 5);
            var empty = FMatrixModule.empty(0, 5);
            var result1 = hankel2x5.ConcatVertical(empty);
            var result2 = empty.ConcatVertical(hankel2x5);
            Assert.AreEqual(hankel2x5, result1);
            Assert.AreEqual(hankel2x5, result2);
        }

        [Test]
        public void ConcatVertical_Hankel2x5Hankel2x5_4x5()
        {
            /* 1 2 3 4 5
               2 3 4 5 6
               1 2 3 4 5
               2 3 4 5 6 */
            var hankel2x5 = FMatrixModule.hankelOfN(2, 5);
            var result1 = hankel2x5.ConcatVertical(hankel2x5);
            var result2 = FMatrixModule.subMatrix(null, 2, null, null, result1);
            var result3 = FMatrixModule.subMatrix(3, null, null, null, result1);
            Assert.AreEqual(hankel2x5, result2);
            Assert.AreEqual(hankel2x5, result3);
        }

        [Test, ExpectedException(typeof(Exception))]
        public void ConcatVertical_Empty0x0Hankel2x5_Exception()
        {
            /* 1 2 3 4 5
               2 3 4 5 6 */
            var hankel2x5 = FMatrixModule.hankelOfN(2, 5);
            var empty = FMatrixModule.empty(0, 0);
            empty.ConcatVertical(hankel2x5);
        }

        [Test, ExpectedException(typeof(Exception))]
        public void ConcatVertical_Hankel2x5Empty0x0_Exception()
        {
            /* 1 2 3 4 5
               2 3 4 5 6 */
            var hankel2x5 = FMatrixModule.hankelOfN(2, 5);
            var empty = FMatrixModule.empty(0, 0);
            hankel2x5.ConcatVertical(empty);
        }

        #endregion
    }
}
