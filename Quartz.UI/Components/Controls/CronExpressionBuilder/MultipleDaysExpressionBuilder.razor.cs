namespace Quartz.UI.Components.Controls.CronExpressionBuilder;

using Microsoft.AspNetCore.Components;

public partial class MultipleDaysExpressionBuilder
{
    private (bool Mon, bool Tue, bool Wed, bool Thu, bool Fri, bool Sat, bool Sun) days;
    private TimeSpan? selectedTime;
    private readonly List<DayOfWeek> daysOfTheWeek = [];

    [Parameter]
    public EventCallback<(TimeSpan timeSpan, DayOfWeek[] DaysOfWeek)> OnDaysTimeChanged { get; set; }

    private void MonChangedHandler(bool value)
    {
        this.days.Mon = value;
        if (value)
        {
            this.daysOfTheWeek.Add(DayOfWeek.Monday);
        }
        else
        {
            _ = this.daysOfTheWeek.Remove(DayOfWeek.Monday);
        }

        this.RaiseOnDayTimeChanged();
    }

    private void TueChangedHandler(bool value)
    {
        this.days.Tue = value;
        if (value)
        {
            this.daysOfTheWeek.Add(DayOfWeek.Tuesday);
        }
        else
        {
            _ = this.daysOfTheWeek.Remove(DayOfWeek.Tuesday);
        }

        this.RaiseOnDayTimeChanged();
    }

    private void WedChangedHandler(bool value)
    {
        this.days.Wed = value;
        if (value)
        {
            this.daysOfTheWeek.Add(DayOfWeek.Wednesday);
        }
        else
        {
            _ = this.daysOfTheWeek.Remove(DayOfWeek.Wednesday);
        }

        this.RaiseOnDayTimeChanged();
    }

    private void ThuChangedHandler(bool value)
    {
        this.days.Thu = value;
        if (value)
        {
            this.daysOfTheWeek.Add(DayOfWeek.Thursday);
        }
        else
        {
            _ = this.daysOfTheWeek.Remove(DayOfWeek.Thursday);
        }

        this.RaiseOnDayTimeChanged();
    }

    private void FriChangedHandler(bool value)
    {
        this.days.Fri = value;
        if (value)
        {
            this.daysOfTheWeek.Add(DayOfWeek.Friday);
        }
        else
        {
            _ = this.daysOfTheWeek.Remove(DayOfWeek.Friday);
        }

        this.RaiseOnDayTimeChanged();
    }

    private void SatChangedHandler(bool value)
    {
        this.days.Sat = value;
        if (value)
        {
            this.daysOfTheWeek.Add(DayOfWeek.Saturday);
        }
        else
        {
            _ = this.daysOfTheWeek.Remove(DayOfWeek.Saturday);
        }

        this.RaiseOnDayTimeChanged();
    }

    private void SunChangedHandler(bool value)
    {
        this.days.Sun = value;
        if (value)
        {
            this.daysOfTheWeek.Add(DayOfWeek.Sunday);
        }
        else
        {
            _ = this.daysOfTheWeek.Remove(DayOfWeek.Sunday);
        }

        this.RaiseOnDayTimeChanged();
    }

    private void TimeChangedHandler(TimeSpan? time)
    {
        this.selectedTime = time;
        this.RaiseOnDayTimeChanged();
    }

    private void RaiseOnDayTimeChanged()
    {
        if (this.daysOfTheWeek?.Count > 0 && this.selectedTime != null)
        {
            _ = this.OnDaysTimeChanged.InvokeAsync((this.selectedTime.Value, this.daysOfTheWeek.ToArray()));
        }
    }
}
