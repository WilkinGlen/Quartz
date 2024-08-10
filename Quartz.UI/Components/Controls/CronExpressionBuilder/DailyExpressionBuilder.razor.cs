namespace Quartz.UI.Components.Controls.CronExpressionBuilder;

using Microsoft.AspNetCore.Components;

public partial class DailyExpressionBuilder
{
    [Parameter]
    public EventCallback<TimeSpan?> OnTimeChanged { get; set; }

    private void TimeChangedHandler(TimeSpan? time) => this.OnTimeChanged.InvokeAsync(time);
}
