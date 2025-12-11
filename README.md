# CsvGridViewer

A small, production-quality .NET WinForms application that:

- Upload a CSV file into a grid
- Shows the clicked cell value in a separate dialog
- Logs all errors and key events to a text file on the user's Desktop

## Tech Stack

- **Framework:** .NET 8 (or later)
- **UI:** Windows Forms (WinForms)
- **Language:** C#
- **Testing:** xUnit
- **OS:** Windows

## Solution Structure

```text
CsvGridExplorer/
  CsvGridViewer.Core/
    CsvGridViewer.Core.csproj
    Services/
      ICsvParser.cs
      CsvParser.cs
      ILoggingService.cs
      FileLoggingService.cs

  CsvGridViewer.App/
    CsvGridViewer.App.csproj
    Program.cs
    MainForm.cs
    MainForm.Designer.cs
    CellDetailsForm.cs
    CellDetailsForm.Designer.cs
    Data/
      input.csv

  CsvGridViewer.Core.Tests/
    CsvGridViewer.Core.Tests.csproj
    CsvParserTests.cs
    FileLoggingServiceTests.cs
```

### Projects

- **CsvGridViewer.App**  
  WinForms UI application. Hosts the main grid and cell details dialog.  
  Depends on `CsvGridViewer.Core`.

- **CsvGridViewer.Core**  
  Class library containing:
  - `ICsvParser` / `CsvParser` – CSV reading and validation
  - `ILoggingService` / `FileLoggingService` – file-based logging

- **CsvGridViewer.Core.Tests**  
  xUnit test project with unit tests for:
  - CSV parsing behavior
  - Logging behavior

## Features

- **CSV → Grid**
  - Upload `Data/input.csv` or any valid csv format at startup.
  - Displays CSV content in a read-only `DataGridView`
  - Validates that all rows have the same number of columns

- **Cell Double-Click**
  - Double-click any cell to open a `CellDetailsForm`
  - Shows the exact cell value in a read-only, scrollable textbox

- **Error Logging**
  - Logs to a file on the Desktop:
    - File name: `CsvGridViewer.log`
    - Location: `%USERPROFILE%\Desktop` (via `Environment.SpecialFolder.DesktopDirectory`)
  - Logs:
    - Informational messages (e.g., CSV load start/success)
    - Errors (e.g., invalid/missing CSV, unexpected exceptions)
    - Unhandled UI & non-UI exceptions (via global handlers)


## Prerequisites

- **Windows OS**
- **.NET SDK 8.0 or later**  

IDE options (any one is fine):

- Visual Studio 2022 (Community or higher) with **“.NET desktop development”** workload  
  or
- Visual Studio Code with C# Dev Kit / C# extensions

## Getting Started

### 1. Clone or Download

```bash
git clone <your-repo-url> CsvGridViewer
cd CsvGridViewer
```

Or download the ZIP and extract it, then open the folder.

### 2. Restore & Build

From the solution root:

```bash
dotnet build ./CsvGridViewer.App/CsvGridViewer.App.csproj
```

### 3. Run Tests

```bash
dotnet test ./CsvGridViewer.Core.Tests/CsvGridViewer.Core.Tests.csproj
```

### 4. Run the Application

```bash
dotnet run --project CsvGridViewer.App
```

This will:

1. Start the WinForms application.
2. Upload a .csv extention file.
3. Display its content in a grid.

## Running from Visual Studio

1. Open the folder in Visual Studio (or create a solution around the three projects).
2. Set **`CsvGridViewer.App`** as the startup project.
3. Press **F5** (Run with Debugging) or **Ctrl+F5** (Run without Debugging).

## CSV Input

The default CSV file is:

`CsvGridViewer.App/Data/input.csv`

Example contents:

```text
1,2,3
4,5,6
7,8,9
10,11,12
13,14,15
```

- Each line is a row.
- Values are comma-separated.
- All rows are required to have the same number of columns; otherwise a `FormatException` is thrown and logged.

You can replace `input.csv` with your own file, as long as it follows the same basic structure.

## Logging

- Log file path is derived at runtime:

  ```csharp
  Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
  ```

- Final path:

  ```text
  %USERPROFILE%\Desktop\CsvGridViewer.log
  ```

- The `FileLoggingService`:
  - Creates the directory if needed
  - Appends log entries with timestamps and log levels.

- Logging failures are intentionally swallowed so the app never crashes just because logging failed.

## Error Handling

- CSV load errors:
  - Logged as `ERROR`
  - A user-friendly message box is shown.

- Double-click handler errors:
  - Logged as `ERROR`
  - The user sees an error message and the app remains running.


These ensure unexpected runtime errors are captured in the log file.

## Design & Coding Principles

- **Separation of Concerns**
  - UI logic is isolated in `CsvGridViewer.App`.
  - Core logic (parsing/logging) lives in `CsvGridViewer.Core` and is reusable/testable.

- **Dependency Injection Friendly**
  - UI depends on `ICsvParser` and `ILoggingService` abstractions.
  - Concrete implementations (`CsvParser`, `FileLoggingService`) are injected in `Program.cs`.

- **Fail Fast & Validate**
  - Guard clauses for null/empty arguments.
  - Explicit exceptions on invalid CSV structure.

- **Testable**
  - Core logic is covered by xUnit tests.
