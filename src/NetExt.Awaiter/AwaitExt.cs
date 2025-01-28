namespace NetExt.Awaiter;

public static class AwaitExt
{
    public static Task TasksAsync(IEnumerable<Task> noResultTasks)
        => ExecuteAsync(Array.Empty<Task>(), noResultTasks);
    
    public static async Task<T1> TasksAsync<T1>(Task<T1> task1, IEnumerable<Task>? noResultTasks = null)
    {
        await ExecuteAsync([task1], noResultTasks).ConfigureAwait(false);
        return task1.GetAwaiter().GetResult();
    }
    
    public static async Task<(T1, T2)> TasksAsync<T1, T2>(
        Task<T1> task1, Task<T2> task2,
        IEnumerable<Task>? noResultTasks = null)
    {
        await ExecuteAsync([task1, task2], noResultTasks).ConfigureAwait(false);
        return (task1.GetAwaiter().GetResult(), task2.GetAwaiter().GetResult());
    }
    
    public static async Task<(T1, T2, T3)> TasksAsync<T1, T2, T3>(
        Task<T1> task1, Task<T2> task2, Task<T3> task3,
        IEnumerable<Task>? noResultTasks = null)
    {
        await ExecuteAsync([task1, task2, task3], noResultTasks).ConfigureAwait(false);
        return (task1.GetAwaiter().GetResult(), task2.GetAwaiter().GetResult(), task3.GetAwaiter().GetResult());
    }
    
    public static async Task<(T1, T2, T3, T4)> TasksAsync<T1, T2, T3, T4>(
        Task<T1> task1, Task<T2> task2, Task<T3> task3,
        Task<T4> task4,
        IEnumerable<Task>? noResultTasks = null)
    {
        await ExecuteAsync([task1, task2, task3], noResultTasks).ConfigureAwait(false);
        return (task1.GetAwaiter().GetResult(), task2.GetAwaiter().GetResult(), task3.GetAwaiter().GetResult(),
                    task4.GetAwaiter().GetResult());
    }
    
    public static async Task<(T1, T2, T3, T4, T5)> TasksAsync<T1, T2, T3, T4, T5>(
        Task<T1> task1, Task<T2> task2, Task<T3> task3,
        Task<T4> task4, Task<T5> task5,
        IEnumerable<Task>? noResultTasks = null)
    {
        await ExecuteAsync([task1, task2, task3], noResultTasks).ConfigureAwait(false);
        return (task1.GetAwaiter().GetResult(), task2.GetAwaiter().GetResult(), task3.GetAwaiter().GetResult(),
                    task4.GetAwaiter().GetResult(), task5.GetAwaiter().GetResult());
    }
    
    public static async Task<(T1, T2, T3, T4, T5, T6)> TasksAsync<T1, T2, T3, T4, T5, T6>(
        Task<T1> task1, Task<T2> task2, Task<T3> task3,
        Task<T4> task4, Task<T5> task5, Task<T6> task6,
        IEnumerable<Task>? noResultTasks = null)
    {
        await ExecuteAsync([task1, task2, task3], noResultTasks).ConfigureAwait(false);
        return (task1.GetAwaiter().GetResult(), task2.GetAwaiter().GetResult(), task3.GetAwaiter().GetResult(),
                    task4.GetAwaiter().GetResult(), task5.GetAwaiter().GetResult(), task6.GetAwaiter().GetResult());
    }
    
    public static async Task<(T1, T2, T3, T4, T5, T6, T7)> TasksAsync<T1, T2, T3, T4, T5, T6, T7>(
        Task<T1> task1, Task<T2> task2, Task<T3> task3,
        Task<T4> task4, Task<T5> task5, Task<T6> task6,
        Task<T7> task7,
        IEnumerable<Task>? noResultTasks = null)
    {
        await ExecuteAsync([task1, task2, task3], noResultTasks).ConfigureAwait(false);
        return (task1.GetAwaiter().GetResult(), task2.GetAwaiter().GetResult(), task3.GetAwaiter().GetResult(),
                    task4.GetAwaiter().GetResult(), task5.GetAwaiter().GetResult(), task6.GetAwaiter().GetResult(),
                    task7.GetAwaiter().GetResult());
    }
    
