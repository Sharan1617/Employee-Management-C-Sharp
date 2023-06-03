namespace MultiformEmployeeInfo
{
    internal class Employee
    {
        
        public bool IsNew { get; set; } = true;
        public int Emp_Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public decimal? Hourly_rate { get; set; }
    }
}
