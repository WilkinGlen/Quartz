﻿namespace Quartz.UI.Components.Controls.CronExpressionBuilder.Components;

using Microsoft.AspNetCore.Components;

public sealed partial class MonthlyExpressionBuilder
{
    private readonly IEnumerable<int> days = Enumerable.Range(1, 28);
    private int selectedDay = 1;
    private TimeSpan? selectedTime;

    [Parameter]
    public EventCallback<(int Day, TimeSpan Time)> OnDayTimeChanged { get; set; }

    private void TimeChangedHandler(TimeSpan? time)
    {
        this.selectedTime = time;
        this.RaiseOnDayTimeChanged();
    }

    private void SelectedDayChanged(int day)
    {
        this.selectedDay = day;
        this.RaiseOnDayTimeChanged();
    }

    private void RaiseOnDayTimeChanged()
    {
        if (this.selectedTime != null)
        {
            _ = this.OnDayTimeChanged.InvokeAsync((this.selectedDay, this.selectedTime.Value));
        }
    }
}
