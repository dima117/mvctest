using System;

namespace Mvc.Study.Domain.Model
{
    public class CatalogSection
    {
        public Guid Id { get; set; }

		public string UrlCode { get; set; }

        public int SortOrder { get; set; }

        public string MenuTitle { get; set; }

        public string ContentPrimary { get; set; }

        public string ContentSecondary { get; set; }
    }
}
