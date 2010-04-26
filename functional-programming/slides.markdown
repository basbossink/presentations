% Functional Programming
% Bas Bossink
% March 2010

# Contents

- Introduction
- Definition
- History
- Taxonomy of functional languages
- Features of functional languages
- Functional concepts
- What is it good at?
- What is it bad at?
- Resources

# Introduction

- Anecdote
- Disclaimer
- About this presentation
    + opensource under GFDL
    + on [github][gh]

[gh]: http://github.com/basbossink/presentations "Presentations on github"

# Definition

- Functions are central construct
- Functions are *regular* values
    + passed around
    + returned 
    + composed
    + (partially) applied
- No *variables* but *binding* of values
    + all *variables* are __immutable__

# Definition of a Function

- Functions are mathematical  

# Example 

![](/parabola.png "A simple function")

# Non-example

![](/curve.png "A simple curve")

# Definition of a Function

- Same input -> same output
- No side effects, *pure*

# History

- Lambda calculus 
    + Alonzo Church 1930s
    + untyped lambda calculus
    + simply typed lambda calculus  

![](/languages.png "Abbreviated genealogy of functional programming languages")

# Taxonomy

- Group functional languages accross several axis:
    + Statically typed / Dynamically typed
    + Strong typing / Weak typing
    + Lazy / Eager
    + Single paradigm / Multi paradigm

# Taxonomy

![](/dynamic-static-strong-weak.png "dynamic vs. static and strong vs. weak typing") 

# Taxonomy 

![](/lazy-eager-single-multi.png "lazy vs eager evaluation and single vs multi-paradigm" )

# Features

- Read Eval Print Loop (REPL)
- Type inference (var on steroids)
- Pattern matching
- Algabraic data types
- Function composition
- Anonymous functions (lambda expressions) 
    + Closure

# Features

- Sequence Epressions (List Comprehensions)
- Partial function application (currying)
- Higher order functions (map, fold, filter)

# Funtional concepts

- Tail Recursion
- Continuation passing style
- Memoization

# Computation Expressions (Monads)

- Concept from mathematics, Category theory
- A triple:
    + type constructor
    + bind aka chain operation
    + return aka inject operation

# Category 

- a collection of elements
- a collection of morphisms (think function)
- a notion of composition of these morphisms
- Example **Grp**, **Set**, **Hask**

# Functor 

- Transformation between categories
- Given categorie C, D, functor F 
     + F : C -> D
     + f: A -> B then F(f) -> F(A) -> F(B)
- Examples: F: **Grp** -> **Set**, forgetful functor

# Monad 

- Functor: M: C -> C
- unit: X -> M(X)
- join: M(M(X)) -> M(X)

# Monads

    class Monad m where
        (>>=) :: m a -> (a -> m b) -> m b
        return :: a -> m a

# What is it good at?

- stateless
- data-transformations
- calculation /scientific computing
- parrallellism

# What is it bad at?

- a lotta state
- gui's

# Resources

- F#
    + [Expert F#][exp]
    + [Wikibook][wikib]
    + [Developer Center][devc]
    + [HubFs][hubfs] 
    
- Haskell
    + [Real World Haskell (book)][rwh]
    + [Real World Haskell online][rwho]
    + [Haskell.org][org]
    + [Haskell lectures Erik Meijer][mei]
    + [Yet another Haskell tutorial][yaht]

[devc]: http://msdn.microsoft.com/nl-nl/fsharp/default(en-us).aspx
[exp]: http://www.apress.com/book/view/1590598504
[wikib]: http://en.wikibooks.org/wiki/F_Sharp_Programming
[hubfs]: http://cs.hubfs.net/
[rwh]: http://oreilly.com/catalog/9780596514983/
[rwho]: http://book.realworldhaskell.org/read/index.html
[org]: http://www.haskell.org
[mei]: http://www.cs.nott.ac.uk/~gmh/book.html#videos
[yaht]: http://en.wikibooks.org/wiki/Haskell/YAHT

# Labs

- Haskell 
- F#
- fix code such that quickcheck/fscheck succeeds
- solutions on solution branch
- try [euler project][eul]

[eul]: http://projecteuler.net/
