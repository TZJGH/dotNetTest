// See https://aka.ms/new-console-template for more information
# define SlidingWindowRateLimiter
using System.Threading.RateLimiting;


#if ConcurrencyLimiter

RateLimiter limiter = new ConcurrencyLimiter(
    new ConcurrencyLimiterOptions()
    {
        PermitLimit = 2,
        QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
        QueueLimit = 2
    });

// thread 1:
_ = Task.Run(async () =>
{
    using RateLimitLease lease = limiter.AttemptAcquire(permitCount: 2);
    if (lease.IsAcquired)
    {
        Console.WriteLine($"{DateTime.Now.ToLongTimeString()} thread 1");

        await Task.Delay(5000);
        Console.WriteLine($"{DateTime.Now.ToLongTimeString()} thread 1 dispose");
    }
   
});

// thread 2:
_ = Task.Run(async () =>
{
    using RateLimitLease lease2 = await limiter.AcquireAsync(permitCount: 2);
    if (lease2.IsAcquired)
    {
        Console.WriteLine($"{DateTime.Now.ToLongTimeString()} thread 2");
    }
});
#endif

#if TokenBucketRateLimiter
RateLimiter limiter = new TokenBucketRateLimiter(new TokenBucketRateLimiterOptions()
{
    TokenLimit = 5,//存储桶中随时可以包含的最大令牌数。 必须设置为值 > 0。
    QueueProcessingOrder = QueueProcessingOrder.OldestFirst,//确定当没有足够的资源可以租用时的行为 AcquireAsync(Int32, CancellationToken) 。
    QueueLimit = 1,//排队的获取请求的最大累积令牌计数。 必须将这些选项设置为值 >= 0。
    ReplenishmentPeriod = TimeSpan.FromSeconds(5),//指定补货之间的最短期限。 必须设置为大于 Zero 将这些选项传递给 的 TokenBucketRateLimiter构造函数时的值。
    TokensPerPeriod = 1,//指定用于还原每次补充的最大令牌数。 必须设置为值 > 0。
    AutoReplenishment = true//指定 是自动补充令牌，还是 TokenBucketRateLimiter 其他人将调用 TryReplenish() 以补充令牌。
});

_ = Task.Run(async () =>
{
    bool isAcquired = false;
    do
    {
        using RateLimitLease lease = await limiter.AcquireAsync(5);
        isAcquired = lease.IsAcquired;
        if (isAcquired)
        {
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} thread 1");

            await Task.Delay(2000);
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} thread 1 dispose");
        }

    } while (!isAcquired);

});

_ = Task.Run(async () =>
{
    bool isAcquired = false;
    do
    {
        // will complete after ~5 seconds
        using RateLimitLease lease2 = await limiter.AcquireAsync();
        isAcquired = lease2.IsAcquired;
        if (isAcquired)
        {
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} thread 2");
        }
    } while (!isAcquired);
});
#endif

#if FixedWindowRateLimiter
RateLimiter limiter = new FixedWindowRateLimiter(new FixedWindowRateLimiterOptions()
{
    PermitLimit = 2,
    QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
    QueueLimit = 1,
    Window = TimeSpan.FromSeconds(10),
    AutoReplenishment = true
});

_ = Task.Run(async () =>
{
    bool isAcquired = false;
    do
    {
        using RateLimitLease lease = await limiter.AcquireAsync(2);
        isAcquired = lease.IsAcquired;
        if (isAcquired)
        {
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} thread 1");

            await Task.Delay(2000);
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} thread 1 dispose");
        }

    } while (!isAcquired);

});

_ = Task.Run(async () =>
{
    bool isAcquired = false;
    do
    {
        // will complete after ~5 seconds
        using RateLimitLease lease2 = await limiter.AcquireAsync(1);
        isAcquired = lease2.IsAcquired;
        if (isAcquired)
        {
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} thread 2");
        }
    } while (!isAcquired);
});
#endif

#if SlidingWindowRateLimiter
RateLimiter limiter = new SlidingWindowRateLimiter(new SlidingWindowRateLimiterOptions()
{
    PermitLimit = 3,
    QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
    QueueLimit = 2,
    Window = TimeSpan.FromSeconds(10),
    SegmentsPerWindow = 100,
    AutoReplenishment = true
});


_ = Task.Run(async () =>
{
    bool isAcquired = false;
    do
    {
        using RateLimitLease lease = await limiter.AcquireAsync(2);
        isAcquired = lease.IsAcquired;
        if (isAcquired)
        {
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} thread 1");

            await Task.Delay(2000);
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} thread 1 dispose");
        }

    } while (!isAcquired);

});

_ = Task.Run(async () =>
{
    bool isAcquired = false;
    do
    {
        // will complete after ~5 seconds
        using RateLimitLease lease2 = await limiter.AcquireAsync(2);
        isAcquired = lease2.IsAcquired;
        if (isAcquired)
        {
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} thread 2");
        }
    } while (!isAcquired);
});
#endif

Console.ReadKey();
