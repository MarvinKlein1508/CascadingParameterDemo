using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Pages
{
    public partial class AuftragStornieren : IDisposable
    {
        [Parameter] public int Auftragsnummer { get; set; }
#nullable disable
        [CascadingParameter] public AppMitarbeiter Mitarbeiter { get; set; }
#nullable enable
        public AuftragStornierenInput? Input { get; set; }

        public bool IstBuchhaltungNotwendig { get; set; }
        public bool IstLieferantNotwendig { get; set; }
        public bool ErfordertZahlartKontodaten { get; set; }

        private List<StornierTemplate> _templates = new List<StornierTemplate>()
        {
            new StornierTemplate{ STTE_A_GRUND = "Other" },
            new StornierTemplate{ STTE_A_GRUND = "Test" }
        };

        private EditForm? _editForm;
        protected override async Task OnParametersSetAsync()
        {
            if (Auftragsnummer > 0)
            {
                // The real project checks in database for an object, simulate with sessionstorage
                bool isStorno  = await SessionStorage.GetItemAsync<bool>(Auftragsnummer.ToString());

                if (isStorno)
                {
                    await AddAlertAsync(new AlertBox
                    {
                        Message = $"AU-{Auftragsnummer} ist bereits storniert.",
                        AlertType = AlertType.Danger
                    });
                    navigationManager.NavigateTo("/Auftraege");
                    return;
                }

                Input = new AuftragStornierenInput(Auftragsnummer, 20)
                {
                    Kontoinhaber = "Marvin Klein"
                };

                Input.ValueForTextChanged += Input_ValueForTextChanged;

                IstBuchhaltungNotwendig = false;
                ErfordertZahlartKontodaten = false;
                IstLieferantNotwendig = false;
            }
        }

        private async Task SaveAsync()
        {
            if (_editForm is null || _editForm.EditContext is null || Input is null)
            {
                return;
            }

            if (true) // the real app calls validation for edit form here
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

                    // This is the important line
                    navigationManager.NavigateTo("/");
                }
                catch (Exception)
                {
                    // Stuff is happening in original project here
                    throw;
                }


            }
        }

        #region Generierung der Texte
        private void Input_ValueForTextChanged(object? sender, EventArgs e)
        {
            // More stuff is happening here
            StateHasChanged();
        }

       

        #endregion
        #region IDisposable
        public void Dispose()
        {
            if (Input is not null)
            {
                Input.ValueForTextChanged -= Input_ValueForTextChanged;
            }
        }
        #endregion
    }
}
