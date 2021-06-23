using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class AuftragStornierenInput
    {
        private string _kontoinhaber = String.Empty;
        private string _iban = String.Empty;
        private string _bic = String.Empty;
        private string _begründung = String.Empty;
        private bool _bankdatenErhalten;

        public string Begründung
        {
            get => _begründung;
            set
            {
                _begründung = value;
                ValueForTextChanged?.Invoke(Begründung, EventArgs.Empty);
            }
        }
        public int Auftragsnummer { get; }
        public int ZahlungsbedingungId { get; }
        public bool MailAnKunden { get; set; }
        public bool MailAnLieferanten { get; set; }
        public bool MailAnBuchhaltung { get; set; }
        public bool BankdatenErhalten
        {
            get => _bankdatenErhalten;
            set
            {
                _bankdatenErhalten = value;
                ValueForTextChanged?.Invoke(BankdatenErhalten, EventArgs.Empty);
            }
        }
        public string TextKundenMail { get; set; }
        public string TextLieferantenMail { get; set; }
        public string TextBuchhaltungsMail { get; set; }

        public string Kontoinhaber
        {
            get => _kontoinhaber;
            set
            {
                _kontoinhaber = value;
                ValueForTextChanged?.Invoke(Kontoinhaber, EventArgs.Empty);
            }
        }
        public string Iban
        {
            get => _iban;
            set
            {
                _iban = value;
                ValueForTextChanged?.Invoke(Iban, EventArgs.Empty);
            }
        }
        public string Bic
        {
            get => _bic;
            set
            {
                _bic = value;
                ValueForTextChanged?.Invoke(Bic, EventArgs.Empty);
            }
        }

        public AuftragStornierenInput(int auftragsnummer, int zahlungsbedingungId)
        {
            Auftragsnummer = auftragsnummer;
            ZahlungsbedingungId = zahlungsbedingungId;
            Kontoinhaber = String.Empty;
            Iban = String.Empty;
            Bic = String.Empty;
            TextKundenMail = String.Empty;
            TextLieferantenMail = String.Empty;
            TextBuchhaltungsMail = String.Empty;
            Begründung = String.Empty;
        }

        public event EventHandler? ValueForTextChanged;


    }
}
