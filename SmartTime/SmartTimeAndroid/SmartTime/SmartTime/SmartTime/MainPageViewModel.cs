using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Firebase.Database;
using Firebase.Database.Query;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SmartTime
{
    public class MainPageViewModel : ViewModelBase
    {
        public double Latitude
        {
            get => _latitude;
            set
            {
                _latitude = value; 
                OnPropertyChanged();
            }
        }

        public double Longitude
        {
            get => _longitude;
            set
            {
                _longitude = value; 
                OnPropertyChanged();
            }
        }

        public float Temperature
        {
            get => _temperature;
            set
            {
                _temperature = value; 
                OnPropertyChanged();
            }
        }

        public ICommand ToggleTVCommand { get; set; }
        private HttpClient httpClient;
        private readonly FirebaseClient _firebase;
        private double _latitude;
        private double _longitude;
        private float _temperature;

        public MainPageViewModel()
        {
            _firebase = new FirebaseClient("https://smarttime-894c9.firebaseio.com/");
            UpdateContinuously();
            Temperature = 25;
            httpClient = new HttpClient(new HttpClientHandler());
            ToggleTVCommand = new Command(async () =>
            {
                var currentStatus = await _firebase.Child("TVStatus").OnceSingleAsync<string>();
                if (currentStatus == "On")
                    await _firebase.Child("TVStatus").PutAsync("\"Off\"");
                else
                    await _firebase.Child("TVStatus").PutAsync("\"On\"");
            });
            MessagingCenter.Subscribe<App, float>(this, "Temperature changed", (app, temperature) => Temperature = temperature);
        }

        private async void UpdateContinuously()
        {
            while (true)
            {
                await UpdateFirebase();

                await Task.Delay(TimeSpan.FromSeconds(3));
            }
        }

        async Task UpdateFirebase()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Latitude = location.Latitude;
                    Longitude = location.Longitude;
                    await _firebase.Child("Latitude").PutAsync(Latitude.ToString());
                    await _firebase.Child("Longitude").PutAsync(Longitude.ToString());
                    await _firebase.Child("Temperature").PutAsync(Temperature.ToString());
                }
            }
            catch (Exception ex)
            {
                //Message = ex.Message;
            }
        }
    }
}