using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using WebApplication1.Data;

namespace WebApplication1.Pages
{
    public partial class Test2
    {
#nullable disable
        [CascadingParameter] public AppMitarbeiter Mitarbeiter { get; set; }
#nullable enable


        protected override Task OnParametersSetAsync()
        {
            // PUT DEBUG POINT HERE
            return base.OnParametersSetAsync();
        }
    }
}