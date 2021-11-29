using Microsoft.EntityFrameworkCore;
using ServerSideSPA.Interface;
using ServerSideSPA.Models;

namespace ServerSideSPA.DataAccess
{

    public class EmployeeDataAccessLayer : IEmployee
    {
        private EmployeeDBContext db;

        public EmployeeDataAccessLayer(EmployeeDBContext _db)
        {
            db = _db;
        }

        //To Get all employees details     
        public List<Employee> GetAllEmployees()
        {
            try
            {
                return db.Employees.AsNoTracking().ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new employee record       
        public void AddEmployee(Employee employee)
        {
            try
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar employee      
        public void UpdateEmployee(Employee employee)
        {
            try
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular employee      
        public Employee GetEmployeeData(int id)
        {
            try
            {
                Employee? employee = db.Employees.Find(id);

                if (employee != null)
                {
                    db.Entry(employee).State = EntityState.Detached;
                    return employee;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular employee      
        public void DeleteEmployee(int id)
        {
            try
            {
                Employee? employee = db.Employees.Find(id);

                if (employee != null)
                {
                    db.Employees.Remove(employee);
                }
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        // To get the list of Cities
        public List<City> GetCityData()
        {
            try
            {
                return db.Cities.ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
