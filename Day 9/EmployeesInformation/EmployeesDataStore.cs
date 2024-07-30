using EmployeesInformation.Models;
using Microsoft.Data.SqlClient;

namespace EmployeesInformation
{
    public class EmployeesDataStore
    {
        private readonly IConfiguration _configuration;

        public EmployeesDataStore(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public EmployeesDataStore()
        //{
        //    Employees = new List<Employee>
        //    {
        //        new Employee { ID = 1, Name = "John Doe", JobTitle = "Software Engineer", Salary = 60000 },
        //        new Employee { ID = 2, Name = "Jane Smith", JobTitle = "Project Manager", Salary = 75000 },
        //        new Employee { ID = 3, Name = "Alice Johnson", JobTitle = "UX Designer", Salary = 50000 },
        //        new Employee { ID = 4, Name = "Bob Brown", JobTitle = "DevOps Engineer", Salary = 65000 }
        //    };
        //}

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            string? connectionString = _configuration.GetConnectionString("EmployeesDatabase");

            const string queryString =
                "SELECT [ID] ,[Name] ,[JobTitle] ,[Salary] FROM [EmployeesDatabase].[dbo].[Employee]";

            List<Employee> employees = [];
            using (SqlConnection connection = new(connectionString))
            {
                SqlCommand command = new(queryString, connection);
                connection.Open();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    employees.Add(new Employee
                    {
                        ID = Convert.ToInt32(reader[0]),
                        Name = reader[1].ToString()!,
                        JobTitle = reader[2].ToString()!,
                        Salary = Convert.ToDecimal(reader[3])
                    });
                }
                reader.Close();
            }
            return employees; 
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            string? connectionString = _configuration.GetConnectionString("EmployeesDatabase");

            const string queryString =
                "SELECT [ID] ,[Name] ,[JobTitle] ,[Salary] FROM [EmployeesDatabase].[dbo].[Employee] WHERE ID=@Id";

            Employee? employee = null;
            using (SqlConnection connection = new(connectionString))
            {
                SqlCommand command = new(queryString, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    employee = new Employee
                    {
                        ID = Convert.ToInt32(reader[0]),
                        Name = reader[1].ToString()!,
                        JobTitle = reader[2].ToString()!,
                        Salary = Convert.ToDecimal(reader[3])
                    };
                }
                reader.Close();
            }
            return employee;
        }

        public async Task<int> CreateEmployee(Employee employee)
        {
            string? connectionString = _configuration.GetConnectionString("EmployeesDatabase");

            const string queryString =
                "INSERT INTO Employee(Name, JobTitle, Salary) VALUES (@Name, @JobTitle, @Salary); SELECT @@IDENTITY";

            int id = -1;
            using (SqlConnection connection = new(connectionString))
            {
                SqlCommand command = new(queryString, connection);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@JobTitle", employee.JobTitle);
                command.Parameters.AddWithValue("@Salary", employee.Salary);
                connection.Open();
                var reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader[0]);
                    break;
                }
                reader.Close();
            }
            return id;
        }

        public async Task DeleteEmployeeById(int id)
        {
            string? connectionString = _configuration.GetConnectionString("EmployeesDatabase");

            const string queryString =
                "DELETE FROM [EmployeesDatabase].[dbo].[Employee] WHERE ID=@Id";

            using (SqlConnection connection = new(connectionString))
            {
                SqlCommand command = new(queryString, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
