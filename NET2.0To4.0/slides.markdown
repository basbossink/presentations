% .NET 2.0 -> 4.0 What's new
% Bas Bossink
% August 2011
# Contents

- Introduction
- Time table
- C# 
- .NET Framework
- F#

# Introduction
- Goal
    + Introduction
    + Encouragement
- About
    + GFDL
    + on [github][gh]
    + *libre* tools

[gh]: http://github.com/basbossink/presentations "Presentations on github"

# Time table
Time   VS        Framework   C#   Theme
----- --------- ----------- ----- -----
2005      2005        2.0    2.0  Generics
2006      2005        3.0    2.0  WPF, WCF, WF
2008      2008        3.5    3.0  LINQ
2009  2008 SP1    3.5 SP1    3.0 
2010      2010        4.0    4.0  Dynamic, Parallel

# C# Features (3.0)
- Implicitly Typed Local Variables and Arrays
- Auto-Implemented Properties
- Collection Initializers
- Object Initializers
- Extension Methods
- Anonymous Types
- $\lambda$ Expressions
- Query Keywords (LINQ)

# C# Features (4.0)
- Partial Method Definitions
- Dynamic keyword
- Named and optional arguments
- Covariance
- Contravariance

# Implicitly Typed Local Variables
- `var` $\neq$ `object`
- Compiler infers correct type
- Still strongly typed 

~~~ { .Cs }
Dictionary<string,Func<string,double>> fred = 
    new Dictionary<string, Func<string,double>>();
~~~    

$\downarrow$

~~~ { .Cs }    
var fred = new Dictionary<string, Func<string,double>>();
~~~

# Auto-Implemented Properties
- Compiler generates property backing member

~~~ { .Cs }
public class Flinstone { 
    private string m_Name;
    public string Name {
        get { return m_Name; }
        set { m_Name = value; }
    }
}
~~~

$\downarrow$

~~~ { .Cs }
public class Flinstone {
    public string Name { get; set; }
}
~~~

# Collection Initializers
- Natural extension of array initializer syntax

~~~ { .Cs }
var fred = new List<int>() { 37, 42, 53 };
~~~

# Object Initializers
~~~ { .Cs }
var fred = new Flinstone { Name = "Fred" };
~~~

# Extension methods 
- Add methods to existing types
- No modification of original types
- No deriving
- Used extensively to provide LINQ 'helper' methods on `IEnumerable<T>`

~~~ { .Cs }
public static string YabaDabaDo(this Flinstone fred) {
    ...
}
...
var noise = fred.YabaDabaDo();
~~~

# Anonymous types 
- Main usage LINQ
- Types without a name

~~~ { .Cs }
var fred = new { Name = "Fred", Friend="Barney" };
~~~

# $\lambda$ Expressions
- shorter notation for anonymous methods

~~~ { .Cs }
var flinstones = bedrockCitizins.Find(
    delegate(string c) { 
        return c.Lastname.Equals("Flinstone"); 
    });
~~~

$\downarrow$ 

~~~ { .Cs }
var flinstones = bedrockCitizins.Find(
    c => c.Lastname.Equals("Flinstone"));
~~~

# Query keywords (LINQ)
- Language INtegrated Query
- Embedded SQL-like language
- LINQ to `{`objects, xml, ... `}`
- Mostly 'lazy'
- Extension methods on `IEnumerable<T>`,`IQuereable<T>` in `System.Linq`

# LINQ
- Extensible: 
    + `IQueryable<T>` 
    + Implementing query operators
- Examples:
    + LINQ To WMI
    + LINQ To MSI
    + LINQ To Excel
    + LINQ To Sharepoint
    + LINQ To Active Directory
    + LINQ To Simpsons


# Query keywords (LINQ)

<table>
<tr><td>- <code>from</code></td><td>- <code>let</code></td></tr>
<tr><td>- <code>where</code></td><td>- <code>ascending</code></td></tr>
<tr><td>- <code>select</code></td><td>- <code>descending</code></td></tr>
<tr><td>- <code>group</code></td><td>- <code>on</code></td></tr>
<tr><td>- <code>into</code></td><td>- <code>equals</code></td></tr>
<tr><td>- <code>orderby</code></td><td>- <code>in</code></td></tr>
<tr><td>- <code>join</code></td><td>- <code>by</code></td></tr>
</table>

# LINQ examples

~~~ { .Cs }
var flinstones = from citizen in bedrockCitizens
                 where citizen.Name.Equals("Flinestone")
                 select citizen.Name;

var pythagoreanTriples = from a in Enumerable.Range(1, 25)
                         from b in Enumerable.Range(a, 25 - a)
                         from c in Enumerable.Range(b, 25 - b)
                         where a * a + b * b == c * c
                         select Tuple.Create(a, b, c);
~~~

