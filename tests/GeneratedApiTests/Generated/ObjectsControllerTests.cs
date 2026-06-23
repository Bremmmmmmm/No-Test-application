using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using NoTestApplication.Services;
using NoTestApplication.Controllers;
using NoTestApplication.Models;
using System.Collections.Generic;

namespace GeneratedApiTests
{
    public class ObjectsControllerTests
    {
        private readonly Mock<IObjectService> _mockObjectService;
        private readonly ObjectsController _controller;

        public ObjectsControllerTests()
        {
            _mockObjectService = new Mock<IObjectService>();
            _controller = new ObjectsController(_mockObjectService.Object);
        }

        [Fact]
        public void GetAll_ReturnsOkResultWithListOfObjects()
        {
            // Arrange
            var objects = new List<ObjectModel>
            {
                new ObjectModel { Id = 1, Name = "TestObject1" },
                new ObjectModel { Id = 2, Name = "TestObject2" }
            };
            _mockObjectService.Setup(s => s.GetAll()).Returns(objects);

            // Act
            var result = _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedObjects = Assert.IsType<List<ObjectModel>>(okResult.Value);
            Assert.Equal(objects.Count, returnedObjects.Count);
        }

        [Fact]
        public void GetById_ReturnsOkResultWithObject()
        {
            // Arrange
            var obj = new ObjectModel { Id = 1, Name = "TestObject" };
            _mockObjectService.Setup(s => s.GetById(1)).Returns(obj);

            // Act
            var result = _controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedObj = Assert.IsType<ObjectModel>(okResult.Value);
            Assert.Equal(obj.Id, returnedObj.Id);
        }

        [Fact]
        public void GetById_ReturnsNotFoundForInvalidId()
        {
            // Arrange
            _mockObjectService.Setup(s => s.GetById(It.IsAny<int>())).Returns((ObjectModel)null);

            // Act
            var result = _controller.GetById(999);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public void Create_ValidRequest_ReturnsCreatedAtAction()
        {
            // Arrange
            var request = new CreateObjectRequest { Name = "NewTestObject" };
            var createdObject = new ObjectModel { Id = 1, Name = "NewTestObject" };
            _mockObjectService.Setup(s => s.Create(request)).Returns(createdObject);

            // Act
            var result = _controller.Create(request);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(nameof(_controller.GetById), createdAtActionResult.ActionName);
            Assert.Equal(createdObject.Id, createdAtActionResult.RouteValues["id"]);
        }

        [Fact]
        public void Create_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("Name", "Required");

            // Act
            var result = _controller.Create(new CreateObjectRequest());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void Update_ValidRequest_ReturnsNoContent()
        {
            // Arrange
            var id = 1;
            _mockObjectService.Setup(s => s.Update(id, It.IsAny<UpdateObjectRequest>())).Returns(true);

            // Act
            var result = _controller.Update(id, new UpdateObjectRequest());

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Update_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("Property", "Error");

            // Act
            var result = _controller.Update(1, new UpdateObjectRequest());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Update_NotFound_ReturnsNotFound()
        {
            // Arrange
            _mockObjectService.Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateObjectRequest>())).Returns(false);

            // Act
            var result = _controller.Update(999, new UpdateObjectRequest());

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void Delete_ExistingId_ReturnsNoContent()
        {
            // Arrange
            var id = 1;
            _mockObjectService.Setup(s => s.Delete(id)).Returns(true);

            // Act
            var result = _controller.Delete(id);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            _mockObjectService.Setup(s => s.Delete(It.IsAny<int>())).Returns(false);

            // Act
            var result = _controller.Delete(999);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
