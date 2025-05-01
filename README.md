# ASFLogger

A lightweight, extensible .NET logging library designed for applications that require structured logging to console, PostgreSQL, or other targets.

## Features

- ✅ Simple static logger for quick setup.
- ✅ Supports logging to console and PostgreSQL.
- ✅ Dependency Injection (DI) compatible version for ASP.NET Core or testable environments.

---

## Installation

Copy the source files into your .NET project. You can optionally organize the structure as a library.

---

## Quick Start (Static Logger)

1. Set an external logger (e.g., PostgreSQL logger):

```csharp
ASFLogger.ExternalLogger = entry => new PostgresLogger("YourConnectionString").Write(entry);
