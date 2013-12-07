using System;
using System.Collections.ObjectModel;
using Cirrious.MvvmCross.ViewModels;

namespace BindingTalk.Core.ViewModels
{
    public class MappingViewModel
        : MvxViewModel
    {
        public class Location
            : MvxNotifyPropertyChanged
        {
            private double _lat;

            public double Lat
            {
                get { return _lat; }
                set
                {
                    _lat = value;
                    RaisePropertyChanged(() => Lat);
                }
            }

            private double _lng;
            public double Lng 
            {   
                get { return _lng; }
                set { _lng = value; RaisePropertyChanged(() => Lng); }
            }
        }

        public class Zombie
            : MvxNotifyPropertyChanged
        {
            private Location _location;
            public Location Location 
            {   
                get { return _location; }
                set { _location = value; RaisePropertyChanged(() => Location); }
            }

            private string _name;
            public string Name 
            {   
                get { return _name; }
                set { _name = value; RaisePropertyChanged(() => Name); }
            }
        }

        private ObservableCollection<Zombie> _zombies;
        public ObservableCollection<Zombie> Zombies 
        {   
            get { return _zombies; }
            set { _zombies = value; RaisePropertyChanged(() => Zombies); }
        }

        public MappingViewModel()
        {
            _zombies = new ObservableCollection<Zombie>();
        }

        private Location _center = new Location()
            {
                Lat = 51.5112,
                Lng = -0.1198
            };
        public Location Center 
        {   
            get { return _center; }
            set { _center = value; RaisePropertyChanged(() => Center); }
        }

        private readonly Random _r = new Random();
        private Location RandomLocation()
        {
            return new Location()
                {
                    Lat = (_r.NextDouble() - 0.5) * 0.01 + _center.Lat,
                    Lng = (_r.NextDouble() - 0.5) * 0.01 + _center.Lng,
                };
        }
        public IMvxCommand AddZombieCommand
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        var z = new Zombie
                            {
                                Name = "Zombie #" + (Zombies.Count + 1), 
                                Location = RandomLocation()
                            };
                        Zombies.Add(z);
                    });
            }
        }
    }
}