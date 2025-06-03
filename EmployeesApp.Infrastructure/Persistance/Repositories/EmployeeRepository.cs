using EmployeesApp.Infrastructure.Persistance;
using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;

namespace EmployeesApp.Infrastructure.Persistance.Repositories
{
    public class EmployeeRepository(ApplicationContext context) : IEmployeeRepository
    {
        public void Add(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges(); // Inte glömma!
        }

        //Classic C# syntax for GetAll()
        public Employee[] GetAll() => [.. context.Employees];

        public Employee? GetById(int id) => context.Employees
            .Find(id);
    }
}