using System.Collections.Generic;
using System.Data.SqlClient;

namespace MultiformEmployeeInfo
{
    internal class DB
    {
        const string CONNECTION_STRING = @"Server=localhost\SQLEXPRESS;Database=Personnel;Trusted_Connection=True;";
        const string INSERT_COMMAND = "INSERT INTO Employee (name, position, hourlyRate)" + "VALUES(@NAME, @POSITION, @HOURLY_RATE)";
        const string UPDATE_COMMAND = "UPDATE Employee " +
                   "SET hourlyRate = @HOURLY_RATE, name = @NAME, position = @POSITION " +
                   "WHERE empID = @EMP_ID";
        const string DELETE_COMMAND = "DELETE FROM Employee WHERE empID = @EMP_ID";
        const string SELECT_COMMAND = "SELECT empID, name, position, hourlyRate FROM Employee";
        const string SEARCH_COMMAND = "SELECT empID, name, position, hourlyRate FROM Employee WHERE NAME LIKE @NAME";

        private static DB db;
        public static DB Instance { get { db ??= new DB(); return db; } }

        private SqlConnection conn;
        private DB()
        {
            conn = new SqlConnection(CONNECTION_STRING);
            conn.Open();
        }
        public bool Insert(Employee employee)
        {
            using SqlCommand cmd = new SqlCommand(INSERT_COMMAND, conn);
           // cmd.Parameters.AddWithValue("@EMP_ID", employee.Emp_Id);
            cmd.Parameters.AddWithValue("@NAME", employee.Name);
            cmd.Parameters.AddWithValue("@POSITION", employee.Position);
            cmd.Parameters.AddWithValue("@HOURLY_RATE", employee.Hourly_rate);
            return cmd.ExecuteNonQuery() > 0;
        }
        public bool Update(Employee employee)
        {
            using SqlCommand cmd = new SqlCommand(UPDATE_COMMAND, conn);
           cmd.Parameters.AddWithValue("@EMP_ID", employee.Emp_Id);
            cmd.Parameters.AddWithValue("@NAME", employee.Name);
            cmd.Parameters.AddWithValue("@POSITION", employee.Position);
            cmd.Parameters.AddWithValue("@HOURLY_RATE", employee.Hourly_rate);
            return cmd.ExecuteNonQuery() > 0;
        }
        public bool Delete(Employee employee)
        {
            using SqlCommand cmd = new SqlCommand(DELETE_COMMAND, conn);
            cmd.Parameters.AddWithValue("@EMP_ID", employee.Emp_Id);
            return cmd.ExecuteNonQuery() > 0;
        }
        public List<Employee> Get()
        {
            List<Employee> employees = new List<Employee>();
            using SqlCommand cmd = new SqlCommand(SELECT_COMMAND, conn);
            using SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
                employees.Add(new Employee
                {
                    Emp_Id = dr.GetInt32(dr.GetOrdinal("empID")),
                    Name = dr.GetString(dr.GetOrdinal("name")),
                    Position = dr.GetString(dr.GetOrdinal("position")),
                    Hourly_rate = dr.IsDBNull(dr.GetOrdinal("hourlyRate")) ? null : (decimal?)dr.GetDecimal(dr.GetOrdinal("hourlyRate")),
                    IsNew = false
                });
            dr.Close();
            return employees;
        }
        public List<Employee> Search(string input)
        {
            List<Employee> employees = new List<Employee>();
            using SqlCommand cmd = new SqlCommand(SEARCH_COMMAND, conn);
            cmd.Parameters.AddWithValue("@NAME", $"%{input}%");
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
                employees.Add(new Employee
                {
                    Emp_Id = dr.GetInt32(dr.GetOrdinal("empID")),
                    Name = dr.GetString(dr.GetOrdinal("name")),
                    Position = dr.GetString(dr.GetOrdinal("position")),
                    Hourly_rate = dr.IsDBNull(dr.GetOrdinal("hourlyRate")) ? null : (decimal?)dr.GetDecimal(dr.GetOrdinal("hourlyRate")),
                    IsNew = false
                });
            dr.Close();
            return employees;
        }
    }
}
