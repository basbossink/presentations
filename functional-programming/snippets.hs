{-- Type inference --}

let f a b = a^2 + b^2

let g a b = sqrt (a^2 + b^2)

let h a b = sqrt $ a^2 + b^2

let square = flip (^) 2

let hypo = sqrt . sum . map square
--\\


{-- Pattern matching --}

let fib 0 = 0
let fib 1 = 1
let fib n = fib (n-2) + fib (n-1)

--\\


{-- Algebraic datatypes --}

let data Color = 
      Red
    | Yellow
    | Blue

let data Tree a = Node a (Tree a) (Tree a)
            | Empty
            deriving (Show)
--\


{-- Partial application --}

let timesPi = (*) 3

--\


