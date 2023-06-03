using System.Windows;

namespace MultiformEmployeeInfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VM vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = VM.Instance;
            DataContext = vm;
            
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            EditWindow ew = new EditWindow(false) { Owner = this };
            ew.ShowDialog();
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (vm.SelectedEmployee != null)
            {
                EditWindow ew = new EditWindow(true) { Owner = this };
                ew.ShowDialog();
            }
            else
                MessageBox.Show("Please select any column to edit");
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (vm.SelectedEmployee != null)
            {
                vm.Delete();
            }
            else
                MessageBox.Show("Please select any column to delete");
        }
        private void SortByName_Click(object sender, RoutedEventArgs e)
        {
            vm.SortByName();
        }
        private void SearchByName_Click(object sender, RoutedEventArgs e)
        {
            vm.SearchByName();
        }
    }
}