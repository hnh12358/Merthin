namespace Merthin.FSharp
open System
open System.Reflection

module FSharpCodes =

       let typeIdentifier (typeObj : Type) =
           match typeObj with
           | _ -> typeObj.Name

       let methodIdentifier (methodMember : MethodInfo) =

           let fixedOps = [("+","op_Addition");("-","op_Subtraction");("*","op_Multiply");("/","op_Division");
                          ("@","op_Append");("^","op_Concatenate");("%","op_Modulus");("&&&)","op_BitwiseAnd");
                          ("|||","op_BitwiseOr");("^^^","op_ExclusiveOr");("<<<","op_LeftShift");("~~~)","op_LogicalNot");
                          (">>>","op_RightShift");("~+","op_UnaryPlus");("~-","op_UnaryNegation");("=","op_Equality");
                          ("<=","op_LessThanOrEqual");(">=","op_GreaterThanOrEqual");("<","op_LessThan");
                          (">","op_GreaterThan");("?","op_Dynamic");("?<-","op_DynamicAssignment");
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

       let methodSignature (methodMember : MethodInfo) = 
           let methodIdentifier = methodIdentifier methodMember
           let parameters = methodMember.GetParameters()
                            |> Array.fold (fun x acc -> String.Format("{0} -> ",typeIdentifier(acc.ParameterType)) + x) String.Empty


           let signature = parameters + methodMember.ReturnType.Name
           String.Format("{0} : {1}",methodIdentifier,signature) 