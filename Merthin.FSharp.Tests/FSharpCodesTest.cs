using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;

namespace Merthin.FSharp.Tests
{
    [TestFixture]
    public class FSharpCodesTest
    {
        #region MethodIdentifier

        [Test]
        public void MethodIdentifier_CombinedOperators_Correct()
        {
            var method = typeof(MethodContainer<>).GetMethods(BindingFlags.Static | BindingFlags.Public)[0];
            var actual = FSharpCodes.MethodIdentifier(method);
            const string expected = "( ><+-*/=~%.&|@^!? )";
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region TypeIdentifier

        [Test]
        public void TypeIdentifier_GenericTypesClosed_Correct()
        {
            var nullableIntTypeCode = FSharpCodes.TypeIdentifier(typeof(Nullable<Int32>));
            Assert.AreEqual("Nullable<int>", nullableIntTypeCode);

            var dictionaryType = new Dictionary<String, Dictionary<Int32, Double>>().GetType();
            var dictionaryTypeCode = FSharpCodes.TypeIdentifier(dictionaryType);
            Assert.AreEqual("Dictionary<string,Dictionary<int,double>>", dictionaryTypeCode);
        }

        [Test]
        public void TypeIdentifier_GenericTypesOpen_Correct()
        {
            var genericOpenType1 = FSharpCodes.TypeIdentifier(typeof(MethodContainer<>));
            Assert.AreEqual("MethodContainer<'T>", genericOpenType1);

            var genericOpenType2 = FSharpCodes.TypeIdentifier(typeof(Dictionary<,>));
            Assert.AreEqual("Dictionary<'TKey,'TValue>", genericOpenType2);
        }

        [Test]
        public void TypeIdentifier_Tuples_Correct()
        {
            var tuple1Type = Tuple.Create(1).GetType();
            var tuple1TypeCode = FSharpCodes.TypeIdentifier(tuple1Type);
            Assert.AreEqual("int",tuple1TypeCode);

            var tuple2Type = Tuple.Create(1, 2).GetType();
            var tuple2TypeCode = FSharpCodes.TypeIdentifier(tuple2Type);
            Assert.AreEqual("int * int", tuple2TypeCode);

            var tuple3Type = Tuple.Create(1, 2, 3).GetType();
            var tuple3TypeCode = FSharpCodes.TypeIdentifier(tuple3Type);
            Assert.AreEqual("int * int * int", tuple3TypeCode);

            var tuple4Type = Tuple.Create(1, 2, 3, 4).GetType();
            var tuple4TypeCode = FSharpCodes.TypeIdentifier(tuple4Type);
            Assert.AreEqual("int * int * int * int", tuple4TypeCode);

            var tuple5Type = Tuple.Create(1, 2, 3, 4, 5).GetType();
            var tuple5TypeCode = FSharpCodes.TypeIdentifier(tuple5Type);
            Assert.AreEqual("int * int * int * int * int", tuple5TypeCode);

            var tuple6Type = Tuple.Create(1, 2, 3, 4, 5, 6).GetType();
            var tuple6TypeCode = FSharpCodes.TypeIdentifier(tuple6Type);
            Assert.AreEqual("int * int * int * int * int * int", tuple6TypeCode);

            var tuple7Type = Tuple.Create(1, 2, 3, 4, 5, 6, 7).GetType();
            var tuple7TypeCode = FSharpCodes.TypeIdentifier(tuple7Type);
            Assert.AreEqual("int * int * int * int * int * int * int", tuple7TypeCode);

            var tuple8Type = Tuple.Create(1, 2, 3, 4, 5, 6, 7, Tuple.Create(8)).GetType();
            var tuple8TypeCode = FSharpCodes.TypeIdentifier(tuple8Type);
            Assert.AreEqual("int * int * int * int * int * int * int * int", tuple8TypeCode);
        }

        [Test]
        public void TypeIdentifier_PrimitiveDataTypes_Correct()
        {
            var pairs = new[]
                            {
                                Tuple.Create(typeof (Byte), "byte"),
                                Tuple.Create(typeof (Boolean), "bool"),
                                Tuple.Create(typeof (SByte), "sbyte"),
                                Tuple.Create(typeof (Int16), "int16"),
                                Tuple.Create(typeof (UInt16), "uint16"),
                                Tuple.Create(typeof (Int32), "int"),
                                Tuple.Create(typeof (UInt32), "uint32"),
                                Tuple.Create(typeof (Int64), "int64"),
                                Tuple.Create(typeof (UInt64), "uint64"),
                                Tuple.Create(typeof (UIntPtr), "unativeint"),
                                Tuple.Create(typeof (Char), "char"),
                                Tuple.Create(typeof (String), "string"),
                                Tuple.Create(typeof (Decimal), "decimal"),
                                Tuple.Create(typeof (void), "unit"),
                                Tuple.Create(typeof (Single), "float32"),
                                Tuple.Create(typeof (Double), "double")
                            };
            foreach(var pair in pairs)
                Assert.AreEqual(pair.Item2,FSharpCodes.TypeIdentifier(pair.Item1));
        }

        #endregion
    }

    internal class MethodContainer<T>
    {
        public static int op_GreaterLessPlusMinusMultiplyDivideEqualsTwiddlePercentDotAmpBarAtHatBangQmark(MethodContainer<T> a, MethodContainer<T> b)
        {
            return 4;
        }

    }

}
