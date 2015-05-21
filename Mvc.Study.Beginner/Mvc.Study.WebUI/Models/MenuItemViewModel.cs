using System;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Study.Beginner
{
    /// <summary>
    /// Эелемент верхнего меню
    /// </summary>
    public class MenuItemViewModel
    {
        /// <summary>
        /// Идентификатор страницы
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название страницы
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Название страницы
        /// </summary>
        public string Title { get; set; }
    }
}