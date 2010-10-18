using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Merthin.Math.Algebra.Matrix.Tests
{
    /// <summary>
    ///This is a test class for FMatrix module and is intended
    ///to contain all FMatrix module Unit Tests.
    ///</summary>
    [TestFixture]
    public class FMatrixModuleTest
    {
        #region Minor Tests

        [Test]
        public void Minor_MiddleMiddle_Correct()
        {            
            /* 1 2 3 4 5
               2 3 4 5 6
               3 4 5 6 7
               4 5 6 7 8
               5 6 7 8 9 */
            var source1 = FMatrixModule.hankelOfN(5, 5);
            var result1 = FMatrixModule.minor(3,3,source1);
            var expected1 = FMatrixModule.fromString("1 2 4 5\n2 3 5 6\n4 5 7 8\n5 6 8 9");
            Assert.AreEqual(result1, expected1);
        }

        [Test]
        public void Minor_UpperLeft_Correct()
        {
            /* 1 2 3 4 5
               2 3 4 5 6
               3 4 5 6 7
               4 5 6 7 8
               5 6 7 8 9 */
            var source1 = FMatrixModule.hankelOfN(5, 5);
            var result1 = FMatrixModule.minor(1, 1, source1);
            var expected1 = FMatrixModule.fromString("3 4 5 6\n4 5 6 7\n5 6 7 8\n6 7 8 9");
            Assert.AreEqual(result1, expected1);
        }

        [Test]
        public void Minor_UpperRight_Correct()
        {
            /* 1 2 3 4 5
               2 3 4 5 6
               3 4 5 6 7
               4 5 6 7 8
               5 6 7 8 9 */
            var source1 = FMatrixModule.hankelOfN(5, 5);
            var result1 = FMatrixModule.minor(1, 5, source1);
            var expected1 = FMatrixModule.fromString("2 3 4 5\n3 4 5 6\n4 5 6 7\n5 6 7 8");
            Assert.AreEqual(result1, expected1);
        }

        [Test]
        public void Minor_BottomLeft_Correct()
        {
            /* 1 2 3 4 5
               2 3 4 5 6
               3 4 5 6 7
               4 5 6 7 8
               5 6 7 8 9 */
            var source1 = FMatrixModule.hankelOfN(5, 5);
            var result1 = FMatrixModule.minor(5, 1, source1);
            var expected1 = FMatrixModule.fromString("2 3 4 5\n3 4 5 6\n4 5 6 7\n5 6 7 8");
            Assert.AreEqual(result1, expected1);
        }

        [Test]
        public void Minor_BottomRight_Correct()
        {
            /* 1 2 3 4 5
               2 3 4 5 6
               3 4 5 6 7
               4 5 6 7 8
               5 6 7 8 9 */
            var source1 = FMatrixModule.hankelOfN(5, 5);
            var result1 = FMatrixModule.minor(5, 5, source1);
            var expected1 = FMatrixModule.fromString("1 2 3 4\n2 3 4 5\n3 4 5 6\n4 5 6 7");
            Assert.AreEqual(result1, expected1);
        }

        #endregion

        #region SubMatrix Tests

        [Test]
        public void SubMatrix_NoIndexes_Correct()
        {
            var source1 = FMatrixModule.hankelOfN(5, 5);
            var result1 = FMatrixModule.subMatrix(null, null, null, null,source1);
            Assert.AreEqual(result1, source1);
        }

        [Test]
        public void SubMatrix_ThirdBlock_Correct()
        {
            var source1 = FMatrixModule.hankelOfN(5, 5);
            var result1 = FMatrixModule.subMatrix(3, null, 3, null, source1);
            var expected1 = FMatrixModule.fromString("5 6 7\n6 7 8\n7 8 9");
            Assert.AreEqual(result1, expected1);
        }

        #endregion

        #region SubMatrixOrEmpty Tests

        [Test]        
        public void SubMatrixOrEmpty_UpperLeftCorner_Empty0x0()
        {

            /* 1 2 3 4 5
               2 3 4 5 6
               3 4 5 6 7
               4 5 6 7 8
               5 6 7 8 9 */
            var _ = new Nullable<int>();
            var source1 = FMatrixModule.hankelOfN(5, 5);
            var result1 = FMatrixModule.subMatrixOrEmpty(_, 0, _, 0, source1);
            Assert.IsTrue(result1.IsEmpty);
        }

        [Test]        
        public void SubMatrixOrEmpty_UpperRightCorner_Empty0x0()
        {

            /* 1 2 3 4 5
               2 3 4 5 6
               3 4 5 6 7
               4 5 6 7 8
               5 6 7 8 9 */
            var _ = new Nullable<int>();
            var source1 = FMatrixModule.hankelOfN(5, 5);
            var result1 = FMatrixModule.subMatrixOrEmpty(_, 0, 6, _, source1);
            Assert.IsTrue(result1.IsEmpty);
        }

        [Test]        
        public void SubMatrixOrEmpty_BottomLeftCorner_Empty0x0()
        {

            /* 1 2 3 4 5
               2 3 4 5 6
               3 4 5 6 7
               4 5 6 7 8
               5 6 7 8 9 */
            var _ = new Nullable<int>();
            var source1 = FMatrixModule.hankelOfN(5, 5);
            var result1 = FMatrixModule.subMatrixOrEmpty(6, _, _, 0, source1);
            Assert.IsTrue(result1.IsEmpty);
        }

        [Test]        
        public void SubMatrixOrEmpty_BottomRightCorner_Empty0x0()
        {

            /* 1 2 3 4 5
               2 3 4 5 6
               3 4 5 6 7
               4 5 6 7 8
               5 6 7 8 9 */
            var _ = new Nullable<int>();
            var source1 = FMatrixModule.hankelOfN(5, 5);
            var result1 = FMatrixModule.subMatrixOrEmpty(6, _, 6, _, source1);
            Assert.IsTrue(result1.IsEmpty);
        }

        #endregion

        #region Determinant Tests

        [Test,MaxTime(1000)]
        public void Determinant_Identity10_Correct()
        {

            var source1 = FMatrixModule.identity(10);
            var result1 = FMatrixModule.determinant(source1);

            Assert.AreEqual(1, result1);
        }

        [Test, MaxTime(1000)]
        public void Determinant_Identity20_Correct()
        {

            var source1 = FMatrixModule.identity(50);
            var result1 = FMatrixModule.determinant(source1);
            Assert.AreEqual(result1, 1);
        }

        #endregion

        #region FromSeq Tests

        [Test]
        public void FromSeq_NaturalIncreasingOffset10x10_Hankel10x10()
        {
            
            var seq =  Enumerable.Range(0, 10).Select( i => Range(1 + i,10 + i));
            var result = FMatrixModule.fromSeq(seq);
            var expected = FMatrixModule.hankelOfN(10, 10);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FromSeq_EmptySequence_Empty0x0()
        {

            var seq = Enumerable.Range(0, 10).Select(i => Range(0,-1));
            var result = FMatrixModule.fromSeq(seq);
            var expected = FMatrixModule.empty(10, 0);
            Assert.AreEqual(expected, result);
        }

        private IEnumerable<Double> Range(int start, int count)
        {
            for (var i = start; i <= count; i++)
                yield return Convert.ToDouble(i);
            yield break;
        }

        #endregion

        #region Strassen Multiplication

        private static void AssertStrassenMultiplication(int n)
        {
            var a = FMatrixModule.hankelOfN(n, n);
            var b = FMatrixModule.hankelOfNWithOffset(2, n, n);
            var actual = FMatrixModule.StrassenMultiplication(a, b).ToString(n, n, null, "", '0');
            var expected = (a * b).ToString(n, n, null, "", '0');
            Assert.AreEqual(expected, actual);
        }

        private static void AssertStrassenMultiplication(int n, int crossPoint)
        {
            var a = FMatrixModule.hankelOfN(n, n);
            var b = FMatrixModule.hankelOfNWithOffset(2, n, n);
            var actual = FMatrixModule.StrassenMultiplication_ForAnySize(a, b, crossPoint).ToString(n, n, null, "", '0');
            var expected = (a * b).ToString(n, n, null, "", '0');
            Assert.AreEqual(expected, actual);
        }

        #region Strassen Multiplication - Power of Two - No Cross Point

        [Test]
        [Category("Strassen Multiplication - Power of Two - No Cross Point")]
        public void StrassenMultiplication_Size16_CrossPoint0_Correct()
        {
            AssertStrassenMultiplication(16, 0);
        }

        [Test]
        [Category("Strassen Multiplication - Power of Two - No Cross Point")]
        public void StrassenMultiplication_Size32_CrossPoint0_Correct()
        {
            AssertStrassenMultiplication(32, 0);
        }

        #endregion

        #region Strassen Multiplication - No Power Of Two - Cross Point

        [Test]
        [Category("Strassen Multiplication - No Power Of Two - No Cross Point")]
        public void StrassenMultiplication_Size3_CrossPoint0_Correct()
        {
            AssertStrassenMultiplication(3, 0);
        }

        [Test]
        [Category("Strassen Multiplication - No Power Of Two - No Cross Point")]
        public void StrassenMultiplication_Size15_CrossPoint0_Correct()
        {
            AssertStrassenMultiplication(15, 0);
        }

        [Test]
        [Category("Strassen Multiplication - No Power Of Two - No Cross Point")]
        public void StrassenMultiplication_Size27_CrossPoint0_Correct()
        {
            AssertStrassenMultiplication(27, 0);
        }

        #endregion

        #region Strassen Multiplication - Power Of Two - Cross Point

        [Test]
        [Category("Strassen Multiplication - Power Of Two - Cross Point")]
        public void StrassenMultiplication_Size8_CrossPoint4_Correct()
        {
            AssertStrassenMultiplication(8, 4);
        }

        [Test]
        [Category("Strassen Multiplication - Power Of Two - Cross Point")]
        public void StrassenMultiplication_Size16_CrossPoint8_Correct()
        {
            AssertStrassenMultiplication(16, 8);
        }

        [Test]
        [Category("Strassen Multiplication - Power Of Two - Cross Point")]
        public void StrassenMultiplication_Size32_CrossPoint16_Correct()
        {
            AssertStrassenMultiplication(32, 16);
        }

        [Test]
        [Category("Strassen Multiplication - Power Of Two - Cross Point")]
        public void StrassenMultiplication_Size64_CrossPoint32_Correct()
        {
            AssertStrassenMultiplication(64, 32);
        }

        #endregion

        #region Strassen Multiplication - No Power Of Two - Cross Point

        [Test]
        [Category("Strassen Multiplication - No Power Of Two - Cross Point")]
        public void StrassenMultiplication_Size3_CrossPoint2_Correct()
        {
            AssertStrassenMultiplication(3, 2);
        }

        [Test]
        [Category("Strassen Multiplication - No Power Of Two - Cross Point")]
        public void StrassenMultiplication_Size15_CrossPoint8_Correct()
        {
            AssertStrassenMultiplication(15, 8);
        }

        [Test]
        [Category("Strassen Multiplication - No Power Of Two - Cross Point")]
        public void StrassenMultiplication_Size27_CrossPoint16_Correct()
        {
            AssertStrassenMultiplication(27, 16);
        }

        [Test]
        [Category("Strassen Multiplication - No Power Of Two - Cross Point")]
        public void StrassenMultiplication_Size55_CrossPoint32_Correct()
        {
            AssertStrassenMultiplication(55, 32);
        }

        #endregion

        #region Strassen Multiplication - Automatic Cross Point

        [Test]
        [Category("Strassen Multiplication - Automatic Cross Point")]
        public void StrassenMultiplication_Size19_Correct()
        {
            AssertStrassenMultiplication(19);
        }

        [Test]
        [Category("Strassen Multiplication - Automatic Cross Point")]
        public void StrassenMultiplication_Size32_Correct()
        {
            AssertStrassenMultiplication(32);
        }

        #endregion

        #endregion
    }
}
