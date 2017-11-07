using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameCost.Logic
{
	public class Currency
	{
		#region Constatnts

		private readonly string DollarText = "DOLLAR";
		private readonly string DollarsText = "DOLLARS";

		private readonly string CentText = "CENT";
		private readonly string CentsText = "CENTS";

		private readonly string OnlyText = "ONLY";
		private readonly string AndText = "AND";
		private readonly string MinusText = "MINUS";

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
		public decimal Value { get; set; }
		public Currency(decimal value)
		{
			this.Value = value;
		}
		public int Dollars
		{
			get
			{
				return (int)Math.Truncate(Value);
			}
		}
		public string DollarsUnit
		{
			get
			{
				return Dollars == 1 ? DollarText : DollarsText;
			}
		}
		public int Cents
		{
			get
			{
				return Math.Abs((int)((Value - Math.Truncate(Value)) * 100));
			}
		}
		public string CentsUnit
		{
			get
			{
				return Cents == 1 ? CentText : CentsText;
			}
		}
		#endregion

		#region Methods
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

			// 10 DOLLARS AND 25 CENTS
			return $"{NumberToWords(Dollars)} {DollarsUnit} {AndText} {NumberToWords(Cents)} {CentsUnit}";
		}

		private string NumberToWords(int number)
		{
			if (number < 0)
				return MinusText + NumberToWords(Math.Abs(number));

			string result = "";

			int[] powers = { 1000000000, 1000000, 1000, 100 };
			for (int i = 0; i < powers.Length; i++)
			{

				if (number >= powers[i])
				{
					if (result != "") result += " ";
					result += NumberToWords(number / powers[i]) + " " + Words[powers[i]];
					number %= powers[i];
				}
			}

			if (number == 0)
				return result;

			if (result != "")
				result += $" {AndText} ";

			if (number <= 20)
			{
				result += Words[number];
				return result;
			}

			result += Words[(number / 10) * 10];
			number %= 10;
			if (number > 0)
				result += "-" + Words[number];

			return result;
		}
		#endregion
	}
}
