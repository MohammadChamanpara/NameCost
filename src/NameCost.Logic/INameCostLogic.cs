using NameCost.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameCost.Logic
{
	public interface INameCostLogic
	{
		void ConvertCostToWords(NameCostModel nameCost);
	}
}
