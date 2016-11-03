using InfoNotes.Common;
using InfoNotes.Models;
using System;
using System.Linq;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.UI.StartScreen;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Navigation;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace InfoNotes
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewNotes : Page
    {
        private Geolocator geoLocator;
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private Note note;
        private static double latitude, longitude;
        private string thisPageUri;
        public ViewNotes()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            geoLocator = new Geolocator();
            //geoLocator.MovementThreshold = 100;
            geoLocator.DesiredAccuracy = PositionAccuracy.High;
        }
        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
            note = e.Parameter as Note;
            DataContext = note;
            latitude = Double.Parse(note.Latitude);
            longitude = Double.Parse(note.Longitude);
            if (note.Category != null)
            {
                tbCategory.Text = note.Category;
            }

            loadMap();

            var noteID = int.Parse(note.ID);
       }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EditNote), note);

        }

        private void btnPin_Click(object sender, RoutedEventArgs e)
        {
            SecondaryTile tileData = new SecondaryTile()
            {
                TileId = note.ID,
                DisplayName = note.Title,
                Arguments = note.Content
            };
            tileData.VisualElements.Square150x150Logo = new Uri("ms-appx:///Assets/tile.png");
            tileData.VisualElements.ShowNameOnSquare150x150Logo = true;
            tileData.RequestCreateAsync();    
            btnPin.Icon = new SymbolIcon(Symbol.UnPin);
        }

        private void loadMap()
        {
            Geopoint centerPoint = new Geopoint(new BasicGeoposition()
            { Latitude = latitude, Longitude = longitude }, 0);
            myMap.Center = centerPoint;
            myMap.ZoomLevel = 16;
            MapIcon mapIcon = new MapIcon();
            mapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/map-marker-hi.png"));
            mapIcon.Location = centerPoint;
            mapIcon.NormalizedAnchorPoint = new Point(0.5, 1.0);
            mapIcon.Title = "Center";
            myMap.MapElements.Add(mapIcon);

        }
    }
}
