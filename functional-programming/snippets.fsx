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

let f = sqrt >> sum 

//

//- Anonymous functions

let cubes = List.map (fun n -> n * n * n)

//

//- Local functions

let root a b c = 
    let discriminant = b*b - 4 * a * c
    (-b + sqrt (discriminant))/2 * a

//

//- Partial application

let timespi = (*) 3 

//


//- Local functions

let primes = 
    let rec sieve (p :: xs) = p :: (sieve (List.filter (fun x -> x % p <> 0) xs))
    sieve [2..200]
