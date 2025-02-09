﻿namespace Quartz.UI.Components.Controls.CronExpressionBuilder.Components;

using Microsoft.AspNetCore.Components;

public sealed partial class DailyExpressionBuilder
{
    [Parameter]
    public EventCallback<TimeSpan> OnTimeChanged { get; set; }

    private void TimeChangedHandler(TimeSpan? time)
    {
        if (time != null)
        {
            _ = this.OnTimeChanged.InvokeAsync(time.Value);
        }
    }
}
