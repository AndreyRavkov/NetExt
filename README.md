# Package: NetExt.Awaiter
Awaiter is a lightweight package for simplifying the management of multiple asynchronous tasks. It allows you to seamlessly await tasks with or without return values, combining them into a single, structured workflow. With tuple-based result handling, Awaiter helps you reduce boilerplate code and improves the readability of complex asynchronous operations.

Features:
- Simplifies Task Management
Combine tasks with and without return values into a single operation.
- Tuple-Based Results
Receive the results of tasks in a structured tuple format, supporting up to 20 returnable tasks.
- Mixed Task Support
Manage tasks with mixed return types while optionally awaiting non-returnable tasks.
- Clean Code
Reduce boilerplate code for Task.WhenAll and manual result extraction.

### Usage
#### Basic Usage:
```csharp
using NetExt.Awaiter;

// Tasks with return values
var task1 = Task.FromResult(10);
var task2 = Task.FromResult("Hello");

// Tasks without return values
var noResultTasks = new[] { Task.Delay(100), Task.Delay(200) };

// Await and combine results
var result = await AwaitExt.TasksAsync(task1, task2, noResultTasks);

Console.WriteLine(result.Item1); // Outputs: 10
Console.WriteLine(result.Item2); // Outputs: Hello
```

#### Handling Multiple Returnable Tasks
```csharp
var task1 = Task.FromResult(10);
var task2 = Task.FromResult("Hello");
var task3 = Task.FromResult(true);

var result = await AwaitExt.TasksAsync(task1, task2, task3);

Console.WriteLine(result.Item1); // 10
Console.WriteLine(result.Item2); // Hello
Console.WriteLine(result.Item3); // True
```

#### Working with Only Non-Returnable Tasks
```csharp
var noResultTasks = new[] { Task.Delay(100), Task.Delay(200) };

await AwaitExt.TasksAsync(noResultTasks);
```

### Benefits
- Improved Readability: Streamline asynchronous workflows with a clear and concise API.
- Flexibility: Supports up to 20 tasks with return values, making it suitable for large operations.
- Consistency: Combines returnable and non-returnable tasks in a unified method.

# Package: NetExt.Models
The package provides a set of core models and exceptions designed to simplify application development by offering reusable structures and standardized error handling. This package ensures consistency and clarity in managing data and exceptions across your application.

Models:
- IdNameModel: A simple model containing an Id and Name, ideal for representing key-value pairs or lookup entities.
- ListResult: A utility model for returning paginated or list-based results, commonly used in API responses. 

Exceptions:
- BadRequestException: Represents an HTTP 400 (Bad Request) error for invalid or malformed input.
- ForbiddenException: Represents an HTTP 403 (Forbidden) error for unauthorized access attempts.
- NotFoundException: Represents an HTTP 404 (Not Found) error for missing resources.
- UnAuthorizationException: Represents an HTTP 401 (Unauthorized) error for failed authentication.

Benefits:
- Standardization: Provides consistent models and exception handling throughout your application.
- Readability: Improves code clarity by using well-defined structures and error types.
- Ease of Use: Simplifies the development process with ready-to-use models and exceptions.

Use Cases:
- Define and share common models for API responses or data handling.
- Ensure unified exception handling for client-server communication.
- Improve the maintainability and scalability of your codebase.

# Package: NetExt.Strings
NetExt.Strings is a powerful utility library that extends string manipulation capabilities in .NET. It provides a variety of robust, easy-to-use methods for trimming, validating, transforming, encoding, and replacing string values. This package simplifies common string operations, improves code readability, and enhances productivity for .NET developers.

#### Key Features:
- String Validation: Check for null, empty, or whitespace values with optional trimming.
- Custom Replacements: Replace keys, characters, or substrings within strings using flexible methods.
- Base64 Encoding and Decoding: Seamlessly convert strings to and from Base64 with customizable encoding.
- Digit Extraction: Extract numeric values from strings with ease.
- String Joining: Combine collections of strings with a specified separator.
- Culture-Aware Conversion: Convert objects to strings using CultureInfo.InvariantCulture or a custom provider.
- Enhanced Trimming: Remove leading and trailing whitespaces with improved trimming functionality.

