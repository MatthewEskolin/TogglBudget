
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Components;

namespace TogglTimeWeb.Client.Pages.Dashboard.ProgressBar
{
    public partial class ProgressBar   
    {
        [Parameter] public string Direction { get; set; } = "UP";
        [Parameter] public string? LeftDisplayLabel { get; set; }
        [Parameter] public string? RightDisplayLabel { get; set; }
        [Parameter] public int LeftDisplayValue { get; set; }
        [Parameter] public int RightDisplayValue { get; set; }
        [Parameter] public bool UseRightDisplay { get; set; } = true;
        [Parameter] public bool UseLeftDisplay { get; set; } = true;

        [Parameter] public double ProgressWidth { get; set; } = 5;

        public string ProgressWithString => $"{ProgressWidth}%";

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters);
        }


        protected override void OnParametersSet()
        {
        }

    }



}
