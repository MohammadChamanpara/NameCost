using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NameCost.Controllers;
using NameCost.Core.Models;
using NameCost.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NameCost.Controllers.Tests
{
	[TestClass()]
	public class ConvertControllerTests
	{
		[TestMethod()]
		public void Ouput_Always_ShouldReturnView()
		{
			//Arrange
			var model = new NameCostModel();
			var ConvertController = new ConvertController();

			//Act
			ActionResult actionResult = ConvertController.Output(model);

			//Assert
			actionResult.Should().BeOfType<ViewResult>(because: "shorten get action should return view");
		}
		[TestMethod()]
		public void Output_Always_ShouldReturnOutputView()
		{
			//Arrange
			var model = new NameCostModel();
			var ConvertController = new ConvertController();

			//Act
			ActionResult actionResult = ConvertController.Output(model);

			//Assert
			(actionResult as ViewResult)?.ViewName.ShouldBeEquivalentTo("output");
		}
	}
}