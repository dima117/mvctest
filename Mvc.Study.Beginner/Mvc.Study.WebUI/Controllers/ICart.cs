using System;
using System.Web.Mvc;

namespace Mvc.Study.Beginner
{
    public interface ICart
    {
        /// <summary>
        /// Добавить продукт в корзину
        /// </summary>
        ActionResult Add(Guid productId);

        /// <summary>
        /// Удалить продукт из корзины
        /// </summary>
        ActionResult Remove(Guid productId);

        /// <summary>
        /// Получить содержимое корзины
        /// </summary>
        ActionResult GetList();
    }
}