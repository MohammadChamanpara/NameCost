using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NameCost.Core;

namespace NameCost.Logic
{
	public class NameCostLogic : INameCostLogic
	{
		public void GenerateWords(NameCostModel model)
		{
			model.CostInWords = new Currency(model.Cost).ToWords();
		}
	}
}
