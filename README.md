# Quartz Redis Store
This plugin to  [Quartz.NET](https://github.com/quartznet/quartznet) library aims to deliver a way to store information inside the Redis. 

This repo exists because all the other Redis Stores for Quartz.NET are abandoned. 🥹
So I thought, why not keep the good code and features and support / add new features?

```cs

var properties = new NameValueCollection
{
    ["quartz.jobStore.type"] = "QuartzRedis.Store.RedisJobStore, QuartzRedis.Store",
    ["quartz.jobStore.keyPrefix"] = "UnitJob",
    ["quartz.serializer.type"] = "newtonsoft",
    ["quartz.scheduler.instanceId"] = "AUTO",
    ["quartz.jobStore.dbNum"] = "1",
    ["quartz.jobStore.redisConfiguration"] = "127.0.0.1:6379,allowAdmin=true,syncTimeout=5000,password=1234",
    //Start Redis Sentinel Model
    //["quartz.jobStore.isSentinel"] = "true",
    //["quartz.jobStore.sentinelServiceName"] = "",
    //["quartz.jobStore.password"] = "******",
    //["quartz.jobStore.allowAdmin"] = "true",
    //End Redis Sentinel Model
    ["quartz.jobStore.clustered"] = "true",
    ["quartz.threadPool.threadCount"] = "1",
    [StdSchedulerFactory.PropertySchedulerInstanceName] = "QUARTZ_JOB",
};

builder.Services.AddQuartz(properties, (q) =>
{
    q.AddJob(typeof(MyJob), MyJob.Key, configure => configure.StoreDurably());
});

builder.Services.AddQuartzHostedService(opt =>
{
    opt.WaitForJobsToComplete = true;
});

```
