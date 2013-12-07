using System;
using System.Collections.Generic;
using System.ComponentModel;
using Android.App;
using Android.OS;
using BindingTalk.Droid.ViewModels;
using Cirrious.MvvmCross.Droid.Views;

namespace BindingTalk.Droid.Views
{
    [Activity(Label = "Second Principles")]
    public class SecondPrinciplesView : MvxActivity
    {
        readonly List<string> _bindingDescriptions = new List<string>()
                {
                    "FirstNameEdit Text FirstName TwoWay",
                    "SecondNameEdit Text SecondName TwoWay",
                    "FullNameLabel Text FullName OneWay",
                };

        protected INotifyPropertyChanged _dataContext;

        private List<Action> _cleanupActions = new List<Action>(); 

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstPrinciplesView);
            _dataContext = new SimpleViewModel();
            ApplyBindings();
        }

        protected void ApplyBindings()
        {
            foreach (var description in _bindingDescriptions)
            {
                var split = description.Split(' ');

                var controlName = split[0];
                var controlPropertyName = split[1];
                var viewModelPropertyName = split[2];
                var mode = split[3];

                var cleanups = ApplyBinding(controlName, controlPropertyName, viewModelPropertyName, mode);
                _cleanupActions.AddRange(cleanups);
            }
        }

        private IEnumerable<Action> ApplyBinding(string controlName, string controlPropertyName, string viewModelPropertyName, string mode)
        {
            var resourceId = Resources.GetIdentifier(controlName, "id", ApplicationContext.ApplicationContext.PackageName);
            var control = FindViewById(resourceId);

            var controlPropertyInfo = control.GetType().GetProperty(controlPropertyName);
            var viewModelPropertyInfo = _dataContext.GetType().GetProperty(viewModelPropertyName);

            // 1. Initially copy values ViewModel -> View 
            var initialValue = viewModelPropertyInfo.GetValue(_dataContext);
            controlPropertyInfo.SetValue(control, initialValue);

            // 4. Don’t loop!
            bool isSettingValue = false;

            // 2. When ViewModel changes, update View
            var propertyChangedEventHandler = new PropertyChangedEventHandler((sender, args) =>
                {
                    if (isSettingValue)
                        return;

                    isSettingValue = true;
                    if (string.IsNullOrEmpty(args.PropertyName) ||
                        args.PropertyName == viewModelPropertyName)
                    {
                        var currentValue = viewModelPropertyInfo.GetValue(_dataContext);
                        controlPropertyInfo.SetValue(control, currentValue);
                    }
                    isSettingValue = false;
                });
            _dataContext.PropertyChanged += propertyChangedEventHandler;
            yield return () => { _dataContext.PropertyChanged += propertyChangedEventHandler; };

            // 3. When View changes, update ViewModel
            if (mode == "TwoWay")
            {
                var eventChangedName = controlPropertyName + "Changed";
                var eventInfo = control.GetType().GetEvent(eventChangedName);
                EventHandler innerDelegate = (object sender, EventArgs e) =>
                    {
                        if (isSettingValue)
                            return;

                        isSettingValue = true;
                        var controlValue = controlPropertyInfo.GetValue(control);
                        viewModelPropertyInfo.SetValue(_dataContext, controlValue);
                        isSettingValue = false;
                    };

                var outerDelegate = Delegate.CreateDelegate(eventInfo.EventHandlerType, 
                                                            innerDelegate.Target,
                                                            innerDelegate.Method, 
                                                            true);
                eventInfo.AddEventHandler(control, outerDelegate);
                yield return () => eventInfo.RemoveEventHandler(control, outerDelegate);
            }
        }

        protected override void OnDestroy()
        {
            // 5. When the View disappears, dispose the bindings
            _cleanupActions.ForEach(a => a());
            _cleanupActions.Clear();
            base.OnDestroy();
        }
    }
}