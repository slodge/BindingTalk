using System;
using System.ComponentModel;
using Android.App;
using Android.OS;
using Android.Widget;
using BindingTalk.Droid.ViewModels;
using Cirrious.MvvmCross.Droid.Views;

namespace BindingTalk.Droid.Views
{
    [Activity(Label = "First Principles")]
    public class FirstPrinciplesView : MvxActivity
    {
        private SimpleViewModel _simpleViewModel;
        
        private EditText _firstNameEdit;
        private EditText _secondNameEdit;
        private TextView _fullNameLabel;

        // 4. Don’t loop!
        private bool _isSettingValue;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstPrinciplesView);
            _simpleViewModel = new SimpleViewModel();

            _firstNameEdit = FindViewById<EditText>(Resource.Id.FirstNameEdit);
            _secondNameEdit = FindViewById<EditText>(Resource.Id.SecondNameEdit);
            _fullNameLabel = FindViewById<TextView>(Resource.Id.FullNameLabel);

            // 1. Initially copy values ViewModel -> View 
            SetInitialValues();

            // 2. When ViewModel changes, update View
            _simpleViewModel.PropertyChanged += OnPropertyChanged;

            // 3. When View changes, update ViewModel
            SubscribeToUIChanges();
        }

        private void SetInitialValues()
        {
            _firstNameEdit.Text = _simpleViewModel.FirstName;
            _secondNameEdit.Text = _simpleViewModel.SecondName;
            _fullNameLabel.Text = _simpleViewModel.FullName;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _isSettingValue = true;
            switch (e.PropertyName)
            {
                case "FirstName":
                    _firstNameEdit.Text = _simpleViewModel.FirstName;
                    break;
                case "SecondName":
                    _secondNameEdit.Text = _simpleViewModel.SecondName;
                    break;
                case "FullName":
                    _fullNameLabel.Text = _simpleViewModel.FullName;
                    break;
                case "":
                case null:
                    _firstNameEdit.Text = _simpleViewModel.FirstName;
                    _secondNameEdit.Text = _simpleViewModel.SecondName;
                    _fullNameLabel.Text = _simpleViewModel.FullName;
                    break;
            }
            _isSettingValue = false;
        }

        private void SubscribeToUIChanges()
        {
            _firstNameEdit.TextChanged += (s, e) =>
            {
                if (_isSettingValue)
                    return;
                _simpleViewModel.FirstName = _firstNameEdit.Text;
            };
            _secondNameEdit.TextChanged += (s, e) =>
            {
                if (_isSettingValue)
                    return;
                _simpleViewModel.SecondName = _secondNameEdit.Text;
            };
        }

        protected override void OnDestroy()
        {
            // 5. When the View disappears, dispose the bindings
            _simpleViewModel.PropertyChanged -= OnPropertyChanged;
            _simpleViewModel = null;
            base.OnDestroy();
        }
    }
}