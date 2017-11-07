using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace NameCost.Logic.Tests
{
	[TestClass]
	public class CurrencyTests
	{
		[TestMethod]
		public void ToWord_WithDollarAndCent_ShouldConcat()
		{
			//Arrange
			var currency = new Currency(123456.45m);

			//Act
			var words = currency.ToWords();

			//Assert
			words.ToUpper().ShouldBeEquivalentTo("ONE HUNDRED AND TWENTY-THREE THOUSAND FOUR HUNDRED AND FIFTY-SIX DOLLARS AND FORTY-FIVE CENTS");
		}
		[TestMethod]
		public void ToWord_WithoutCents_ShouldAddOnly()
		{
			//Arrange
			var currency = new Currency(100);

			//Act
			var words = currency.ToWords();

			//Assert
			words.ToUpper().ShouldBeEquivalentTo("ONE HUNDRED DOLLARS ONLY");
		}

		[TestMethod]
		public void ToWord_WithoutDollars_ShouldUseCents()
		{
			//Arrange
			var currency = new Currency(0.25m);

			//Act
			var words = currency.ToWords();

			//Assert
			words.ToUpper().ShouldBeEquivalentTo("TWENTY-FIVE CENTS");
		}

		[TestMethod]
		public void ToWord_WithOneDollar_ShouldUseSingularForm()
		{
			//Arrange
			var currency = new Currency(1.25m);

			//Act
			var words = currency.ToWords();

			//Assert
			words.ToUpper().ShouldBeEquivalentTo("ONE DOLLAR AND TWENTY-FIVE CENTS");
		}


		[TestMethod]
		public void ToWord_WithOneCent_ShouldUseSingularForm()
		{
			//Arrange
			var currency = new Currency(12.01m);

			//Act
			var words = currency.ToWords();

			//Assert
			words.ToUpper().ShouldBeEquivalentTo("TWELVE DOLLARS AND ONE CENT");
		}
		[TestMethod]
		public void ToWord_WithBigNumber_ShouldConvert()
		{
			//Arrange
			var currency = new Currency(2000000000.00m);

			//Act
			var words = currency.ToWords();

			//Assert
			words.ToUpper().ShouldBeEquivalentTo("TWO BILLION DOLLARS ONLY");
		}
	}
}
