# ASFLogger

A lightweight, extensible .NET logging library designed for applications that require structured logging to console, PostgreSQL, or other targets.

## Features

- ✅ Simple static logger for quick setup.
- ✅ Supports logging to console and PostgreSQL.

---

## Installation

Copy the source files into your .NET project. You can optionally organize the structure as a library.

---

## Quick Start (Static Logger)

1. Set an external logger (e.g., PostgreSQL logger):

```csharp
ASFLogger.Log("System started.");
ASFLogger.LogException(new Exception("Something went wrong"), "Startup");
ASFLogger.ExternalLogger = entry => new PostgresLogger("YourConnectionString").Write(entry);


