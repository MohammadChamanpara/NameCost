using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameCost.Core.Models;
using NameCost.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameCost.Logic.Tests
{
	[TestClass()]
	public class NameCostLogicTests
	{
		[TestMethod()]
		public void GenerateWords_Always_ShouldInitializeWords()
		{
			//Arrange
			var logic = new NameCostLogic();
			var model = new NameCostModel() { Cost = 1 };

			//Act
			logic.GenerateWords(model);

			//Assert
			model.CostInWords.Should().NotBeNullOrEmpty();
		}
	}
}