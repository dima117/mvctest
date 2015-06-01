using System;

namespace Mvc.Study.Beginner
{
    /// <summary>
    /// Данные страницы
    /// </summary>
    public class CatalogItemViewModel
    {
        /// <summary>
        /// Идентификатор страницы
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название страницы
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Название страницы
        /// </summary>
        public string Title { get; set; }
    }
}