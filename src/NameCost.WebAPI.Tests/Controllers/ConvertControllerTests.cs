using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NameCost.Core.Models;
using NameCost.Logic;
using NameCost.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace NameCost.WebAPI.Controllers.Tests
{
	[TestClass()]
	public class ConvertControllerTests
	{
		[TestMethod()]
		public void Convert_WithValidModel_ShouldReturnOkModel()
		{
			//Arrange
			var mockUrlLogic = new Mock<INameCostLogic>();
			var controller = new ConvertController(mockUrlLogic.Object);
			var model = new NameCostModel();

			//Act
			IHttpActionResult actionResult = controller.Convert(model);

			//Assert
			actionResult.Should().BeOfType<OkNegotiatedContentResult<NameCostModel>>(because: "model is valid");
		}


		[TestMethod()]
		public void Convert_WithValidModel_ShouldCallConvertLogic()
		{
			//Arrange
			var mockUrlLogic = new Mock<INameCostLogic>();
			var controller = new ConvertController(mockUrlLogic.Object);
			var model = new NameCostModel() { Cost = 1 };

			//Act
			IHttpActionResult actionResult = controller.Convert(model);

			//Assert
			mockUrlLogic.Verify(x => x.GenerateWords(It.IsAny<NameCostModel>()), "valid model should reach logic");
		}

		[TestMethod()]
		public void Convert_WithInvalidModel_ShouldNotCallConvertLogic()
		{
			//Arrange
			var mockUrlLogic = new Mock<INameCostLogic>();
			var controller = new ConvertController(mockUrlLogic.Object);
			controller.ModelState.AddModelError("", "");

			var model = new NameCostModel() { Cost = 1 };

			//Act
			IHttpActionResult actionResult = controller.Convert(model);

			//Assert
			mockUrlLogic.Verify(x => x.GenerateWords(It.IsAny<NameCostModel>()), Times.Never, "Invalid model should not reach logic");
		}

		[TestMethod()]
		public void Convert_WithInvalidModel_ShouldReturnInvalidModelStateResult()
		{
			//Arrange
			var mockUrlLogic = new Mock<INameCostLogic>();
			var controller = new ConvertController(mockUrlLogic.Object);
			controller.ModelState.AddModelError("", "");
			var model = new NameCostModel() { Cost = 1 };

			//Act
			IHttpActionResult actionResult = controller.Convert(model);

			//Assert
			actionResult.Should().BeOfType<InvalidModelStateResult>(because: "model is not valid");
		}
	}
}