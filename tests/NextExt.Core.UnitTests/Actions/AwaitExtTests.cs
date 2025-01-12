using NetExt.Core.Actions;
using Xunit;

namespace NextExt.Core.UnitTests.Actions;

public class AwaitExtTests
{
    private const int InputValue1 = 101;
    private const int InputValue2 = 102;
    private const int InputValue3 = 103;
    private const int InputValue4 = 104;
    private const int InputValue5 = 105;
    private const int InputValue6 = 106;
    private const int InputValue7 = 107;
    private const int InputValue8 = 108;
    private const int InputValue9 = 109;
    private const int InputValue10 = 110;
    private const int InputValue11 = 201;
    private const int InputValue12 = 202;
    private const int InputValue13 = 203;
    private const int InputValue14 = 204;
    private const int InputValue15 = 205;
    private const int InputValue16 = 206;
    private const int InputValue17 = 207;
    private const int InputValue18 = 208;
    private const int InputValue19 = 209;
    private const int InputValue20 = 210;
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public static async Task Await_NoResult_Count_Test(uint noResultCount)
    {
        var noResultTasks = GenerateTasks(noResultCount);
        await AwaitExt.TasksAsync(noResultTasks);
        
        AssertTasksCompletedSuccessfully(noResultTasks);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public static async Task Await_Result_Count_1_Test(uint noResultCount)
    {
        var noResultTasks = GenerateTasks(noResultCount);
        var result = await AwaitExt.TasksAsync(DelayValueAsync(InputValue1), noResultTasks);
        
        Assert.True(result == InputValue1);
        AssertTasksCompletedSuccessfully(noResultTasks);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public static async Task Await_Result_Count_2_Test(uint noResultCount)
    {
        var noResultTasks = GenerateTasks(noResultCount);
        
        var result = await AwaitExt.TasksAsync(
                         DelayValueAsync(InputValue1),
                         DelayValueAsync(InputValue2),
                         noResultTasks);
        
        Assert.True(result.Item1 == InputValue1);
        Assert.True(result.Item2 == InputValue2);
        AssertTasksCompletedSuccessfully(noResultTasks);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public static async Task Await_Result_Count_3_Test(uint noResultCount)
    {
        var noResultTasks = GenerateTasks(noResultCount);
        var result = await AwaitExt.TasksAsync(
                         DelayValueAsync(InputValue1), DelayValueAsync(InputValue2), DelayValueAsync(InputValue3),
                         noResultTasks);
        
        Assert.True(result.Item1 == InputValue1);
        Assert.True(result.Item2 == InputValue2);
        Assert.True(result.Item3 == InputValue3);
        AssertTasksCompletedSuccessfully(noResultTasks);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public static async Task Await_Result_Count_4_Test(uint noResultCount)
    {
        var noResultTasks = GenerateTasks(noResultCount);
        var result = await AwaitExt.TasksAsync(
                         DelayValueAsync(InputValue1), DelayValueAsync(InputValue2), DelayValueAsync(InputValue3),
                         DelayValueAsync(InputValue4),
                         noResultTasks);
        
        Assert.True(result.Item1 == InputValue1);
        Assert.True(result.Item2 == InputValue2);
        Assert.True(result.Item3 == InputValue3);
        Assert.True(result.Item4 == InputValue4);
        AssertTasksCompletedSuccessfully(noResultTasks);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public static async Task Await_Result_Count_5_Test(uint noResultCount)
    {
        var noResultTasks = GenerateTasks(noResultCount);
        var result = await AwaitExt.TasksAsync(
                         DelayValueAsync(InputValue1), DelayValueAsync(InputValue2), DelayValueAsync(InputValue3),
                         DelayValueAsync(InputValue4), DelayValueAsync(InputValue5),
                         noResultTasks);
        
        Assert.True(result.Item1 == InputValue1);
        Assert.True(result.Item2 == InputValue2);
        Assert.True(result.Item3 == InputValue3);
        Assert.True(result.Item4 == InputValue4);
        Assert.True(result.Item5 == InputValue5);
        AssertTasksCompletedSuccessfully(noResultTasks);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public static async Task Await_Result_Count_6_Test(uint noResultCount)
    {
        var noResultTasks = GenerateTasks(noResultCount);
        var result = await AwaitExt.TasksAsync(
                         DelayValueAsync(InputValue1), DelayValueAsync(InputValue2), DelayValueAsync(InputValue3),
                         DelayValueAsync(InputValue4), DelayValueAsync(InputValue5), DelayValueAsync(InputValue6),
                         noResultTasks);

        Assert.True(result.Item1 == InputValue1);
        Assert.True(result.Item2 == InputValue2);
        Assert.True(result.Item3 == InputValue3);
        Assert.True(result.Item4 == InputValue4);
        Assert.True(result.Item5 == InputValue5);
        Assert.True(result.Item6 == InputValue6);
        AssertTasksCompletedSuccessfully(noResultTasks);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public static async Task Await_Result_Count_7_Test(uint noResultCount)
    {
        var noResultTasks = GenerateTasks(noResultCount);
        var result = await AwaitExt.TasksAsync(
                         DelayValueAsync(InputValue1), DelayValueAsync(InputValue2), DelayValueAsync(InputValue3),
                         DelayValueAsync(InputValue4), DelayValueAsync(InputValue5), DelayValueAsync(InputValue6),
                         DelayValueAsync(InputValue7),
                         noResultTasks);
        
        Assert.True(result.Item1 == InputValue1);
        Assert.True(result.Item2 == InputValue2);
        Assert.True(result.Item3 == InputValue3);
        Assert.True(result.Item4 == InputValue4);
        Assert.True(result.Item5 == InputValue5);
        Assert.True(result.Item6 == InputValue6);
        Assert.True(result.Item7 == InputValue7);
        AssertTasksCompletedSuccessfully(noResultTasks);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public static async Task Await_Result_Count_8_Test(uint noResultCount)
    {
        var noResultTasks = GenerateTasks(noResultCount);
        var result = await AwaitExt.TasksAsync(
                         DelayValueAsync(InputValue1), DelayValueAsync(InputValue2), DelayValueAsync(InputValue3),
                         DelayValueAsync(InputValue4), DelayValueAsync(InputValue5), DelayValueAsync(InputValue6),
                         DelayValueAsync(InputValue7), DelayValueAsync(InputValue8),
                         noResultTasks);
        
        Assert.True(result.Item1 == InputValue1);
        Assert.True(result.Item2 == InputValue2);
        Assert.True(result.Item3 == InputValue3);
        Assert.True(result.Item4 == InputValue4);
        Assert.True(result.Item5 == InputValue5);
        Assert.True(result.Item6 == InputValue6);
        Assert.True(result.Item7 == InputValue7);
        Assert.True(result.Item8 == InputValue8);
        AssertTasksCompletedSuccessfully(noResultTasks);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public static async Task Await_Result_Count_9_Test(uint noResultCount)
    {
        var noResultTasks = GenerateTasks(noResultCount);
        var result = await AwaitExt.TasksAsync(
                         DelayValueAsync(InputValue1), DelayValueAsync(InputValue2), DelayValueAsync(InputValue3),
                         DelayValueAsync(InputValue4), DelayValueAsync(InputValue5), DelayValueAsync(InputValue6),
                         DelayValueAsync(InputValue7), DelayValueAsync(InputValue8), DelayValueAsync(InputValue9),
                         noResultTasks);
        
        Assert.True(result.Item1 == InputValue1);
        Assert.True(result.Item2 == InputValue2);
        Assert.True(result.Item3 == InputValue3);
        Assert.True(result.Item4 == InputValue4);
        Assert.True(result.Item5 == InputValue5);
        Assert.True(result.Item6 == InputValue6);
        Assert.True(result.Item7 == InputValue7);
        Assert.True(result.Item8 == InputValue8);
        Assert.True(result.Item9 == InputValue9);
        AssertTasksCompletedSuccessfully(noResultTasks);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public static async Task Await_Result_Count_10_Test(uint noResultCount)
    {
        var noResultTasks = GenerateTasks(noResultCount);
        var result = await AwaitExt.TasksAsync(
                         DelayValueAsync(InputValue1), DelayValueAsync(InputValue2), DelayValueAsync(InputValue3),
                         DelayValueAsync(InputValue4), DelayValueAsync(InputValue5), DelayValueAsync(InputValue6),
                         DelayValueAsync(InputValue7), DelayValueAsync(InputValue8), DelayValueAsync(InputValue9),
                         DelayValueAsync(InputValue10),
                         noResultTasks);
        
        Assert.True(result.Item1 == InputValue1);
        Assert.True(result.Item2 == InputValue2);
        Assert.True(result.Item3 == InputValue3);
        Assert.True(result.Item4 == InputValue4);
        Assert.True(result.Item5 == InputValue5);
        Assert.True(result.Item6 == InputValue6);
        Assert.True(result.Item7 == InputValue7);
        Assert.True(result.Item8 == InputValue8);
        Assert.True(result.Item9 == InputValue9);
        Assert.True(result.Item10 == InputValue10);
        AssertTasksCompletedSuccessfully(noResultTasks);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public static async Task Await_Result_Count_11_Test(uint noResultCount)
    {
        var noResultTasks = GenerateTasks(noResultCount);
        var result = await AwaitExt.TasksAsync(
                         DelayValueAsync(InputValue1), DelayValueAsync(InputValue2), DelayValueAsync(InputValue3),
                         DelayValueAsync(InputValue4), DelayValueAsync(InputValue5), DelayValueAsync(InputValue6),
                         DelayValueAsync(InputValue7), DelayValueAsync(InputValue8), DelayValueAsync(InputValue9),
                         DelayValueAsync(InputValue10), DelayValueAsync(InputValue11),
                         noResultTasks);
        
        Assert.True(result.Item1 == InputValue1);
        Assert.True(result.Item2 == InputValue2);
        Assert.True(result.Item3 == InputValue3);
        Assert.True(result.Item4 == InputValue4);
        Assert.True(result.Item5 == InputValue5);
        Assert.True(result.Item6 == InputValue6);
        Assert.True(result.Item7 == InputValue7);
        Assert.True(result.Item8 == InputValue8);
        Assert.True(result.Item9 == InputValue9);
        Assert.True(result.Item10 == InputValue10);
        Assert.True(result.Item11 == InputValue11);
        AssertTasksCompletedSuccessfully(noResultTasks);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public static async Task Await_Result_Count_12_Test(uint noResultCount)
    {
        var noResultTasks = GenerateTasks(noResultCount);
        var result = await AwaitExt.TasksAsync(
                         DelayValueAsync(InputValue1), DelayValueAsync(InputValue2), DelayValueAsync(InputValue3),
                         DelayValueAsync(InputValue4), DelayValueAsync(InputValue5), DelayValueAsync(InputValue6),
                         DelayValueAsync(InputValue7), DelayValueAsync(InputValue8), DelayValueAsync(InputValue9),
                         DelayValueAsync(InputValue10), DelayValueAsync(InputValue11), DelayValueAsync(InputValue12),
                         noResultTasks);
        
        Assert.True(result.Item1 == InputValue1);
        Assert.True(result.Item2 == InputValue2);
        Assert.True(result.Item3 == InputValue3);
        Assert.True(result.Item4 == InputValue4);
        Assert.True(result.Item5 == InputValue5);
        Assert.True(result.Item6 == InputValue6);
        Assert.True(result.Item7 == InputValue7);
        Assert.True(result.Item8 == InputValue8);
        Assert.True(result.Item9 == InputValue9);
        Assert.True(result.Item10 == InputValue10);
        Assert.True(result.Item11 == InputValue11);
        Assert.True(result.Item12 == InputValue12);
        AssertTasksCompletedSuccessfully(noResultTasks);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public static async Task Await_Result_Count_13_Test(uint noResultCount)
    {
        var noResultTasks = GenerateTasks(noResultCount);
        var result = await AwaitExt.TasksAsync(
                         DelayValueAsync(InputValue1), DelayValueAsync(InputValue2), DelayValueAsync(InputValue3),
                         DelayValueAsync(InputValue4), DelayValueAsync(InputValue5), DelayValueAsync(InputValue6),
                         DelayValueAsync(InputValue7), DelayValueAsync(InputValue8), DelayValueAsync(InputValue9),
                         DelayValueAsync(InputValue10), DelayValueAsync(InputValue11), DelayValueAsync(InputValue12),
                         DelayValueAsync(InputValue13),
                         noResultTasks);
        
        Assert.True(result.Item1 == InputValue1);
        Assert.True(result.Item2 == InputValue2);
        Assert.True(result.Item3 == InputValue3);
        Assert.True(result.Item4 == InputValue4);
        Assert.True(result.Item5 == InputValue5);
        Assert.True(result.Item6 == InputValue6);
        Assert.True(result.Item7 == InputValue7);
        Assert.True(result.Item8 == InputValue8);
        Assert.True(result.Item9 == InputValue9);
        Assert.True(result.Item10 == InputValue10);
        Assert.True(result.Item11 == InputValue11);
        Assert.True(result.Item12 == InputValue12);
        Assert.True(result.Item13 == InputValue13);
        AssertTasksCompletedSuccessfully(noResultTasks);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public static async Task Await_Result_Count_14_Test(uint noResultCount)
    {
        var noResultTasks = GenerateTasks(noResultCount);
        var result = await AwaitExt.TasksAsync(
                         DelayValueAsync(InputValue1), DelayValueAsync(InputValue2), DelayValueAsync(InputValue3),
                         DelayValueAsync(InputValue4), DelayValueAsync(InputValue5), DelayValueAsync(InputValue6),
                         DelayValueAsync(InputValue7), DelayValueAsync(InputValue8), DelayValueAsync(InputValue9),
                         DelayValueAsync(InputValue10), DelayValueAsync(InputValue11), DelayValueAsync(InputValue12),
                         DelayValueAsync(InputValue13), DelayValueAsync(InputValue14),
                         noResultTasks);
        
        Assert.True(result.Item1 == InputValue1);
        Assert.True(result.Item2 == InputValue2);
        Assert.True(result.Item3 == InputValue3);
        Assert.True(result.Item4 == InputValue4);
        Assert.True(result.Item5 == InputValue5);
        Assert.True(result.Item6 == InputValue6);
        Assert.True(result.Item7 == InputValue7);
        Assert.True(result.Item8 == InputValue8);
        Assert.True(result.Item9 == InputValue9);
        Assert.True(result.Item10 == InputValue10);
        Assert.True(result.Item11 == InputValue11);
        Assert.True(result.Item12 == InputValue12);
        Assert.True(result.Item13 == InputValue13);
        Assert.True(result.Item14 == InputValue14);
        AssertTasksCompletedSuccessfully(noResultTasks);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public static async Task Await_Result_Count_15_Test(uint noResultCount)
    {
        var noResultTasks = GenerateTasks(noResultCount);
        var result = await AwaitExt.TasksAsync(
                         DelayValueAsync(InputValue1), DelayValueAsync(InputValue2), DelayValueAsync(InputValue3),
                         DelayValueAsync(InputValue4), DelayValueAsync(InputValue5), DelayValueAsync(InputValue6),
                         DelayValueAsync(InputValue7), DelayValueAsync(InputValue8), DelayValueAsync(InputValue9),
                         DelayValueAsync(InputValue10), DelayValueAsync(InputValue11), DelayValueAsync(InputValue12),
                         DelayValueAsync(InputValue13), DelayValueAsync(InputValue14), DelayValueAsync(InputValue15),
                         noResultTasks);
        
        Assert.True(result.Item1 == InputValue1);
        Assert.True(result.Item2 == InputValue2);
        Assert.True(result.Item3 == InputValue3);
        Assert.True(result.Item4 == InputValue4);
        Assert.True(result.Item5 == InputValue5);
        Assert.True(result.Item6 == InputValue6);
        Assert.True(result.Item7 == InputValue7);
        Assert.True(result.Item8 == InputValue8);
        Assert.True(result.Item9 == InputValue9);
        Assert.True(result.Item10 == InputValue10);
        Assert.True(result.Item11 == InputValue11);
        Assert.True(result.Item12 == InputValue12);
        Assert.True(result.Item13 == InputValue13);
        Assert.True(result.Item14 == InputValue14);
        Assert.True(result.Item15 == InputValue15);
        AssertTasksCompletedSuccessfully(noResultTasks);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public static async Task Await_Result_Count_16_Test(uint noResultCount)
    {
        var noResultTasks = GenerateTasks(noResultCount);
        var result = await AwaitExt.TasksAsync(
                         DelayValueAsync(InputValue1), DelayValueAsync(InputValue2), DelayValueAsync(InputValue3),
                         DelayValueAsync(InputValue4), DelayValueAsync(InputValue5), DelayValueAsync(InputValue6),
                         DelayValueAsync(InputValue7), DelayValueAsync(InputValue8), DelayValueAsync(InputValue9),
                         DelayValueAsync(InputValue10), DelayValueAsync(InputValue11), DelayValueAsync(InputValue12),
                         DelayValueAsync(InputValue13), DelayValueAsync(InputValue14), DelayValueAsync(InputValue15),
                         DelayValueAsync(InputValue16),
                         noResultTasks);
        
        Assert.True(result.Item1 == InputValue1);
        Assert.True(result.Item2 == InputValue2);
        Assert.True(result.Item3 == InputValue3);
        Assert.True(result.Item4 == InputValue4);
        Assert.True(result.Item5 == InputValue5);
        Assert.True(result.Item6 == InputValue6);
        Assert.True(result.Item7 == InputValue7);
        Assert.True(result.Item8 == InputValue8);
        Assert.True(result.Item9 == InputValue9);
        Assert.True(result.Item10 == InputValue10);
        Assert.True(result.Item11 == InputValue11);
        Assert.True(result.Item12 == InputValue12);
        Assert.True(result.Item13 == InputValue13);
        Assert.True(result.Item14 == InputValue14);
        Assert.True(result.Item15 == InputValue15);
        Assert.True(result.Item16 == InputValue16);
        AssertTasksCompletedSuccessfully(noResultTasks);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public static async Task Await_Result_Count_17_Test(uint noResultCount)
    {
        var noResultTasks = GenerateTasks(noResultCount);
        var result = await AwaitExt.TasksAsync(
                         DelayValueAsync(InputValue1), DelayValueAsync(InputValue2), DelayValueAsync(InputValue3),
                         DelayValueAsync(InputValue4), DelayValueAsync(InputValue5), DelayValueAsync(InputValue6),
                         DelayValueAsync(InputValue7), DelayValueAsync(InputValue8), DelayValueAsync(InputValue9),
                         DelayValueAsync(InputValue10), DelayValueAsync(InputValue11), DelayValueAsync(InputValue12),
                         DelayValueAsync(InputValue13), DelayValueAsync(InputValue14), DelayValueAsync(InputValue15),
                         DelayValueAsync(InputValue16), DelayValueAsync(InputValue17),
                         noResultTasks);
        
        Assert.True(result.Item1 == InputValue1);
        Assert.True(result.Item2 == InputValue2);
        Assert.True(result.Item3 == InputValue3);
        Assert.True(result.Item4 == InputValue4);
        Assert.True(result.Item5 == InputValue5);
        Assert.True(result.Item6 == InputValue6);
        Assert.True(result.Item7 == InputValue7);
        Assert.True(result.Item8 == InputValue8);
        Assert.True(result.Item9 == InputValue9);
        Assert.True(result.Item10 == InputValue10);
        Assert.True(result.Item11 == InputValue11);
        Assert.True(result.Item12 == InputValue12);
        Assert.True(result.Item13 == InputValue13);
        Assert.True(result.Item14 == InputValue14);
        Assert.True(result.Item15 == InputValue15);
        Assert.True(result.Item16 == InputValue16);
        Assert.True(result.Item17 == InputValue17);
        AssertTasksCompletedSuccessfully(noResultTasks);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public static async Task Await_Result_Count_18_Test(uint noResultCount)
    {
        var noResultTasks = GenerateTasks(noResultCount);
        var result = await AwaitExt.TasksAsync(
                         DelayValueAsync(InputValue1), DelayValueAsync(InputValue2), DelayValueAsync(InputValue3),
                         DelayValueAsync(InputValue4), DelayValueAsync(InputValue5), DelayValueAsync(InputValue6),
                         DelayValueAsync(InputValue7), DelayValueAsync(InputValue8), DelayValueAsync(InputValue9),
                         DelayValueAsync(InputValue10), DelayValueAsync(InputValue11), DelayValueAsync(InputValue12),
                         DelayValueAsync(InputValue13), DelayValueAsync(InputValue14), DelayValueAsync(InputValue15),
                         DelayValueAsync(InputValue16), DelayValueAsync(InputValue17), DelayValueAsync(InputValue18),
                         noResultTasks);
        
        Assert.True(result.Item1 == InputValue1);
        Assert.True(result.Item2 == InputValue2);
        Assert.True(result.Item3 == InputValue3);
        Assert.True(result.Item4 == InputValue4);
        Assert.True(result.Item5 == InputValue5);
        Assert.True(result.Item6 == InputValue6);
        Assert.True(result.Item7 == InputValue7);
        Assert.True(result.Item8 == InputValue8);
        Assert.True(result.Item9 == InputValue9);
        Assert.True(result.Item10 == InputValue10);
        Assert.True(result.Item11 == InputValue11);
        Assert.True(result.Item12 == InputValue12);
        Assert.True(result.Item13 == InputValue13);
        Assert.True(result.Item14 == InputValue14);
        Assert.True(result.Item15 == InputValue15);
        Assert.True(result.Item16 == InputValue16);
        Assert.True(result.Item17 == InputValue17);
        Assert.True(result.Item18 == InputValue18);
        AssertTasksCompletedSuccessfully(noResultTasks);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public static async Task Await_Result_Count_19_Test(uint noResultCount)
    {
        var noResultTasks = GenerateTasks(noResultCount);
        var result = await AwaitExt.TasksAsync(
                         DelayValueAsync(InputValue1), DelayValueAsync(InputValue2), DelayValueAsync(InputValue3),
                         DelayValueAsync(InputValue4), DelayValueAsync(InputValue5), DelayValueAsync(InputValue6),
                         DelayValueAsync(InputValue7), DelayValueAsync(InputValue8), DelayValueAsync(InputValue9),
                         DelayValueAsync(InputValue10), DelayValueAsync(InputValue11), DelayValueAsync(InputValue12),
                         DelayValueAsync(InputValue13), DelayValueAsync(InputValue14), DelayValueAsync(InputValue15),
                         DelayValueAsync(InputValue16), DelayValueAsync(InputValue17), DelayValueAsync(InputValue18),
                         DelayValueAsync(InputValue19),
                         noResultTasks);
        
        Assert.True(result.Item1 == InputValue1);
        Assert.True(result.Item2 == InputValue2);
        Assert.True(result.Item3 == InputValue3);
        Assert.True(result.Item4 == InputValue4);
        Assert.True(result.Item5 == InputValue5);
        Assert.True(result.Item6 == InputValue6);
        Assert.True(result.Item7 == InputValue7);
        Assert.True(result.Item8 == InputValue8);
        Assert.True(result.Item9 == InputValue9);
        Assert.True(result.Item10 == InputValue10);
        Assert.True(result.Item11 == InputValue11);
        Assert.True(result.Item12 == InputValue12);
        Assert.True(result.Item13 == InputValue13);
        Assert.True(result.Item14 == InputValue14);
        Assert.True(result.Item15 == InputValue15);
        Assert.True(result.Item16 == InputValue16);
        Assert.True(result.Item17 == InputValue17);
        Assert.True(result.Item18 == InputValue18);
        Assert.True(result.Item19 == InputValue19);
        AssertTasksCompletedSuccessfully(noResultTasks);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public static async Task Await_Result_Count_20_Test(uint noResultCount)
    {
        var noResultTasks = GenerateTasks(noResultCount);
        var result = await AwaitExt.TasksAsync(
                         DelayValueAsync(InputValue1), DelayValueAsync(InputValue2), DelayValueAsync(InputValue3),
                         DelayValueAsync(InputValue4), DelayValueAsync(InputValue5), DelayValueAsync(InputValue6),
                         DelayValueAsync(InputValue7), DelayValueAsync(InputValue8), DelayValueAsync(InputValue9),
                         DelayValueAsync(InputValue10), DelayValueAsync(InputValue11), DelayValueAsync(InputValue12),
                         DelayValueAsync(InputValue13), DelayValueAsync(InputValue14), DelayValueAsync(InputValue15),
                         DelayValueAsync(InputValue16), DelayValueAsync(InputValue17), DelayValueAsync(InputValue18),
                         DelayValueAsync(InputValue19), DelayValueAsync(InputValue20),
                         noResultTasks);
        
        Assert.True(result.Item1 == InputValue1);
        Assert.True(result.Item2 == InputValue2);
        Assert.True(result.Item3 == InputValue3);
        Assert.True(result.Item4 == InputValue4);
        Assert.True(result.Item5 == InputValue5);
        Assert.True(result.Item6 == InputValue6);
        Assert.True(result.Item7 == InputValue7);
        Assert.True(result.Item8 == InputValue8);
        Assert.True(result.Item9 == InputValue9);
        Assert.True(result.Item10 == InputValue10);
        Assert.True(result.Item11 == InputValue11);
        Assert.True(result.Item12 == InputValue12);
        Assert.True(result.Item13 == InputValue13);
        Assert.True(result.Item14 == InputValue14);
        Assert.True(result.Item15 == InputValue15);
        Assert.True(result.Item16 == InputValue16);
        Assert.True(result.Item17 == InputValue17);
        Assert.True(result.Item18 == InputValue18);
        Assert.True(result.Item19 == InputValue19);
        Assert.True(result.Item20 == InputValue20);
        AssertTasksCompletedSuccessfully(noResultTasks);
    }
    
    #region private help tasks
    
    private static async Task<T> DelayValueAsync<T>(T value, int milliseconds = 100)
    {
        await Task.Delay(milliseconds);
        return value;
    }
    
    private static Task DelayAsync(int milliseconds = 100)
    {
        return Task.Delay(milliseconds);
    }
    
    private static List<Task> GenerateTasks(uint count)
    {
        var list = new List<Task>();
        for (var index = 0; index < count; index++)
        {
            list.Add(DelayAsync());
        }
        return list;
    }
    
    private static void AssertTasksCompletedSuccessfully(List<Task> tasks)
    {
        foreach (var task in tasks)
        {
            Assert.True(task.IsCompletedSuccessfully);
        }
    }
    
    #endregion
}
