let rec fib n =
    match n with
    | 0 | 1 -> n
    | _ -> fib (n - 1) + fib (n - 2)

let timespi x = 3 * xe

let type Color = 
    | Red
    | Yellow
    | Blue

let test c = 
    match c with 
    | Red -> "yummi"
    | Yellow -> "yugh"
    | Blue -> "delicious"
