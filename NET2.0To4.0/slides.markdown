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

# C# Features
- Implicitly Typed Local Variables and Arrays
- Auto-Implemented Properties
- Object Initializers
- Collection Initializers
- Extension Methods
- Anonymous Types
- Lambda Expressions
- Query Keywords (LINQ)
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

$\Downarrow$

~~~ { .Cs }    
var fred = new Dictionary<string, Func<string,double>>();
~~~

# Auto-Implemented Properties
- compiler generates property backing member

~~~ { .Cs }
public class Flinstone { 
    private string m_Name;
    public string Name {
        get { return m_Name; }
        set { m_Name = value; }
    }
}
~~~

$\Downarrow$

~~~ { .Cs }
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

~~~ { .Cs}
var fred = new { Name = "Fred", Friend="Barney" };
~~~

# Lambda Expressions
- shorter notation for anonymous methods

~~~ { .Cs }
var flinstones = bedrockCitizins.Find(
    delegate(string c) { 
        return c.Lastname.Equals("Flinstone"); 
    });
~~~

$\Downarrow$ 

~~~ { .Cs }
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

~~~ { .Cs }
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
  
# Named and optional arguments

# Covariance

# Contravariance

# .NET Framework
- `HashSet<T>`
- `Func<...>` delegate declarations
- `Action<...>` delegate declarations
- `Tuple<...>`
- `ReaderWriterLockSlim`
- BigInteger and Complex Numbers
- Pipes
- Garbage Collection improvements
- ThreadPool Performance Enhancements
- Code Contracts
- Dynamic Language Runtime
- File System Enumeration Improvements
- Memory-Mapped Files
- Managed Extensibility Framework
- Task Parallel Library

F\#
===
