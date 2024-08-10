namespace Quartz.UI.Components.Controls.CronExpressionBuilder.Services;

using Quartz.Impl.Triggers;
using System;

public static class CronExpressionBuilderService
{
    public static string? BuildCronExpression(TimeSpan timeSpan) =>
        timeSpan != TimeSpan.Zero
            ? ((CronTriggerImpl)CronScheduleBuilder
                .DailyAtHourAndMinute(timeSpan.Hours, timeSpan.Minutes)
                .Build())
                .CronExpressionString
            : null;

    public static string? BuildCronExpression(DayOfWeek dayOfWeek, TimeSpan timeSpan) =>
        timeSpan != TimeSpan.Zero
            ? ((CronTriggerImpl)CronScheduleBuilder
                .WeeklyOnDayAndHourAndMinute(dayOfWeek, timeSpan.Hours, timeSpan.Minutes)
                .Build())
                .CronExpressionString
            : null;

    public static string? BuildCronExpression(TimeSpan timeSpan, params DayOfWeek[] daysOfWeek) =>
        timeSpan != TimeSpan.Zero
            ? ((CronTriggerImpl)CronScheduleBuilder
                .AtHourAndMinuteOnGivenDaysOfWeek(timeSpan.Hours, timeSpan.Minutes, daysOfWeek)
                .Build())
                .CronExpressionString
            : null;
}
