namespace Quartz.UI.Components.Controls.CronExpressionBuilder;

using Microsoft.AspNetCore.Components;

public partial class WeeklyExpressionBuilder
{
    private (bool Mon, bool Tue, bool Wed, bool Thu, bool Fri, bool Sat, bool Sun)  days;
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
            this.OnDayTimeChanged.InvokeAsync((this.selectedDay.Value, this.selectedTime.Value));
        }
    }
}
