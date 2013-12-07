using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using BindingTalk.Core.ViewModels;
using Cirrious.CrossCore.Converters;
using Cirrious.CrossCore.Core;
using Cirrious.CrossCore.Exceptions;
using Cirrious.CrossCore.WeakSubscription;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging;

namespace BindingTalk.Droid.Views
{
    [Activity(Label = "Mapping")]
    public class MappingActivity : MvxFragmentActivity
    {
        private ZombieMarkerSet _zombieMarkers;
        private CenterHelper _centerHelper;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MappingView);
            var mapFragment = (SupportMapFragment)SupportFragmentManager.FindFragmentById(Resource.Id.map);
            var zoomUpdate = CameraUpdateFactory.ZoomTo(14);
            mapFragment.Map.MoveCamera(zoomUpdate);

            _zombieMarkers = new ZombieMarkerSet(mapFragment.Map);
            _centerHelper = new CenterHelper(mapFragment.Map);

            var set = this.CreateBindingSet<MappingActivity, MappingViewModel>();
            set.Bind(_zombieMarkers)
               .For(m => m.ItemsSource)
               .To(vm => vm.Zombies);
            set.Bind(_centerHelper)
               .For(m => m.Center)
               .To(vm => vm.Center)
               .WithConversion(new LocationToLatLngValueConverter(), null);
            set.Apply();
        }
    }

    public class LocationToLatLngValueConverter
        : MvxValueConverter<MappingViewModel.Location, LatLng>
    {
        protected override LatLng Convert(MappingViewModel.Location value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;

            return new LatLng(value.Lat, value.Lng);
        }

        protected override MappingViewModel.Location ConvertBack(LatLng value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;

            return new MappingViewModel.Location() { Lat = value.Latitude, Lng = value.Longitude };
        }
    }

    public class CenterHelper
    {
        private readonly GoogleMap _map;

        public CenterHelper(GoogleMap map)
        {
            _map = map;
            _map.CameraChange += (sender, args) => CenterChanged.Raise(this);
        }

        public event EventHandler CenterChanged;

        public LatLng Center
        {
            get
            {
                return _map.CameraPosition.Target;
            }
            set
            {
                var center = CameraUpdateFactory.NewLatLng(value);
                _map.MoveCamera(center);
            }
        }
    }

    public class ZombieMarkerSet
    {
        private IDisposable _token;
        private readonly List<ZombieWrapper> _markerWrappers = new List<ZombieWrapper>();

        private readonly GoogleMap _map;

        private IEnumerable _itemsSource;

        public ZombieMarkerSet(GoogleMap map)
        {
            _map = map;
        }

        public IEnumerable ItemsSource
        {
            get { return _itemsSource; }
            set
            {
                if (_itemsSource == value)
                    return;

                if (_token != null)
                {
                    _token.Dispose();
                    _token = null;
                }

                _itemsSource = value;

                var notify = _itemsSource as INotifyCollectionChanged;
                if (notify != null)
                    _token = notify.WeakSubscribe(HandleChangedMessage);

                ReloadAll();
            }
        }

        private void ReloadAll()
        {
            RemoveAll();
            AddAll();
        }

        private void AddAll()
        {
            if (_itemsSource == null)
                return;

            foreach (var item in _itemsSource)
            {
                var zomby = (MappingViewModel.Zombie)item;
                AddZombie(zomby);
            }
        }

        private void AddZombie(MappingViewModel.Zombie zomby)
        {
            var options = new MarkerOptions();
            options.SetPosition(new LatLng(zomby.Location.Lat, zomby.Location.Lng));
            options.SetTitle(zomby.Name);
            var marker = _map.AddMarker(options);
            var markerWrapper = new ZombieWrapper(zomby, marker);
            _markerWrappers.Add(markerWrapper);
        }

        private void RemoveAll()
        {
            foreach (var markerWrapper in _markerWrappers)
            {
                markerWrapper.Remove();
                markerWrapper.Dispose();
            }
            _markerWrappers.Clear();
        }

        private void HandleChangedMessage(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var item in e.NewItems)
                    {
                        var zomby = (MappingViewModel.Zombie)item;
                        AddZombie(zomby);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var item in e.OldItems)
                    {
                        var zomby = (MappingViewModel.Zombie)item;
                        RemoveZombie(zomby);
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    // ignore this - not used
                    throw new MvxException("Zombies should not be moved");
                    break;
                case NotifyCollectionChangedAction.Move:
                    // ignore this - not used
                    throw new MvxException("Zombies should not be moved");
                    break;
                case NotifyCollectionChangedAction.Reset:
                    ReloadAll();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void RemoveZombie(MappingViewModel.Zombie zomby)
        {
            var zombieWrapper = _markerWrappers.FirstOrDefault(mw => mw.Zombie == zomby);
            if (zombieWrapper == null)
                throw new MvxException("Zombie not found");

            _markerWrappers.Remove(zombieWrapper);
            zombieWrapper.Dispose();
        }
    }


    public sealed class ZombieWrapper
        : IDisposable
    {
        private readonly MappingViewModel.Zombie _zombie;
        private readonly Marker _marker;
        private IDisposable _token;

        public ZombieWrapper(MappingViewModel.Zombie zombie, Marker marker)
        {
            _zombie = zombie;
            _marker = marker;

            _token = _zombie.WeakSubscribe(OnLocationChanged);
        }

        private void OnLocationChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Location")
                return;

            Position = new LatLng(_zombie.Location.Lat, _zombie.Location.Lng);
        }

        public LatLng Position
        {
            get { return _marker.Position; }
            set { _marker.Position = value; }
        }

        public MappingViewModel.Zombie Zombie
        {
            get { return _zombie; }
        }

        public void Remove()
        {
            _marker.Remove();
        }

        public void Dispose()
        {
            _token.Dispose();
        }
    }

}