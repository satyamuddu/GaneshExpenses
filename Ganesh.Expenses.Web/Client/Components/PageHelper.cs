using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ganesh.Expenses.Web.Client.Components
{
    public class PageHelper
    {
        public static async Task<bool> ShowConfirmationDialog(IDialogService dialogService, string buttonText, string message, Color color, string context)
        {
            var parameters = new DialogParameters();
            parameters.Add("ContentText", message);
            parameters.Add("ButtonText", buttonText);
            parameters.Add("Color", color);

            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

            var dialog = dialogService.Show<ConfirmationDialog>(context, parameters, options);
            var result = await dialog.Result;
            if (result.Cancelled)
            {
                return false;
            }
            return true;
        }
    }
}
