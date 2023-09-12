Console.WriteLine("Press any key to start");
Console.ReadKey();

var task = new TimerTask(TimeSpan.FromSeconds(1));
task.Start();

Console.WriteLine("Press any key to stop");
Console.ReadKey();

await task.Stop();