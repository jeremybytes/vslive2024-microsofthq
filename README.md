# Visual Studio Live! Microsoft HQ - August 2024  

## Description  
This repository contains slides and code samples for sessions presented at Visual Studio Live! Microsoft HQ - August 5-9, 2023.  

## Sessions  

**VM02 - Hands-On Lab: Asynchronous and Parallel Programming in C#**  
*Level: Intermediate*  

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

Resources:  
* Slides: [/VM02-AsyncWorkshop/SLIDES-Asynchronous-Programming-in-CSharp.pdf](./VM02-AsyncWorkshop/SLIDES-Asynchronous-Programming-in-CSharp.pdf)
* Resources: [/VM02-AsyncWorkshop/](./VM02-AsyncWorkshop/)  
* Labs (for easy download): *Coming Soon*

---  

**VT14 - Design Patters: Not Just for Architects**  
*Level: Introductory*  

Design patterns are not just for architects. In fact, you already use Design Patterns but probably don't know it. Observer, Facade, Iterator, Proxy - these are all patterns that allow us to better communicate our ideas with other developers. And once we understand the patterns, we can use solutions that people way smarter than us have already implemented. In this session, we'll take a look at several Gang of Four patterns that we regularly use without realizing it. Don't know who the Gang of Four is? Join us to find out.

You will learn:

* What design patterns are
* How you are already using design patterns (even if you don't realize it)
* How intentional use of patterns can lead to better software  

Resources:  
* Slides: [/VT14-DesignPatterns/SLIDES-DesignPatterns.pdf](./VT14-DesignPatterns/SLIDES-DesignPatterns.pdf)
* Sample Code: [/VT14-DesignPatterns/](./VT14-DesignPatterns/)

---

**VW02 - DI Why? Getting a Grip on Dependency Injection**  
*Level: Introductory / Intermediate*  

Many of our modern frameworks have Dependency Injection (DI) built in. But how do you use that effectively? We need to look at what DI is and why we want to use it. We'll look at the problems caused by tight coupling. Then we'll use some DI patterns such as constructor injection and property injection to break that tight coupling. We'll see how loosely-coupled applications are easier to extend and test. With a better understanding of the basic patterns, we'll remove the magic behind DI containers so that we can use the tools appropriately in our code.

You will learn:

* See the problems that DI can solve
* Understand DI by using it without a container
* See how a DI container can add some magic and reduce some code  

Resources:  
* Slides: [/VW02-DependencyInjection/SLIDES-DependencyInjection.pdf](./VW02-DependencyInjection/SLIDES-DependencyInjection.pdf)
* Sample Code: [/VW02-DependencyInjection/](./VW02-DependencyInjection/)

---

**VH13 - Fast Focus: Safer Code - Nullability and Null Operators in C#**  
*Level: Introductory / Intermediate*  

New projects in C# have nullable reference types enabled by default. This helps make the intent of our code more clear, and we can catch potential null references before they happen. But things can get confusing, particularly when migrating existing projects. In this session, you will learn about the safeguards that nullability provides as well as the problems you still need to watch out for yourself. In addition, you will learn the various null operators in C# (including null conditional, null coalescing, and null forgiving operators). These can make your code more expressive and safe.

You will learn:

* How compile-time warnings help you avoid null reference exceptions
*How to use nullability to make the intent of your code clear
* How to use the nullability operators: ?, !, ??  

Resources:  
* Slides: [/VH13-Nullability/SLIDES-FastFocus-Nullability.pdf](./VH13-Nullability/SLIDES-FastFocus-Nullability.pdf)
* Sample Code: [/VH13-Nullability/](./VH13-Nullability/)

---
    