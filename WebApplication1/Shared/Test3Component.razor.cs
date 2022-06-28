using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using WebApplication1;
using WebApplication1.Shared;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using WebApplication1.Data;

namespace WebApplication1.Shared
{
    public partial class Test3Component
    {
#nullable disable
        [CascadingParameter] public AppMitarbeiter Mitarbeiter { get; set; }
#nullable enable

        protected override Task OnParametersSetAsync()
        {
            return base.OnParametersSetAsync();
        }
    }
}