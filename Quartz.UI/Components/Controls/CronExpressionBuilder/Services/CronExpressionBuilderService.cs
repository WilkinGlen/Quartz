namespace Quartz.UI.Components.Controls.CronExpressionBuilder.Services;

using Quartz.Impl.Triggers;

public static class CronExpressionBuilderService
{
    public static string? BuildDailyCronExpression(TimeSpan timeSpan) => 
        timeSpan != TimeSpan.Zero
            ? ((CronTriggerImpl)CronScheduleBuilder
                .DailyAtHourAndMinute(timeSpan.Hours, timeSpan.Minutes)
                .Build())
                .CronExpressionString
            : null;
}
