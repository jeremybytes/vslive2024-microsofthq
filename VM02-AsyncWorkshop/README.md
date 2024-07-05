VM02 - Asynchronous and Parallel Programming in C#
============================

**To download just the labs, you can visit this repository:  
[https://github.com/jeremybytes/async-workshop-labs-only-2024](https://github.com/jeremybytes/async-workshop-labs-only-2024)**  


This project contains slides and code samples for the "Asynchronous and Parallel Programming in C#" workshop with Jeremy Clark.  

Overview and Objectives
-----------------------
Level: Intermediate  

Asynchronous programming is a critical skill to take full advantage of today's multi-core systems. But async programming brings its own set of issues. In this workshop, we'll work through some of those issues and get comfortable using parts of the .NET Task Parallel Library (TPL).  

We'll start by calling asynchronous methods using the Task Asynchronous Pattern (TAP), including how to handle exceptions and cancellation. With this in hand, we'll look at creating our own asynchronous methods and methods that use asynchronous libraries. Along the way, we'll see how to avoid deadlocks, how to isolate our code for easier async, and why it's important to stay away from "async void".  

In addition, we'll look at some patterns for running code in parallel, including using Parallel.ForEachAsync, channels, and other techniques. We'll see pros and cons so that we can use the right pattern for a particular problem.  

Throughout the day, we'll go hands-on with lab exercises to put these skills into practice.  

Objectives:  

* Use asynchronous methods with Task and await  
* Create asynchronous methods and libraries  
* How to avoid deadlocks and other pitfalls  
* Understand different parallel programming techniques  

Pre-Requisites:  

Basic understanding of C# and object-oriented programming (classes, inheritance, methods, and properties). No prior experience with asynchronous programming is necessary; we'll take care of that as we go.  

Attendee Requirements:

* You must provide your own laptop computer (Windows or Mac) for this hands-on lab.

* You need to have the .NET 6 SDK or .NET 8 SDK installed as well as the code editor of your choice (Visual Studio 2022 Community Edition or Visual Studio Code are both good (free) choices).

* Interactive labs, web application samples, and console samples will work with Windows, macOS, and Linux (anywhere .NET 6/8 will run).

* WPF desktop samples will only work on Windows machines. There are equivalent web and console examples for these projects.

Links:

* .NET 8.0 SDK
[https://dotnet.microsoft.com/en-us/download](https://dotnet.microsoft.com/en-us/download)

* Visual Studio 2022 (Community)
[https://visualstudio.microsoft.com/downloads/](https://visualstudio.microsoft.com/downloads/)
Note: Install the "ASP.NET and web development" workload for the labs and samples. Include ".NET desktop development" for "digit-display" sample and WPF-based samples.

* Visual Studio Code
[https://code.visualstudio.com/download](https://code.visualstudio.com/download)

Running the Samples
-------------------
The sample code use .NET 6 or .NET 8. The console and web samples will run on all Window, macOS, and Linux versions that support .NET. The desktop samples are Windows-only.

Samples have been tested with Visual Studio 2022 and Visual Studio Code.

All samples require the "Person.Service" web service be running. To start the service, navigate to the "Person.Service" folder from the command line and type "dotnet run".

Ex:
```
C:\understanding-async\People.Service> dotnet run
```  

The service can be found at [http://localhost:9874/people](http://localhost:9874/people)

Project Layout
--------------
The "DemoCode" folder contains the code samples used in the workshop.  
**Shared Projects**  
* *People.Service*  
A web service that supplies data for the sample projects.  
* *TaskAwait.Shared*  
A library with data types that are shared across projects (primarily the "Person" type).  
* *TaskAwait.Library*  
A library with asynchronous methods that access the web service. These methods are called in the various applications detailed below.  
Relevant file: **PersonReader.cs**

**Concurrent Samples**  
The Concurrent samples run asynchronous methods, get results, handle exceptions, and support cancellation (unless otherwise noted).
* *Concurrent.UI.Console*  
A console application  (Windows, macOS, Linux)  
Relevant file: **Program.cs**
* *Concurrent.UI.Desktop*  
A WPF desktop application (Windows only).  
Relevant file: **MainWindow.xaml.cs**  
* *Concurrent.UI. Web*  
A web application (Windows, macOS, Linux).  
Note: this application does not support cancellation.  
Relevant file: **Controllers/PeopleController.cs**  

**Parallel Samples**  
The Parallel samples use Task to run asynchronous methods in parallel - also get results, handle exceptions, and support cancellation (unless otherwise noted).
* *Parallel.Basic*  
A console application that does not support cancellation or error handling (Windows, macOS, Linux).  
Relevant file: **Program.cs**
* *Parallel.UI.Console*  
A console application (Windows, macOS, Linux).  
Relevant file: **Program.cs**
* *Parallel.UI.Desktop*  
A WPF desktop application (Windows only).  
Relevant file: **MainWindow.xaml.cs**  
* *Parallel.UI. Web*  
A web application (Windows, macOS, Linux).  
Note: this application does not support cancellation.  
Relevant file: **Controllers/PeopleController.cs**  

**Progress Reporting (Bonus Material)**  
The Progress Reporting samples show how to report progress from an asynchronous method - in this case, as a percentage complete. These also get results, handle exceptions, and support cancellation.
* *ProgressReport.UI.Console*  
A console application that reports percentage complete progress through text. Ex: "21% Complete". (Windows, macOS, Linux)  
Relevant file: **Program.cs**
* *Parallel.UI.Desktop*  
A WPF desktop application that  reports percentage complete progress through a graphical progress bar. (Windows only)  
Relevant file: **MainWindow.xaml.cs**  
* *TaskAwait.Library*  
This shared library contains a method that supports progress reporting.  
Relevant method:
```c#
public async Task<List<Person>> GetPeopleAsync(IProgress<int> progress,
    CancellationToken cancelToken = new CancellationToken()) {...}
```

Hands-On Labs  
--------------
The "Labs" folder contains hands-on labs. The labs are integrated throughout the workshop day.    

* [Lab 01 - Recommended Practices and Continuations](Labs/Lab01/)
* [Lab 02 - Adding Async to an Existing Application](Labs/Lab02/)
* [Lab 03 - Parallel Practices](Labs/Lab03/)
* [Lab BONUS - Working with AggregateException](Labs/LabBONUS-AggregateException/)
* [Lab BONUS - Unit Testing Asynchronous Methods](Labs/LabBONUS-UnitTesting/)

Each lab consists of the following:

* **Labxx-Instructions** (Markdown)  
A markdown file containing the lab instructions. This includes the scenario, a set of goals, and step-by-step instructions.  
This can be viewed on GitHub or in Visual Studio Code (just click the "Open Preview to the Side" button in the upper right corner).

* **Starter** (Folder)  
This folder contains the starting code for the lab.

* **Completed** (Folder)  
This folder contains the completed solution. If at any time, you get stuck during the lab, you can check this folder for a solution.

Additional Resources
--------------------
**Related Articles (by Jeremy)**
* Why Do You Have to Return "Task" Whenever You "await" Something in a Method in C#?  
  [Article](https://jeremybytes.blogspot.com/2023/08/why-do-you-have-to-return-task-whenever.html)  
  [Video](https://www.youtube.com/watch?v=3kuwLDibFDE)
* [Don't Use "Task.WhenAll" for Interdependent Tasks](https://jeremybytes.blogspot.com/2023/10/dont-use-taskwhenall-for-interdependent.html)  
* [Looking at Producer/Consumer Dependencies: Bounded vs. Unbounded Channels](https://jeremybytes.blogspot.com/2023/10/looking-at-producerconsumer.html)  
* [Producer/Consumer Exception Handling - A More Reliable Approach](https://jeremybytes.blogspot.com/2023/10/producerconsumer-exception-handling.html)  
* ["await.WhenAll" Shows 1 Exception - Here's How to See Them All](https://jeremybytes.blogspot.com/2020/09/await-taskwhenall-shows-one-exception.html)

**Video Series & Articles (by Jeremy)**  
Each of these has a lot of supporting links:  
* [I'll Get Back to You: Task, Await, and Asynchronous Programming in C#](http://www.jeremybytes.com/Demos.aspx#TaskAndAwait) (Includes progress reporting)  
* [Run Faster: Parallel Programming in C#](http://www.jeremybytes.com/Demos.aspx#ParallelProgramming)  
* [Learn to Love Lambdas in C# (and LINQ, ToO!)](http://www.jeremybytes.com/Demos.aspx#LLL)  
* [Get Func-y: Delegates in .NET](http://www.jeremybytes.com/Demos.aspx#GF)  

**BackgroundWorker Component**  
* [BackgroundWorker Component and .NET 6](https://github.com/jeremybytes/backgroundworker-dotnet6)  
* [BackgroundWorker Component - "I'm not Dead, Yet!"](https://jeremybytes.blogspot.com/2012/05/backgroundworker-component-im-not-dead.html)  
* [Keep Your UI Responsive with the BackgroundWorker Component](http://www.jeremybytes.com/Demos.aspx#KYUIR)  

**Other Resources**  
Stephen Cleary has lots of great articles, books, and practical advice.
* .NET 8 - [ConfigureAwait in .NET 8](https://blog.stephencleary.com/2023/11/configureawait-in-net-8.html) - Stephen Cleary
* [Don't Block on Async Code](https://blog.stephencleary.com/2012/07/dont-block-on-async-code.html) - Stephen Cleary
* [Async/Await - Best Practices in Asynchronous Programming](https://docs.microsoft.com/en-us/archive/msdn-magazine/2013/march/async-await-best-practices-in-asynchronous-programming) - Stephen Cleary

Stephen Toub has great articles, too (generally with advanced insights).
* [Do I Need to Dispose of Tasks?](https://devblogs.microsoft.com/pfxteam/do-i-need-to-dispose-of-tasks/) - Stephen Toub  
* [Understanding the Whys, Whats, and Whens of ValueTask](https://devblogs.microsoft.com/dotnet/understanding-the-whys-whats-and-whens-of-valuetask/) - Stephen Toub  

**Articles / Videos Suggested by prior Workshop Attendees**  
* [ASP.NET Core SynchronizationContext](https://blog.stephencleary.com/2017/03/aspnetcore-synchronization-context.html) by Stephen Cleary  
* [ConfigureAwait FAQ](https://devblogs.microsoft.com/dotnet/configureawait-faq/) by Stephen Toub  
* [There Is No Thread](https://blog.stephencleary.com/2013/11/there-is-no-thread.html) by Stephen Cleary  
* [C# Async/Await/Task Explained (Deep Dive)](https://www.youtube.com/watch?v=il9gl8MH17s) Video by Raw Coding

For more information, visit [jeremybytes.com](http://www.jeremybytes.com).