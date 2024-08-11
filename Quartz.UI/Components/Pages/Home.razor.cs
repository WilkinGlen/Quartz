namespace Quartz.UI.Components.Pages;

public partial class Home
{
    private string? cronExpression;

    private void CronExpressionBuilderOnCronExpressionChanged(string cronExpression) =>
        this.cronExpression = cronExpression;
}
