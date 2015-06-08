using System;

namespace Mvc.Study.Beginner.Models
{
    /// <summary>
    /// Данные страницы
    /// </summary>
	public class ContentPageModel
    {
        public Guid Id { get; set; }

        public string MenuTitle { get; set; }

        public string Content { get; set; }
    }
}