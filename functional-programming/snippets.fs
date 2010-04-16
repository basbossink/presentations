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

open Microsoft.FSharp.Math
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

let f = sqrt >> (*3.14)

//

//- Anonymous functions

let adder a = fun n -> a + n
let add37 = adder 37
add37 42 
let cubes = List.map (fun n -> n * n * n)


//

//- Partial application

let timespi = (*) 3 

//

//- Sequence Expressions

seq { for i in 1..5 -> (i, i*i) }
[ for i in 1..5 -> i * i ]
[| for i in 1..5 -> i * i |]

//

//- Higher order functions

List.map (fun x -> x * x) [1..10]

//

//- Workflows


#light
type Attempt<'a> = (unit -> 'a option)

// ----------------------------
// Listing 9-6.

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

// ----------------------------

let sumIfBothSmall1 (inp1,inp2) =
    attempt { let! n1 = failIfBig inp1
              do printfn "Hey, n1 was small!"
              let! n2 = failIfBig inp2
              do printfn "n2 was also small!"
              let sum = n1 + n2
              return sum }


// ----------------------------

runAttempt(sumIfBothSmall1 (999,999))

runAttempt(sumIfBothSmall1 (999,1003))

// ----------------------------

let sumIfBothSmall2 (inp1,inp2) =
    attempt { let sum = ref 0
              let! n1 = failIfBig inp1
              do sum := sum.Value + n1
              let! n2 = failIfBig inp2
              do sum := sum.Value + n2
              return sum.Value }

let printThenSeven =
        attempt { do printf "starting..."
                  return 3 + 4 }

// -
