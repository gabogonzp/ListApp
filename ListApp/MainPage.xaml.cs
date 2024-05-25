using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ListApp.Datamodels;

namespace ListApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                myCollectionView.ItemsSource = await App.MyDatabase.ReadTask();
            }
            catch { }
        }
         async void Agrega_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTask());
        }

        async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as ToDoItem;
            await Navigation.PushAsync(new EditTask(emp));
        }

        async void SwipeItem_InvokedDelete(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as ToDoItem;
            await App.MyDatabase.DeleteTask(emp);
            myCollectionView.ItemsSource = await App.MyDatabase.ReadTask();

        }
    }
}