# LINQ, $\lambda$ Expressions, Homoiconicity
- 'Deferred' execution via `Expression`'s
- Homoiconic :
    + homo = same
    + iconic = appearance
- LISP
- Code is data, data is code

~~~ { .Cs }
Func<int, int> twiceD = x => x * 2; 
Expression<Func<int, int>> twiceE = x => x * 2;
~~~

# Partial Method Definitions

~~~ { .Cs }
// Definition in file1.cs
partial void onNameChanged();

// Implementation in file2.cs
partial void onNameChanged()
{
  // method body
}
~~~

# Dynamic
- For COM interop
- For interacting with dynamically typed languages (Iron-, -Python,
  -Ruby)
- `dynamic` almost everywhere you would use a type name
- Compile time errors $\rightarrow$ runtime errors
- Opens opportunities like `method_missing` meta-programming

# Dynamic Example
  
~~~ { .Cs } 
// Before the introduction of dynamic.
((Excel.Range)excelApp.Cells[1, 1]).Value2 = "Name";
Excel.Range range2008 = (Excel.Range)excelApp.Cells[1, 1];


// With dynamic 
excelApp.Cells[1, 1].Value = "Name";
Excel.Range range2010 = excelApp.Cells[1, 1];
~~~
 
# Named and optional arguments
- For COM interop
- For Microsoft Office Automation API
- Use name iso position to identify parameter
- Can be used for: 
    + methods
    + indexers
    + constructors
    + delegates

# Named arguments
- Declaration does not need to change

~~~ { .Cs }
bool IsFlinstone(
    string firstName, 
    string lastName) {
    ...
}  
...
var fred = IsFlinstone(
    lastName: "Rubble", 
    firstName: "Barney");
~~~

# Optional arguments
- Have a default value in definition
- Come after all required parameters

~~~ { .Cs }
bool IsFlinstone(
    string firstName, 
    string lastName = "Flinstone") {
    ...
}
if(IsFlinstone("Fred")) {
...
}
if(IsFlinstone("Barney", "Rubble")) {
...
}
~~~

# Covariance
- Convert narrow to wider 
- Safe
- Implicit
- arrays, delegates, generics
- Preserves assignment compatibility
- `out` keyword for generic parameters

~~~ { .Cs }
public interface IEnumerator<out T> : 
    IDisposable, 
    IEnumerator {
        T Current { get; }
        bool MoveNext();
        void Reset();
}
~~~

# Covariance Example

~~~ { .Cs }
IEnumerable<String> strings = new List<String>();
IEnumerable<Object> objects = strings;
~~~

# Contravariance
- Convert from wide to narrow
- Safe
- Implicit
- arrays, delegates, generics
- `in` keyword for generic parameters

~~~ { .Cs }
public interface IComparer<in T> {
    int Compare(T x, T y);
}
~~~

# Contravariance Example

~~~ { .Cs }
void PutOutside(object o) { .... }
Action<object> action = PutOutside;
Action<Flinstone> dinoAction = action;
~~~

# .NET Framework
- `HashSet<T>`
- `Func<...>` delegate declarations
- `Action<...>` delegate declarations
- `Tuple<...>`
- `ReaderWriterLockSlim`
- `BigInteger`
- `Complex`

# .NET Framework
- File System Enumeration Improvements
- Pipes
- Memory-Mapped Files
- Code Contracts
- ThreadPool Performance Enhancements
- Garbage Collection improvements

# .NET Framework 
- Dynamic Language Runtime (DLR)
- Task Parallel Library (TPL)
- Managed Extensibility Framework (MEF)
- Windows Presentation Foundation (WPF)
- Windows Communication Foundation (WCF)
- Windows Workflow Foundation (WF)

# Task Parallel Library
- `System.Threading.Tasks` namespace
- "Friends don't let friends create threads"
- Parallel LINQ

~~~ { .Cs }
Parallel.ForEach(sourceCollection, 
    item => Process(item));

Task<string> reportData2 = 
    Task.Factory.StartNew(() => GetFileData())
        .ContinueWith((x) => Analyze(x.Result))
        .ContinueWith((y) => Summarize(y.Result));

var pythagoreanTriples = 
    from a in Enumerable.Range(1, 25).AsParallel()
    from b in Enumerable.Range(a, 25 - a)
    from c in Enumerable.Range(b, 25 - b)
    where a * a + b * b == c * c
    select Tuple.Create(a, b, c);

~~~

F\#
===
- Multiparadigm
- Functional by default
- Statically typed
- Eager by default
- Syntax OCAML
- Type inference

# F# Features
- Discriminated unions
- Active Patterns
- Currying
- Higher order functions
- Sequence expressions
- Asynchronous workflows

<!--
% Copyright 2012 Bas Bossink <bas.bossink@gmail.com>.
% See the file LICENSE for copying conditions.
-->
