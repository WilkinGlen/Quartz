namespace Quartz.UI.Components.Controls.CronExpressionBuilder;

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

    private void MultipleDaysExpressionBuilderDaysTimeChangedHandler((TimeSpan timeSpan, DayOfWeek[] daysOfTheWeek) values) =>
        this.cronExpression = CronExpressionBuilderService.BuildCronExpression(values.timeSpan, values.daysOfTheWeek);

    private enum ScheduleTypes
    {
        Select,
        Hourly,
        Daily,
        MultipleDays,
        Weekly
    }
}
