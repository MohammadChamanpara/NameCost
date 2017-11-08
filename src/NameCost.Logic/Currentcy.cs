using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameCost.Logic
{
	/// <summary>
	/// This class provides currency-related functionality 
	/// including the conversion from number to words.
	/// </summary>
	public class Currency
	{
		#region Variables
		
		// All the string literals are gathered in these readonly variables 
		// to simplify the update, changes in strategy or text, or to read them later from config.
		private readonly string DollarText = "DOLLAR";
		private readonly string DollarsText = "DOLLARS";

		private readonly string CentText = "CENT";
		private readonly string CentsText = "CENTS";

		private readonly string OnlyText = "ONLY";
		private readonly string AndText = "AND";
		private readonly string MinusText = "MINUS";

		/// <summary>
		/// In order to implement a clean well designed algorithm,
		/// I decided to store the words in a dictionary like the following 
		/// and unify the way words are being retrieved and accessed.
		/// </summary>
		private static readonly Dictionary<int, string> Words = new Dictionary<int, string>
		{
			{ 0, "ZERO" },
			{ 1, "ONE" },
			{ 2, "TWO" },
			{ 3, "THREE" },
			{ 4, "FOUR" },
			{ 5, "FIVE" },
			{ 6, "SIX" },
			{ 7, "SEVEN" },
			{ 8, "EIGHT" },
			{ 9, "NINE" },
			{ 10, "TEN" },
			{ 11, "ELEVEN" },
			{ 12, "TWELVE" },
			{ 13, "THIRTEEN" },
			{ 14, "FOURTEEN" },
			{ 15, "FIFTEEN" },
			{ 16, "SIXTEEN" },
			{ 17, "SEVENTEEN" },
			{ 18, "EIGHTEEN" },
			{ 19, "NINETEEN" },
			{ 20, "TWENTY" },
			{ 30, "THIRTY" },
			{ 40, "FORTY" },
			{ 50, "FIFTY" },
			{ 60, "SIXTY" },
			{ 70, "SEVENTY" },
			{ 80, "EIGHTY" },
			{ 90, "NINETY" },
			{ 100, "HUNDRED" },
			{ 1000, "THOUSAND" },
			{ 1000000, "MILLION" },
			{ 1000000000, "BILLION" },
		};

		#endregion

		#region Properties		
		/// <summary>
		/// Gets or sets the currency main value.
		/// </summary>
		/// <value>
		/// The currecny value.
		/// </value>
		public decimal Value { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Currency"/> class.
		/// </summary>
		/// <param name="value">The value.</param>
		public Currency(decimal value)
		{
			this.Value = value;
		}

		/// <summary>
		/// Gets the dollars part of the currency.
		/// <para>
		/// e.g: 220.55 - > 220
		/// </para>
		/// </summary>
		/// <value>
		/// The dollars which is the integral part of the currency.
		/// </value>
		public int Dollars
		{
			get
			{
				return (int)Math.Truncate(Value);
			}
		}

		/// <summary>
		/// Gets the dollars unit which varies according to the <see cref="Dollars"/> value.
		/// <para>
		/// It can be Dollar or Dollars.
		/// </para>
		/// </summary>
		/// <value>
		/// The dollars unit
		/// </value>
		public string DollarsUnit
		{
			get
			{
				return Dollars == 1 ? DollarText : DollarsText;
			}
		}
		/// <summary>
		/// Gets the cents part of the currency.
		/// e.g: 1234.56 - > 56
		/// </summary>
		/// <value>
		/// The cents which is the fractional part of the currency.
		/// </value>
		public int Cents
		{
			get
			{
				//If the Value is negative it should not affect the cents part.
				// So we use Abs.
				// -123.45 -> 45
				return Math.Abs((int)((Value - Math.Truncate(Value)) * 100));
			}
		}

		/// <summary>
		/// Gets the cents unit which varies according to the <see cref="Cents"/> value.
		/// <para>
		/// It can be Cent or Cents.
		/// </para>
		/// </summary>
		/// <value>
		/// The dollars unit
		/// </value>
		public string CentsUnit
		{
			get
			{
				return Cents == 1 ? CentText : CentsText;
			}
		}
		#endregion

		#region Methods		
		/// <summary>
		/// Convert the value number to words format.
		/// </summary>
		/// <returns>Words representation of the currency</returns>
		public string ToWords()
		{
			//ZERO
			if (Value == 0)
			{
				return NumberToWords(0);
			}

			// 10 DOLLARS | 1 DOLLAR
			if (Cents == 0)
			{
				return $"{NumberToWords(Dollars)} {DollarsUnit} {OnlyText}";
			}

			// 10 CENTS | 1 CENT
			if (Dollars == 0)
			{
				return $"{NumberToWords(Cents)} {CentsUnit}";
			}

			// 10 DOLLARS AND 25 CENTS | 1 DOLLAR AND 20 CENTS | ETC.
			return $"{NumberToWords(Dollars)} {DollarsUnit} {AndText} {NumberToWords(Cents)} {CentsUnit}";
		}
		/// <summary>
		/// Private method to be used internally and convert an integer number to words.
		/// This will be called from <see cref="ToWords"/> and also recursively to generate the ultimate words.
		/// </summary>
		/// <param name="number">The number to be converted to words format.</param>
		/// <returns>
		/// a string containing the number in words format
		/// </returns>
		private string NumberToWords(int number)
		{
			//ZERO
			if (number == 0)
				return Words[0];
			
			//MINUS 100 DOLARS
			if (number < 0)
				return MinusText + NumberToWords(Math.Abs(number));

			string result = "";

			//The following array and loop helps to unify the way we treat hundred through billion prefixes.
			int[] powers = { 1000000000, 1000000, 1000, 100 };
			for (int i = 0; i < powers.Length; i++)
			{

				if (number >= powers[i])
				{
					if (result != "") result += " ";
					
					// 2300 -> TWO + THOUSAND
					result += NumberToWords(number / powers[i]) + " " + Words[powers[i]];

					// 2300 -> 200
					number %= powers[i]; 
				}
			}

			// No remaining digits so return the produced words
			if (number == 0)
				return result;

			// TWO TOUSAND + AND 
			if (result != "")
				result += $" {AndText} ";

			// 0 through 20 can just retrieve the word value from dictionary
			if (number <= 20)
			{
				result += Words[number];
				return result;
			}

			// According to previous conditions, 
			// here the number is greater than 20 and less than hundred 
			// So a two digit number from 21 through 99
			// let's say 35
			
			// 35 -> 30 -> THIRTY
			result += Words[(number / 10) * 10];

			// 35 -> 5
			number %= 10;

			if (number > 0)
			{
				// THIRTY -> THIRTY-FIVE
				result += "-" + Words[number];
			}

			// Let's return and see what we have done :)
			return result;
		}
		#endregion
	}
}
