using System;

namespace Mvc.Study.Beginner.Models
{
    public class MenuItemModel
    {
	    public MenuItemModel(Guid id, string menuTitle, string urlCode)
	    {
		    Id = id;
		    MenuTitle = menuTitle;
		    UrlCode = urlCode;
	    }

	    public Guid Id { get; set; }

        public string MenuTitle { get; set; }

        public string UrlCode { get; set; }
    }
}