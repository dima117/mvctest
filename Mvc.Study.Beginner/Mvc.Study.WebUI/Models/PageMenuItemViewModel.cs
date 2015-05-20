using System;

namespace Mvc.Study.Beginner
{
    /// <summary>
    /// Эелемент верхнего меню
    /// </summary>
    public class PageMenuItemViewModel
    {
        /// <summary>
        /// Идентификатор страницы
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название страницы
        /// </summary>
        public string Title { get; set; }
    }
}