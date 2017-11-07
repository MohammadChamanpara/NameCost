using NameCost.Core.Models;

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
