using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Pages
{
    public class AlertPageBase : ComponentBase
    {
        protected List<AlertBox> ShowAlerts { get; set; } = new List<AlertBox>();

#nullable disable
        [Inject] public ISessionStorageService SessionStorage { get; set; }
#nullable enable
        /// <summary>
        /// Ruft die Alerts aus dem SessionStorage ab und legt diese auf die Eigenschaft <see cref="ShowAlerts"/> fest.
        /// </summary>
        /// <returns></returns>
        protected async Task SetAlerts()
        {
            List<AlertBox>? alerts = await SessionStorage.GetItemAsync<List<AlertBox>>("alerts");

            if (alerts is not null)
            {
                ShowAlerts = alerts;
                await SessionStorage.RemoveItemAsync("alerts");
            }
        }
        /// <summary>
        /// Fügt ein Alert dem SessionStorage hinzu, das beim nächsten Aufruf von <see cref="SetAlerts"/> abgerufen wird.
        /// </summary>
        /// <param name="alert"></param>
        /// <returns></returns>
        protected async Task AddAlertAsync(AlertBox alert)
        {
            List<AlertBox> alerts = (await SessionStorage.GetItemAsync<List<AlertBox>>("alerts")) ?? new List<AlertBox>();
            alerts.Add(alert);
            await SessionStorage.SetItemAsync("alerts", alerts);


            await InvokeAsync(StateHasChanged);
        }

        protected async Task AddAlertsAsync(List<AlertBox> alerts)
        {
            foreach (var alert in alerts)
            {
                await AddAlertAsync(alert);
            }
        }
    }
}
