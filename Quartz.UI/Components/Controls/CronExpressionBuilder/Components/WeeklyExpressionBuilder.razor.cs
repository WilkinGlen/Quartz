namespace Quartz.UI.Components.Controls.CronExpressionBuilder.Components;

using Microsoft.AspNetCore.Components;

public partial class WeeklyExpressionBuilder
{
    private DayOfWeek? selectedDay;
    private TimeSpan? selectedTime;

    [Parameter]
    public EventCallback<(DayOfWeek DayOfTheWeek, TimeSpan time)> OnDayTimeChanged { get; set; }

    private void DaySelected(string day)
    {
        this.selectedDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), day);
        this.RaiseOnDayTimeChanged();
    }

    private void TimeChangedHandler(TimeSpan? time)
    {
        this.selectedTime = time;
        this.RaiseOnDayTimeChanged();
    }

    private void RaiseOnDayTimeChanged()
    {
        if (this.selectedDay != null && this.selectedTime != null)
        {
            _ = this.OnDayTimeChanged.InvokeAsync((this.selectedDay.Value, this.selectedTime.Value));
        }
    }
}
