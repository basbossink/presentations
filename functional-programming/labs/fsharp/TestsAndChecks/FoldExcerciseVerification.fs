#light

open FsCheck
open System
open FoldExcercises
open System.Linq

let prop_concat (xs:list<list<int>>) = List.concat xs = FoldExcercises.concat (xs: list<list<int>>)

let predicate x = x < 37
let prop_takeWhile (xs: seq<int>) = xs.TakeWhile predicate = FoldExcercises.takeWhile predicate xs

Console.WriteLine("----------Check all toplevel properties----------------");
type Marker = member x.Null = ()
//if there are instances defined: (throws exception if not)
//overwriteGeneratorsByType (typeof<Marker>.DeclaringType)
quickCheckAll (typeof<Marker>.DeclaringType)

Console.ReadKey() |> ignore
