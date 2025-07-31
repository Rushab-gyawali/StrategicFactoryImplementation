using FactoryStrategy.Config;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class SyncBackgroundService
{
    private readonly OperationFactory _factory;
    private readonly ClientConfig _client;
    private CancellationTokenSource _cts;
    private Task _runningTask;

    public SyncBackgroundService(OperationFactory factory, ClientConfig client)
    {
        _factory = factory;
        _client = client;
    }

    public void Start()
    {
        if (_cts != null && !_cts.IsCancellationRequested)
            throw new InvalidOperationException("Service is already running.");

        _cts = new CancellationTokenSource();
        _runningTask = Task.Run(() => RunLoopAsync(_cts.Token));
    }

    public async Task StopAsync()
    {
        if (_cts == null)
            return;

        _cts.Cancel();
        try
        {
            await _runningTask.ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            // Expected on cancellation
        }
        finally
        {
            _cts.Dispose();
            _cts = null;
            _runningTask = null;
        }
    }

    private async Task RunLoopAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            var tasks = new List<Task>();

            foreach (var operation in _client.EnabledOperations)
            {
                if (token.IsCancellationRequested)
                    break;

                try
                {
                    var opInstance = _factory.Create(operation);
                    tasks.Add(opInstance.ExecuteAsync(token));  // Start each operation async
                }
                catch (Exception ex)
                {
                    // TODO: log or handle exception
                }
            }

            try
            {
                await Task.WhenAll(tasks).ConfigureAwait(false);  // Wait for all to finish in parallel
            }
            catch (Exception ex)
            {
                // TODO: log exceptions from any operation
            }

            try
            {
                await Task.Delay(TimeSpan.FromSeconds(60), token).ConfigureAwait(false);
            }
            catch (TaskCanceledException)
            {
                // Cancellation requested during delay, exit loop
                break;
            }
        }
    }
}
