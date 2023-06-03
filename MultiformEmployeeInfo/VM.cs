using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MultiformEmployeeInfo
{
    internal class VM : INotifyPropertyChanged
    {
        DB db = DB.Instance;
        List<Employee> employees;
        #region singleton
        private static VM vm;
        public static VM Instance { get { vm ??= new VM(); return vm; } }

        private VM()
        {
            employees = db.Get();
            updateEmployees();
        }
        #endregion
        public BindingList<Employee> Employees { get; set; } = new BindingList<Employee>();

        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set { selectedEmployee = value; propertyChanged(); }
        }

        private string searchEmployee;
        public string SearchEmployee
        {
            get => searchEmployee;
            set { searchEmployee = value; propertyChanged(); }
        }
        public void Save(Employee employee)
        {
            bool success = false;

            if (employee.IsNew)
            {
                success = db.Insert(employee);
            }
            else
            {
                success = db.Update(employee);
                if (success)
                {
                    employees.Remove(SelectedEmployee);
                    SelectedEmployee = null;
                }
            }
            if (success)
            {
                employees.Add(employee);
                employees = employees.OrderBy(e => e.Emp_Id).ToList();
                updateEmployees();
            }
        }
        public void Delete()
        {
            if (db.Delete(selectedEmployee))
            {
                employees.Remove(selectedEmployee);
                Employees.Remove(selectedEmployee);
                SelectedEmployee = null;
            }
        }
        private void updateEmployees()
        {
            employees = db.Get();
            Employees.Clear();
            foreach (Employee e in employees)
                Employees.Add(e);
        }
        public void SortByName()
        {
            Employees.Clear();
            foreach (var e in employees.OrderBy(e => e.Name))
                Employees.Add(e);
        }
        public void SearchByName()
        {
            employees = db.Search(searchEmployee);
            updateEmployees();
        }
        #region Property Changed
        public event PropertyChangedEventHandler? PropertyChanged;

        private void propertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

