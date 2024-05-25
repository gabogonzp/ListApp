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
    public partial class EditTask : ContentPage
    {
        public EditTask()
        {
            InitializeComponent();
        }

        Datamodels.ToDoItem _toDoItem;

        public EditTask(Datamodels.ToDoItem toDoItem)
        {
            InitializeComponent();
            _toDoItem = toDoItem;
            taskEdit.Text = toDoItem.Task;
            taskEdit.Focus();
        }

        async void Editar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(taskEdit.Text))
            {
                await DisplayAlert("Invalido", "Espacio vacio es invalido", "Ok");
            }


            else
                UpdateTask();
        }

        async void UpdateTask()
        {
            _toDoItem.Task = taskEdit.Text;
            await App.MyDatabase.UpdateTask(_toDoItem);
            await Navigation.PopAsync();    
        }

        async void Volver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}