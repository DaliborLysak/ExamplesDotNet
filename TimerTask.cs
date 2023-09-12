using System.Diagnostics;

public class TimerTask
{
    private readonly PeriodicTimer? periodicTimer;
    private readonly CancellationTokenSource cancellationTokenSource = new();
    private Task? timerTask;

    public TimerTask(TimeSpan period)
    {
        this.periodicTimer = new PeriodicTimer(period);
    }

    private async Task Process()
    {
        if (this.periodicTimer is null)
            return;

        try
        {
            while (await this.periodicTimer.WaitForNextTickAsync(this.cancellationTokenSource.Token))
            {
                Console.WriteLine($"Waiting in time: {DateTime.Now.ToString()}");
            }

        }
        catch (OperationCanceledException exception)
        {
            Console.WriteLine(exception.Message.ToString());
        }
    }

    public void Start()
    {
        Console.WriteLine("Timer start");
        this.timerTask = this.Process();
    }

    public async Task Stop()
    {
        if (this.timerTask is null)
            return;

        this.cancellationTokenSource.Cancel();
        await this.timerTask;
        this.cancellationTokenSource.Dispose();
        Console.WriteLine("Timer stop");
    }
}