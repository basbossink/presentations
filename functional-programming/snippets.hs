{-- Type inference --}

f a b = a*a + b*b
g a b = sqrt (a*a + b*b)
h a b = sqrt $ a*a + b*b
l a b = sqrt $ a**2 + b**2


--\\


{-- Pattern matching --}

fib 0 = 0
fib 1 = 1
fib n = fib (n-2) + fib (n-1)

--\


{-- Algebraic datatypes --}

data Color = 
      Red
    | Yellow
    | Blue

data Tree a = Node a (Tree a) (Tree a)
            | Empty
            deriving (Show)
--\


{-- Partial application --}

timesPi = (*) 3

--\


