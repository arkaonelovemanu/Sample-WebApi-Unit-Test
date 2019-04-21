namespace WebAPI.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Net.Http;
    using System.Web.Http;
    using WebAPI.Controllers;
    using WebAPI.Models;

    [TestClass]
    public class EmployeeUnitTest
    {
        [TestMethod]
        public void EmployeeGetById()
        {
            // Set up Prerequisites 
            var controller = new EmployeeController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act on Test
            var response = controller.Get(1);

            // Assert the result
            Employee employee;
            Assert.IsTrue(response.TryGetContentValue<Employee>(out employee));
            Assert.AreEqual("Jignesh", employee.Name);
        }

        [TestMethod]
        public void EmployeePost()
        {
            // Set up Prerequisites 
            var controller = new EmployeeController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act on Test
            Employee employee = new Employee
            {
                Id = 7,
                Name = "Jayesh",
                DepartmentId = 1,
                Salary = 2550,
                EmailAddress = "test@gmail.com",
                PhoneNumber = "2323232",
                Address = "Hello"
            };
            var response = controller.Post(employee);

            // Assert the result

            Assert.IsTrue(response.TryGetContentValue<Employee>(out employee));
            Assert.AreEqual("Jayesh", employee.Name);
        }
    }
}
