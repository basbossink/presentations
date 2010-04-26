#light
namespace FoldExcercises

module FoldExcercises =

/// write alternatives to the standard concat, takeWhile and groupBy functions
/// using a fold 

    let concat xs = List.fold List.append [] xs
    let takeWhile predicate xs = Seq.empty
    let groupBy predicate xs = Seq.empty
    