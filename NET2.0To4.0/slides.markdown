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
Time   VS        Framework   C# 
----- --------- ----------- -----
2005      2005        2.0    2.0 
2006      2005        3.0    2.0 
2008      2008        3.5    3.0 
2009  2008 SP1    3.5 SP1    3.0 
2010      2010        4.0    4.0 

# C# Features (3.0)
- Implicitly Typed Local Variables and Arrays
- Auto-Implemented Properties
- Object Initializers
- Collection Initializers
- Extension Methods
- Anonymous Types
- Lambda Expressions
- Query Keywords (LINQ)

# C# Features (4.0)
- Partial Method Definitions
- Dynamic
- Named and optional arguments
- Covariance
- Contravariance

# Implicitly Typed Local Variables
- `var` $\neq$ `object`
- compiler infers correct type
- still strongly typed 

~~~ { .Cs }
Dictionary<string,Func<string,double>> fred = 
    new Dictionary<string, Func<string,double>>();
~~~    

$\downarrow$

~~~ { .Cs }    
var fred = new Dictionary<string, Func<string,double>>();
~~~

# Auto-Implemented Properties
- compiler generates property backing member

~~~ { .Cs .numberLines}
public class Flinstone { 
    private string m_Name;
    public string Name {
        get { return m_Name; }
        set { m_Name = value; }
    }
}
~~~

$\downarrow$

~~~ { .Cs .numberLines}
public class Flinstone {
    public string Name { get; set; }
}
~~~

# Object Initializers
~~~ { .Cs }
var fred = new Flinstone { Name = "Fred" };
~~~

# Collection Initializers

~~~ { .Cs }
var fred = new List<int>() { 37, 42, 53 };
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

~~~ { .Cs .numberLines }
var flinstones = bedrockCitizins.Find(
    delegate(string c) { 
        return c.Lastname.Equals("Flinstone"); 
    });
~~~

$\downarrow$ 

~~~ { .Cs .numberLines }
var flinstones = bedrockCitizins.Find(
    c => c.Lastname.Equals("Flinstone"));
~~~

# Query keywords (LINQ)
- Language INtegrated Query
- Embedded SQL-like language
- LINQ to `{`objects, xml, SQL, ... `}`
- Provider model via `IQueryable<T>`
- mostly 'lazy'
- Set of extension methods in `System.Linq`
- 'Deferred' execution via `Expression`'s

~~~ { .Cs .numberLines }
var flinstones = from citizen in bedrockCitizens
                 where citizen.Name.Equals("Flinestone")
                 select citizen.Name;
~~~

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


# LINQ, $\lambda$ Expressions, Homoiconicity
- Homoiconic :
    + home = same
    + iconic = appearance
- LISP
- code is data, data is code

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
bool IsPythagoreanTriple(int opposite, int adjacent, int hypotenuse) {
    ...
}  
...
var fred = IsPythagoreanTripele(hypotenuse: 5, adjacent: 4, opposite: 3);
~~~

# Optional arguments
- Have a default value in definition
- Come after all required parameters

~~~ { .Cs .numberLines}
bool IsFlinstone(string firstName, string lastName = "Flinstone") {
    ...
}
if(IsFlinstone("Fred")) {
...
}
if(IsFlinstone("Barney", "Rubble"))
...
}
~~~

# Covariance
- Safe
- Implicit
- arrays, delegates, generics
- Preserves assignment compatibility
- `out` keyword for generic parameters

~~~ { .Cs .numberLines }
public interface IEnumerator<out T> : IDisposable, IEnumerator {
    T Current { get; }
    bool MoveNext();
    void Reset();
}
~~~

- Example

~~~ { .Cs .numberLines }
IEnumerable<String> strings = new List<String>();
IEnumerable<Object> objects = strings;
~~~

# Contravariance
- Safe
- Implicit
- arrays, delegates, generics
- `in` keyword for generic parameters

~~~ { .Cs .numberLines }
public interface IComparer<in T> {
    int Compare(T x, T y);
}
~~~

- Example

~~~ { .Cs .numberLines }
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
- BigInteger and Complex Numbers
- File System Enumeration Improvements
- Pipes
- Garbage Collection improvements
- Memory-Mapped Files
- ThreadPool Performance Enhancements
- Code Contracts

# .NET Framework 
- Dynamic Language Runtime (DLR)
- Managed Extensibility Framework (MEF)
- Task Parallel Library (TPL)
- Windows Presentation Foundation (WPF)
- Windows Communication Foundation (WCF)
- Windows Workflow Foundation (WF)


# Managed Extensibility Framework 

F\#
===
