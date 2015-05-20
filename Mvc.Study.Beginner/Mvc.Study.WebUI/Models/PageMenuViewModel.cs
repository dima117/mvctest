using System;
using Mvc.Study.Domain.Model;

namespace Mvc.Study.Beginner
{
    /// <summary>
    /// Данные для отображения верхнего меню
    /// </summary>
    public class PageMenuViewModel
    {
        /// <summary>
        /// Страницы
        /// </summary>
        public Page[] Pages { get; set; }

        /// <summary>
        /// Идентификатор выбраной страницы
        /// </summary>
        public Guid? SelectedPageId { get; set; }
    }
}