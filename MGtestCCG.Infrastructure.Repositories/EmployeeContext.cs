using MGtestCCG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace MGtestCCG.Infrastructure.Repositories
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> employee { get; set; }
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
            
        }

        public void Initialize()
        {
            EmployeeLoad();
            SaveChanges();
        }

        private void EmployeeLoad()
        {
            var employeeOne = new Employee
            {
                Id = 1,
                HourlySalary = 3,
                MonthlySalary = 0,
                TypeContract = 0,
                Name = "Cristian",
                LastName = "Crizon",
                PhoneNumber = "123456"

            };

            var employeeSix = new Employee
            {
                Id = 2,
                HourlySalary = 0,
                MonthlySalary = 720,
                TypeContract = 1,
                Name = "Pedro",
                LastName = "Crizon",
                PhoneNumber = "445523"

            };
            var employeeFive = new Employee
            {
                Id = 3,
                HourlySalary = 4,
                MonthlySalary = 0,
                TypeContract = 0,
                Name = "Jorge",
                LastName = "Crizon",
                PhoneNumber = "7788552"

            };
            var employeeFour = new Employee
            {
                Id = 4,
                HourlySalary = 0,
                MonthlySalary = 960,
                TypeContract = 1,
                Name = "Alberto",
                LastName = "Crizon",
                PhoneNumber = "1238756"

            };
            var employeeTwo = new Employee
            {
                Id = 5,
                HourlySalary = 5,
                MonthlySalary = 0,
                TypeContract = 0,
                Name = "Francisco",
                LastName = "Crizon",
                PhoneNumber = "5599336"

            };
            var employeeThree = new Employee
            {
                Id = 6,
                HourlySalary = 0,
                MonthlySalary = 1200,
                TypeContract = 1,
                Name = "Juan",
                LastName = "Crizon",
                PhoneNumber = "2266875"

            };
            employee.AddRange(new Employee[]
            {
                employeeOne,
                employeeSix,
                employeeFive,
                employeeFour,
                employeeTwo,
                employeeThree
            });
        }

       
    }
}
