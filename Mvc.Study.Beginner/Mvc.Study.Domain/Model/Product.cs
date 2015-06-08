using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc.Study.Domain.Model
{
	public class Product
	{
		public Guid Id { get; set; }

		public Guid CatalogSectionId { get; set; }

		[ForeignKey("CatalogSectionId")]
		public CatalogSection CatalogSection { get; set; }

		public string Name { get; set; }

		public decimal Price { get; set; }

		public string Description { get; set; }

		public string FullDescription { get; set; }
	}
}
