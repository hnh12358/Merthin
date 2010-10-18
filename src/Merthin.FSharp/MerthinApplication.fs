namespace Merthin.FSharp
open Merthin.FSharp.DesignPatterns

[<AllowNullLiteral>]
type MerthinApplication =
    
    [<DefaultValue>]
    val mutable private m_isParallel : bool

    [<DefaultValue>]
    val mutable private m_showParallelEvidence : bool

    internal new() = {}

    static member Current
           with get() = Singleton<MerthinApplication>.Instance

    member public this.ShowParallelEvidence
           with get () = this.m_showParallelEvidence
           and set (value) = this.m_showParallelEvidence <- value