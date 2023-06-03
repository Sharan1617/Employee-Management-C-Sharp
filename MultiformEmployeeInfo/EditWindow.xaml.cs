using System.Windows;
using System.Data.SqlClient;

namespace MultiformEmployeeInfo
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        VM vm;
        Employee employee = new Employee();
        
        public EditWindow(bool IsEdit)
        {
            InitializeComponent();
            vm = VM.Instance;

            if (IsEdit)
            {
                employee.Emp_Id = vm.SelectedEmployee.Emp_Id;
                employee.Name = vm.SelectedEmployee.Name;
                employee.Position = vm.SelectedEmployee.Position;
                employee.Hourly_rate = vm.SelectedEmployee.Hourly_rate;

                employee.IsNew = false;
                EmployeeID.IsEnabled = false;

            }
            else
            {
                Title = "Edit Employee Details";
                EmployeeID.IsEnabled = false;
             
            }
            DataContext = employee;
           
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
         //   if(EmployeeID.Value == employee.Emp_Id)
         //   {
         //       MessageBox.Show("Please enter other value ");
         //   }
          //  else
            vm.Save(employee);
            Close();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
