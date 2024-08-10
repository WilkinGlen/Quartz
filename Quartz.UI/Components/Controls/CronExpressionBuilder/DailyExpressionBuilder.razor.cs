namespace Quartz.UI.Components.Controls.CronExpressionBuilder;

using Microsoft.AspNetCore.Components;

public partial class DailyExpressionBuilder
{
    private TimeSpan? time;

    [Parameter]
    public EventCallback<TimeSpan?> OnTimeChanged { get; set; }

    private void Submit() => this.OnTimeChanged.InvokeAsync(this.time);
}
