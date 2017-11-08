using NameCost.Core.Models;

namespace NameCost.Logic
{
	/// <summary>
	/// This interface represents any implementation of the logic for the convert number to words in the application
	/// Via this we adopt strategy pattern so that the logic implementation could be replaced with a new one
	/// without affecting the rest of the application that use logic
	/// </summary>
	public interface INameCostLogic
	{
		/// <summary>
		/// Generates the words for the <see cref="NameCostModel.Cost"/> property of the parameter 
		/// and stores it in the <see cref="NameCostModel.CostInWords"/> property.
		/// </summary>
		/// <param name="nameCost">The model from which <see cref="NameCostModel.Cost"/> will be used 
		/// to generate and set the <see cref="NameCostModel.CostInWords"/></param>
		void GenerateWords(NameCostModel nameCost);
	}
}
