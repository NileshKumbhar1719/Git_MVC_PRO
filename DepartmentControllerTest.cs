using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Git_MVC_PRO.Service;
using Git_MVC_PRO.Controllers;
using Git_MVC_PRO.Models;
using System.Threading.Tasks;

namespace Controller.test
{
    public class DepartmentControllerTest
    {
        private Mock<IDepartService> _mockService;
        private DEPARTMENTS _controller;

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IDepartService>();

            _controller = new DEPARTMENTS(_mockService.Object);

            // Setup TempData
            var httpContext = new DefaultHttpContext();
            var tempDataProvider = new Mock<ITempDataProvider>();
            _controller.TempData = new TempDataDictionary(httpContext, tempDataProvider.Object);
        }

        [Test]
        public async Task Create_ValidDepartment_RedirectsToIndex_AndSetsMessage()
        {
            // Arrange
            var dept = new Departments
            {
                Name = "IT"
            };

            // ✅ Return a Departments object, not bool
            _mockService.Setup(s => s.AddDepartmentsService(dept))
                        .ReturnsAsync(dept);

            // Act
            var result = await _controller.Create(dept);

            // Assert

            // Check redirect
            var redirectResult = result as RedirectToActionResult;
            Assert.IsNotNull(redirectResult);
            Assert.AreEqual("Index", redirectResult.ActionName);

            // Check TempData
            Assert.AreEqual("Create data Successfully", _controller.TempData["message"]);

            // Verify service call
            _mockService.Verify(s => s.AddDepartmentsService(dept), Times.Once);
        }
    }
}