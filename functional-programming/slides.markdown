% Functional Programming
% Bas Bossink
% March 2010

# Contents

- Introduction
- What is it?
- History
- Taxonomy
- Features of functional languages
- Functional concepts
- What is it good at?
- What is it bad at?
- Resources

# Introduction

- Disclaimer
- About this presentation
    + opensource under GFDL
    + on [github][gh]

[gh]: http://github.com/basbossink/presentations "Presentations on github"

# What is it?

- Functions are central construct
- Functions are mathematical  

![simple function](/parabola.png "A simple function")

# What is it?

- Same input -> same output
- No side effects
- No (global) state
- No *variables* but *binding* of values

# History

- Lambda calculus 
    + Alonzo Church 1930s
    + untyped lambda calculus
    + simply typed lambda calculus  

![timeline](/languages.png "Abbreviated genealogy of functional programming languages")

# Taxonomy

- Group functional languages accross several axis:
    + Statically typed / Dynamically typed
    + Strong typing / Weak typing
    + Lazy / Eager
    + Single paradigm / Multi paradigm

# Taxonomy

<object data="/dynamic-static-strong-weak.svg" type="image/svg+xml"/>

# Taxonomy 

<object data="/lazy-eager-single-multi.svg" type="image/svg+xml"/>

# Features

- Read Eval Print Loop (REPL)
- Type inference (var on steroids)
- Pattern matching
- Algabraic data types
- Function composition
- Anonymous functions (lambda expressions) 

# Features

- Sequence Expressions (List Comprehensions)
- Partial function application (currying)
- Higher order functions (map, fold, filter)
- Computation Expressions (Monads)

# Funtional concepts

- Tail Recursion
- Continuation passing style
- Closure
- Memoization
- Functors
- Monoids
