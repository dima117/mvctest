using System;

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
        public PageMenuItemViewModel[] Items { get; set; }

        /// <summary>
        /// Идентификатор выбраной страницы
        /// </summary>
        public Guid? SelectedItemId { get; set; }
    }
}