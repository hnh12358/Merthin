namespace Merthin.FSharp
open System
open System.Text
open System.Reflection
open System.Runtime.CompilerServices

module FSharpCodes =

       [<CompiledNameAttribute("TypeIdentifier")>]
       let rec typeIdentifier (typeObj : Type) =
           
           match typeObj with
           | x when x = typeof<Boolean> -> "bool"
           | x when x = typeof<Byte> -> "byte"
           | x when x = typeof<SByte> -> "sbyte"
           | x when x = typeof<Int16> -> "int16"
           | x when x = typeof<UInt16> -> "uint16"
           | x when x = typeof<Int32> -> "int"
           | x when x = typeof<UInt32> -> "uint32"
           | x when x = typeof<Int64> -> "int64"
           | x when x = typeof<UInt64> -> "uint64"
           | x when x = typeof<UIntPtr> -> "unativeint"
           | x when x = typeof<Char> -> "char"
           | x when x = typeof<String> -> "string"
           | x when x = typeof<Decimal> -> "decimal"
           | x when x = typeof<Void> -> "unit"
           | x when x = typeof<Single> -> "float32"
           | x when x = typeof<Double> -> "double"
           | x when x.IsGenericParameter -> String.Format("'{0}",x.Name)
           | x when x.IsGenericType ->
                    let genericTypeDefinition = x.GetGenericTypeDefinition()
                    //TODO: ADD CONSTRAINTS
                    match x with
                    //Tuples
                    | x when genericTypeDefinition = typedefof<Tuple<_>> ->
                             String.Format("{0}", x.GetGenericArguments() 
                                                  |> Array.map typeIdentifier 
                                                  |> Array.map box)

                    | x when genericTypeDefinition = typedefof<Tuple<_,_>> ->
                             String.Format("{0} * {1}", x.GetGenericArguments() 
                                                        |> Array.map typeIdentifier 
                                                        |> Array.map box )

                    | x when genericTypeDefinition = typedefof<Tuple<_,_,_>> ->
                             String.Format("{0} * {1} * {2}", 
                                           x.GetGenericArguments() 
                                           |> Array.map typeIdentifier 
                                           |> Array.map box)

                    | x when genericTypeDefinition = typedefof<Tuple<_,_,_,_>> ->
                             String.Format("{0} * {1} * {2} * {3}", 
                                           x.GetGenericArguments() 
                                           |> Array.map typeIdentifier 
                                           |> Array.map box)

                    | x when genericTypeDefinition = typedefof<Tuple<_,_,_,_,_>> ->
                             String.Format("{0} * {1} * {2} * {3} * {4}", 
                                           x.GetGenericArguments() 
                                           |> Array.map typeIdentifier 
                                           |> Array.map box)

                    | x when genericTypeDefinition = typedefof<Tuple<_,_,_,_,_,_>> ->
                             String.Format("{0} * {1} * {2} * {3} * {4} * {5}", 
                                           x.GetGenericArguments() 
                                           |> Array.map typeIdentifier 
                                           |> Array.map box)

                    | x when genericTypeDefinition = typedefof<Tuple<_,_,_,_,_,_,_>> ->
                             String.Format("{0} * {1} * {2} * {3} * {4} * {5} * {6}", 
                                           x.GetGenericArguments()
                                           |> Array.map typeIdentifier 
                                           |> Array.map box)

                    | x when genericTypeDefinition = typedefof<Tuple<_,_,_,_,_,_,_,_>> ->
                             String.Format("{0} * {1} * {2} * {3} * {4} * {5} * {6} * {7}", 
                                           x.GetGenericArguments() 
                                           |> Array.map typeIdentifier 
                                           |> Array.map box)

                    //Option
                    | x when genericTypeDefinition = typedefof<option<_>> ->
                             String.Format("{0} option", 
                                            x.GetGenericArguments() 
                                            |> Array.map typeIdentifier)

                    | x -> String.Format("{0}<{1}>", x.Name.Substring(0,x.Name.IndexOf("`")), x.GetGenericArguments() |> Array.map typeIdentifier |> String.join ",")

           | _ -> typeObj.Name

       [<CompiledNameAttribute("MethodIdentifier")>]
       let methodIdentifier (methodMember : MethodInfo) =

           let fixedOps = [("+","op_Addition");("-","op_Subtraction");("*","op_Multiply");("/","op_Division");
                          ("@","op_Append");("^","op_Concatenate");("%","op_Modulus");("&&&)","op_BitwiseAnd");
                          ("|||","op_BitwiseOr");("^^^","op_ExclusiveOr");("<<<","op_LeftShift");("~~~)","op_LogicalNot");
                          (">>>","op_RightShift");("~+","op_UnaryPlus");("~-","op_UnaryNegation");("=","op_Equality");
                          ("<>","op_Inequality");("<=","op_LessThanOrEqual");(">=","op_GreaterThanOrEqual");
                          ("<","op_LessThan");(">","op_GreaterThan");("?","op_Dynamic");("?<-","op_DynamicAssignment");
                          ("|>","op_PipeRight");("<|","op_PipeLeft");("!","op_Dereference");(">>","op_ComposeRight");
                          ("<<","op_ComposeLeft");("<@ @>","op_Quotation");("<@@ @@>","op_QuotationUntyped");
                          ("+=","op_AdditionAssignment");("-=","op_SubtractionAssignment");("*=","op_MultiplyAssignment");
                          ("/=","op_DivisionAssignment");("..","op_Range");(".. ..","op_RangeStep")]

           let combinedOps =  [("Bang","!");("Percent","%");("Amp","&");("Multiply","*");("Plus","+");
                               ("Minus","-");("Dot",".");("Divide","/");("Less","<");("Equals","=");
                               ("Greater",">");("Qmark","?");("At","@");("Hat","^");("Bar","|");("Twiddle","~")]              
         
           match methodMember with
           | x when x.IsStatic && x.Name.StartsWith("op_") ->
               let fixedOp = fixedOps |> List.tryFind (fun (_,name) -> methodMember.Name = name) 
               if fixedOp.IsSome then
                  String.Format("( {0} )",fst (fixedOp.Value))
               else
                  let replaced = String.replaceByList (methodMember.Name) combinedOps
                  String.Format("( {0} )",replaced.Substring(3))              
           | x -> x.Name

       [<CompiledNameAttribute("MethodSignature")>]
       let methodSignature (methodMember : MethodInfo) = 
           let methodIdentifier = methodIdentifier methodMember
           let parameters = methodMember.GetParameters()
                            |> Array.fold (fun (acc : StringBuilder) current -> acc.AppendFormat("{0} -> ",typeIdentifier(current.ParameterType)) ) (new StringBuilder())
           let signature = parameters.ToString() + typeIdentifier(methodMember.ReturnType)
           String.Format("{0} : {1}",methodIdentifier,signature) 