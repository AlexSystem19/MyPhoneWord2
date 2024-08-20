namespace MyPhoneWord2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        string translatedNumber;

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
                Btnllamar.Text = "llamar";
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
                // TODO: dial the phone
            }
        }
    }

}
