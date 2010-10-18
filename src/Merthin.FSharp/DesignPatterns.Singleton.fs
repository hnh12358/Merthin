namespace Merthin.FSharp.DesignPatterns

type internal Singleton<'a when 'a : ( new : unit -> 'a )>()  =
     static let  m_instance = new 'a()
     static member Instance = m_instance
