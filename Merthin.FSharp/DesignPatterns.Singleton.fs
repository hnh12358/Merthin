﻿(*
 * Merthin Project         - (http://merthin.codeplex.com)
 * Horacio Núñez Hernández - (hnh12358 at gmail.com)
 * 23/06/2010
 *)

namespace Merthin.FSharp.DesignPatterns

type internal Singleton<'a when 'a : ( new : unit -> 'a )>()  =
     static let  m_instance = new 'a()
     static member Instance = m_instance