    public static async Task<(T1, T2, T3, T4, T5, T6, T7, T8)> TasksAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
        Task<T1> task1, Task<T2> task2, Task<T3> task3,
        Task<T4> task4, Task<T5> task5, Task<T6> task6,
        Task<T7> task7, Task<T8> task8,
        IEnumerable<Task>? noResultTasks = null)
    {
        await ExecuteAsync([task1, task2, task3], noResultTasks).ConfigureAwait(false);
        return (task1.GetAwaiter().GetResult(), task2.GetAwaiter().GetResult(), task3.GetAwaiter().GetResult(),
                   task4.GetAwaiter().GetResult(), task5.GetAwaiter().GetResult(), task6.GetAwaiter().GetResult(),
                   task7.GetAwaiter().GetResult(), task8.GetAwaiter().GetResult());
    }
    
    public static async Task<(T1, T2, T3, T4, T5, T6, T7, T8, T9)> TasksAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        Task<T1> task1, Task<T2> task2, Task<T3> task3,
        Task<T4> task4, Task<T5> task5, Task<T6> task6,
        Task<T7> task7, Task<T8> task8, Task<T9> task9,
        IEnumerable<Task>? noResultTasks = null)
    {
        await ExecuteAsync([task1, task2, task3], noResultTasks).ConfigureAwait(false);
        return (task1.GetAwaiter().GetResult(), task2.GetAwaiter().GetResult(), task3.GetAwaiter().GetResult(),
                   task4.GetAwaiter().GetResult(), task5.GetAwaiter().GetResult(), task6.GetAwaiter().GetResult(),
                   task7.GetAwaiter().GetResult(), task8.GetAwaiter().GetResult(), task9.GetAwaiter().GetResult());
    }
    
    public static async Task<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)> TasksAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
        Task<T1> task1, Task<T2> task2, Task<T3> task3,
        Task<T4> task4, Task<T5> task5, Task<T6> task6,
        Task<T7> task7, Task<T8> task8, Task<T9> task9,
        Task<T10> task10,
        IEnumerable<Task>? noResultTasks = null)
    {
        await ExecuteAsync([task1, task2, task3], noResultTasks).ConfigureAwait(false);
        return (task1.GetAwaiter().GetResult(), task2.GetAwaiter().GetResult(), task3.GetAwaiter().GetResult(),
                   task4.GetAwaiter().GetResult(), task5.GetAwaiter().GetResult(), task6.GetAwaiter().GetResult(),
                   task7.GetAwaiter().GetResult(), task8.GetAwaiter().GetResult(), task9.GetAwaiter().GetResult(),
                   task10.GetAwaiter().GetResult());
    }
    
    public static async Task<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11)> 
        TasksAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            Task<T1> task1, Task<T2> task2, Task<T3> task3,
            Task<T4> task4, Task<T5> task5, Task<T6> task6,
            Task<T7> task7, Task<T8> task8, Task<T9> task9,
            Task<T10> task10, Task<T11> task11,
            IEnumerable<Task>? noResultTasks = null)
    {
        await ExecuteAsync([task1, task2, task3], noResultTasks).ConfigureAwait(false);
        return (task1.GetAwaiter().GetResult(), task2.GetAwaiter().GetResult(), task3.GetAwaiter().GetResult(),
                   task4.GetAwaiter().GetResult(), task5.GetAwaiter().GetResult(), task6.GetAwaiter().GetResult(),
                   task7.GetAwaiter().GetResult(), task8.GetAwaiter().GetResult(), task9.GetAwaiter().GetResult(),
                   task10.GetAwaiter().GetResult(), task11.GetAwaiter().GetResult());
    }
    
    public static async Task<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12)> 
        TasksAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            Task<T1> task1, Task<T2> task2, Task<T3> task3,
            Task<T4> task4, Task<T5> task5, Task<T6> task6,
            Task<T7> task7, Task<T8> task8, Task<T9> task9,
            Task<T10> task10, Task<T11> task11, Task<T12> task12,
            IEnumerable<Task>? noResultTasks = null)
    {
        await ExecuteAsync([task1, task2, task3], noResultTasks).ConfigureAwait(false);
        return (task1.GetAwaiter().GetResult(), task2.GetAwaiter().GetResult(), task3.GetAwaiter().GetResult(),
                   task4.GetAwaiter().GetResult(), task5.GetAwaiter().GetResult(), task6.GetAwaiter().GetResult(),
                   task7.GetAwaiter().GetResult(), task8.GetAwaiter().GetResult(), task9.GetAwaiter().GetResult(),
                   task10.GetAwaiter().GetResult(), task11.GetAwaiter().GetResult(), task12.GetAwaiter().GetResult());
    }
    
    public static async Task<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13)> 
        TasksAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            Task<T1> task1, Task<T2> task2, Task<T3> task3,
            Task<T4> task4, Task<T5> task5, Task<T6> task6,
            Task<T7> task7, Task<T8> task8, Task<T9> task9,
            Task<T10> task10, Task<T11> task11, Task<T12> task12,
            Task<T13> task13,
            IEnumerable<Task>? noResultTasks = null)
    {
        await ExecuteAsync([task1, task2, task3], noResultTasks).ConfigureAwait(false);
        return (task1.GetAwaiter().GetResult(), task2.GetAwaiter().GetResult(), task3.GetAwaiter().GetResult(),
                   task4.GetAwaiter().GetResult(), task5.GetAwaiter().GetResult(), task6.GetAwaiter().GetResult(),
                   task7.GetAwaiter().GetResult(), task8.GetAwaiter().GetResult(), task9.GetAwaiter().GetResult(),
                   task10.GetAwaiter().GetResult(), task11.GetAwaiter().GetResult(), task12.GetAwaiter().GetResult(),
                   task13.GetAwaiter().GetResult());
    }
    
    public static async Task<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14)> 
        TasksAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            Task<T1> task1, Task<T2> task2, Task<T3> task3,
            Task<T4> task4, Task<T5> task5, Task<T6> task6,
            Task<T7> task7, Task<T8> task8, Task<T9> task9,
            Task<T10> task10, Task<T11> task11, Task<T12> task12,
            Task<T13> task13, Task<T14> task14,
            IEnumerable<Task>? noResultTasks = null)
    {
        await ExecuteAsync([task1, task2, task3], noResultTasks).ConfigureAwait(false);
        return (task1.GetAwaiter().GetResult(), task2.GetAwaiter().GetResult(), task3.GetAwaiter().GetResult(),
                   task4.GetAwaiter().GetResult(), task5.GetAwaiter().GetResult(), task6.GetAwaiter().GetResult(),
                   task7.GetAwaiter().GetResult(), task8.GetAwaiter().GetResult(), task9.GetAwaiter().GetResult(),
                   task10.GetAwaiter().GetResult(), task11.GetAwaiter().GetResult(), task12.GetAwaiter().GetResult(),
                   task13.GetAwaiter().GetResult(), task14.GetAwaiter().GetResult());
    }
    
    public static async Task<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15)> 
        TasksAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            Task<T1> task1, Task<T2> task2, Task<T3> task3,
            Task<T4> task4, Task<T5> task5, Task<T6> task6,
            Task<T7> task7, Task<T8> task8, Task<T9> task9,
            Task<T10> task10, Task<T11> task11, Task<T12> task12,
            Task<T13> task13, Task<T14> task14, Task<T15> task15,
            IEnumerable<Task>? noResultTasks = null)
    {
        await ExecuteAsync([task1, task2, task3], noResultTasks).ConfigureAwait(false);
        return (task1.GetAwaiter().GetResult(), task2.GetAwaiter().GetResult(), task3.GetAwaiter().GetResult(),
                   task4.GetAwaiter().GetResult(), task5.GetAwaiter().GetResult(), task6.GetAwaiter().GetResult(),
                   task7.GetAwaiter().GetResult(), task8.GetAwaiter().GetResult(), task9.GetAwaiter().GetResult(),
                   task10.GetAwaiter().GetResult(), task11.GetAwaiter().GetResult(), task12.GetAwaiter().GetResult(),
                   task13.GetAwaiter().GetResult(), task14.GetAwaiter().GetResult(), task15.GetAwaiter().GetResult());
    }
    
    public static async Task<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)> 
        TasksAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            Task<T1> task1, Task<T2> task2, Task<T3> task3,
            Task<T4> task4, Task<T5> task5, Task<T6> task6,
            Task<T7> task7, Task<T8> task8, Task<T9> task9,
            Task<T10> task10, Task<T11> task11, Task<T12> task12,
            Task<T13> task13, Task<T14> task14, Task<T15> task15,
            Task<T16> task16,
            IEnumerable<Task>? noResultTasks = null)
    {
        await ExecuteAsync([task1, task2, task3], noResultTasks).ConfigureAwait(false);
        return (task1.GetAwaiter().GetResult(), task2.GetAwaiter().GetResult(), task3.GetAwaiter().GetResult(),
                   task4.GetAwaiter().GetResult(), task5.GetAwaiter().GetResult(), task6.GetAwaiter().GetResult(),
                   task7.GetAwaiter().GetResult(), task8.GetAwaiter().GetResult(), task9.GetAwaiter().GetResult(),
                   task10.GetAwaiter().GetResult(), task11.GetAwaiter().GetResult(), task12.GetAwaiter().GetResult(),
                   task13.GetAwaiter().GetResult(), task14.GetAwaiter().GetResult(), task15.GetAwaiter().GetResult(),
                   task16.GetAwaiter().GetResult());
    }
    
    public static async Task<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17)> 
        TasksAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
            Task<T1> task1, Task<T2> task2, Task<T3> task3,
            Task<T4> task4, Task<T5> task5, Task<T6> task6,
            Task<T7> task7, Task<T8> task8, Task<T9> task9,
            Task<T10> task10, Task<T11> task11, Task<T12> task12,
            Task<T13> task13, Task<T14> task14, Task<T15> task15,
            Task<T16> task16, Task<T17> task17,
            IEnumerable<Task>? noResultTasks = null)
    {
        await ExecuteAsync([task1, task2, task3], noResultTasks).ConfigureAwait(false);
        return (task1.GetAwaiter().GetResult(), task2.GetAwaiter().GetResult(), task3.GetAwaiter().GetResult(),
                   task4.GetAwaiter().GetResult(), task5.GetAwaiter().GetResult(), task6.GetAwaiter().GetResult(),
                   task7.GetAwaiter().GetResult(), task8.GetAwaiter().GetResult(), task9.GetAwaiter().GetResult(),
                   task10.GetAwaiter().GetResult(), task11.GetAwaiter().GetResult(), task12.GetAwaiter().GetResult(),
                   task13.GetAwaiter().GetResult(), task14.GetAwaiter().GetResult(), task15.GetAwaiter().GetResult(),
                   task16.GetAwaiter().GetResult(), task17.GetAwaiter().GetResult());
    }
    
    public static async Task<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18)> 
        TasksAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
            Task<T1> task1, Task<T2> task2, Task<T3> task3,
            Task<T4> task4, Task<T5> task5, Task<T6> task6,
            Task<T7> task7, Task<T8> task8, Task<T9> task9,
            Task<T10> task10, Task<T11> task11, Task<T12> task12,
            Task<T13> task13, Task<T14> task14, Task<T15> task15,
            Task<T16> task16, Task<T17> task17, Task<T18> task18,
            IEnumerable<Task>? noResultTasks = null)
    {
        await ExecuteAsync([task1, task2, task3], noResultTasks).ConfigureAwait(false);
        return (task1.GetAwaiter().GetResult(), task2.GetAwaiter().GetResult(), task3.GetAwaiter().GetResult(),
                   task4.GetAwaiter().GetResult(), task5.GetAwaiter().GetResult(), task6.GetAwaiter().GetResult(),
                   task7.GetAwaiter().GetResult(), task8.GetAwaiter().GetResult(), task9.GetAwaiter().GetResult(),
                   task10.GetAwaiter().GetResult(), task11.GetAwaiter().GetResult(), task12.GetAwaiter().GetResult(),
                   task13.GetAwaiter().GetResult(), task14.GetAwaiter().GetResult(), task15.GetAwaiter().GetResult(),
                   task16.GetAwaiter().GetResult(), task17.GetAwaiter().GetResult(), task18.GetAwaiter().GetResult());
    }
    
    public static async Task<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19)> 
        TasksAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
            Task<T1> task1, Task<T2> task2, Task<T3> task3,
            Task<T4> task4, Task<T5> task5, Task<T6> task6,
            Task<T7> task7, Task<T8> task8, Task<T9> task9,
            Task<T10> task10, Task<T11> task11, Task<T12> task12,
            Task<T13> task13, Task<T14> task14, Task<T15> task15,
            Task<T16> task16, Task<T17> task17, Task<T18> task18,
            Task<T19> task19,
            IEnumerable<Task>? noResultTasks = null)
    {
        await ExecuteAsync([task1, task2, task3], noResultTasks).ConfigureAwait(false);
        return (task1.GetAwaiter().GetResult(), task2.GetAwaiter().GetResult(), task3.GetAwaiter().GetResult(),
                   task4.GetAwaiter().GetResult(), task5.GetAwaiter().GetResult(), task6.GetAwaiter().GetResult(),
                   task7.GetAwaiter().GetResult(), task8.GetAwaiter().GetResult(), task9.GetAwaiter().GetResult(),
                   task10.GetAwaiter().GetResult(), task11.GetAwaiter().GetResult(), task12.GetAwaiter().GetResult(),
                   task13.GetAwaiter().GetResult(), task14.GetAwaiter().GetResult(), task15.GetAwaiter().GetResult(),
                   task16.GetAwaiter().GetResult(), task17.GetAwaiter().GetResult(), task18.GetAwaiter().GetResult(),
                   task19.GetAwaiter().GetResult());
    }
    
    public static async Task<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20)> 
        TasksAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(
            Task<T1> task1, Task<T2> task2, Task<T3> task3,
            Task<T4> task4, Task<T5> task5, Task<T6> task6,
            Task<T7> task7, Task<T8> task8, Task<T9> task9,
            Task<T10> task10, Task<T11> task11, Task<T12> task12,
            Task<T13> task13, Task<T14> task14, Task<T15> task15,
            Task<T16> task16, Task<T17> task17, Task<T18> task18,
            Task<T19> task19, Task<T20> task20,
            IEnumerable<Task>? noResultTasks = null)
    {
        await ExecuteAsync([task1, task2, task3], noResultTasks).ConfigureAwait(false);
        return (task1.GetAwaiter().GetResult(), task2.GetAwaiter().GetResult(), task3.GetAwaiter().GetResult(),
                   task4.GetAwaiter().GetResult(), task5.GetAwaiter().GetResult(), task6.GetAwaiter().GetResult(),
                   task7.GetAwaiter().GetResult(), task8.GetAwaiter().GetResult(), task9.GetAwaiter().GetResult(),
                   task10.GetAwaiter().GetResult(), task11.GetAwaiter().GetResult(), task12.GetAwaiter().GetResult(),
                   task13.GetAwaiter().GetResult(), task14.GetAwaiter().GetResult(), task15.GetAwaiter().GetResult(),
                   task16.GetAwaiter().GetResult(), task17.GetAwaiter().GetResult(), task18.GetAwaiter().GetResult(),
                   task19.GetAwaiter().GetResult(), task20.GetAwaiter().GetResult());
    }
    
    private static async Task ExecuteAsync(
        IEnumerable<Task> resultTasks,
        IEnumerable<Task>? noResultTasks = null)
    {
        var tasks = resultTasks.Concat(noResultTasks ?? new List<Task>());
        
        // ReSharper disable once AsyncApostle.AsyncAwaitMayBeElidedHighlighting
        await Task.WhenAll(tasks).ConfigureAwait(false);
    }
}