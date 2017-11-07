using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameCost.Core.Models
{
	/// <summary>
	/// This models servers as DomainModel and ViewModel in this application
	/// for the sake of simplicity given the fact that the mentioned models 
	/// had no or slight differences in terms of strucure.
	/// </summary>
	public class NameCostModel
    {
		/// <summary>
		/// Gets or sets the Name property.
		/// </summary>
		/// <value>
		/// The calculated short URL.
		/// </value>
		[Required]
		[Display(Name = "Person Name")]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the cost.
		/// </summary>
		/// <value>
		/// The cost in number format.
		/// </value>

		[Required]
		[Display(Name ="Cost")]
		public decimal Cost { get; set; }

		/// <summary>
		/// Gets or sets the cost in words.
		/// </summary>
		/// <value>
		/// The cost in words format.
		/// </value>
		[Display(Name ="Cost in Words")]
		public string CostInWords { get; set; }
	}
}
