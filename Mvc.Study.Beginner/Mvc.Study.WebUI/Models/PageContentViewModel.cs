using System;

namespace Mvc.Study.Beginner
{
    /// <summary>
    /// Данные страницы
    /// </summary>
    public class PageContentViewModel
    {
        /// <summary>
        /// Идентификатор страницы
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название страницы
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Содержимое страницы
        /// </summary>
        public string Html { get; set; }
    }
}