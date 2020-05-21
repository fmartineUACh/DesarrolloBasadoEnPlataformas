using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartTime
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage(new MainPageViewModel());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
