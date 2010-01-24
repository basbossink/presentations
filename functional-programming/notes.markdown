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
- Tools used:
    + pandoc (Haskell markup 2 markup transformer)
    + dot (graph layout engine)
    + Rake (ruby build automation)
    + git (source control)
    + vim (ide)
    + gnuplot (plotting graphs)

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
- untyped was shown to be logically inconsistent 
  due to Kleene-Rosser paradox
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
