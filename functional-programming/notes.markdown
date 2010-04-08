# Notes concerning Functional Programming Presentation

## Contents
- Taxonomy = classification

## Introduction

### Disclaimer

- No *real* project experience with FP
- Just read some books and did a few excercises

### About

- Opensource GFDL
- On github 
- Cross platform
- Tools used:
    + pandoc (Haskell markup 2 markup transformer)
    + dot (graph layout engine)
    + Rake (ruby build automation)
    + git (source control)
    + vim (ide)
    + gnuplot (plotting graphs)
    + perl
    + Miktex/latex 

## What is it?

### first class citizen

- comparison to OO: 
    + objects can be created
    + passed around
    + returned from methods
    + mutated
    + transformed into new objects
- support for operations on functions:
    + composition
    + (partial) application

### functions are mathematical

- same input, same output
- for each x there's 0 or 1 y value, never 2
  several x's can have the same y

## History

### Lambda calculus

- Research in foundations of mathematics
- formalise function definition, application, recursion
- typed is computationally weaker but logically consistent

### Timeline

- Lisp one of the first programming languages
    + predates C by 14 years
    + based on untyped lambda calculus
- Scheme attempt to clean-up Lisp
- Erlang also influenced by Prolog 
- CLOS Common Lisp Object System: OO added to Lisp
- OCaml is OO added to Caml
- Scala runs on both JVM and .Net
- F# syntax compatible with OCaml
- Haskell 2010 is about to be released
    + Haskell is designed by committee
    + Haskell was designed to focus research of typed, lazy functional
      languages
- Clojure a Lisp on the JVM

## Taxonomy

- Languages can be classified in different ways
- Next is rough sketch, no scale
- To see who your friends are

### Static/Dynamic, Strong/Weak

- Functional languages are mostly strongly typed
- Two basic camps still exist

### Lazy/Eager, Single/Multi-paradigm

- Erlang, really functional, Armstrong says: "Concurrency Oriented"
- Common Lisp, CLOS, Common Lisp Object System
- F#:
    + Funtional
    + Imperative
    + Object-Oriented
    + Language-Oriented
- Scala:
    + Functional
    + Object-Oriented

## Features

### Read Eval Print Loop (REPL)

- Also found in:
    + Python
    + Ruby
    + Scala

### Type inference

- Lately mostly doing Haskell, preperation a bit disappointing
  F# inference does not use info about signature sqrt
  Haskell does.

### Pattern matching
- Examples
- F# supports *Active Patterns* functions to be run as part of pattern matching
  Makes it possible to match over arbitrary types and paremeterize pattern 
  matching.

### Algabraic data types
- What's in a name
- Somewhat similar to `union`

### Function Composition

### Anonymous function (lamdba expressions)

#### Closure
 
>In computer science, a closure is a first-class function with free 
>variables that are bound in the lexical environment. Such a function is 
>said to be "closed over" its free variables. 

### Sequence Expressions (List Comprehensions)
- Think PowerShell ranges on steriods
- Also available in Python and Erlang
- F# generalizes list comprehensions to Sequence Expressions with syntactic sugar for seq, list and array

### Higher order functions
- functions that take functions as arguments or return functions
