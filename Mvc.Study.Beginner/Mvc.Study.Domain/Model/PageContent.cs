using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc.Study.Domain
{
    [Table("PageContent")]
	public class PageContent
	{
        #region Required

        /// <summary>
        /// Внутренний идентификатор страницы
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Название страницы для адресации
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Порядковый номер страницы
        /// </summary>
        [Required]
        public int OrderId { get; set; }

        #endregion

        /// <summary>
        /// Заголовок страницы
        /// </summary>
		public string Title { get; set; }

        /// <summary>
        /// Содержимое страницы
        /// </summary>
		public string Content { get; set; }
	}
}
