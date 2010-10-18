namespace Merthin.FSharp

open System
open Microsoft.FSharp.Core

[<RequireQualifiedAccess>]
type NetOption<'a when 'a : (new : unit -> 'a)> = 
    | None 
    | Some of 'a
    with 
        member this.Value =
               match this with
               | Some(v) -> v
               | _ -> failwith "No value attached"

        //FROM HARD VALUE
        static member op_Implicit(value : 'a) =
               NetOption.Some(value)

        //FROM NULLABLE VALUE
        static member op_Implicit<'t  when 't : struct and 't :> ValueType and 't : (new : unit -> 't)>(nullableValue : Nullable<'t>) =
               if nullableValue.HasValue then 
                  NetOption.Some(nullableValue.Value) 
               else 
                  NetOption.None

        //FROM FSHARPOPTION VALUE
        static member op_Implicit(optionValue : option<'a> ) =
               if optionValue.IsSome then 
                  NetOption.Some(optionValue.Value) 
               else 
                  NetOption.None

        //TO HARD VALUE
        static member op_Implicit(nOptionValue : NetOption<'a>) = 
               match nOptionValue with
               | NetOption.Some(value) -> value
               | _ -> Unchecked.defaultof<'a>
         
        //TO FSHARPOPTION VALUE
        static member op_Implicit(nOptionValue : NetOption<'a>) = 
               match nOptionValue with
               | NetOption.Some(value) -> Option.Some(value)
               | _ -> Option.None

        //TO NULLABLE VALUE
        static member op_Implicit<'t when 't : struct and 't :> ValueType and 't : (new : unit -> 't)>(nOptionValue : NetOption<'t>) = 
               match nOptionValue with
               | NetOption.Some(value) -> Nullable.op_Implicit(value)
               | _ -> Unchecked.defaultof<Nullable<'t>>