using ServerSideSPA.App.DataAccess;
using ServerSideSPA.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSideSPA.App.Services
{
    public class EmployeeService
    {
        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();

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
