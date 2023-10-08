namespace YDotNet.Document.Events;

internal sealed class EventSubscription : IDisposable
{
    private readonly Action unsubscribe;

    internal EventSubscription(Action unsubscribe)
    {
        this.unsubscribe = unsubscribe;
    }

    public void Dispose()
    {
        this.unsubscribe();
    }
}
