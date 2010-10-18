using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Speedometer.Framework;

namespace Merthin.Math.Algebra.Matrix.SpeedoMeters
{
    [SpeedoMeterFixture("Procedures to compare time cost of matrix multiplication using the normal and strassen approach.")]
    [SpeedoCompareGroupDefinition("Size45","Tests from 45")]
    public class MatrixMultiplicationMeters : IDisposable
    {
        public MatrixMultiplicationMeters()
        {
            
        }

        [SpeedoMeter("","00:01:00","00:05:00")]
        [SpeedoCompareGroup("Size45")]
        public static void StrassenMultiplication_Size45()
        {
            
        }

        [SpeedoMeter("", "00:01:00", "00:05:00")]
        [SpeedoCompareGroup("Size45")]
        public static void NormalMultiplication_Size45()
        {

        }

        public void Dispose()
        {
            
        }
    }
}