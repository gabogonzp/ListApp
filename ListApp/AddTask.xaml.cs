using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddTask : ContentPage
	{
		public AddTask ()
		{
			InitializeComponent ();
		}

       

        async void Agregar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(taskEntry.Text))
            {
                await DisplayAlert("Invalido", "Espacio vacio es invalido", "Ok");
            }
          
           
            else
                AddNewTask();
        }

        async void AddNewTask()
        {
            await App.MyDatabase.CreateTask(new Datamodels.ToDoItem
            {
                Task = taskEntry.Text,
                Status = false,
            });
            await Navigation.PopAsync();
        }

        async void Volver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}