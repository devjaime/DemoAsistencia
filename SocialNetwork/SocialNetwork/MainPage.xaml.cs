using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


using System.Net;
using System.IO;


using System.Xml;
using Xamarin.Essentials;

namespace SocialNetwork
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


        }

        private async void btnLocalizacion_Clicked(object sender, EventArgs e)
        {
            await ObtenerLocalizacionAsync();
        }

        private async Task ObtenerLocalizacionAsync()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    await DisplayAlert("Ubicación", $"Latitude: {location.Latitude}, Longitude: {location.Longitude}", "OK");
                    System.Diagnostics.Debug.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}");

                    var map = new Mapa();
                    await Navigation.PushAsync(map);
                    map.SetMapPosition(location);
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                System.Diagnostics.Debug.WriteLine(fnsEx.ToString());
                await DisplayAlert("Error", "GPS no disponible.", "OK");
            }
            catch (PermissionException pEx)
            {
                System.Diagnostics.Debug.WriteLine(pEx.ToString());
                await DisplayAlert("Error", "GPS no permitido.", "OK");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                await DisplayAlert("Error", $"Error {ex.Message}", "OK");
                if (System.Diagnostics.Debugger.IsAttached)
                    System.Diagnostics.Debugger.Break();
            }
        }
    }
}
