namespace Quartz.UI.Components.Controls.CronExpressionBuilder;

using Microsoft.AspNetCore.Components;
using Quartz.UI.Components.Controls.CronExpressionBuilder.Services;

public partial class CronExpressionBuilder
{
    private string? cronExpression;
    private readonly List<ScheduleTypes> scheduleTypes = Enum.GetValues<ScheduleTypes>().Select(t => t).ToList();
    private ScheduleTypes selectedScheduleType;

    private void DailyExpressionBuilderTimeChangedHandler(TimeSpan time) => 
        this.cronExpression = CronExpressionBuilderService.BuildCronExpression(time);

    private void WeeklyExpressionBuilderDayTimeChangedHandler((DayOfWeek DayOfTheWeek, TimeSpan Time) values) =>
        this.cronExpression = CronExpressionBuilderService.BuildCronExpression(values.DayOfTheWeek, values.Time);

    private enum ScheduleTypes
    {
        Select,
        Hourly,
        Daily,
        Weekly
    }
}
