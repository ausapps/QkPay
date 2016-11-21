using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace QkPay.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            if (App.Database.GetUsers().Count() == 0)
                App.Current.Navigation.Navigation.PushModalAsync(new NavigationPage(new SignUpPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }

        public void LoginClicked(object sender, EventArgs e)
        {
            App.Current.GotoMain();
        }
    }
}