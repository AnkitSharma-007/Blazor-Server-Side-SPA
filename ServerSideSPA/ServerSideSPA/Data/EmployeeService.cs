using ServerSideSPA.Interface;
using ServerSideSPA.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerSideSPA.Data
{
    public class EmployeeService
    {
        private readonly IEmployee objemployee;

        public EmployeeService(IEmployee _objemployee)
        {
            objemployee = _objemployee;
        }

        public Task<List<Employee>> GetEmployeeList()
        {
            return Task.FromResult(objemployee.GetAllEmployees());
        }

        public void Create(Employee employee)
        {
            objemployee.AddEmployee(employee);
        }
        public Task<Employee> Details(int id)
        {
            return Task.FromResult(objemployee.GetEmployeeData(id));
        }

        public void Edit(Employee employee)
        {
            objemployee.UpdateEmployee(employee);
        }

        public void Delete(int id)
        {
            objemployee.DeleteEmployee(id);
        }
        public Task<List<Cities>> GetCities()
        {
            return Task.FromResult(objemployee.GetCityData());
        }

    }
}
