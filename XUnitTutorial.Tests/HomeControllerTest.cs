using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using XUnitTutorial.API.Interfaces;
using XUnitTutorial.API.Models;
using XUnitTutorial.UI.Controllers;

namespace XUnitTutorial.Tests
{
    public class HomeControllerTest
    {
        public HomeControllerTest()
        {
        }

        [Fact]
        public void ShouldReturnView()
        {
            var _repoMock = new Mock<IProductService>();

            _repoMock.Setup(x => x.GetAllProduct())
                .Returns(
                new List<Product>() {
                new Product(1,"IPhone"),
                new Product(2,"MacBook"),
                new Product(3,"AirTag")
            });

            var controller = new HomeController(_repoMock.Object);

            var result = controller.Index();

            Assert.IsAssignableFrom<List<Product>>(controller.ViewData.Model);

            Assert.IsType<ViewResult>(result);

        }
    }
}
