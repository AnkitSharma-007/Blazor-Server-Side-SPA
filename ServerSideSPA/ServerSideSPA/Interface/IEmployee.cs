using ServerSideSPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSideSPA.Interface
{
    public interface IEmployee
    {
        public List<Employee> GetAllEmployees();
        public void AddEmployee(Employee employee);
        public void UpdateEmployee(Employee employee);
        public Employee GetEmployeeData(int id);
        public void DeleteEmployee(int id);
        public List<Cities> GetCityData();
    }
}
