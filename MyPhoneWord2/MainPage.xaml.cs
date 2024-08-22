using System.Drawing;

namespace MyPhoneWord2
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
            ChangedOb();
        }
        string translatedNumber;

        void ChangedOb()
        {
            if (translatedNumber != null)
            {
                Btnllamar.IsEnabled = false;
                Btnllamar.FontSize = 6;
            }

        }

        private void OnTranslate(object sender, EventArgs e)
        {
            string enteredNumber = NumeroTelefonoTexto.Text;
            translatedNumber = MyPhoneWord2.PhoneWordTranslator.ToNumber(enteredNumber);

            if (!string.IsNullOrEmpty(translatedNumber))
            {
                Btnllamar.IsEnabled = true;
                Btnllamar.Text = "Llamar " + translatedNumber;
            }
            else
            {
                Btnllamar.IsEnabled = false;
                Btnllamar.Text = "Ingresar numero en letras";
            }
        }

        async void OnCall(object sender, EventArgs e)
        {
            if (await this.DisplayAlert(
       "Marcar Numero",
       "Siguiente numero a marcar : " + translatedNumber + "?",
       "LLAMAR",
       "SALIR"))
            {
                try
                {
                    if (PhoneDialer.Default.IsSupported)
                        PhoneDialer.Default.Open(translatedNumber);
                }
                catch (ArgumentNullException) 
                {
                    await DisplayAlert("Unable to dial", "Numero no valido", "Ok");
                }
                catch (Exception)
                {
                    await DisplayAlert("Desactivado", "no se puede marcar", "OK");
                }
            }
        }
    }

}
