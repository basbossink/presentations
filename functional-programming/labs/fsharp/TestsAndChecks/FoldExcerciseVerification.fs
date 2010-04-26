#light

open FsCheck
open System
open FoldExcercises

let prop_concat (xs:list<list<int>>) = 
    List.concat xs = FoldExcercises.concat (xs: list<list<int>>)

let prop_takeWhile (xs:seq<int>) = 
    let predicate x = x < 37
    Seq.takeWhile predicate xs = FoldExcercises.takeWhile predicate xs

let prop_groupBy predicate (xs: seq<int>) = 
    Seq.groupBy predicate xs = FoldExcercises.groupBy predicate xs

let equal x y = y % 3 = 0

type FoldExcercises = 
    static member concat = prop_concat
    static member takeWhile = prop_takeWhile
    static member groupBy = prop_groupBy

quickCheckAll (typeof<FoldExcercises>)

Console.ReadKey() |> ignore
