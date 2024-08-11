namespace Quartz.UI.Components.Pages;

public partial class Home
{
    private string? cronExpression;

    private void CronExpressionBuilderOnCronExpressionChangedHandler(string cronExpression) =>
        this.cronExpression = cronExpression;
}
