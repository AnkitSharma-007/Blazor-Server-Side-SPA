using Microsoft.AspNetCore.Components;
using ServerSideSPA.Data;
using ServerSideSPA.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerSideSPA.Pages
{
    public class AddEditEmployeeModel : ComponentBase
    {
        [Inject]
        protected EmployeeService EmployeeService { get; set; }
        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }
        [Parameter]
        public int empID { get; set; }

        protected string Title = "Add";
        public Employee emp = new Employee();
        protected List<Cities> cityList = new List<Cities>();

        protected override async Task OnInitializedAsync()
        {
            await GetCityList();
        }

        protected override async Task OnParametersSetAsync()
        {
            if (empID != 0)
            {
                Title = "Edit";
                emp = await EmployeeService.Details(empID);
            }
        }

        protected async Task GetCityList()
        {
            cityList = await EmployeeService.GetCities();
        }

        protected async Task SaveEmployee()
        {
            if (emp.EmployeeId != 0)
            {
                await Task.Run(() =>
                {
                    EmployeeService.Edit(emp);
                });
            }
            else
            {
                await Task.Run(() =>
                {
                    EmployeeService.Create(emp);
                });
            }
            Cancel();
        }

        public void Cancel()
        {
            UrlNavigationManager.NavigateTo("/fetchemployee");
        }
    }
}
