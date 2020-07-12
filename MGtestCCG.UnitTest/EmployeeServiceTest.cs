using MGtestCCG.Domain.Entities;
using MGtestCCG.Domain.Irepositories;
using MGtestCCG.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace MGtestCCG.UnitTest
{
    [TestClass]
    public class EmployeeServiceTest
    { 
        private IEmployeeRepository employeeRepository;
        [TestInitialize]
        public void InitializeTest() 
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
            employeeRepository = Substitute.For<IEmployeeRepository>();
            employeeRepository.GetByIdAsync(1).Returns(employeeOne);
        }
        [TestMethod]
        public void CalculateSalaryForEmployeeWithHourlySalary()
        {
            EmployeeServicePerHour employeeServicePerHour = new EmployeeServicePerHour(employeeRepository);
            var employee = employeeRepository.GetByIdAsync(1);
            var salary = employeeServicePerHour.CalculateEmployeeSalaryAsync(employee.Result.Id);
            Assert.AreEqual(4320, salary.Result);
        }
    }
}
