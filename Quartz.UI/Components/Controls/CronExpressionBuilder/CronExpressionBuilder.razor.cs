namespace Quartz.UI.Components.Controls.CronExpressionBuilder;

using Microsoft.AspNetCore.Components;
using Quartz.UI.Components.Controls.CronExpressionBuilder.Services;
using System.Reflection.Metadata;

public partial class CronExpressionBuilder
{
    private string? cronExpression;
    private readonly List<ScheduleTypes> scheduleTypes = Enum.GetValues<ScheduleTypes>().Select(t => t).ToList();
    private ScheduleTypes selectedScheduleType;

    [Parameter]
    public EventCallback<string> OnCronExpressionChanged { get; set; }

    private void DailyExpressionBuilderTimeChangedHandler(TimeSpan time) =>
        this.cronExpression = CronExpressionBuilderService.BuildCronExpression(time);

    private void WeeklyExpressionBuilderDayTimeChangedHandler((DayOfWeek DayOfTheWeek, TimeSpan Time) values) =>
        this.cronExpression = CronExpressionBuilderService.BuildCronExpression(values.DayOfTheWeek, values.Time);

    private void MultipleDaysExpressionBuilderDaysTimeChangedHandler((TimeSpan timeSpan, DayOfWeek[] daysOfTheWeek) values) =>
        this.cronExpression = CronExpressionBuilderService.BuildCronExpression(values.timeSpan, values.daysOfTheWeek);

    private void MonthlyExpressionBuilderOnDayTimeChanged((int day, TimeSpan timeSpan) values) =>
        this.cronExpression = CronExpressionBuilderService.BuildCronExpression(values.day, values.timeSpan);

    private void SubmitClickedHandler() =>
        this.OnCronExpressionChanged.InvokeAsync(this.cronExpression);

    private enum ScheduleTypes
    {
        Select,
        Daily,
        MultipleDays,
        Weekly,
        Monthly
    }
}
