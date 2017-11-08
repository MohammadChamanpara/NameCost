using NameCost.Core.Models;

namespace NameCost.Logic
{
	/// <summary>
	/// An implementation of the <see cref="NameCost.Logic.INameCostLogic" /> 
	/// Which generates the words format
	/// </summary>
	/// <seealso cref="NameCost.Logic.INameCostLogic" />
	public class NameCostLogic : INameCostLogic
	{
		/// <summary>
		/// Generates the words for the <see cref="NameCostModel.Cost"/> property of the parameter 
		/// and stores it in the <see cref="NameCostModel.CostInWords"/> property.
		/// </summary>
		/// <param name="nameCost">The model from which <see cref="NameCostModel.Cost"/> will be used 
		/// to generate and set the <see cref="NameCostModel.CostInWords"/></param>
		public void GenerateWords(NameCostModel model)
		{
			model.CostInWords = new Currency(model.Cost).ToWords();
		}
	}
}
