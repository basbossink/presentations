% Unit Testing
% Bas Bossink
% November 2010
% Copyright 2012 Bas Bossink <bas.bossink@gmail.com>.
% See the file LICENSE for copying conditions.

# Contents

- Introduction
- Definitions
- Inspiration
- Reality
- Where do we want to go?
- Next actions

# Introduction
- Goal
    + Common vocabulary
    + Defining next actions
- About
    + GFDL
    + on [github][gh]
    + *libre* tools
- Sources
    + [Working Effectively with Legacy Code Micheal C. Feathers][welc]
    + [xUnit Test Patterns Gerard Meszaros][xtp]
    + [Kata Casts][kc]
    + [Pragmatic Unit Testing in Java Andy Hunt, Dave Thomas][putj]
    
[gh]: http://github.com/basbossink/presentations "Presentations on github"
[welc]: http://www.amazon.com/Working-Effectively-Legacy-Michael-Feathers/dp/0131177052/ref=sr_1_1?s=books&ie=UTF8&qid=1289675186&sr=1-1 "Working Effectively with Legacy code"
[xtp]: http://xunitpatterns.com/ "xUnit Test Patterns"
[kc]: http://www.katacasts.com/ "Kata Casts"
[putj]: http://pragprog.com/titles/utj/pragmatic-unit-testing-in-java-with-junit "Pragmatic Unit Testing in Java"
[exmp]: http://www.exampler.com/ "Brian Marrick"
[agt]: http://www.amazon.com/Agile-Testing-Practical-Guide-Testers/dp/0321534468/ref=sr_1_1?ie=UTF8&qid=1297200292&sr=8-1 "Agile testing"

# Definitions
![](http://lh3.ggpht.com/_X3kaawac_g4/S3VCgzOuyQI/AAAAAAAAAvw/aww4Ui2N7LU/agile-testing-quadrants.JPG?imgmax=800 "agile testing quadrants")

[see: exampler.com][exmp]

[as dicusssed in Agile Testing][agt]


# Definitions
- Unit test
    + [WELC][welc] : A test that runs in less than 1/10th of a second
    and is small enough to help you localize problems when it fails.
    + [XTP][xtp] : A test that verifies the behavior of some small
    part of the overall system.
    + [wikipedia][wput] : In computer programming, unit testing is a
    method by which individual units of source code are tested to
    determine if they are fit for use. A unit is the smallest testable
    part of an application.
- Component Test :
    + Component : 
         - More granular 
         - Self contained
         - Clear responibillity
         - (deployable)
- SUT : System Under Test

# Good Unit Tests
- Run fast
    + 6000 classes => 6000 test fixtures
    + Avg. 3 test/fixture = 18.000 tests
    + Acceptable runtime 2-3 min. => 0.01 s/test
- Help localize problems
- Help improve quality
- Help understand SUT
- Reduce (and not introduce) risk
- Are easy to run
- Are easy to write and maintain

# Good Economics
![](http://xunitpatterns.com/Economics-Good.gif "Good testing economics")

[xunitpatterns.com][xtpge]

# Bad Economics
![](http://xunitpatterns.com/Economics-Bad.gif "Bad testing economics")

[xunitpatterns.com][xtpge]

[xtpge]: http://xunitpatterns.com/Goals%20of%20Test%20Automation.html#Economics of Test Automation "Good Economics of Test Automation"

# Good Unit Tests are A TRIP
- Automatic
- Thorough
- Repeatable
- Independent
- Professional

[pragmatic unit testing summary card][pragsum]

[pragsum]: http://media.pragprog.com/titles/utj/StandaloneSummary.pdf "Summary Card"

# It ain't a Unit Test when
- It talks to a database
- It communicates across a network
- It touches the filesystem
- It starts other processes
- It starts other threads
- It calls <code>Thread.Sleep(...)</code>

# Test Code Quality
- DRY
- DRY
- DRY
- DRY : don't repeat yourself

# Test Doubles

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Pattern             Purpose                                      Has Behavior  Injects indirect  Handles indirect                          Values provided by           Examples                             
                                                                               inputs into SUT   outputs of SUT                            test(er)                                                         
------------------- -------------------------------------------- ------------  ----------------- ----------------------------------------- ---------------------------- ------------------------------------
Test Double         Generic name for family                

Dummy Object        Attribute or Method Parameter                no            no, never called  no, never called                          no                           Null, "Ignored String", new Object() 

Test Stub           Verify indirect inputs of SUT                yes           yes               ignores them                              inputs                                                           

Test Spy            Verify indirect outputs of SUT               yes           optional          captures them for later verification      inputs (optional)                                                

Mock Object         Verify indirect outputs of SUT               yes           optional          verifies correctness against expectations outputs & inputs (optional)                                      

Fake Object         Run (unrunnable) tests (faster)              yes           no                uses them                                 none                         In-memory database emulator          

Temporary Test Stub Stand in for procedural code not yet written yes           no                uses them                                 none                         In-memory database emulator          
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


[wput]: http://en.wikipedia.org/wiki/Unit_test "Wikipedia Unit Test"

# Inspiration
- Positive filter
- Watch flow, kadanz
- Code Kata by [Robert C. Martin][ub] aka [Uncle Bob][ub]
    + ruby
    + calculate the list of primes that divide of a given number

[Katacast Uncle Bob Prime Factors][kata]

[kata]: http://vimeo.com/7762511 "Prime number kata"
[ub]: http://www.objectmentor.com/omTeam/martin_r.html "Bio for Robert C. Martin"

# Reality
- Happy medium
- Part of an interview with [Billy Hollis][bh] for [dotnetrocks][dnr]

[Excerpt of Billy Hollis interview][600]

[dnr]: http://www.dotnetrocks.com/Default.aspx ".NET Rocks"
[bh]: http://dotnetmasters.com/ "Billy Hollis"
[600]: http://www.dotnetrocks.com/default.aspx?showNum=600 "dotnetrocks show 600"

# Where do we want to go?

# Next actions
