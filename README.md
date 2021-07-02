# Overview

This solution contains the DealerOn Coding Test projects, code, and unit tests.

# Implementation Notes

* I just threw together a Solution layout from a "get this done perspective". In more complex solutions, I would most likely add a lot more libraries and what-not. Sometimes even multiple test projects splitting out Unit, Integration, Acceptance, and Load tests.
* `ConsoleInputParser` shows knowledge of static classes / methods for non-instance based requirements.
* Definitely some missing Unit Test cases, but didn't want to go nuts since this is an interview project.
* Used xUnit Theories on some Unit Tests to show writing of tests without loops and logic inside of them.
* Did not achieve full code coverage, just wanted to show that I know about it and know how to use things like Coverlet, Cobertura, report-generator, and the dotnet tooling to get those metrics.
* Could have introduce usage of something like AutoMapper for mapping the Model -> Item DSL class, but didn't want to overcompliacte things.

# Technology Used

* [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)
* [.NET Core 5 SDK](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.301-windows-x64-installer)

# Code Coverage

If you decide to try using the code-coverage script, it requires having the .NET Core Runtime and Report Generator tooling installed.

* [.NET Core 5 Runtime](https://dotnet.microsoft.com/download/dotnet/5.0/runtime)
* `dotnet tool install -g dotnet-reportgenerator-globaltool`
