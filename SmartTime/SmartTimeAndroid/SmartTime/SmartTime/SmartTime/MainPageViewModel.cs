using System;
using System.Threading.Tasks;
using Firebase.Database;
using Xamarin.Essentials;

namespace SmartTime
{
    public class MainPageViewModel : ViewModelBase
    {
        private string _message;

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        private readonly FirebaseClient _firebase;

        public MainPageViewModel()
        {
            _firebase = new FirebaseClient("https://smarttime-894c9.firebaseio.com/");
            UpdateContinuously();
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
                    Message = $"Latitude: {location.Latitude}, Longitude: {location.Longitude} ";
                    await _firebase.Child("Latitude").PutAsync(location.Latitude.ToString());
                    await _firebase.Child("Longitude").PutAsync(location.Longitude.ToString());
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
    }
}