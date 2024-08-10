namespace QuartzServices;

using Microsoft.Extensions.Configuration;
using Quartz;
using Quartz.Impl;
using System.Collections.Frozen;
using System.Collections.Specialized;

public interface IQuartzDataReadService
{
    Task<FrozenSet<string>> GetGroupNamesAsync();
}

public class QuartzDataReadService : IQuartzDataReadService
{
    private readonly IScheduler scheduler;

    public QuartzDataReadService(IConfiguration config)
    {
        var properties = new NameValueCollection
        {
            ["quartz.jobStore.useProperties"] = config["QuartzJobStoreUseProperties"],
            ["quartz.jobStore.type"] = config["QuartzJobStoreType"],
            ["quartz.jobStore.driverDelegateType"] = config["QuartzJobStoreDriverDelegateType"],
            ["quartz.jobStore.tablePrefix"] = config["QuartzJobStoreTablePrefix"],
            ["quartz.jobStore.dataSource"] = config["QuartzJobStoreDataSource"],
            ["quartz.serializer.type"] = config["QuartzSerializerType"],
            ["quartz.dataSource.myDS.connectionString"] = config["QuartzDataSourceMyDSConnectionString"],
            ["quartz.dataSource.myDS.provider"] = config["QuartzDataSourceMyDSProvider"]
        };
        var schedulerFactory = new StdSchedulerFactory(properties);
        this.scheduler = schedulerFactory.GetScheduler().Result;
    }

    public async Task<FrozenSet<string>> GetGroupNamesAsync()
    {
        var jobDetails = await scheduler.GetJobDetail(new JobKey("GlensJob", "GlensGroup"));
        var jobGroupNames = await this.scheduler.GetJobGroupNames();
        var triggerGroupNames = await this.scheduler.GetTriggerGroupNames();
        return triggerGroupNames.ToFrozenSet();
    }
}
