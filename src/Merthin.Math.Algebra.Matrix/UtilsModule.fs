namespace Merthin.Math.Algebra.Matrix

open System

[<AutoOpen>]
module internal Utils =

       let isPowerOf n p =
           let log = Math.Log(n,p)
           Math.Floor(log) = Math.Ceiling(log)

       let paddingForPowerOf n p =
           let log = Math.Log(n,p)
           let f,c = Math.Floor(log), Math.Ceiling(log)
           if c <> f then Math.Pow(p,c) - n else 0.0