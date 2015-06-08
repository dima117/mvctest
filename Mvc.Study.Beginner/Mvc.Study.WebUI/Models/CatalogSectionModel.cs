using System;

namespace Mvc.Study.Beginner.Models
{
    /// <summary>
    /// Данные страницы
    /// </summary>
    public class CatalogSectionModel
    {
        public Guid Id { get; set; }

        public string MenuTitle { get; set; }

        public string ContentPrimary { get; set; }

        public string ContentSecondary { get; set; }
    }
}