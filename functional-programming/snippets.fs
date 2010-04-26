#light

//- Type inference 

let f a b = a*a + b*b

let g a b = sqrt (a*a + b*b)

let g (a : double) (b : double) = (a*a + b*b) |> sqrt 

//

//- Pattern matching

let rec fib n =
    match n with
    | 0 | 1 -> n
    | _ -> fib (n - 1) + fib (n - 2)

//

//- Algebraic datatypes

type Color = 
    | Red
    | Yellow
    | Blue

type Tree<'a>  = 
    | Tree of 'a * Tree<'a> * Tree<'a>
    | Empty

//

//- Function composition

let f = sqrt >> ((*) 3.14)

//

//- Anonymous functions

let adder a = fun n -> a + n
let add37 = adder 37

add37 42 

let cubes = List.map (fun n -> n * n * n)

cubes [3;4;5]

//

//- Partial application

let timespi = (*) 3 

timespi 4

//

//- Sequence Expressions

let ienumerable = seq { for i in 1..5 -> (i, i*i) }

let list = [ for i in 1..5 -> i * i ]

let array = [| for i in 1..5 -> i * i |]

//

//- Higher order functions

List.map (fun x -> x * x) [1..10]

//

//- Tail Recursion

open System.Numerics

let rec fact n = 
    if n = BigInteger.Zero then BigInteger.One 
    else n * (fact n-BigInteger.One)

fact (new BigInteger 10000)

let rec factTail n = 
    let rec aux i acc = 
        if i = BigInteger.Zero then acc
        else aux (i-BigInteger.One) (i*acc)
    aux n BigInteger.One

factTail (new BigInteger 10000)

//

//- Continuation passing style

type Tree =
    | Node of string * Tree * Tree
    | Tip of string

let rec naiveSize tree =
    match tree with
    | Tip _ -> 1
    | Node(_, left, right) -> 
        naiveSize left + naiveSize right

let rec sizeCont tree continuation =
    match tree with 
    | Tip _ -> continuation 1
    | Node (_, left, right) ->
        sizeCont left (fun leftSize -> 
            sizeCont right (fun rightSize -> 
                continuation (leftSize + rightSize)))

let size tree = sizeCont tree (fun x -> x)

//

//- Memoization

let rec fibNaive n = 
    if n <= 2 then 1 
    else fibNaive(n-1) + fibNaive(n-2)

fibNaive 43

let fibFast =
    let cache = new System.Collections.Generic.Dictionary<int,int>()
    let rec fibCached n = 
        if cache.ContainsKey(n) then cache.[n]
        else if n <= 2 then 1
        else let result = fibCached(n-1) + fibCached(n-2)
             cache.Add(n,result)
             result
    fun n -> fibCached n

fibFast 43

//

//- Workflows

//type 'a option = 
//    | None
//    | Some of 'a

type Attempt<'a> = (unit -> 'a option)

let succeed x = (fun () -> Some(x))
let fail      = (fun () -> None)
let runAttempt (a:Attempt<'a>) = a()
let bind p rest = match runAttempt p with None -> fail | Some r -> (rest r)
let delay f = (fun () -> runAttempt (f ()))

type AttemptBuilder() =
    /// Wraps an ordinary value into an Attempt value.
    /// Used to de-sugar uses of 'return' inside computation expressions.
    member b.Return(x) = succeed x

    /// Composes two attempt values. If the first returns Some(x) then the result
    /// is the result of running rest(x).
    /// Used to de-sugar uses of 'let!' inside computation expressions.
    member b.Bind(p,rest) = bind p rest

    /// Sequences two attempts. If the first returns Some(x) then the result
    /// is the result of running rest(x).
    /// Used to de-sugar computation expressions.
    member b.Delay(f) = delay f

    /// Used to de-sugar uses of 'let' inside computation expressions.
    member b.Let(p,rest) : Attempt<'a> = rest p

    member b.ReturnFrom(p : Attempt<'a> ) = p

let attempt = new AttemptBuilder()

let alwaysOne = attempt { return 1 }
let alwaysPair = attempt { return (1,"two") }

let failIfBig n = attempt { if n > 1000 then return! fail else return n }

let failIfEitherBig (inp1,inp2) =
        attempt { let! n1 = failIfBig inp1
                  let! n2 = failIfBig inp2
                  return (n1,n2) }

let sumIfBothSmall (inp1,inp2) =
        attempt { let! n1 = failIfBig inp1
                  let! n2 = failIfBig inp2
                  let sum = n1 + n2
                  return sum }

let sumIfBothSmall1 (inp1,inp2) =
    attempt { let! n1 = failIfBig inp1
              do printfn "Hey, n1 was small!"
              let! n2 = failIfBig inp2
              do printfn "n2 was also small!"
              let sum = n1 + n2
              return sum }

runAttempt(sumIfBothSmall1 (999,999))

runAttempt(sumIfBothSmall1 (999,1003))