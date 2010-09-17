using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Merthin.FSharp.Tests
{
    [TestFixture]
    public class FSharpCodesTest
    {
        [Test]
        public void methodIdentifier_CombinedOperators_Correct()
        {

        }
    }

    internal class MethodContainer
    {
        // Methods
        public static int operator +(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int op_AdditionAssignment(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int op_Append(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int operator &(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int operator |(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int op_ComposeLeft(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int op_ComposeRight(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int op_Concatenate(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int op_Dereference(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int operator /(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int op_DivisionAssignment(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int op_Dynamic(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int op_DynamicAssignment(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int operator ==(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int operator ^(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int op_GreaterLessPlusMinusMultiplyDivideEqualsTwiddlePercentDotAmpBarAtHatBangQmark(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int operator >(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int operator >=(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int operator <<(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int operator <(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int operator <=(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int op_LogicalNot(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int operator %(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int operator *(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int op_MultiplyAssignment(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int op_PipeLeft(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int op_PipeRight(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int op_Quotation(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int op_QuotationUntyped(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int op_Range(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int op_RangeStep(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int operator >>(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int operator -(MethodContainer a, MethodContainer b)
        {
            return 4;
        }

        public static int op_SubtractionAssignment(MethodContainer a, MethodContainer b)
        {
            return 4;
        }
    }

}
