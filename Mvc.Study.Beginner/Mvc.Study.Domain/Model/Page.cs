using System;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Study.Domain
{
	public class Page
	{
        /// <summary>
        /// Внутренний идентификатор страницы
        /// </summary>
		public Guid Id { get; set; }

        /// <summary>
        /// Название страницы для адресации
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Заголовок страницы
        /// </summary>
		public string Title { get; set; }

        /// <summary>
        /// Содержимое страницы
        /// </summary>
		public string Content { get; set; }

        /// <summary>
        /// Порядковый номер страницы
        /// </summary>
        [Required]
        public int OrderId { get; set; }
	}
}
