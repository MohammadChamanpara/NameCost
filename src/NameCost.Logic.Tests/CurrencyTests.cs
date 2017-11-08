using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace NameCost.Logic.Tests
{
	/// <summary>
	/// Unit tests for <see cref="Currency"/> class.
	/// </summary>
	[TestClass]
	public class CurrencyTests
	{
		/// <summary>
		/// As naming convention depicts: 
		/// ToWord when the provided parameter has both the dollar and cent parts,
		/// should concat both parts in the generated words
		/// </summary>
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

		/// <summary>
		/// ToWord without cents part should add only text at the end.
		/// </summary>
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

		/// <summary>
		/// ToWord without dollars should use cents in the generated words.
		/// </summary>
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

		/// <summary>
		/// ToWord with one dollar should use singular form.
		/// e.g: 1 -> ONE DOLLAR not ONE DOLLARS
		/// </summary>
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

		/// <summary>
		/// ToWord with one cent should use singular form.
		/// e.g: 0.01 -> ONE CENT not ONE CENTS
		/// </summary>
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

		/// <summary>
		/// Toword with big number should convert correctly.
		/// </summary>
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
