namespace Merthin.Math
open System
open System.Linq.Expressions

module DoubleExpressionTrees =
    
    (* HELPERS *)
    let Constant_double (a : obj) = Expression.Constant(Convert.ToDouble(a)) :> Expression

    let Parameter_double a = Expression.Parameter(typeof<System.Double>,a)

    let CreateLambda parameters body = Expression.Lambda(body,parameters)

    let (|DoubleExpression|_|) (x: Expression) = if x.Type = typeof<System.Double> then Some() else None

    

    let (|DoubleConstant|_|) (x: Expression) =
        match x with
        | :? ConstantExpression as xc when xc.Type = typeof<System.Double> -> Some(xc.Value :?> System.Double)
        | _ -> None

    let Multiply_double (a : Expression) (b : Expression) =
        match a,b with
        | DoubleConstant(ac), DoubleConstant(bc) -> Constant_double (ac * bc)
        | DoubleConstant(v), (DoubleExpression as e) | (DoubleExpression as e) , DoubleConstant(v) when v = 1.0 -> e
        | DoubleConstant(v), DoubleExpression | DoubleExpression, DoubleConstant(v) when v = 0.0 -> Constant_double 0.0 
        | DoubleExpression, DoubleExpression -> Expression.Multiply(a,b) :> Expression
        | _ -> failwith "The type of the expressions must be double."

    let Add_double (a : Expression) (b : Expression) =
        match a,b with
        | DoubleConstant(av), DoubleConstant(bv) -> Constant_double( av + bv)
        | DoubleConstant(v), (DoubleExpression as e) | (DoubleExpression as e) , DoubleConstant(v) when v = 0.0 -> e
        | DoubleExpression, DoubleExpression -> Expression.Add(a,b) :> Expression
        | _ -> failwith "The type of the expressions must be double."

    let Substract_double (a : Expression) (b : Expression) =
        match a,b with
        | DoubleConstant(av), DoubleConstant(bv) -> Constant_double(av - bv)
        | DoubleConstant(av), DoubleExpression when av = 0.0 -> Multiply_double (Constant_double -1.0) b
        | DoubleExpression, DoubleConstant(bv) when bv = 0.0 -> a 
        | DoubleExpression, DoubleExpression -> Expression.Subtract(a,b) :> Expression
        | _ -> failwith "The type of the expressions must be double."
    
    let Divide_double (a : Expression) (b : Expression) = 
        match a,b with
        | DoubleConstant(av), DoubleConstant(bv) -> Constant_double(av / bv)
        | DoubleConstant(av), DoubleExpression when av = 0.0 -> Constant_double 0.0
        | DoubleExpression, DoubleConstant(bv) when bv = 1.0 -> a
        | DoubleExpression, DoubleConstant(bv) when bv = 0.0 -> failwith "division by zero is not defined."
        | DoubleExpression, DoubleExpression -> Expression.Divide(a,b) :> Expression
        | _ -> failwith "The type of the expressions must be double."
 
    let rec Power_double (a : Expression) (b : Expression) =
        match a, b with
        | DoubleConstant(av),DoubleConstant(bv) -> Constant_double(Math.Pow(av,bv))
        | DoubleExpression, DoubleConstant(bv) when bv < 0.0 -> Divide_double (Constant_double 1.0) (Power_double a  (Constant_double (bv * -1.0)))
        | DoubleExpression, DoubleConstant(bv) when bv = 0.0 -> Constant_double 1.0
        | DoubleExpression, DoubleConstant(bv) when bv = 1.0 -> a
        | DoubleExpression, DoubleExpression -> Expression.Power(a,b) :> Expression
        | _ -> failwith "The type of the expressions must be double."  

    [<AutoOpen>]
    module Operators =
        let (@+) a b = Add_double a b
        let (@-) a b = Substract_double a b
        let (@*) a b = Multiply_double a b          
        let (@/) a b = Divide_double a b
        let (@^) a b = Power_double a b

    [<AutoOpen>]
    module Parameters =
        let PX = Parameter_double "x"
        let PXE = PX :> Expression
        let Unit = Constant_double 1.0
        let Zero = Constant_double 0.0

