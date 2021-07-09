using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Pages
{
    public partial class AuftragStornieren : IAsyncDisposable
    {
        [Parameter] public int Auftragsnummer { get; set; }
#nullable disable
        [CascadingParameter] public AppMitarbeiter Mitarbeiter { get; set; }
#nullable enable
        public AuftragStornierenInput? Input { get; set; }



        protected override async Task OnParametersSetAsync()
        {
            // Put DEBUG point here
            if (Auftragsnummer > 0)
            {
                // The real project checks in database for an object, simulate with sessionstorage
                bool isStorno = await SessionStorage.GetItemAsync<bool>(Auftragsnummer.ToString());

                // This section is now true when you ran SaveAsync before therefor we now have two AlertBoxes. Which is false
                if (isStorno)
                {
                    await AddAlertAsync(new AlertBox
                    {
                        Message = $"AU-{Auftragsnummer} ist bereits storniert.",
                        AlertType = AlertType.Danger
                    });
                    navigationManager.NavigateTo("/");
                    return;
                }

                Input = new AuftragStornierenInput(Auftragsnummer, 20)
                {
                    Kontoinhaber = "Marvin Klein"
                };

                Input.ValueForTextChanged += Input_ValueForTextChanged;


            }
        }

        private async Task SaveAsync()
        {

            try
            {
                Console.WriteLine(Mitarbeiter.PersonalNummer);
                // The real app updates the orde rin database, simulate here
                await SessionStorage.SetItemAsync(Auftragsnummer.ToString(), true);
                // Stuff is happening in original project here
                await AddAlertAsync(new AlertBox
                {
                    AlertType = AlertType.Success,
                    Message = $"AU-{Auftragsnummer} wurde erfolgreich storniert"
                });

                // This is the important line which causes OnParameterSetAsync to be called again which should be the case
                navigationManager.NavigateTo("/");
            }
            catch (Exception)
            {
                // Stuff is happening in original project here
                throw;
            }
        }

        #region Generierung der Texte
        private void Input_ValueForTextChanged(object? sender, EventArgs e)
        {
            // More stuff is happening here
            StateHasChanged();
        }



        #endregion
        #region IAsyncDisposable

        public ValueTask DisposeAsync()
        {
            if (Input is not null)
            {
                Input.ValueForTextChanged -= Input_ValueForTextChanged;
            }

            return ValueTask.CompletedTask;
        }
        #endregion
    }
}
