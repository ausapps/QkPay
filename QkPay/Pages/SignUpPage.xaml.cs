using Plugin.Media;
using Plugin.Media.Abstractions;
using QkPay.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace QkPay.Pages
{
    public partial class SignUpPage : CarouselPage
    {

        private User _appUser;
        private int _selectedGender;
        private string _pinConfirm;

        public int SelectedGender
        {
            get { return _selectedGender; }
            set { _selectedGender = value; OnPropertyChanged(); }
        }

        public string PinConfirm
        {
            get { return _pinConfirm; }
            set { _pinConfirm = value; OnPropertyChanged(); }
        }

        public SignUpPage()
        {
            InitializeComponent();

            _appUser = new Models.User();

            BindingContext = this;
        }

        private async void Take_Clicked(object sender, EventArgs e)
        {
            await TakePicture();
        }

        private async System.Threading.Tasks.Task TakePicture()
        {
            try
            {
                await CrossMedia.Current.Initialize();
                MediaFile file = null;

                file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                    AllowCropping = true,
                    PhotoSize = PhotoSize.Medium,
                    Name = "QkPayAvatar.png"
                });

                Avatar = file.Path;
                //    OnPropertyChanged("ApUser");
            }
            catch (Exception ex)
            {
            }
        }

        private void Next_Clicked(object sender, EventArgs e)
        {
            if (this.CurrentPage.StyleId == "1")
                this.CurrentPage = Page2;
            else if (this.CurrentPage.StyleId == "2")
                this.CurrentPage = Page3;
            else
                SaveUser();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            if (this.CurrentPage.StyleId == "3")
                this.CurrentPage = Page2;
            else if (this.CurrentPage.StyleId == "2")
                this.CurrentPage = Page1;
            else
                App.Current.Navigation.Navigation.PopModalAsync();
        }

        public void SaveUser()
        {
            Gender = SelectedGender == 0 ? "M" : "F";

            App.Database.SaveUser(_appUser);

            App.Current.Navigation.Navigation.PopModalAsync();
        }

        public string UserId
        {
            get { return _appUser.Id; }
            set { _appUser.Id = value; OnPropertyChanged(); }
        }

        public int? Pin
        {
            get
            {
                if (_appUser.Pin > 0)
                    return _appUser.Pin;
                else
                    return null;
            }
            set {
                if(value.HasValue)
                _appUser.Pin = value.Value; OnPropertyChanged(); }
        }

        public string Name
        {
            get { return _appUser.Name; }
            set { _appUser.Name = value; OnPropertyChanged(); }
        }


        public string Surname
        {
            get { return _appUser.Surname; }
            set { _appUser.Surname = value; OnPropertyChanged(); }
        }


        public string Birthday
        {
            get { return _appUser.Birthday; }
            set { _appUser.Birthday = value; OnPropertyChanged(); }
        }


        public string Gender
        {
            get { return _appUser.Gender; }
            set { _appUser.Gender = value; OnPropertyChanged(); }
        }


        public string Passport
        {
            get { return _appUser.Passport; }
            set { _appUser.Passport = value; OnPropertyChanged(); }
        }


        public string Avatar
        {
            get { return _appUser.Avatar; }
            set { _appUser.Avatar = value; OnPropertyChanged(); }
        }
    }
}