namespace Merthin.FSharp.Compatibility
open System
open System.Runtime.CompilerServices

[<Extension>]
module DelegateExtensions =

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let FuncToFSharpTupledFunc(func : Func<'R>) =
        let result = (fun () -> func.Invoke())
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let ActionToFSharpTupledFunc(action : Action) =
        let result = (fun () -> action.Invoke())
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1FuncToFSharpTupledFunc(func : Func<'T1,'R>) =
        let result = (fun (p1) -> func.Invoke(p1))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunction")>]
    let T1FuncToFSharpFunc(func : Func<'T1,'R>) =
        let result = (fun p1 -> func.Invoke(p1))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1ActionToFSharpTupledFunc(action : Action<'T1>) =
        let result = (fun (p1) -> action.Invoke(p1))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunc")>]
    let T1ActionToFSharpFunc(action : Action<'T1>) =
        let result = (fun p1 -> action.Invoke(p1))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2FuncToFSharpTupledFunc(func : Func<'T1,'T2,'R>) =
        let result = (fun (p1,p2) -> func.Invoke(p1,p2))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunction")>]
    let T1T2FuncToFSharpFunc(func : Func<'T1,'T2,'R>) =
        let result = (fun p1 p2 -> func.Invoke(p1,p2))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2ActionToFSharpTupledFunc(action : Action<'T1,'T2>) =
        let result = (fun (p1,p2) -> action.Invoke(p1,p2))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunc")>]
    let T1T2ActionToFSharpFunc(action : Action<'T1,'T2>) =
        let result = (fun p1 p2 -> action.Invoke(p1,p2))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3FuncToFSharpTupledFunc(func : Func<'T1,'T2,'T3,'R>) =
        let result = (fun (p1,p2,p3) -> func.Invoke(p1,p2,p3))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunction")>]
    let T1T2T3FuncToFSharpFunc(func : Func<'T1,'T2,'T3,'R>) =
        let result = (fun p1 p2 p3 -> func.Invoke(p1,p2,p3))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3ActionToFSharpTupledFunc(action : Action<'T1,'T2,'T3>) =
        let result = (fun (p1,p2,p3) -> action.Invoke(p1,p2,p3))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunc")>]
    let T1T2T3ActionToFSharpFunc(action : Action<'T1,'T2,'T3>) =
        let result = (fun p1 p2 p3 -> action.Invoke(p1,p2,p3))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4FuncToFSharpTupledFunc(func : Func<'T1,'T2,'T3,'T4,'R>) =
        let result = (fun (p1,p2,p3,p4) -> func.Invoke(p1,p2,p3,p4))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunction")>]
    let T1T2T3T4FuncToFSharpFunc(func : Func<'T1,'T2,'T3,'T4,'R>) =
        let result = (fun p1 p2 p3 p4 -> func.Invoke(p1,p2,p3,p4))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4ActionToFSharpTupledFunc(action : Action<'T1,'T2,'T3,'T4>) =
        let result = (fun (p1,p2,p3,p4) -> action.Invoke(p1,p2,p3,p4))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunc")>]
    let T1T2T3T4ActionToFSharpFunc(action : Action<'T1,'T2,'T3,'T4>) =
        let result = (fun p1 p2 p3 p4 -> action.Invoke(p1,p2,p3,p4))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4T5FuncToFSharpTupledFunc(func : Func<'T1,'T2,'T3,'T4,'T5,'R>) =
        let result = (fun (p1,p2,p3,p4,p5) -> func.Invoke(p1,p2,p3,p4,p5))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunction")>]
    let T1T2T3T4T5FuncToFSharpFunc(func : Func<'T1,'T2,'T3,'T4,'T5,'R>) =
        let result = (fun p1 p2 p3 p4 p5 -> func.Invoke(p1,p2,p3,p4,p5))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4T5ActionToFSharpTupledFunc(action : Action<'T1,'T2,'T3,'T4,'T5>) =
        let result = (fun (p1,p2,p3,p4,p5) -> action.Invoke(p1,p2,p3,p4,p5))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunc")>]
    let T1T2T3T4T5ActionToFSharpFunc(action : Action<'T1,'T2,'T3,'T4,'T5>) =
        let result = (fun p1 p2 p3 p4 p5 -> action.Invoke(p1,p2,p3,p4,p5))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4T5T6FuncToFSharpTupledFunc(func : Func<'T1,'T2,'T3,'T4,'T5,'T6,'R>) =
        let result = (fun (p1,p2,p3,p4,p5,p6) -> func.Invoke(p1,p2,p3,p4,p5,p6))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunction")>]
    let T1T2T3T4T5T6FuncToFSharpFunc(func : Func<'T1,'T2,'T3,'T4,'T5,'T6,'R>) =
        let result = (fun p1 p2 p3 p4 p5 p6 -> func.Invoke(p1,p2,p3,p4,p5,p6))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4T5T6ActionToFSharpTupledFunc(action : Action<'T1,'T2,'T3,'T4,'T5,'T6>) =
        let result = (fun (p1,p2,p3,p4,p5,p6) -> action.Invoke(p1,p2,p3,p4,p5,p6))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunc")>]
    let T1T2T3T4T5T6ActionToFSharpFunc(action : Action<'T1,'T2,'T3,'T4,'T5,'T6>) =
        let result = (fun p1 p2 p3 p4 p5 p6 -> action.Invoke(p1,p2,p3,p4,p5,p6))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4T5T6T7FuncToFSharpTupledFunc(func : Func<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'R>) =
        let result = (fun (p1,p2,p3,p4,p5,p6,p7) -> func.Invoke(p1,p2,p3,p4,p5,p6,p7))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunction")>]
    let T1T2T3T4T5T6T7FuncToFSharpFunc(func : Func<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'R>) =
        let result = (fun p1 p2 p3 p4 p5 p6 p7 -> func.Invoke(p1,p2,p3,p4,p5,p6,p7))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4T5T6T7ActionToFSharpTupledFunc(action : Action<'T1,'T2,'T3,'T4,'T5,'T6,'T7>) =
        let result = (fun (p1,p2,p3,p4,p5,p6,p7) -> action.Invoke(p1,p2,p3,p4,p5,p6,p7))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunc")>]
    let T1T2T3T4T5T6T7ActionToFSharpFunc(action : Action<'T1,'T2,'T3,'T4,'T5,'T6,'T7>) =
        let result = (fun p1 p2 p3 p4 p5 p6 p7 -> action.Invoke(p1,p2,p3,p4,p5,p6,p7))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4T5T6T7T8FuncToFSharpTupledFunc(func : Func<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'R>) =
        let result = (fun (p1,p2,p3,p4,p5,p6,p7,p8) -> func.Invoke(p1,p2,p3,p4,p5,p6,p7,p8))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunction")>]
    let T1T2T3T4T5T6T7T8FuncToFSharpFunc(func : Func<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'R>) =
        let result = (fun p1 p2 p3 p4 p5 p6 p7 p8 -> func.Invoke(p1,p2,p3,p4,p5,p6,p7,p8))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4T5T6T7T8ActionToFSharpTupledFunc(action : Action<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8>) =
        let result = (fun (p1,p2,p3,p4,p5,p6,p7,p8) -> action.Invoke(p1,p2,p3,p4,p5,p6,p7,p8))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunc")>]
    let T1T2T3T4T5T6T7T8ActionToFSharpFunc(action : Action<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8>) =
        let result = (fun p1 p2 p3 p4 p5 p6 p7 p8 -> action.Invoke(p1,p2,p3,p4,p5,p6,p7,p8))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4T5T6T7T8T9FuncToFSharpTupledFunc(func : Func<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'R>) =
        let result = (fun (p1,p2,p3,p4,p5,p6,p7,p8,p9) -> func.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunction")>]
    let T1T2T3T4T5T6T7T8T9FuncToFSharpFunc(func : Func<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'R>) =
        let result = (fun p1 p2 p3 p4 p5 p6 p7 p8 p9 -> func.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4T5T6T7T8T9ActionToFSharpTupledFunc(action : Action<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9>) =
        let result = (fun (p1,p2,p3,p4,p5,p6,p7,p8,p9) -> action.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunc")>]
    let T1T2T3T4T5T6T7T8T9ActionToFSharpFunc(action : Action<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9>) =
        let result = (fun p1 p2 p3 p4 p5 p6 p7 p8 p9 -> action.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4T5T6T7T8T9T10FuncToFSharpTupledFunc(func : Func<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'R>) =
        let result = (fun (p1,p2,p3,p4,p5,p6,p7,p8,p9,p10) -> func.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunction")>]
    let T1T2T3T4T5T6T7T8T9T10FuncToFSharpFunc(func : Func<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'R>) =
        let result = (fun p1 p2 p3 p4 p5 p6 p7 p8 p9 p10 -> func.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4T5T6T7T8T9T10ActionToFSharpTupledFunc(action : Action<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10>) =
        let result = (fun (p1,p2,p3,p4,p5,p6,p7,p8,p9,p10) -> action.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunc")>]
    let T1T2T3T4T5T6T7T8T9T10ActionToFSharpFunc(action : Action<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10>) =
        let result = (fun p1 p2 p3 p4 p5 p6 p7 p8 p9 p10 -> action.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4T5T6T7T8T9T10T11FuncToFSharpTupledFunc(func : Func<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'T11,'R>) =
        let result = (fun (p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11) -> func.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunction")>]
    let T1T2T3T4T5T6T7T8T9T10T11FuncToFSharpFunc(func : Func<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'T11,'R>) =
        let result = (fun p1 p2 p3 p4 p5 p6 p7 p8 p9 p10 p11 -> func.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4T5T6T7T8T9T10T11ActionToFSharpTupledFunc(action : Action<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'T11>) =
        let result = (fun (p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11) -> action.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunc")>]
    let T1T2T3T4T5T6T7T8T9T10T11ActionToFSharpFunc(action : Action<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'T11>) =
        let result = (fun p1 p2 p3 p4 p5 p6 p7 p8 p9 p10 p11 -> action.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4T5T6T7T8T9T10T11T12FuncToFSharpTupledFunc(func : Func<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'T11,'T12,'R>) =
        let result = (fun (p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12) -> func.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunction")>]
    let T1T2T3T4T5T6T7T8T9T10T11T12FuncToFSharpFunc(func : Func<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'T11,'T12,'R>) =
        let result = (fun p1 p2 p3 p4 p5 p6 p7 p8 p9 p10 p11 p12 -> func.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4T5T6T7T8T9T10T11T12ActionToFSharpTupledFunc(action : Action<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'T11,'T12>) =
        let result = (fun (p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12) -> action.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunc")>]
    let T1T2T3T4T5T6T7T8T9T10T11T12ActionToFSharpFunc(action : Action<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'T11,'T12>) =
        let result = (fun p1 p2 p3 p4 p5 p6 p7 p8 p9 p10 p11 p12 -> action.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4T5T6T7T8T9T10T11T12T13FuncToFSharpTupledFunc(func : Func<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'T11,'T12,'T13,'R>) =
        let result = (fun (p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13) -> func.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunction")>]
    let T1T2T3T4T5T6T7T8T9T10T11T12T13FuncToFSharpFunc(func : Func<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'T11,'T12,'T13,'R>) =
        let result = (fun p1 p2 p3 p4 p5 p6 p7 p8 p9 p10 p11 p12 p13 -> func.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4T5T6T7T8T9T10T11T12T13ActionToFSharpTupledFunc(action : Action<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'T11,'T12,'T13>) =
        let result = (fun (p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13) -> action.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunc")>]
    let T1T2T3T4T5T6T7T8T9T10T11T12T13ActionToFSharpFunc(action : Action<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'T11,'T12,'T13>) =
        let result = (fun p1 p2 p3 p4 p5 p6 p7 p8 p9 p10 p11 p12 p13 -> action.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4T5T6T7T8T9T10T11T12T13T14FuncToFSharpTupledFunc(func : Func<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'T11,'T12,'T13,'T14,'R>) =
        let result = (fun (p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14) -> func.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunction")>]
    let T1T2T3T4T5T6T7T8T9T10T11T12T13T14FuncToFSharpFunc(func : Func<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'T11,'T12,'T13,'T14,'R>) =
        let result = (fun p1 p2 p3 p4 p5 p6 p7 p8 p9 p10 p11 p12 p13 p14 -> func.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4T5T6T7T8T9T10T11T12T13T14ActionToFSharpTupledFunc(action : Action<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'T11,'T12,'T13,'T14>) =
        let result = (fun (p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14) -> action.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunc")>]
    let T1T2T3T4T5T6T7T8T9T10T11T12T13T14ActionToFSharpFunc(action : Action<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'T11,'T12,'T13,'T14>) =
        let result = (fun p1 p2 p3 p4 p5 p6 p7 p8 p9 p10 p11 p12 p13 p14 -> action.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4T5T6T7T8T9T10T11T12T13T14T15FuncToFSharpTupledFunc(func : Func<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'T11,'T12,'T13,'T14,'T15,'R>) =
        let result = (fun (p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15) -> func.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunction")>]
    let T1T2T3T4T5T6T7T8T9T10T11T12T13T14T15FuncToFSharpFunc(func : Func<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'T11,'T12,'T13,'T14,'T15,'R>) =
        let result = (fun p1 p2 p3 p4 p5 p6 p7 p8 p9 p10 p11 p12 p13 p14 p15 -> func.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4T5T6T7T8T9T10T11T12T13T14T15ActionToFSharpTupledFunc(action : Action<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'T11,'T12,'T13,'T14,'T15>) =
        let result = (fun (p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15) -> action.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunc")>]
    let T1T2T3T4T5T6T7T8T9T10T11T12T13T14T15ActionToFSharpFunc(action : Action<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'T11,'T12,'T13,'T14,'T15>) =
        let result = (fun p1 p2 p3 p4 p5 p6 p7 p8 p9 p10 p11 p12 p13 p14 p15 -> action.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4T5T6T7T8T9T10T11T12T13T14T15T16FuncToFSharpTupledFunc(func : Func<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'T11,'T12,'T13,'T14,'T15,'T16,'R>) =
        let result = (fun (p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,p16) -> func.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,p16))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunction")>]
    let T1T2T3T4T5T6T7T8T9T10T11T12T13T14T15T16FuncToFSharpFunc(func : Func<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'T11,'T12,'T13,'T14,'T15,'T16,'R>) =
        let result = (fun p1 p2 p3 p4 p5 p6 p7 p8 p9 p10 p11 p12 p13 p14 p15 p16 -> func.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,p16))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpTupledFunction")>]
    let T1T2T3T4T5T6T7T8T9T10T11T12T13T14T15T16ActionToFSharpTupledFunc(action : Action<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'T11,'T12,'T13,'T14,'T15,'T16>) =
        let result = (fun (p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,p16) -> action.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,p16))
        result

    [<Extension>]
    [<CompiledNameAttribute("AsFSharpFunc")>]
    let T1T2T3T4T5T6T7T8T9T10T11T12T13T14T15T16ActionToFSharpFunc(action : Action<'T1,'T2,'T3,'T4,'T5,'T6,'T7,'T8,'T9,'T10,'T11,'T12,'T13,'T14,'T15,'T16>) =
        let result = (fun p1 p2 p3 p4 p5 p6 p7 p8 p9 p10 p11 p12 p13 p14 p15 p16 -> action.Invoke(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,p16))
        result