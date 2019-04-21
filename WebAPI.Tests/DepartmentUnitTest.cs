namespace WebAPI.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Results;
    using WebAPI.Controllers;
    using WebAPI.Models;

    [TestClass]
    public class DepartmentUnitTest
    {
        [TestMethod]
        public void DepartmentGetByIdSuccess()
        {
            // Set up Prerequisites 
            var controller = new DepartmentController();

            // Act on Test
            var response = controller.Get(1);
            var contentResult = response as OkNegotiatedContentResult<Department>;

            // Assert the result
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.DepartmentId);

        }

        [TestMethod]
        public void GetDepartmentNotFound()
        {
            // Set up Prerequisites 
            var controller = new DepartmentController();

            // Act
            IHttpActionResult actionResult = controller.Get(100);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void AddDepartmentTest()
        {
            // Arrange
            var controller = new DepartmentController();

            Department department = new Department
            {
                DepartmentName = "Test Department",
            };

            // Act
            IHttpActionResult actionResult = controller.Post(department);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Department>;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["id"]);
        }

        [TestMethod]
        public void UpdateDepartmentTest()
        {
            // Arrange
            var controller = new DepartmentController();
            Department department = new Department
            {
                DepartmentId = 4,
                DepartmentName = "Test Department",
            };

            // Act
            IHttpActionResult actionResult = controller.Put(department);
            var contentResult = actionResult as NegotiatedContentResult<Department>;

            Assert.IsNotNull(contentResult);
            Assert.AreEqual(HttpStatusCode.Accepted, contentResult.StatusCode);
            Assert.IsNotNull(contentResult.Content);
        }

    }
}
