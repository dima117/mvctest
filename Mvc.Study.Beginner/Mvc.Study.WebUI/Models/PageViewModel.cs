using System;

namespace Mvc.Study.Beginner
{
    /// <summary>
    /// Данные страницы
    /// </summary>
    public class PageViewModel
    {
        /// <summary>
        /// Идентификатор страницы
        /// </summary>
        public Guid PageId { get; set; }

        /// <summary>
        /// Название страницы
        /// </summary>
        public string PageTitle { get; set; }

        /// <summary>
        /// Содержимое страницы
        /// </summary>
        public string PageContent { get; set; }
    }
}