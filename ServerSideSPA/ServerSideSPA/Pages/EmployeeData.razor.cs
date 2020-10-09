using Microsoft.AspNetCore.Components;
using ServerSideSPA.Data;
using ServerSideSPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSideSPA.Pages
{
    public class EmployeeDataModel : ComponentBase
    {
        [Inject]
        protected EmployeeService EmployeeService { get; set; }
        protected List<Employee> empList = new List<Employee>();
        protected List<Employee> searchEmpData = new List<Employee>();
        protected Employee emp = new Employee();
        protected string SearchString { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await GetEmployee();
        }

        protected async Task GetEmployee()
        {
            empList = await EmployeeService.GetEmployeeList();
            searchEmpData = empList;
        }

        protected void FilterEmp()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                empList = searchEmpData.Where(x => x.Name.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            }
            else
            {
                empList = searchEmpData;
            }
        }

        protected void DeleteConfirm(int empID)
        {
            emp = empList.FirstOrDefault(x => x.EmployeeId == empID);
        }

        protected async Task DeleteEmployee(int empID)
        {
            await Task.Run(() =>
            {
                EmployeeService.Delete(empID);
            });
            await GetEmployee();
        }
    }
}
