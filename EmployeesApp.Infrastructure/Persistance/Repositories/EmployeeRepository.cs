﻿using EmployeesApp.Infrastructure.Persistance;
using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Infrastructure.Persistance.Repositories
{
    public class EmployeeRepository(ApplicationContext context) : IEmployeeRepository
    {
        public async Task AddAsync(Employee employee)
        {
            context.Employees.Add(employee);
            await context.SaveChangesAsync(); // Inte glömma!
        }

        //Classic C# syntax for GetAll()
        public async Task<Employee[]> GetAllAsync() => await context.Employees.ToArrayAsync();

        public async Task<Employee?> GetByIdAsync(int id) => await context.Employees
            .FindAsync(id);
    }
}