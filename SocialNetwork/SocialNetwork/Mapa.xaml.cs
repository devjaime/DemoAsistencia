using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace SocialNetwork
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mapa : ContentPage
    {
        Map map;

        public Mapa()
        {
            InitializeComponent();
            AgregaMapa();
        }

        private void AgregaMapa()
        {
            map = new Map
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            mainLayout.Children.Add(map);
        }

        public void SetMapPosition(Location location)
        {
            var pos = new Position(location.Latitude, location.Longitude);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(pos, new Distance(500)));
            map.Pins.Add(new Pin { Position = pos, Type = PinType.Generic, Label = "Mi ubicación" });
        }
    }
}