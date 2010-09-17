using System;
using System.Threading;
using NUnit.Framework;

namespace Merthin.Math.Algebra.Matrix.Tests
{
    
    /// <summary>
    ///This is a test class for Interactive module and is intended
    ///to contain all Interactive module Unit Tests.
    ///</summary>
    [TestFixture]
    public class InteractiveTest
    {
        public IFormatProvider Format = Thread.CurrentThread.CurrentCulture;

        #region ToConsoleString

        /// <summary>
        ///A test for ToConsoleString when the representation should reflect all the dimensions.
        ///</summary>
        [Test]
        public void ToConsoleString_AllRowsAllColumns_Correct()
        {
            var matrixStr = "01 02 03 04 05 06\n" +
                            "08 09 10 04 05 06\n" +
                            "01 02 03 04 05 06\n" +
                            "01 02 03 04 05 06\n" +
                            "01 02 03 04 05 06";
            var matrix = FMatrixModule.fromString(matrixStr);
            var actual = Interactive.ToConsoleStringNullables(matrix, null, null, Format, String.Empty, '0');
            Assert.AreEqual(matrixStr, actual);
        }

        /// <summary>
        ///A test for ToConsoleString when the representation reflects less rows than the dimension.
        ///</summary>
        [Test]
        public void ToConsoleString_FewRowsAllColumns_Correct()
        {
            var matrixStr = "01 02 03 04 05 06\n" +
                            "08 09 10 04 05 06\n" +
                            "01 02 03 04 05 06\n" +
                            "01 02 03 04 05 06\n" +
                            "01 02 03 04 05 06";

            var expectedStr = "01 02 03 04 05 06\n" +
                              "08 09 10 04 05 06\n" +
                              "01 02 03 04 05 06\n" +
                              " .  .  .  .  .  .";
                              
            var matrix = FMatrixModule.fromString(matrixStr);
            var actual = Interactive.ToConsoleStringNullables(matrix, 3, null, Format, String.Empty, '0');
            Assert.AreEqual(expectedStr, actual);
        }

        /// <summary>
        ///A test for ToConsoleString when the representation reflects less columns than the dimension.
        ///</summary>
        [Test]
        public void ToString_AllRowsFewColumns_Correct()
        {
            var matrixStr = "01 02 03 04 05 06\n" +
                            "08 09 10 04 05 06\n" +
                            "01 02 03 04 05 06\n" +
                            "01 02 03 04 05 06\n" +
                            "01 02 03 04 05 06";

            var expectedStr = "01 02 03 .\n" +
                              "08 09 10 .\n" +
                              "01 02 03 .\n" +
                              "01 02 03 .\n" +
                              "01 02 03 .";

            var matrix = FMatrixModule.fromString(matrixStr);
            var actual = Interactive.ToConsoleStringNullables(matrix, null, 3, Format, String.Empty, '0');
            Assert.AreEqual(expectedStr, actual);
        }

        /// <summary>
        ///A test for ToConsoleString when the representation reflects less rows and columns than the dimension.
        ///</summary>
        [Test]
        public void ToString_FewRowsFewColumns_Correct()
        {
            var matrixStr = "01 02 03 04 05 06\n" +
                            "08 09 10 04 05 06\n" +
                            "01 02 03 04 05 06\n" +
                            "01 02 03 04 05 06\n" +
                            "01 02 03 04 05 06";

            var expectedStr = "01 02 03 .\n" +
                              "08 09 10 .\n" +
                              "01 02 03 .\n" +
                              " .  .  . .";

            var matrix = FMatrixModule.fromString(matrixStr);
            var actual = Interactive.ToConsoleStringNullables(matrix, 3, 3, Format, String.Empty, '0');
            Assert.AreEqual(expectedStr, actual);
        }

        #endregion
    }
}
