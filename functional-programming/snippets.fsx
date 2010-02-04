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

let f = sqrt >> (*3.14)

//

//- Anonymous functions

let adder a = fun n -> a + n

let cubes = List.map (fun n -> n * n * n)

//

//- Partial application

let timespi = (*) 3 

//
