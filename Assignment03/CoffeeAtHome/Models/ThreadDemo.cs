namespace CoffeeAtHome.Models;

public class ThreadDemo
{
    public static async Task RunAsync()
    {
        Console.WriteLine($"1: {Thread.CurrentThread.ManagedThreadId}");

        var client = new HttpClient();

        Console.WriteLine($"2: {Thread.CurrentThread.ManagedThreadId}");

        var task = client.GetStringAsync("http://google.com"); //initiate I/O operation

        Console.WriteLine($"3: {Thread.CurrentThread.ManagedThreadId}");
        
        //Also we can just Delay: await Task.Delay(2000); 
        var a = 0;
        for (int i = 0; i < 1000000; i++)
        {
            a += i;
        }

        Console.WriteLine($"4: {Thread.CurrentThread.ManagedThreadId}");

        var page = await task; //wait without blocking, continue later on any free thread

        Console.WriteLine($"5: {Thread.CurrentThread.ManagedThreadId}");
    }
}