namespace Session09Assignment;

// =====================================================================
// Part 2 — Q5: AppLogger Singleton
// =====================================================================
// Rules from the assignment:
//   1. Constructor is private  -> no one outside this class can `new` it.
//   2. A private static field holds the single instance (starts as null).
//   3. A public static GetLogger() creates the instance on the first call
//      and returns the same instance every subsequent call.
//
// We use double-check locking to make it thread-safe (best-practice).
// The `sealed` keyword prevents subclassing, which would otherwise
// undermine the single-instance guarantee.
// =====================================================================

public sealed class AppLogger
{
    // (2) private static field, starts null
    private static AppLogger? _instance = null;
    private static readonly object _lock = new();

    // (1) private constructor — blocks external `new AppLogger()`
    private AppLogger()
    {
        Console.WriteLine("[AppLogger] instance created.");
    }

    // (3) public static accessor
    public static AppLogger GetLogger()
    {
        if (_instance is null)
        {
            lock (_lock)
            {
                _instance ??= new AppLogger();
            }
        }
        return _instance;
    }

    public void Log(string message)
        => Console.WriteLine($"[LOG {DateTime.Now:HH:mm:ss}] {message}");
}
