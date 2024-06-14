using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ToDoApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TaskTextBox.Text = "Añadir una nueva Tarea";
            TaskTextBox.Foreground = new SolidColorBrush(Colors.Gray);
        }

        // Manejador de evento para el click raton
      
        // Manejador de evento textbox (teclado)
        private void TaskTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddTask();
            }
        }

        // Manejador de evento para el doble click del ratón en ListBox
        private void TaskListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (TaskListBox.SelectedItem != null)
            {
                MarkTaskAsCompleted();
            }
        }

        // Este método se llama cuando el TaskTextBox obtiene la tarea.
        private void TaskTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Verifica si el texto actual en TaskTextBox es el texto del marcador de posición.
            if (TaskTextBox.Text == "Añadir una nueva Tarea")
            {
                // Si lo es, borra el texto en TaskTextBox.
                TaskTextBox.Text = "";
                // Cambia el color del texto a negro para indicar que el usuario puede empezar a escribir.
                TaskTextBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }


        // Manejador de evento para cuando el TextBox 
        private void TaskTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TaskTextBox.Text))
            {
                TaskTextBox.Text = "Añadir una nueva Tarea";
                TaskTextBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        // Método para agregar una nueva tarea a la lista
        // validacion 
        private void AddTask()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(TaskTextBox.Text) && TaskTextBox.Text != "Añadir una nueva Tarea")
                {
                    TaskListBox.Items.Add(new ListBoxItem { Content = TaskTextBox.Text });
                    TaskTextBox.Clear();
                    TaskTextBox_LostFocus(null, null);
                }
                else
                {
                    throw new Exception("El campo de tarea no puede estar vacío.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        // Método para marcar una tarea como completada
        private void MarkTaskAsCompleted()
        {
            var selectedTask = TaskListBox.SelectedItem as ListBoxItem;
            if (selectedTask != null)
            {
                selectedTask.FontStyle = FontStyles.Italic;
                selectedTask.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void TaskTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            AddTask();

        }
    }
}
