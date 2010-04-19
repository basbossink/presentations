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

# Features

- Sequence Epressions (List Comprehensions)
- Partial function application (currying)
- Higher order functions (map, fold, filter)
- Computation Expressions (Monads)

# Monads

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

- Funtor: M: C -> C
- unit: X -> M(X)
- join: M(M(X)) -> M(X)

# Monads

    class Monad m where
        (>>=) :: m a -> (a -> m b) -> m b
        return :: a -> m a

# Funtional concepts

- Tail Recursion
- Continuation passing style
- Closure
- Memoization
- Functors
- Monoids
