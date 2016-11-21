using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QkPay.Helpers;
using Xamarin.Forms;
using QkPay.Pages;
using QkPay.Data;

namespace QkPay
{
    public partial class App : Application
    {

        public NavigationPage Navigation { get; set; }

        public static new App Current { get; private set; }

        static ItemDatabase database;

        public static ItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ItemDatabase();
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            Current = this;
            MainPage = Navigation = new NavigationPage( new TermsPage());
        }

        public void GotoMain()
        {
            Navigation.Navigation.InsertPageBefore(new MainPage(), Navigation.CurrentPage);
            Navigation.Navigation.PopToRootAsync();
        }

        public void GotoLogin()
        {
            Navigation.Navigation.InsertPageBefore(new LoginPage(), Navigation.CurrentPage);
            Navigation.Navigation.PopToRootAsync();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
