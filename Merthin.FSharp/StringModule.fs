namespace Merthin.FSharp
open System

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module String =
    
    let trim (str : string ) = 
        str.Trim()
    
    let split (separator : string array) (options : StringSplitOptions) (str : string) = 
        str.Split(separator,options)
    
    let toCharArray (str : string) = 
        str.ToCharArray()
    
    let toStringArray (str : string) = 
        str.ToCharArray() 
        |> Array.map (string)
    
    let replace (oldStr : string) (newStr) (str : string) = 
        str.Replace(oldStr,newStr)

    let join (separator : string) (strs : seq<string>) = 
        String.Join(separator,strs)
    
    let reverse (str : string) = 
        str 
        |> toStringArray 
        |> Array.rev 
        |> join String.Empty
    
    let isPalindrome (str : string) = 
        seq {0 .. str.Length / 2} 
        |> Seq.forall(fun x -> str.[x] = str.[str.Length - x - 1])
    
    let add (str : string) str2 = 
        str2 + str
    
    let removeFromEnd (str : string) count = 
        str.Remove(str.Length - 1 - count)
    
    let replaceByList str pairs =
        let rec inner (pairs : (string * string) list) (str : String) =
            match pairs with
            | [] -> str
            | (oldStr,newStr)::tail -> inner tail (str.Replace(oldStr,newStr))
        inner pairs str