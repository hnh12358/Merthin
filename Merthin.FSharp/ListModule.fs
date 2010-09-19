namespace Merthin.FSharp

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module List =
    
    let tupleRange first last =
        List.zip [first .. last] [first .. last]

    let public foldc fold first source  =
       source 
       |> List.fold(fun (c,previous) current -> (c + 1, fold previous current)) (0,first)

    let public foldi fold first source  =
       source 
       |> List.fold(fun (i,previous) current -> (i + 1, fold i previous current)) (0,first)
       |> snd

    let public foldic fold first source  =
       source 
       |> List.fold(fun (i,previous) current -> (i + 1, fold i previous current)) (0,first)

    let public MapEx f lst =
        let rec mapEx f lst (a) = 
            match lst with
            | [] | _::[] -> a                     
            | fst::snd::_ -> mapEx f (List.tail lst) (a @ [f fst snd])
        mapEx f lst ([])

    let public MapEx2 func lst1 lst2 =
        let rec mapEx2 f lst1 lst2 =
            match lst1, lst2 with
            | fst1::snd1::_,fst2::snd2::_ -> func fst1 snd1 fst2 snd2 :: mapEx2 f (List.tail lst1) (List.tail lst2) 
            | _ -> []
        requires (List.length lst1 = List.length lst2) "List must have the same length."
        mapEx2 lst1 lst2

    let rec public Flat lst =
        List.fold (fun previous current -> previous @ current) [] lst
    
    let rec public Flat3 lst =
        Flat (List.fold (fun previous current -> previous @ current) [] lst)

    let public Combine2 lst1 lst2 =
        let rec gen0 value lst2 accu =
            match lst2 with
            | [] -> accu
            | head::tail -> gen0 value tail (accu @ [(value,head)])
        let rec gen1 lst1 lst2 accu =
            match lst1 with
            | [] -> accu
            | head::tail -> gen1 tail lst2 (accu @ (gen0 head lst2 []))
        gen1 lst1 lst2 []

(*
    let rec public unzip lst =
        match lst with
        | [] -> []
        | head::tail -> (fst head) :: (TupleListToLists lst)

    let public unzip2 lst =
        let rec tupleListToLists2 lst (a,b)=
            match lst with
            | [] -> a,b
            | head::tail -> let ha,hb = head
                            tupleListToLists2 tail (a @ [ha],b @ [hb])
        tupleListToLists2 lst ([],[])
  
    let rec public unzip3 lst =
        let rec tupleListToLists3 lst (a,b,c)=
            match lst with
            | [] -> a,b,c
            | head::tail -> let ha,hb,hc = head
                            tupleListToLists3 tail (a @ [ha],b @ [hb],c @ [hc])
        tupleListToLists3 lst ([],[],[])
*)