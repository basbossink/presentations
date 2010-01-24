#light

//- Type inference 

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
//

//- Partial application

let timespi = (*) 3 

//


let test c = 
    match c with 
    | Red -> "yummi"
    | Yellow -> "yugh"
    | Blue -> "delicious"

//- Local functions

let primes = 
    let rec sieve (p :: xs) = p :: (sieve (List.filter (fun x -> x % p <> 0) xs))
    sieve [2..200]