Example Usages:
```csharp
using NetExt.Strings;

// Trim a string
var trimmed = "  Hello World  ".TrimExt(); // Output: "Hello World"

// Validate string
var isNullOrVoid = "".IsNullOrVoidExt(); // Output: true

// Replace keys in a string
var replacements = new Dictionary<string, string> { { "World", "Universe" } };
var replaced = "Hello World".ReplaceExt(replacements); // Output: "Hello Universe"

// Base64 encoding
var base64 = "Hello".ToBase64Ext(); // Output: "SGVsbG8="
var decoded = base64.FromBase64Ext(); // Output: "Hello"

// Get digits from a string
var digits = "A1B2C3".GetOnlyDigitsExt(); // Output: 123

// Join strings
var joined = new[] { "one", "two", "three" }.JoinWithExt(", "); // Output: "one, two, three"
```

# Package NetExt.Core
This is list of daily-useful .net extensions

### Namespace: NetExt.Core.Actions

### Try Extensions
The TryExt class provides utility methods for safely executing synchronous and asynchronous actions with built-in support for exception handling and finalization logic. These methods are designed to simplify error-prone tasks by offering a clean, reusable, and configurable way to handle exceptions and ensure post-action cleanup.
```csharp
TryExt.Execute(
    action: () => { /* execute some action, with or without return result */ },
    /* optional */
    catchAction: (exception) => { Trace.WriteLine(exception.Message); },
    /* optional */
    finallyAction: () => { /* final action */ });

/* The same for async */
await TryExt.ExecuteAsync(...);
```

### Namespace: NetExt.Core.Require
The namespace provides utility methods to enforce object validity and condition checks at runtime. These methods are particularly useful for defensive programming, ensuring that objects meet necessary conditions before proceeding with execution.


### Namespace: NetExt.Core.Collections
The namespace class provides utility methods for working with collections in a more intuitive and streamlined way. These extensions help convert individual items into various collection types and simplify iteration over collections.

### ForEach Extension
The ForEachExt method is an extension for IEnumerable<T> that simplifies iterating over a collection by applying an action to each element. It reduces boilerplate code for loops, making your code cleaner and more expressive.

### Namespace: NetExt.Core.Common
The namespace class provides a utility method to validate nullable values at runtime. This extension is particularly useful for ensuring required parameters are not null, improving code reliability and reducing the need for repetitive null-checking logic.
```csharp
using NetExt.Core.Collections;

var numbers = new List<int> { 1, 2, 3, 4, 5 };

// Apply an action to each element
numbers.ForEachExt(number => Console.WriteLine(number * 2));
// Output:
// 2
// 4
// 6
// 8
// 10
```

### Namespace: NetExt.Core.Enums
The namespace provides an extension method for enums, allowing seamless conversion of enum values to their underlying integer representation. This simplifies handling enums in scenarios where integer values are required, such as database storage, serialization, or calculations.

Also, contains **Sort enum** provides a straightforward way to represent sorting directions, commonly used in ordering datasets, database queries, or collections. Its simplicity and clarity make it ideal for scenarios where sorting logic needs to be explicitly defined.
* ASC: Represents ascending order. Items are sorted from smallest to largest or in lexicographical order (A-Z).
* DESC: Represents descending order. Items are sorted from largest to smallest or in reverse lexicographical order (Z-A).

### Namespace: NetExt.Core.DateTime
The namespace provides a set of extension methods to enhance the functionality of System.DateTime. These methods simplify common operations like Unix time conversions and specifying the DateTimeKind for DateTime objects.

### MayBe Struct (Result pattern)
The `MayBe<T>` struct is a lightweight, readonly wrapper for managing nullable references with enhanced safety and expressiveness. It simplifies handling scenarios where a value may or may not exist, providing built-in methods for validation and error handling.
```csharp
interface IRepository
{
    Task<MayBe<UserEntity>> GetAsync(int id); 
}
...
MayBe<UserEntity> entity = await IRepository.GetAsync(123);
// check that entity exists or not
if (entity.Exists)
{
    // TBD
}
...
// OR
var entity = (await IRepository.GetAsync(123)).GetOrThrow("Entity");
// OR
var entity = await IRepository.GetAsync(123).GetOrThrow("Entity");
...

// return entity or throw exception
var result = entity.AssumeExists("error message");
```
