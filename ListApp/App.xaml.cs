﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ListApp.Datamodels;
using System.IO;

namespace ListApp
{
    public partial class App : Application
    {

        private static SQLiteHelper db;
        public static SQLiteHelper MyDatabase
        {
            get 
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "ListApp.db3"));
                }
                return db;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }



        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
