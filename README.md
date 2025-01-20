# NetExt.Core
This is list of daily-useful .net extensions

### Namespace: NetExt.Core.Actions

### Await Extensions
The AwaitExt class provides utility methods for efficiently handling multiple asynchronous tasks, including tasks with and without return values. These extensions simplify combining, executing, and awaiting multiple tasks, making it easier to manage complex asynchronous workflows.
```csharp
var noResultTasks = new [] { Task.Delay(100), Task.Delay(200), Task.Delay(300) };
var result = await AwaitExt.TasksAsync(
                 /* taskas with returnresults */
                 DelayValueAsync<int>(InputValue1),
                 DelayValueAsync<string>(InputValue2),
                 /* options tasks without results */
                 noResultTasks);

Assert.True(result.Item1 == InputValue1);
Assert.True(result.Item2 == InputValue2);
```
#### Benefits:
1. Simplifies Asynchronous Workflows
Enables easy execution and awaiting of multiple tasks, avoiding complex Task.WhenAll and manual result extraction.
2. Supports Mixed Tasks
Handles both returnable and non-returnable tasks in a single method call.
3. Tuple Support for Results
Returns results in a clean, structured tuple format, making it easier to work with multiple outputs.
4. Scalability
Supports up to 20 tasks with return values, accommodating even the most complex workflows.

#### When to Use:
1. Combining Multiple Tasks
When you need to wait for multiple tasks, possibly with mixed return types.
2. Improved Readability
To reduce boilerplate code for managing Task.WhenAll and extracting results.

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

### Namespace: NetExt.Core.Models.*
Namespace contains the different models & exceptions:

Models:
* IdNameModel
* ListResult

Exceptions:
* BadRequestException
* ForbiddenException
* NotFoundException
* UnAuthorizationException

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

### Namespace: NetExt.Core.Strings
The namespace class provides a rich set of extension methods for enhancing string manipulation. These methods simplify common string operations such as trimming, checking for null or empty strings, encoding to Base64, and more, making string handling more efficient and expressive.
```csharp
// use with params or like default
// stringValue.IsNullOrVoidExt(checkWhiteSpace:false, trim: false)
// OR
// stringValue.IsNullOrVoidExt()

var stringValue = "some string here";
if (stringValue.IsNullOrVoidExt(checkWhiteSpace:false, trim: false)) {
    return false;
} else {
    return true;
}
```

