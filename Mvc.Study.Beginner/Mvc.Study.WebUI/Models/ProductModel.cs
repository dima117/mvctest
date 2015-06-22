using System;

namespace Mvc.Study.Beginner.Models
{
	public class ProductModel
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public decimal Price { get; set; }

		public string Description { get; set; }

		public string FullDescription { get; set; }
	}
}