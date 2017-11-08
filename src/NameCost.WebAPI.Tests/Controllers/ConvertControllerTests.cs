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
	/// <summary>
	/// Unit tests for <see cref="ConvertController"/> class
	/// </summary>
	[TestClass()]
	public class ConvertControllerTests
	{
		/// <summary>
		/// Convert with a valid model should return ok with model parameter.
		/// </summary>
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
			actionResult
				.Should()
				.BeOfType<OkNegotiatedContentResult<NameCostModel>>
				(because: "model is valid");
		}

		/// <summary>
		/// Convert with a valid model should call convert logic.
		/// </summary>
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
			mockUrlLogic.Verify(
				x => 
				x.GenerateWords(It.IsAny<NameCostModel>()),
				"valid model should reach logic");
		}

		/// <summary>
		/// Convert with an invalid model should not call convert logic.
		/// </summary>
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
			mockUrlLogic.Verify(
				x => 
				x.GenerateWords(It.IsAny<NameCostModel>()), 
				Times.Never, 
				"Invalid model should not reach logic");
		}

		/// <summary>
		/// Convert with an invalid model should return invalid model state result.
		/// </summary>
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
			actionResult
				.Should()
				.BeOfType<InvalidModelStateResult>
				(because: "model is not valid");
		}
	}
}