using YDotNet.Server;
using YDotNet.Server.Redis;
using YDotNet.Server.Storage;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceExtensions
{
    public static YDotnetRegistration AddRedis(this YDotnetRegistration registration, Action<RedisOptions>? configure = null)
    {
        registration.Services.Configure(configure ?? (x => { }));
        registration.Services.AddSingleton<RedisConnection>();

        return registration;
    }

    public static YDotnetRegistration AddRedisClustering(this YDotnetRegistration registration, Action<RedisClusteringOptions>? configure = null)
    {
        registration.Services.Configure(configure ?? (x => { }));
        registration.AddPubSub<RedisPubSub>();

        return registration;
    }

    public static YDotnetRegistration AddRedisStorage(this YDotnetRegistration registration, Action<RedisDocumentStorageOptions>? configure = null)
    {
        registration.Services.Configure(configure ?? (x => { }));
        registration.Services.AddSingleton<IDocumentStorage, RedisDocumentStorage>();

        return registration;
    }
}
